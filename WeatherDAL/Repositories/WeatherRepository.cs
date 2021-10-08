using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherDAL.EF;
using WeatherDAL.Entities;

namespace WeatherDAL.Repositories
{
    public class WeatherRepository
    {
        private WeatherContext _context;

        public WeatherRepository()
        {
            _context = new WeatherContext();
        }

        public async Task<List<Weather>> GetAll()
        {
            return await _context.Weathers.ToListAsync();
        }

        public async Task<Weather> GetByCity(string city)
        {
            return await _context.Weathers.FirstOrDefaultAsync(r => r.City.Equals(city));
        }

        public async Task<List<Weather>> GetByCityAll(string city)
        {
            return await _context.Weathers.Where(r => r.City.Equals(city)).ToListAsync();
        }

        public async Task<bool> Insert(Weather weather)
        {
            try
            {
                _context.Weathers.Add(weather);
                var result = await _context.SaveChangesAsync();
                return result == 1;
            }
            catch
            {
                return false;
            }
        }
    }
}
