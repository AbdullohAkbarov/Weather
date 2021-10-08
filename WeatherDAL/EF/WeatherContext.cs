using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Text;
using WeatherDAL.Entities;

namespace WeatherDAL.EF
{
    public class WeatherContext : DbContext
    {
        public WeatherContext() : base(ConfigurationManager.ConnectionStrings["WeatherDB"].ConnectionString) { }

        public DbSet<Weather> Weathers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
