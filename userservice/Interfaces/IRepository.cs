using System.Collections.Generic;
using System.Threading.Tasks;

namespace userservice.Interfaces {
    public interface IRepository<T> {
        Task<List<T>> GetAll();
        Task<T> GetById(string Id);
        Task<bool> Create(T Entity);
    }
}