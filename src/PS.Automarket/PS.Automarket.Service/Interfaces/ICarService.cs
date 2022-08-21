using PS.Automarket.Domain.Entities;
using PS.Automarket.Domain.Response;
using PS.Automarket.Domain.ViewModels.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Automarket.Service.Interfaces
{
    public interface ICarService
    {        
        public Task<IBaseResponse<Car>> GetCarAsync(Guid id);
        public Task<IBaseResponse<Car>> GetCarByNameAsync(string name);
        public Task<IBaseResponse<IEnumerable<Car>>> GetCarsAsync();
        public Task<IBaseResponse<bool>> CreateCarAsync(CarViewModel car);
        public Task<IBaseResponse<bool>> DeleteCarAsync(Guid id);
    }
}
