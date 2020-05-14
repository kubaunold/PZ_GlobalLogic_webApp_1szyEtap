using Microsoft.EntityFrameworkCore;    //for DbContext
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SensorMobCRUD.Models
{
    //version with db created locally, on xampp
    //public class DataContext : DbContext
    //{
    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    {
    //        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
    //        var configuration = builder.Build();
    //        //optionsBuilder.UseMySql(configuration["ConnectionStrings:DefaultConnection"]);
    //        optionsBuilder.UseMySql(configuration["ConnectionStrings:DefaultConnection"]);
    //        //optionsBuilder.
    //    }
    //    public DbSet<Measurment> Measurments { get; set; }

    //}

    //veriosn with db created locally, in c#
    public class DataContext : DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
        //    var configuration = builder.Build();
        //    //optionsBuilder.UseMySql(configuration["ConnectionStrings:DefaultConnection"]);
        //    optionsBuilder.UseMySql(configuration["ConnectionStrings:DefaultConnection"]);
        //    //optionsBuilder.
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("DataSource=app.db");
        }

        public DbSet<Measurment> Measurments { get; set; }
    }

}
