using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SemesterProjekt3Web.ApiAccess;
using SemesterProjekt3Web.Models;
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

        public async Task<IActionResult> CustomerInfoAsync()
        {
            Booking newBooking = new Booking();
            newBooking.BookingId = 36;
            newBooking.Total = 249.99;
            newBooking.TimeOfPurchase = new DateTime(2023, 05, 05, 13, 32, 55);

            newBooking.Showing = new Showing();
            newBooking.Showing.startTime = new DateTime(2023, 05, 12, 15, 30, 00);
            newBooking.Showing.MovieCopy = new MovieCopy();

            newBooking.Showing.MovieCopy.MovieType = new MovieInfo();

            newBooking.Showing.MovieCopy.MovieType.Title = "Shrek 2";
            newBooking.Showing.MovieCopy.MovieType.Length = 119;

            newBooking.BookedSeats = new List<Seat>();
            Seat seat1 = new Seat();
            seat1.RowNumber = 2;
            seat1.SeatNumber = 5;
            seat1.ShowroomId = 5;
            newBooking.BookedSeats.Add(seat1);

            Seat seat2 = new Seat();
            seat2.RowNumber = 2;
            seat2.SeatNumber = 6;
            newBooking.BookedSeats.Add(seat2);

            Seat seat3 = new Seat();
            seat3.RowNumber = 2;
            seat3.SeatNumber = 8;
            newBooking.BookedSeats.Add(seat3);

            BookingAccess ba = new BookingAccess();
            Booking otherBooking = await ba.GetBookingById(1);
            Console.WriteLine(otherBooking);

            return View(newBooking);
        }

        public async Task<IActionResult> ReceiptAsync(string name, string email, string phoneNo, string booking)
        {
            Console.WriteLine(booking);
            Booking realBooking = JsonConvert.DeserializeObject<Booking>(booking);
            realBooking.CustomerPhone = phoneNo;
            ViewBag.CustomerName = name;
            ViewBag.CustomerEmail = email;
            BookingAccess ba = new BookingAccess();
            await ba.AddBooking(realBooking);

            return View(realBooking);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
