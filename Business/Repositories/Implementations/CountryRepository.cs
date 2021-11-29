using Business.Context;
using Business.Entities;
using Business.Mappers;
using Infrastructure.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace Business.Repositories
{
    public class CountryRepository : IRepository<Country>
    {
        private MarketContext MarketContext { get; set; }

        private CountryMapper Mapper { get; set; }

        internal CountryRepository()
        {
            MarketContext = MarketContext.Instance;
            Mapper = new CountryMapper();
        }

        #region Public methods
        
        public void Add(Country entity)
        {
            if (entity.Id != 0)
                throw new ElementCannotBeAddedException();

            entity.Id = 1 + (MarketContext.Countries.Count() == 0 ? 0 : MarketContext.Countries.Select(c => c.Id).Max());
            Mapper.Mapping(entity, entity);
            MarketContext.Countries.Add(entity);
            MarketContext.SaveChanges();
        }

        public void Save(Country entity)
        {
            if (entity.Id == 0)
                throw new ElementCannotBeSavedException();

            Country entityInDB = MarketContext.Countries.Where(c => c.Id == entity.Id).FirstOrDefault();

            if (entityInDB == null)
                throw new ElementNotFoundException();

            Mapper.Mapping(entity, entityInDB);

            MarketContext.Countries.Update(entityInDB);
            MarketContext.SaveChanges();
        }

        public void Remove(Country entity)
        {
            if (entity.Id <= 0)
                throw new ElementNotFoundException();

            Country c = MarketContext.Countries.Where(c => c.Id == entity.Id).FirstOrDefault();

            if (c == null)
                throw new ElementNotFoundException();

            MarketContext.Countries.Remove(c);
            MarketContext.SaveChanges();
        }

        public IList<Country> GetAll()
        {
            IList<Country> countries = (MarketContext.Countries == null) ? new List<Country>() : MarketContext.Countries.ToList();
            
            return countries;
        }

        public Country GetById(int id)
        {
            Country country = null;

            country = MarketContext.Countries.Where(c => c.Id == id).FirstOrDefault();

            return country;
        }

        public Country LastElementAdded()
        {
            Country country = null;

            country = MarketContext.Countries.OrderByDescending(c => c.Id).FirstOrDefault();

            return country;
        }

        #endregion Public methods
    }
}
