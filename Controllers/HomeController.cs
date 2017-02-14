using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        // =========================================================        
        // We will do all of our work in these functions
        // =========================================================

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string link)
        {
            var submittedPhoto = link;
            var resultPhoto = "~/images/AngryDwight.jpg";
            var resultDescription = "You are the angry Dwight!";
            
            var result = new Result() 
            {
                photo = resultPhoto,
                description = resultDescription
            };

            return RedirectToAction("Results", result);
        }

        [HttpGet]
        public IActionResult Results(Result model)
        {
            if (model == null)
            {
                return RedirectToAction("Index", null);
            }

            return View(model);
        }

        // =========================================================
        // ASP.NET Core Templated Code
        // =========================================================        
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
