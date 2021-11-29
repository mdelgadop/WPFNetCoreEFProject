using Business.Context;
using Business.Entities;
using Infrastructure.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace Business.Repositories.Mocks
{
    public class ContactRepository : IRepository<Contact>
    {
        private IList<Contact> Context { get; set; }

        internal ContactRepository()
        {
            Context = new List<Contact>();
        }

        public void Add(Contact entity)
        {
            if (entity.Id != 0)
                throw new ElementCannotBeAddedException();
            else
                entity.Id = 1 + (Context.Count == 0 ? 0 : Context.Select(c => c.Id).Max());

            Context.Add(entity);
        }

        public void Save(Contact entity)
        {
            if (entity.Id == 0)
                throw new ElementCannotBeSavedException();

            Contact c = Context.Where(c => c.Id == entity.Id).FirstOrDefault();

            if (c == null)
                throw new ElementNotFoundException();

            Remove(c);
            Context.Add(entity);
        }

        public void Remove(Contact entity)
        {
            if (entity.Id <= 0)
                throw new ElementNotFoundException();

            Contact c = Context.Where(c => c.Id == entity.Id).FirstOrDefault();

            if (c == null)
                throw new ElementNotFoundException();

            Context.Remove(c);
        }

        public IList<Contact> GetAll()
        {
            IList<Contact> countries = (Context == null) ? new List<Contact>() : Context.ToList();
            return countries;
        }

        public Contact GetById(int id)
        {
            Contact Contact = Context.Where(c => c.Id == id).FirstOrDefault();
            return Contact;
        }

        public Contact LastElementAdded()
        {
            Contact Contact = Context.OrderByDescending(c => c.Id).FirstOrDefault();
            return Contact;
        }
    }
}
