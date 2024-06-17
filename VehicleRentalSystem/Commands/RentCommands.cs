using Cocona;
using VehicleRentalSystem.Data;
using VehicleRentalSystem.Interfaces;
using VehicleRentalSystem.Models;

namespace VehicleRentalSystem.Commands
{
    public class RentCommands : IRentCommands
    {
        private readonly IRentService _rentService;
        private readonly IVehicleData _vehicleData;
        public RentCommands(IRentService rentService, IVehicleData vehicleData) 
        { 
            _rentService = rentService;
            _vehicleData = vehicleData;
        }

        static Vehicle RentedCar = new Vehicle
        {
            Brand = "Mitsubishi",
            Model = "Mirage",
            Type = CarTypes.Car,
            Value = 15000,
            SafetyRating = 3
        };

        static Vehicle rentedMotorcycle = new Vehicle
        {
            Brand = "Triumph",
            Model = "Tiger Sport 660",
            Type = CarTypes.Motorcycles,
            Value = 10000,
            RidersAge = 20
        };

        static Vehicle rentedCargoVan = new Vehicle
        {
            Brand = "Citroen",
            Model = "Jumper",
            Type = CarTypes.CargoVan,
            Value = 20000,
            DriversExperience = 8
        };

        RentModel rentedCarModel = new RentModel
        {
            RentedVehicle = RentedCar,
            StartDate = Convert.ToDateTime("06/03/2024"),
            EndDate = Convert.ToDateTime("06/13/2024"),
            ActualReturnDate = Convert.ToDateTime("06/13/2024")
        };

        RentModel rentedMotorcycleModel = new RentModel
        {
            RentedVehicle = rentedMotorcycle,
            StartDate = Convert.ToDateTime("06/03/2024"),
            EndDate = Convert.ToDateTime("06/13/2024"),
            ActualReturnDate = Convert.ToDateTime("06/13/2024")
        };

        RentModel rentedCargoVanModel = new RentModel
        {
            RentedVehicle = rentedCargoVan,
            StartDate = Convert.ToDateTime("06/03/2024"),
            EndDate = Convert.ToDateTime("06/13/2024"),
            ActualReturnDate = Convert.ToDateTime("06/13/2024")
        };

        [Command("PrintCar")]
        public string PrintCar()
        {
            var car = _rentService.CarCalculations(rentedCarModel);
            return "XXXXXXXXXX\n" +
                $"Date: {car.ActualReturnDate:yyyy-MM-dd}\n" +
                $"Customer Name: John Doe\n" +
                $"Rented Vehicle: {car.RentedVehicle.Brand} {car.RentedVehicle.Model}\n\n" +
                $"Reservation Start Date: {car.StartDate:yyyy-MM-dd}\n" +
                $"Reservation End Date: {car.EndDate:yyyy-MM-dd}\n" +
                $"Reserved Rental Days: {car.ReservedRentalDays} days\n\n" +
                $"Actual Return Date: {car.ActualReturnDate:yyyy-MM-dd}\n" +
                $"Actual Rental Days: {car.ActualDaysRented}\n\n" +
                $"Rental Cost Per Day: ${car.RentalCostPerDay}\n" +
                $"Insurance Per Day: ${car.InsuranceCostPerDay:0.00}\n\n" +
                $"Total Rent: ${car.RentalCost}\n" +
                $"Total Insurance: ${car.InsuranceCost:0.00}\n" +
                $"Total: ${(car.RentalCost + car.InsuranceCost):0.00}\n" +
                $"XXXXXXXXXX";
        }

        [Command("PrintMotorcycle")]
        public string PrintMotorcycle()
        {
            var motorcycle = _rentService.MotorcycleCalculations(rentedMotorcycleModel);
            return "XXXXXXXXXX\n" +
                $"Date: {motorcycle.ActualReturnDate:yyyy-MM-dd}\n" +
                $"Customer Name: Mary Johnson\n" +
                $"Rented Vehicle: {motorcycle.RentedVehicle.Brand} {motorcycle.RentedVehicle.Model}\n\n" +
                $"Reservation Start Date: {motorcycle.StartDate}\n" +
                $"Reservation End Date: {motorcycle.EndDate}\n" +
                $"Reserved Rental Days: {motorcycle.ReservedRentalDays:yyyy-MM-dd} days\n\n" +
                $"Actual Return Date: {motorcycle.ActualReturnDate}\n" +
                $"Actual Rental Days: {motorcycle.ActualDaysRented}\n\n" +
                $"Rental Cost Per Day: ${motorcycle.RentalCostPerDay:0.00}\n" +
                $"Initial Insurance Per Day: ${motorcycle.InsuranceCostPerDay:0.00}\n" +
                $"Insurance Addition Per Day: ${motorcycle.InsuranceAddition:0.00}\n"  + 
                $"Insurance Per Day: ${motorcycle.InsuranceCost + motorcycle.InsuranceAddition:0.00}\n\n" +
                $"Total Rent: ${motorcycle.RentalCost:0.00}\n" +
                $"Total Insurance: ${motorcycle.InsuranceCost:0.00}\n" +
                $"Total: ${motorcycle.RentalCost + motorcycle.InsuranceCost + motorcycle.InsuranceAddition:0.00}\n" +
                $"XXXXXXXXXX";
        }

        [Command("PrintCargoVan")]
        public string PrintCargoVan()
        {
            var cargoVan = _rentService.CargoVanCalculations(rentedCargoVanModel);
            return "XXXXXXXXXX\n" +
                $"Date: {cargoVan.ActualReturnDate:yyyy-MM-dd}\n" +
                $"Customer Name: John Doe\n" +
                $"Rented Vehicle: {cargoVan.RentedVehicle.Brand} {cargoVan.RentedVehicle.Model}\n\n" +
                $"Reservation Start Date: {cargoVan.StartDate}\n" +
                $"Reservation End Date: {cargoVan.EndDate}\n" +
                $"Reserved Rental Date: {cargoVan.ReservedRentalDays:yyyy-MM-dd}\n\n" +
                $"Actual Return Date: {cargoVan.ActualReturnDate}\n" +
                $"Actual Rental Days: {cargoVan.ActualDaysRented}\n\n" +
                $"Rental Cost Per Day: ${cargoVan.RentalCostPerDay:0.00}\n" +
                $"Initial Insurance Per Day: ${cargoVan.InsuranceCostPerDay:0.00}\n" +
                $"Insurance Addition Per Day: ${cargoVan.InsuranceAddition:0.00}\n" +
                $"Insurance Per Day: ${cargoVan.InsuranceCost + cargoVan.InsuranceAddition:0.00}\n\n" +
                $"Total Rent: ${cargoVan.RentalCost:0.00}\n" +
                $"Total Insurance: ${cargoVan.InsuranceCost:0.00}\n" +
                $"Total: ${cargoVan.RentalCost + cargoVan.InsuranceCost + cargoVan.InsuranceAddition:0.00}\n" +
                $"XXXXXXXXXX";
        }
    }
}
