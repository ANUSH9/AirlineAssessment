using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MVC_Airline.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        //public IActionResult Index()
        //{
        //    var Rolename = _roleManager.Roles.ToList();
        //    return View(Rolename);
        //}
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Create(IdentityRole role)
        //{
        //    await _roleManager.CreateAsync(role);
        //    return RedirectToAction("Index");
        //}
    }

}

