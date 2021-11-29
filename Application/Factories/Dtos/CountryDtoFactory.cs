using Application.Dtos;

namespace Application.Factories.Services
{
    public class CountryDtoFactory
    {
        public static CountryDto Create()
        {
            CountryDto element = new CountryDto();
            return element;
        }

        public static CountryDto Create(string code, string name)
        {
            return new CountryDto()
            {
                Code = code,
                Name = name
            };
        }
    }
}