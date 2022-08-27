using ClassLibraryAirline.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryAirline.DBContext
{
    public class DemoDBContext : DbContext
    {
        public DbSet<AirlineModel> AirlineModels { get; set; }
        public DemoDBContext()
        {

        }
        public DemoDBContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-F0DS2US\\SQLEXPRESS;Initial Catalog=AirlineData;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AirlineModel>(entity => entity.HasIndex(e => e.AirlineName).IsUnique());
            builder.Entity<AirlineModel>().Property(e => e.AirlineName).HasColumnType("VARCHAR").HasMaxLength(50);
            builder.Entity<AirlineModel>().Property(e => e.AirlinesFromCity).HasColumnType("VARCHAR").HasMaxLength(30);
            builder.Entity<AirlineModel>().Property(e => e.AirlinesToCity).HasColumnType("VARCHAR").HasMaxLength(30);
        }
    }
}

       

