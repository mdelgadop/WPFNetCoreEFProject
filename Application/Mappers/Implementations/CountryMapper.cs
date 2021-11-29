using Application.Dtos;
using Application.Factories.Services;
using Business.Entities;
using Business.Factories.Entities;
using System.Collections.Generic;

namespace Application.Mappers
{
    public class CountryMapper : IMapper<Country, CountryDto>
    {
        private readonly IMapper<Region, RegionDto> _regionMapper;
        
        private readonly IMapper<Contact, ContactDto> _contactMapper;

        internal CountryMapper(IMapper<Region, RegionDto> regionMapper, IMapper<Contact, ContactDto> contactMapper)
        {
            _regionMapper = regionMapper;
            _contactMapper = contactMapper;
        }

        public Country DtoToEntity(CountryDto dto)
        {
            Country entity = CountryFactory.Create(dto.Code, dto.Name);
            entity.Id = dto.Id;

            if (dto.Region != null)
                entity.Region = _regionMapper.DtoToEntity(dto.Region);

            if (dto.Contact != null)
                entity.Contact = _contactMapper.DtoToEntity(dto.Contact);

            if (dto.BackupContact != null)
                entity.BackupContact = _contactMapper.DtoToEntity(dto.BackupContact);

            return entity;
        }

        public IList<CountryDto> EntitiesToDto(IList<Country> entities)
        {
            IList<CountryDto> list = new List<CountryDto>();

            foreach(Country entity in entities)
            {
                list.Add(EntityToDto(entity));
            }

            return list;
        }

        public CountryDto EntityToDto(Country entity)
        {
            CountryDto dto = CountryDtoFactory.Create(entity.Code, entity.Name);
            dto.Id = entity.Id;

            if (entity.Region != null)
                dto.Region = _regionMapper.EntityToDto(entity.Region);

            if (entity.Contact != null)
                dto.Contact = _contactMapper.EntityToDto(entity.Contact);

            if (entity.BackupContact != null)
                dto.BackupContact = _contactMapper.EntityToDto(entity.BackupContact);

            return dto;
        }
    }
}
