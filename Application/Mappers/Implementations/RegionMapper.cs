using Application.Dtos;
using Application.Factories.Services;
using Business.Entities;
using Business.Factories.Entities;
using System.Collections.Generic;

namespace Application.Mappers
{
    public class RegionMapper : IMapper<Region, RegionDto>
    {
        internal RegionMapper()
        {

        }

        public Region DtoToEntity(RegionDto dto)
        {
            Region entity = RegionFactory.Create(dto.Code, dto.Name);
            entity.Id = dto.Id;
            return entity;
        }

        public IList<RegionDto> EntitiesToDto(IList<Region> entities)
        {
            IList<RegionDto> list = new List<RegionDto>();

            foreach (Region entity in entities)
            {
                list.Add(EntityToDto(entity));
            }

            return list;
        }

        public RegionDto EntityToDto(Region entity)
        {
            RegionDto dto = RegionDtoFactory.Create(entity.Code, entity.Name);
            dto.Id = entity.Id;
            return dto;
        }
    }
}
