using SemesterProjekt3Web.Access;
using SemesterProjekt3Web.ApiAccess;
using SemesterProjekt3Web.Models;

namespace SemesterProjekt3Web.BusinessLogic
{
    public class BookingAccessLogic
    {
        private readonly BookingAccess api;

        public BookingAccessLogic()
        {
            var api = new BookingAccess();
        }


        public async Task<bool> AddBooking(Booking res)
        {
            bool saved;
            try
            {
                saved = await api.AddBooking(res);
            }
            catch (Exception)
            {
                saved = false;
            }

            return saved;
        }

        public async Task<Booking> GetBookingById(int id)
        {
            Booking book;

            try
            {
                book = await api.GetBookingById(id);
            }
            catch (Exception)
            {
                book = null;
            }
            return book;
        }
        public async Task<IEnumerable<Seat>> GetSeatsByBooking()
        {
            IEnumerable<Seat> seats;

            try
            {
                seats = await api.GetSeatsByBooking();
            }
            catch (Exception)
            {
                seats = null;
            }
            return seats;
        }
    }
}