using Business.Context;
using Business.Entities;
using System.Linq;

namespace Business.Mappers
{
    public class CountryMapper
    {
        public void Mapping(Country entity, Country entityInDB)
        {
            MarketContext dbContext = MarketContext.Instance;

            entityInDB.Code = entity.Code;
            entityInDB.Name = entity.Name;
            entityInDB.Region = entity.Region == null ? null : dbContext.Regions.Where(r => r.Id == entity.Region.Id).FirstOrDefault();
            entityInDB.Contact = entity.Contact == null ? null : dbContext.Contacts.Where(r => r.Id == entity.Contact.Id).FirstOrDefault();
            entityInDB.BackupContact = entity.BackupContact == null ? null : dbContext.Contacts.Where(r => r.Id == entity.BackupContact.Id).FirstOrDefault();
        }
    }
}
