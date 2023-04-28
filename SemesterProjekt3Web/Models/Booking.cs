﻿namespace SemesterProjekt3Web.Models
{
    public class Booking
    {

        public int BookingId { get; set; }
        public DateTime TimeOfPurchase { get; set; }
        public double Total { get; set; }
        public String CustomerPhone { get; set; }
        public List<Seat> BookedSeats { get; set; }

    }
}
