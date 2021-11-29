using Business.Entities;
using Business.Repositories;

namespace Business.Factories.Repositories
{
    public class CountryRepositoryFactory
    {
        public static IRepository<Country> Create()
        {
            IRepository<Country> element = new CountryRepository();
            return element;
        }

        public static IRepository<Country> CreateMock()
        {
            IRepository<Country> element = new Business.Repositories.Mocks.CountryRepository();
            return element;
        }
    }
}