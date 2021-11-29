using Application.Dtos;
using Application.Factories.Services;
using Business.Entities;
using Business.Factories.Entities;
using System.Collections.Generic;

namespace Application.Mappers
{
    public class ContactMapper : IMapper<Contact, ContactDto>
    {
        internal ContactMapper()
        {

        }

        public Contact DtoToEntity(ContactDto dto)
        {
            Contact entity = ContactFactory.Create(dto.Code, dto.Name);
            entity.Id = dto.Id;
            return entity;
        }

        public IList<ContactDto> EntitiesToDto(IList<Contact> entities)
        {
            IList<ContactDto> list = new List<ContactDto>();

            foreach (Contact entity in entities)
            {
                list.Add(EntityToDto(entity));
            }

            return list;
        }

        public ContactDto EntityToDto(Contact entity)
        {
            ContactDto dto = ContactDtoFactory.Create(entity.Code, entity.Name);
            dto.Id = entity.Id;
            return dto;
        }
    }
}
