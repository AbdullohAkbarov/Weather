using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using WeatherDAL.Entities;

namespace WeatherDAL.EF
{
    public class WeatherContext : DbContext
    {
        public DbSet<Weather> Weathers { get; set; }

        static WeatherContext()
        {
            //Database.SetInitializer<WeatherContext>(new StoreDBInitializer());
        }

        public WeatherContext(string connectionString): base(connectionString)
        {

        }
    }
}
