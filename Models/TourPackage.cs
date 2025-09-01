namespace HopNExplore.Models

{
    public class TourPackage
    {
        public int Id { get; set; }
        public string TourName { get; set; }
        public string Location { get; set; }
        public string Destination { get; set; }
        public string Duration { get; set; }
        public string Nights { get; set; }
        public int Price { get; set; }
        public int MaxTravelers { get; set; }
        public string Status { get; set; }
        public string ShortDescription { get; set; }
        public string DetailedDescription { get; set; }
        public string Inclusions { get; set; }
        public string Thumbnail { get; set; }

        // Itinerary – Each Day
        // public List<Itinerary> Itineraries { get; set; }
    }

    // public class Itinerary
    // {
    //     public int Id { get; set; }
    //     public int TourPackageId { get; set; }
    //     public string DayTitle { get; set; }
    //     public string DayDescription { get; set; }
    // }
}