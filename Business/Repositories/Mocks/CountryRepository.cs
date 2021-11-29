using Business.Context;
using Business.Entities;
using Infrastructure.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace Business.Repositories.Mocks
{
    public class CountryRepository : IRepository<Country>
    {
        private IList<Country> Context { get; set; }

        internal CountryRepository()
        {
            Context = new List<Country>();
        }

        public void Add(Country entity)
        {
            if (entity.Id != 0)
                throw new ElementCannotBeAddedException();
            else
                entity.Id = 1 + (Context.Count == 0 ? 0 : Context.Select(c => c.Id).Max());

            Context.Add(entity);
        }

        public void Save(Country entity)
        {
            if (entity.Id == 0)
                throw new ElementCannotBeSavedException();

            Country c = Context.Where(c => c.Id == entity.Id).FirstOrDefault();

            if (c == null)
                throw new ElementNotFoundException();

            Remove(c);
            Context.Add(entity);
        }

        public void Remove(Country entity)
        {
            if (entity.Id <= 0)
                throw new ElementNotFoundException();

            Country c = Context.Where(c => c.Id == entity.Id).FirstOrDefault();

            if(c == null)
                throw new ElementNotFoundException();

            Context.Remove(c);
        }

        public IList<Country> GetAll()
        {
            IList<Country> countries = (Context == null) ? new List<Country>() : Context.ToList();
            return countries;
        }

        public Country GetById(int id)
        {
            Country country = Context.Where(c => c.Id == id).FirstOrDefault();
            return country;
        }

        public Country LastElementAdded()
        {
            Country country = Context.OrderByDescending(c => c.Id).FirstOrDefault();
            return country;
        }
    }
}
