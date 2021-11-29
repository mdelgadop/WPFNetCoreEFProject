using Application.Dtos;

namespace Application.Factories.Services
{
    public class RegionDtoFactory
    {
        public static RegionDto Create()
        {
            RegionDto element = new RegionDto();
            return element;
        }

        public static RegionDto Create(string code, string name)
        {
            return new RegionDto()
            {
                Code = code,
                Name = name
            };
        }
    }
}