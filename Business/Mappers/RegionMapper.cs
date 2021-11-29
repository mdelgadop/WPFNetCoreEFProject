using Business.Entities;

namespace Business.Mappers
{
    public class RegionMapper
    {
        internal void Mapping(Region entity, Region entityInDB)
        {
            entityInDB.Code = entity.Code;
            entityInDB.Name = entity.Name;
        }
    }
}
