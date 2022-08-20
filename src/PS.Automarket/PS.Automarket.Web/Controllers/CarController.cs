using Microsoft.AspNetCore.Mvc;
using PS.Automarket.DAL.Interfaces;
using PS.Automarket.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace PS.Automarket.Web.Controllers
{
    public class CarController : Controller
    {

        private readonly ICarRepository _carRepository;

        public CarController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCars()
        {
            var response = await _carRepository.SelectAsync();

            var r1 = await _carRepository.GetByNameAsync("Mersedes");
            var r2 = await _carRepository.GetAsync(Guid.Parse("B3A45441-BC92-4667-9DA9-8AD8312775B0"));

            Car car = new Car()
            {
                Name = "Ваз",
                Model = "Телега",
                Speed = 10,
                Price = 20,
                Description = "есть права бери её",
                DateCreate = DateTime.Now
            };

            await _carRepository.CreateAsync(car);
            await _carRepository.DeleteAsync(car);

            return View(response);
        }
    }
}
