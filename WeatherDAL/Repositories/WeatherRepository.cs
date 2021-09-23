using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using WeatherDAL.EF;
using WeatherDAL.Entities;
using WeatherDAL.Interfaces;

namespace WeatherDAL.Repositories
{
    public class WeatherRepository: IRepository<Weather>
    {
        private WeatherContext db;

        public WeatherRepository(WeatherContext context)
        {
            this.db = context;
        }

        public IEnumerable<Weather> GetAll()
        {
            return db.Weathers;
        }

        public Weather Get(int id)
        {
            return db.Weathers.Find(id);
        }

        public void Create(Weather book)
        {
            db.Weathers.Add(book);
        }

        public void Update(Weather book)
        {
            db.Entry(book).State = EntityState.Modified;
        }

        public IEnumerable<Weather> Find(Func<Weather, Boolean> predicate)
        {
            return db.Weathers.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Weather book = db.Weathers.Find(id);
            if (book != null)
                db.Weathers.Remove(book);
        }
    }
}
