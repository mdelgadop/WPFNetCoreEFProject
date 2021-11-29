using Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IDataService<T>
        where T : GenericDto
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        T Create(T element);
        T Update(int id, T element);
        bool Delete(int id);
    }
}
