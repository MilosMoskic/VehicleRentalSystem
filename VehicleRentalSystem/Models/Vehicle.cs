namespace VehicleRentalSystem.Models
{
    public class Vehicle
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public decimal Value { get; set; }
        public int? RidersAge { get; set; }
        public int? DriversExperience { get; set; }
        public int? SafetyRating { get; set; }
    }
}
