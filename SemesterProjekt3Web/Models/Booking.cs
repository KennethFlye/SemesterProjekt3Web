namespace SemesterProjekt3Web.Models
{
    public class Booking
    {
        public Booking()
        {
            TimeOfPurchase = DateTime.Now;
            Total = 20;
            CustomerPhone = "48939457";
            BookedSeats = null;
            Showing = null;
        }

        public int BookingId { get; set; }
        public DateTime TimeOfPurchase { get; set; }
        public double Total { get; set; }
        public String? CustomerPhone { get; set; }
        public List<Seat> BookedSeats { get; set; }
        public Showing Showing { get; set; }

    }
}
