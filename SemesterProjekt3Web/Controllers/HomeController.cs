using Microsoft.AspNetCore.Mvc;
using SemesterProjekt3Web.BusinessLogic;
using SemesterProjekt3Web.Models;
using System.Diagnostics;

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
            return View();


        }

        public IActionResult Privacy()
        {
            return View();
        }
        //public IActionResult Movies()
        //{

        //    Task<IEnumerable<>> mInfo = _movieAL.GetMovies();
        //    var nInfo = mInfo.GetAwaiter().GetResult();
        //    return View(nInfo);
        //}

        //public ActionResult Showings(int id)
        //{
        //    Task<IEnumerable<Showing>> mInfo = _movieAL.GetShowingsByMovieID(id);
        //    var nInfo = mInfo.GetAwaiter().GetResult();
        //    return View(nInfo);
        //}



        public async Task<ActionResult> Create()
        {
            Booking res = new();
            bool wasUpdated = await _movieAL.AddBooking(res);

            if (wasUpdated)
            {
                TempData["ProcessText"] = "IT Worked!";


            }
            else
            {
                TempData["ProcessText"] = "Sorry - not sorry";
            }

            return RedirectToAction("Privacy");


        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}