using Microsoft.AspNetCore.Mvc;
using SemesterProjekt3Web.Models;
using System.Diagnostics;

namespace SemesterProjekt3Web.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        string baseURL;
        public MoviesController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
