using Microsoft.AspNetCore.Http;
using PS.Automarket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Automarket.Domain.Entities
{
    public class Car
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Model { get; set; }
        public double Speed { get; set; }
        public decimal Price { get; set; }
        public DateTime DateCreate { get; set; }
        public TypeCar TypeCar { get; set; }
        public IFormFile Avatar { get; set; }
    }
}
