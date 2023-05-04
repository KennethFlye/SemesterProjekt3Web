using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SemesterProjekt3Api.Model;
using SemesterProjekt3Web.Models;
using System.Diagnostics;

namespace SemesterProjekt3Web.Controllers
{
    public class BookingController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        string baseURL;
        public BookingController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        
        public IActionResult CustomerInfo()
        {
            var formData = Request.Form["myListInput"];
            string seats = "";

            var myList = new List<string>();
            foreach (var item in formData.ToString().Split(','))
            {
                string addItem = item;
                if (item.StartsWith("["))
                {
                    addItem = item.TrimStart('[');
                }
                if (item.EndsWith("]"))
                {
                    addItem = item.TrimEnd(']');
                }

                myList.Add(addItem);
                Console.WriteLine(addItem);
            }

            Console.WriteLine(myList);
            return View();
        }

        public IActionResult Seats()
        {
            HttpClient client = new HttpClient();

            var respTask = client.GetAsync("https://localhost:7155/api/showings/3");
            respTask.Wait();
            StreamReader sr = new(respTask.Result.Content.ReadAsStream());
            string stringResult = sr.ReadToEnd();
            sr.Close();
            Showing foundShowing = JsonConvert.DeserializeObject<Showing>(stringResult);

            return View(foundShowing);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
