using PS.Automarket.DAL.Interfaces;
using PS.Automarket.Domain.Entities;
using PS.Automarket.Domain.Enums;
using PS.Automarket.Domain.Response;
using PS.Automarket.Domain.ViewModels.Car;
using PS.Automarket.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Automarket.Service.Implementations
{
    public class CarService : ICarService
    {

        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }


        
        public async Task<IBaseResponse<Car>> GetCarAsync(Guid id)
        {
            var baseResponse = new BaseResponse<Car>();

            try
            {
                var car = await _carRepository.GetAsync(id);

                if (car == null)
                {
                    baseResponse.Description = "Car not found";
                    baseResponse.StatusCode = StatusCode.NotFound;

                    return baseResponse;
                }

                baseResponse.Data = car;
                baseResponse.StatusCode = StatusCode.OK;

                return baseResponse;

            }
            catch (Exception e)
            {
                return new BaseResponse<Car>()
                {
                    Description = $"[GetCarAsync] : {e.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<Car>> GetCarByNameAsync(string name)
        {
            var baseResponse = new BaseResponse<Car>();

            try
            {
                var car = await _carRepository.GetByNameAsync(name);

                if(car == null)
                {
                    baseResponse.Description = "Car not found";
                    baseResponse.StatusCode = StatusCode.NotFound;
                    return baseResponse;
                }

                baseResponse.Data = car;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception e)
            {
                return new BaseResponse<Car>()
                {
                    Description = $"[GetCarByNameAsync] - {e.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<Car>>> GetCarsAsync()
        {
            var baseResponse = new BaseResponse<IEnumerable<Car>>();

            try
            {
                var cars = await _carRepository.SelectAsync();

                if(cars.ToList().Count == 0)
                {
                    baseResponse.Description = "Cars not found";
                    baseResponse.StatusCode = StatusCode.NotFound;
                    return baseResponse;
                }

                baseResponse.Data = cars;
                baseResponse.StatusCode = StatusCode.OK;

                return baseResponse;
            }
            catch (Exception e)
            {
                return new BaseResponse<IEnumerable<Car>>()
                {
                    Description = $"[GetCarsAsync] : {e.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }

            
        }

        public async Task<IBaseResponse<bool>> CreateCarAsync(CarViewModel mode)
        {
            var baseResponse = new BaseResponse<bool>();

            try
            {
                var car = new Car()
                {
                    Name = mode.Name,
                    Description = mode.Description,
                    Model = mode.Model,
                    Speed = mode.Speed,
                    Price = mode.Price,
                    DateCreate = mode.DateCreate,
                    TypeCar = (TypeCar)Convert.ToInt32(mode.TypeCar)
                };


                await _carRepository.CreateAsync(car);
                baseResponse.Data = true;
                baseResponse.StatusCode = StatusCode.OK;

                return baseResponse;
            }
            catch (Exception e)
            {
                return new BaseResponse<bool>()
                {
                    Data = false,
                    Description = $"[CreateCarAsync] : {e.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<bool>> DeleteCarAsync(Guid id)
        {
            var baseResponse = new BaseResponse<bool>();

            try
            {
                var car = await _carRepository.GetAsync(id);

                if (car == null)
                {
                    baseResponse.Description = "Car not found";
                    baseResponse.StatusCode = StatusCode.NotFound;
                    baseResponse.Data = false;
                    return baseResponse;
                }

                await _carRepository.DeleteAsync(car);
                baseResponse.Data = true;
                baseResponse.StatusCode = StatusCode.OK;

                return baseResponse;
            }
            catch (Exception e)
            {
                return new BaseResponse<bool>()
                {
                    Data = false,
                    Description = $"[DeleteCarAsync] : {e.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }



        public async Task<IBaseResponse<Car>> EditCarAsync(Guid id, CarViewModel mode)
        {
            var baseResponse = new BaseResponse<Car>();

            try
            {
                var car = await _carRepository.GetAsync(id);

                if(car == null)
                {
                    baseResponse.Description = "Car not found";
                    baseResponse.StatusCode = StatusCode.NotFound;

                    return baseResponse;
                }

                car.Name = mode.Name;
                car.Description = mode.Description;
                car.Model = mode.Model;
                car.Speed = mode.Speed;
                car.Price = mode.Price;
                car.DateCreate = mode.DateCreate;
                //car.TypeCar = (TypeCar)Convert.ToInt32(mode.TypeCar);

                await _carRepository.UpdateAsync(car);

                baseResponse.Data = car;
                baseResponse.StatusCode = StatusCode.OK;

                return baseResponse;
            }
            catch (Exception e)
            {
                return new BaseResponse<Car>()
                {
                    Description = $"[EditCarAsync] : {e.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

    }
}
