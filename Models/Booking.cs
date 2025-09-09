namespace HopNExplore.Models
{
    public class Booking
    {
        public int BookingId { get; set; }

        public int TourPackageId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public int NumberOfTravelers { get; set; }

        public string Address { get; set; }

        public DateTime BookingDate { get; set; } = DateTime.Now;

        public DateTime PreferredDates { get; set; }



        public string SpecialRequests { get; set; }

        public string PaymentStatus { get; set; } = "Pending";

        public string BookingStatus { get; set; } = "Confirmed";

        // 🔗 Navigation Property
        // public virtual TourPackage? TourPackage { get; set; }
    }
}