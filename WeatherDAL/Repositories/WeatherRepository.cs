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
    public class WeatherRepository : IRepository<Weather>
    {
        //public DbSet Entities => DbContext.Set();
        //private WeatherContext db;

        //public WeatherRepository(WeatherContext context)
        //{
        //    this.db = context;
        //}

        //public IEnumerable<Weather> GetAll()
        //{
        //    return db.Weathers;
        //}

        //public Weather Get(int id)
        //{
        //    return db.Weathers.Find(id);
        //}

        //public void Create(Weather book)
        //{
        //    db.Weathers.Add(book);
        //}

        //public void Update(Weather book)
        //{
        //    db.Entry(book).State = EntityState.Modified;
        //}

        //public IEnumerable<Weather> Find(Func<Weather, Boolean> predicate)
        //{
        //    return db.Weathers.Where(predicate).ToList();
        //}

        //public void Delete(int id)
        //{
        //    Weather book = db.Weathers.Find(id);
        //    if (book != null)
        //        db.Weathers.Remove(book);
        //}

        public DbSet<Weather> Entities => throw new NotImplementedException();

        public DbContext DbContext => throw new NotImplementedException();

        public void Create(Weather item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Weather> Find(Func<Weather, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Weather Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Weather> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Weather item)
        {
            throw new NotImplementedException();
        }
    }
}
