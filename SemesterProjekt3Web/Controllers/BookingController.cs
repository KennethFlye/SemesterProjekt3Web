using Microsoft.AspNetCore.Mvc;
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
            return View();
        }

        public IActionResult Receipt()
        {
            Booking booking = new Booking();
            booking.BookingId = 5;
            booking.Total = 249.99;
            booking.TimeOfPurchase = new DateTime(2023, 05, 05, 13, 32, 55);

            booking.Showing = new Showing();
            booking.Showing.startTime = new DateTime(2023, 05, 12, 15, 30, 00);
            booking.Showing.MovieCopy = new MovieCopy();

            booking.Showing.MovieCopy.MovieType = new MovieInfo();

            booking.Showing.MovieCopy.MovieType.Title = "Shrek 2";
            booking.Showing.MovieCopy.MovieType.Length = 119;

            booking.BookedSeats = new List<Seat>();
            Seat seat1 = new Seat();
            seat1.RowNumber = 2;
            seat1.SeatNumber = 5;
            seat1.ShowroomId = 5;
            booking.BookedSeats.Add(seat1);

            Seat seat2 = new Seat();
            seat2.RowNumber = 2;
            seat2.SeatNumber = 6;
            booking.BookedSeats.Add(seat2);

            Seat seat3 = new Seat();
            seat3.RowNumber = 2;
            seat3.SeatNumber = 7;
            booking.BookedSeats.Add(seat3);

            ViewBag.CustomerName = "Oskar Brandt";
            ViewBag.CustomerEmail = "oskarbrandt@yahooo.dk";
            return View(booking);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
