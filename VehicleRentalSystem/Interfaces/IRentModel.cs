using VehicleRentalSystem.Models;

namespace VehicleRentalSystem.Interfaces
{
    public interface IRentModel
    {
        public Vehicle RentedVehicle { get; set; }
        public decimal RentalCost { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime ActualReturnDate { get; set; }
        public int ActualDaysRented { get; set; }
        public int DaysRented { get; set; }
        public decimal InsuranceCost { get; set; }
        public decimal RentalCostPerDay { get; set; }
        public decimal InsuranceCostPerDay { get; set; }
    }
}
