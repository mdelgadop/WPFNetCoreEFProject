using Application.Dtos;
using Application.Mappers;
using Business.Entities;

namespace Application.Factories.Mappers
{
    public class RegionMapperFactory
    {
        public static IMapper<Region, RegionDto> Create()
        {
            IMapper<Region, RegionDto> element = new RegionMapper();
            return element;
        }
    }
}
