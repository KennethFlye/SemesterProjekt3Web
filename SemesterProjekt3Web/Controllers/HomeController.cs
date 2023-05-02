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
        readonly MovieAccessLogic _movieAL;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _movieAL = new MovieAccessLogic();
        }

        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public  IActionResult Movies()
        {

            Task<IEnumerable<MovieInfo>> mInfo = _movieAL.GetMovies();
            var nInfo = mInfo.GetAwaiter().GetResult();
            return View(nInfo);
        }

        public ActionResult Showings(int id)
        {
            //Task<IEnumerable<Showing>> mInfo = _movieAL.GetShowingsByMovieID(id);
            //var nInfo = mInfo.GetAwaiter().GetResult();
            List<Showing> nInfo = new List<Showing>();

            Showing showing1 = new Showing();
            showing1.Id = 1;
            showing1.startTime = DateTime.Now;
            showing1.IsKidFriendly = false;
            showing1.ShowRoom = new ShowRoom();
            showing1.MovieCopy = new MovieCopy();

            showing1.ShowRoom.RoomNumber = 4;
            showing1.ShowRoom.Capacity = 32;
            showing1.ShowRoom.Seats = new List<Seat>();

            showing1.MovieCopy.Id = 2;
            showing1.MovieCopy.Language = "Engelsk";
            showing1.MovieCopy.Is3D = false;
            showing1.MovieCopy.Price = 100;
            showing1.MovieCopy.MovieType = new MovieInfo();

            showing1.MovieCopy.MovieType.Id = 3;
            showing1.MovieCopy.MovieType.Title = "Shrek 2";
            showing1.MovieCopy.MovieType.Length = 119;
            showing1.MovieCopy.MovieType.Genre = "Adventure/Family";
            showing1.MovieCopy.MovieType.PgRating = "+7 år";
            showing1.MovieCopy.MovieType.PremiereDate = new DateTime(2001, 07, 09);

            nInfo.Add(showing1);

            return View(nInfo);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}