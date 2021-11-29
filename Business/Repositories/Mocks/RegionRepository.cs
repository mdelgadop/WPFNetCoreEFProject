using Business.Context;
using Business.Entities;
using Infrastructure.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace Business.Repositories.Mocks
{
    public class RegionRepository : IRepository<Region>
    {
        private IList<Region> Context { get; set; }

        internal RegionRepository()
        {
            Context = new List<Region>();
        }

        public void Add(Region entity)
        {
            if (entity.Id != 0)
                throw new ElementCannotBeAddedException();
            else
                entity.Id = 1 + (Context.Count == 0 ? 0 : Context.Select(c => c.Id).Max());

            Context.Add(entity);
        }

        public void Save(Region entity)
        {
            if (entity.Id == 0)
                throw new ElementCannotBeSavedException();

            Region c = Context.Where(c => c.Id == entity.Id).FirstOrDefault();

            if (c == null)
                throw new ElementNotFoundException();

            Remove(c);
            Context.Add(entity);
        }

        public void Remove(Region entity)
        {
            if (entity.Id <= 0)
                throw new ElementNotFoundException();

            Region c = Context.Where(c => c.Id == entity.Id).FirstOrDefault();

            if (c == null)
                throw new ElementNotFoundException();

            Context.Remove(c);
        }

        public IList<Region> GetAll()
        {
            IList<Region> countries = (Context == null) ? new List<Region>() : Context.ToList();
            return countries;
        }

        public Region GetById(int id)
        {
            Region Region = Context.Where(c => c.Id == id).FirstOrDefault();
            return Region;
        }

        public Region LastElementAdded()
        {
            Region Region = Context.OrderByDescending(c => c.Id).FirstOrDefault();
            return Region;
        }
    }
}
