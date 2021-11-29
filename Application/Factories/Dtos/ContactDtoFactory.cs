using Application.Dtos;

namespace Application.Factories.Services
{
    public class ContactDtoFactory
    {
        public static ContactDto Create()
        {
            ContactDto element = new ContactDto();
            return element;
        }

        public static ContactDto Create(string code, string name)
        {
            return new ContactDto()
            {
                Code = code,
                Name = name
            };
        }
    }
}