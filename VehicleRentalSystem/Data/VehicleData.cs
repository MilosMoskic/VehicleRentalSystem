using VehicleRentalSystem.Interfaces;
using VehicleRentalSystem.Models;

namespace VehicleRentalSystem.Data
{
    public class VehicleData : IVehicleData
    {
        Vehicle RentedCar = new Vehicle
        {
            Brand = "Mitsubishi",
            Model = "Mirage",
            Value = 15000,
            SafetyRating = 3
        };

        Vehicle rentedMotorcycle = new Vehicle
        {
            Brand = "Triumph",
            Model = "Tiger Sport 660",
            Value = 10000,
            RidersAge = 20
        };

        Vehicle rentedCargoVan = new Vehicle
        {
            Brand = "Citroen",
            Model = "Jumper",
            Value = 20000,
            DriversExperience = 8
        };
    }
}
