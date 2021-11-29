using Business.Context;
using Business.Entities;
using Business.Mappers;
using Infrastructure.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace Business.Repositories
{
    public class ContactRepository : IRepository<Contact>
    {
        private MarketContext MarketContext { get; set; }

        private ContactMapper Mapper { get; set; }

        internal ContactRepository()
        {
            MarketContext = MarketContext.Instance;
            Mapper = new ContactMapper();
        }

        public void Add(Contact entity)
        {
            if (entity.Id != 0)
                throw new ElementCannotBeAddedException();
            
            entity.Id = 1 + (MarketContext.Contacts.Count() == 0 ? 0 : MarketContext.Contacts.Select(c => c.Id).Max());
            Mapper.Mapping(entity, entity);
            MarketContext.Contacts.Add(entity);
            MarketContext.SaveChanges();
        }

        public void Save(Contact entity)
        {
            if (entity.Id == 0)
                throw new ElementCannotBeSavedException();

            Contact entityInDB = MarketContext.Contacts.Where(c => c.Id == entity.Id).FirstOrDefault();

            if (entityInDB == null)
                throw new ElementNotFoundException();

            Mapper.Mapping(entityInDB, entity);
            MarketContext.Contacts.Update(entityInDB);
            MarketContext.SaveChanges();
        }

        public void Remove(Contact entity)
        {
            if (entity.Id <= 0)
                throw new ElementNotFoundException();

            Contact c = MarketContext.Contacts.Where(c => c.Id == entity.Id).FirstOrDefault();

            if (c == null)
                throw new ElementNotFoundException();

            MarketContext.Contacts.Remove(c);
            MarketContext.SaveChanges();
        }

        public IList<Contact> GetAll()
        {
            IList<Contact> countries = (MarketContext.Contacts == null) ? new List<Contact>() : MarketContext.Contacts.ToList();
            return countries;
        }

        public Contact GetById(int id)
        {
            Contact Contact = MarketContext.Contacts.Where(c => c.Id == id).FirstOrDefault();
            return Contact;
        }

        public Contact LastElementAdded()
        {
            Contact Contact = MarketContext.Contacts.OrderByDescending(c => c.Id).FirstOrDefault();
            return Contact;
        }
    }
}
