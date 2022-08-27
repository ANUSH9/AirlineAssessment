using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVC_Airline.Areas.Identity.Data;

namespace MVC_Airline.Data;

public class MVC_AirlineContext : IdentityDbContext<MVC_AirlineUser>
{
    public MVC_AirlineContext(DbContextOptions<MVC_AirlineContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
