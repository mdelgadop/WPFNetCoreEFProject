using Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IDataService<T>
        where T : GenericDto
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Create(T element);
        Task<T> Update(int id, T element);
        Task<bool> Delete(int id);
    }
}
