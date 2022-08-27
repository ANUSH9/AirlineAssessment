using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Airline.Models;

namespace MVC_Airline.Controllers
{
    public class AdminController : Controller
    {
        private readonly MvcDbcontext _context;

       
        public AdminController(MvcDbcontext adminDbContext)
        {
            _context = adminDbContext;
        }
        public IActionResult RegisteredPage()
        {
            return View();
        }
        
        public IActionResult Index()
        {
            if (_context.adminModel == null)
            {
                return NotFound();
            }
            List<Admin> adminModels = new List<Admin>();
            adminModels = _context.adminModel.ToList();
            if (adminModels == null)
            {
                return NotFound();
            }
            return View(adminModels);
        }


//        public IActionResult Approve(AdminModel adminModels)
//        {

//            adminModels.Status = "Approved";
//            adminModels.IsApproved = true;
//            _adminDbContext.AdminModels.Update(adminModels);
//            _adminDbContext.SaveChanges();
//            return View("Index", adminModels);
//        }
//        public IActionResult Reject(AdminModel adminModels)
//        {
//            adminModels.Status = "Rejected";
//            adminModels.IsApproved = true;
//            _adminDbContext.AdminModels.Update(adminModels);
//            _adminDbContext.SaveChanges();
//            return View("Index", adminModels);
//        }
//        [Authorize(Policy = "writeonly")]
//        public IActionResult Index()
//        {
//            if (_adminDbContext.AdminModels == null)
//            {
//                return NotFound();
//            }
//            List<AdminModel> adminModels = new List<AdminModel>();
//            adminModels = _adminDbContext.AdminModels.Where(x => x.Status == "Approved" || x.Status == "Pending").ToList();
//            if (adminModels == null)
//            {
//                return NotFound();
//            }
//            return View(adminModels);

//        }

//    }
//}


    }
}
    

