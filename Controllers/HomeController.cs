using System;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using WebApplication.Models;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;

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

            // Make API Call and get back top emotion
            var topEmotion = await MakeRequest(submittedPhoto);

            // Decide which picture and description to display
            var suggestion = MakeSuggestion(topEmotion);

            // Pass the suggestion to the Results page to be displayed
            return RedirectToAction("Results", suggestion);
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

        // =========================================================
        // Helper functions, paste code snippets here
        // =========================================================
        public async Task<String> MakeRequest(string submittedPhoto)
        {
            var client = new HttpClient();

            // Add request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "6470040a779d442b93118357ccff41ce"); // TODO: Fix key
            var uri = "https://api.projectoxford.ai/emotion/v1.0/recognize";
            
            // Format request body
            String picURL= "\"" + submittedPhoto + "\"";
            String format = "\"url\":";
            String requestBody= String.Format("{0} {1}", format, picURL);
            requestBody = "{" + requestBody + "}";
            byte[] byteData = Encoding.UTF8.GetBytes(requestBody);

            // Send request
            HttpResponseMessage response;
            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PostAsync(uri, content).ConfigureAwait(false);
            }

            // Set up objects to store top emotion
            EmotionSet emotions = new EmotionSet();            
            string topEmotion = "";
            
            // Prepare result string for JSON conversion            
            HttpContent httpResults = response.Content;
            var results = await httpResults.ReadAsStringAsync();
            results = results.TrimStart('[');
            results= results.TrimEnd(']');

            // Validate response: an invalid link will return an error code and an invalid image will return "[]"            
            if (!results.Contains("error") && results.Length > 2)
            {
                // Populate a JSON object with the results of the API call and find the top emotion
                JsonConvert.PopulateObject(results, emotions);
                topEmotion = emotions.getTopScore();
            }

            return topEmotion;
        }

        public Result MakeSuggestion(string emotion)
        {
            var link = "";
            var description = "";

            // Decide which image to use based on the emotion in the picture
            switch (emotion)
            {
                case "anger":
                    link = "/images/AngryDwight.jpg";
                    description = "You look just as angry as Dwight!";
                    break;
                case "contempt":
                    link = "/images/Angela.jpg";
                    description = "Your contempt level is reaching Angela levels!";
                    break;
                case "disgust":
                    link = "/images/Kelly.gif";
                    description = "You look just as disgusted as Kelly!";
                    break;
                case "fear":
                    link = "/images/Michael.jpg";
                    description = "You might just be just as fearful and superstitous as Michael!";
                    break;
                case "happiness":
                    link = "/images/JimAndPam.png";
                    description = "You look just as happy as Jim and Pam together!";
                    break;
                case "neutral":
                    link = "/images/Stanley.jpg";
                    description = "Looking just as neutral as Stanley staring at the camera.";
                    break;
                case "sadness":
                    link = "/images/SadDwight.jpg";
                    description = "Looking as sad as Dwight today!";
                    break;
                case "surprise":
                    link = "/images/Jim.jpg";
                    description = "You look just as suprised as Jim walking in on Dwight's birthday suprise.";
                    break;
                case "":
                    link = "/images/Error.jpg";
                    description = "Oops something went wrong! Please make sure that you submitted the correct image link and that your face is both promienent in the image and unobstructed. Submit another link to try again!";
                    break;
            }

            // Store suggestion
            Result suggestion = new Result()
            {
                photo = link,
                description = description
            };

            return suggestion;
        }

        // =========================================================
        // ASP.NET Core Templated Code
        // We won't use these for this workshop
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
