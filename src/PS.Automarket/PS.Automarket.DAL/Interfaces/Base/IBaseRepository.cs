using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Automarket.DAL.Interfaces.Base
{
    public interface IBaseRepository<T>
    {
        public Task<bool> CreateAsync(T entity);
        public Task<T> GetAsync(Guid id);
        public Task<IEnumerable<T>> SelectAsync();
        public Task<bool> DeleteAsync(T entity);
    }
}
