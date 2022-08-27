using Microsoft.EntityFrameworkCore;

namespace MVC_Airline.Models
{
    public class MvcDbcontext:DbContext
    {
        public DbSet<Admin> adminModel { get; set; }
      

        public MvcDbcontext()
        {

        }
        public MvcDbcontext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-F0DS2US\\SQLEXPRESS;Initial Catalog=MVCAirline;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Admin>(entity => entity.HasIndex(e => e.Email).IsUnique());
            builder.Entity<Admin>().Property(e => e.PANNO).HasColumnType("VARCHAR").HasMaxLength(10);
            builder.Entity<Admin>().Property(e => e.Password).HasColumnType("VARCHAR").HasMaxLength(10);
            builder.Entity<Admin>().Property(e => e.ConfirmPassword).HasColumnType("VARCHAR").HasMaxLength(10);
            builder.Entity<Admin>().Property(e => e.RoleName).HasColumnType("VARCHAR").HasMaxLength(10);


        }
    }
    

    
}
