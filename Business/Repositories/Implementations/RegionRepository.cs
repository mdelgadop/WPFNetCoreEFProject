using Business.Context;
using Business.Entities;
using Business.Mappers;
using Infrastructure.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace Business.Repositories
{
    public class RegionRepository : IRepository<Region>
    {
        private MarketContext MarketContext { get; set; }

        private RegionMapper Mapper { get; set; }

        internal RegionRepository()
        {
            MarketContext = MarketContext.Instance;
            Mapper = new RegionMapper();
        }

        public void Add(Region entity)
        {
            if (entity.Id != 0)
                throw new ElementCannotBeAddedException();
            
            entity.Id = 1 + (MarketContext.Regions.Count() == 0 ? 0 : MarketContext.Regions.Select(c => c.Id).Max());
            Mapper.Mapping(entity, entity);
            MarketContext.Regions.Add(entity);
            MarketContext.SaveChanges();
        }

        public void Save(Region entity)
        {
            if (entity.Id == 0)
                throw new ElementCannotBeSavedException();

            Region entityInDB = MarketContext.Regions.Where(c => c.Id == entity.Id).FirstOrDefault();

            if (entityInDB == null)
                throw new ElementNotFoundException();

            Mapper.Mapping(entityInDB, entity);

            MarketContext.Regions.Add(entity);
            MarketContext.SaveChanges();
        }

        public void Remove(Region entity)
        {
            if (entity.Id <= 0)
                throw new ElementNotFoundException();

            Region c = MarketContext.Regions.Where(c => c.Id == entity.Id).FirstOrDefault();

            if (c == null)
                throw new ElementNotFoundException();

            MarketContext.Regions.Remove(c);
            MarketContext.SaveChanges();
        }

        public IList<Region> GetAll()
        {
            IList<Region> countries = (MarketContext.Regions == null) ? new List<Region>() : MarketContext.Regions.ToList();
            return countries;
        }

        public Region GetById(int id)
        {
            Region Region = MarketContext.Regions.Where(c => c.Id == id).FirstOrDefault();
            return Region;
        }

        public Region LastElementAdded()
        {
            Region Region = MarketContext.Regions.OrderByDescending(c => c.Id).FirstOrDefault();
            return Region;
        }
    }
}
