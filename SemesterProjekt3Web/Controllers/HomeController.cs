using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SemesterProjekt3Web.BusinessLogic;
using SemesterProjekt3Web.Models;
using System.Data;
using System.Diagnostics;
using System.Net.Http.Headers;

using static System.Net.WebRequestMethods;

namespace SemesterProjekt3Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        readonly BookingAccessLogic _movieAL;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _movieAL = new BookingAccessLogic();
        }

        public IActionResult Index()
        {

            Task<IEnumerable<MovieInfo>> mInfo = _movieAL.GetMovies();
            var nInfo = mInfo.GetAwaiter().GetResult();
            return View(nInfo);
            
        }

        public IActionResult Privacy()
        {
            return View();
        }
        //public  IActionResult Movies()
        //{

        //    //Task<IEnumerable<MovieInfo>> mInfo = _movieAL.GetMovies();
        //    var nInfo = mInfo.GetAwaiter().GetResult();
        //    return View(nInfo);
        //}

        //public ActionResult Showings(int id)
        //{
        //    //Task<IEnumerable<Showing>> mInfo = _movieAL.GetShowingsByMovieID(id);
        //   // var nInfo = mInfo.GetAwaiter().GetResult();
        //    //return View(nInfo);
        //}


        
        public  async Task<ActionResult> Create()
        {
            Booking res = new();
            bool wasUpdated = await _movieAL.AddBooking(res);
            Booking currentShowing = null;
            if (wasUpdated)
            {
                TempData["ProcessText"] = "IT Worked!";
                currentShowing = res; 
                
            }
            else
            {
                TempData["ProcessText"] = "Sorry - not sorry";
            }

            if (currentShowing != null)
            {
                return RedirectToAction("Privacy");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

    



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}