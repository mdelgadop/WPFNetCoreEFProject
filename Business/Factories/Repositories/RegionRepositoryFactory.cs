using Business.Entities;
using Business.Repositories;

namespace Business.Factories.Repositories
{
    public class RegionRepositoryFactory
    {
        public static IRepository<Region> Create()
        {
            IRepository<Region> element = new RegionRepository();
            return element;
        }

        public static IRepository<Region> CreateMock()
        {
            IRepository<Region> element = new Business.Repositories.Mocks.RegionRepository();
            return element;
        }
    }
}