using Application.Services;
using Business.Entities;
using Business.Factories.Repositories;
using Business.Repositories;

namespace Application.Factories.Services
{
    public class CountryServiceFactory
    {
        public static ICountryService Create()
        {
            ICountryService element = new CountryService(CountryRepositoryFactory.Create(), RegionRepositoryFactory.Create(), ContactRepositoryFactory.Create());
            return element;
        }

        public static ICountryService CreateMock()
        {
            IRepository<Country> countryRepository = CountryRepositoryFactory.CreateMock();
            IRepository<Region> regionRepository = RegionRepositoryFactory.CreateMock();
            IRepository<Contact> contactRepository = ContactRepositoryFactory.CreateMock();

            ICountryService element = new CountryService(countryRepository, regionRepository, contactRepository);

            element.GenerateExampleData();

            return element;
        }
    }
}