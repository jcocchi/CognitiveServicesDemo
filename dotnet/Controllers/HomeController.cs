using System;
using System.Linq;
using System.Text;
using System.Net.Http;
using emotionAPI.Models;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace emotionAPI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string link)
        {
            var submittedPhoto = link;

            // Make API Call and get back top emotion
            // var results = await MakeRequest(submittedPhoto);

            // Parse the results and get the top emotion
            // var topEmotion = ParseResults(results);

            // Decide which picture and description to display
            // var suggestion = MakeSuggestion(topEmotion);

            // Pass the suggestion to the Results page to be displayed
            // return RedirectToAction("Results", suggestion);

            // Remove this once you paste in the proper code snippets
            return View();
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

        [HttpPost]
        public IActionResult Results()
        {
            return RedirectToAction("Index");
        }
    }
}
