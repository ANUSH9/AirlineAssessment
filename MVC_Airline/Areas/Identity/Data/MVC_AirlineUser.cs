using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MVC_Airline.Areas.Identity.Data;

// Add profile data for application users by adding properties to the MVC_AirlineUser class
public class MVC_AirlineUser : IdentityUser
{
    public string PANNO { get; set; }
}

