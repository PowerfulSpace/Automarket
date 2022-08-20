using PS.Automarket.DAL.Interfaces;
using PS.Automarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PS.Automarket.DAL.Repositories
{
    public class CarRepository : ICarRepository
    {

        private readonly ApplicationDbContext _dbContext;

        public CarRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Car> GetAsync(Guid id) => await _dbContext.Cars.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<Car> GetByNameAsync(string name) => await _dbContext.Cars.FirstOrDefaultAsync(x => x.Name == name);

        public async Task<IEnumerable<Car>> SelectAsync() => await _dbContext.Cars.ToListAsync();


        public async Task<bool> CreateAsync(Car entity)
        {
            if (entity == null) { return false; }

            try
            {
                await _dbContext.Cars.AddAsync(entity);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception) { }

            return true;
        }


        public async Task<bool> DeleteAsync(Car entity)
        {
            if(entity == null) { return false; }

            try
            {
                _dbContext.Cars.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception) { }
            
            return true;
        }

      

       
    }
}
