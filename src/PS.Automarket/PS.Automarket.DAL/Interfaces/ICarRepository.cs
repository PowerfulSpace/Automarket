using PS.Automarket.DAL.Interfaces.Base;
using PS.Automarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Automarket.DAL.Interfaces
{
    public interface ICarRepository : IBaseRepository<Car>
    {
        public Task<Car> GetByNameAsync(string name);
    }
}
