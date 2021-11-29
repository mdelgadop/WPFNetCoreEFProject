using Business.Entities;
using Business.Repositories;

namespace Business.Factories.Repositories
{
    public class ContactRepositoryFactory
    {
        public static IRepository<Contact> Create()
        {
            IRepository<Contact> element = new ContactRepository();
            return element;
        }

        public static IRepository<Contact> CreateMock()
        {
            IRepository<Contact> element = new Business.Repositories.Mocks.ContactRepository();
            return element;
        }
    }
}