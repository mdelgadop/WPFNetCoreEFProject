using Application.Dtos;
using Application.Mappers;
using Business.Entities;

namespace Application.Factories.Mappers
{
    public class ContactMapperFactory
    {
        public static IMapper<Contact, ContactDto> Create()
        {
            IMapper<Contact, ContactDto> element = new ContactMapper();
            return element;
        }
    }
}
