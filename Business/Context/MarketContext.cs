using Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Business.Context
{
    public class MarketContext : DbContext
    {
        public MarketContext() { }

        public MarketContext(DbContextOptions<MarketContext> options) : base(options) { }

        #region Entities
        public DbSet<Market> Markets { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Region> Regions { get; set; }
        
        #endregion Entities

        #region Singleton
        private static readonly Lazy<MarketContext> sInstance = new Lazy<MarketContext>(() => CreateInstance());

        private static MarketContext CreateInstance()
        {
            ServiceCollection Services;
            ServiceProvider ServiceProvider;

            Services = new ServiceCollection();

            Services.AddDbContext<MarketContext>(opt => opt.UseInMemoryDatabase(databaseName: "InMemoryDb"),
                ServiceLifetime.Scoped,
                ServiceLifetime.Scoped);

            ServiceProvider = Services.BuildServiceProvider();

            MarketContext dbContext = ServiceProvider.GetService<MarketContext>();

            return dbContext;
        }

        public static MarketContext Instance { get { return sInstance.Value; } }
        #endregion Singleton for testing

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Region>(
                b =>
                {
                    b.HasKey(e => e.Id);
                });
            builder.Entity<Contact>(
                b =>
                {
                    b.HasKey(e => e.Id);
                });
            builder.Entity<Country>(
                b =>
                {
                    b.HasKey(e => e.Id);
                    b.HasOne(e => e.Region).WithMany().HasForeignKey("RegionFK");
                    b.HasOne(e => e.Contact).WithMany().HasForeignKey("ContactFK");
                    b.HasOne(e => e.BackupContact).WithMany().HasForeignKey("BackupContactFK");
                });
            builder.Entity<Market>(
                b =>
                {
                    b.HasKey(e => e.Id);
                    b.HasOne(e => e.Country).WithMany().HasForeignKey("CountryFK");
                });

            base.OnModelCreating(builder);
        }
    }
}
