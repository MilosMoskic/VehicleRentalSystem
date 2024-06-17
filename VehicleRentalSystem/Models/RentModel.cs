using VehicleRentalSystem.Interfaces;

namespace VehicleRentalSystem.Models
{
    public class RentModel : IRentModel
    {
        public Vehicle RentedVehicle { get; set; }
        public decimal RentalCost { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ReservedRentalDays { get; set; }
        public DateTime ActualReturnDate { get; set; }
        public int ActualDaysRented { get; set; }
        public int DaysRented { get; set; }
        public decimal InsuranceCost { get; set; }
        public decimal? InsuranceAddition {  get; set; }
        public decimal RentalCostPerDay { get; set; }
        public decimal InsuranceCostPerDay { get; set; }
    }
}
