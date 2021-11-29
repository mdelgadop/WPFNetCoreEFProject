using Business.Entities;
using System.Collections.Generic;

namespace Business.Repositories
{
    public interface IRepository<T>
        where T: GenericEntity
    {
        void Add(T entity);

        void Save(T entity);

        void Remove(T entity);

        IList<T> GetAll();

        T GetById(int id);

        T LastElementAdded();
    }
}
