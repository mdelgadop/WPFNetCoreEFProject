using Application.Dtos;
using Application.Mappers;
using Business.Entities;

namespace Application.Factories.Mappers
{
    public class CountryMapperFactory
    {
        public static IMapper<Country, CountryDto> Create()
        {
            IMapper<Country, CountryDto> element = new CountryMapper(RegionMapperFactory.Create(), ContactMapperFactory.Create());
            return element;
        }
    }
}
