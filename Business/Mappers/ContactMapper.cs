using Business.Entities;

namespace Business.Mappers
{
    public class ContactMapper
    {
        internal void Mapping(Contact entity, Contact entityInDB)
        {
            entityInDB.Code = entity.Code;
            entityInDB.Name = entity.Name;
        }
    }
}
