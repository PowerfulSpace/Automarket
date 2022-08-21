using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PS.Automarket.DAL.Interfaces;
using PS.Automarket.Domain.Entities;
using PS.Automarket.Domain.ViewModels.Car;
using PS.Automarket.Service.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PS.Automarket.Web.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }


        [HttpGet]
        public async Task<IActionResult> GetCars()
        {
            var response = await _carService.GetCarsAsync();

            if(response.StatusCode == Domain.Enums.StatusCode.OK)
            {
                return View(response.Data.ToList());
            }

            return RedirectToAction("Error");
        }

        [HttpGet]
        public async Task<IActionResult> GetCar(Guid id)
        {
            var response = await _carService.GetCarAsync(id);

            if(response.StatusCode == Domain.Enums.StatusCode.OK)
            {
                return View(response.Data);
            }

            return RedirectToAction("Error");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCar(Guid id)
        {
            var response = await _carService.DeleteCarAsync(id);

            if (response.StatusCode == Domain.Enums.StatusCode.OK)
            {
                return RedirectToAction("GetCars");
            }

            return RedirectToAction("Error");
        }



        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Save(Guid id)
        {
            if(id == Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {
                return View();
            }

            var response = await _carService.GetCarAsync(id);

            if (response.StatusCode == Domain.Enums.StatusCode.OK)
            {
                return View(response.Data);
            }

            return RedirectToAction("Error");
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Save(CarViewModel carViewModel)
        {
            if (ModelState.IsValid)
            {
                if(carViewModel.Id == Guid.Parse("00000000-0000-0000-0000-000000000000"))
                {
                    await _carService.CreateCarAsync(carViewModel);
                }
                else
                {
                    await _carService.EditCarAsync(carViewModel.Id, carViewModel);
                }
            }


            return RedirectToAction("GetCars");
        }



    }
}
