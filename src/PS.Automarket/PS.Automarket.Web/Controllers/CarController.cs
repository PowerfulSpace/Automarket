using Microsoft.AspNetCore.Mvc;
using PS.Automarket.DAL.Interfaces;
using PS.Automarket.Domain.Entities;
using PS.Automarket.Service.Interfaces;
using System;
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
                return View(response.Data);
            }

            return RedirectToAction("Error");
        }
    }
}
