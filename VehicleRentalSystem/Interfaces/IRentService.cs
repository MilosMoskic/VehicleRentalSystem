using VehicleRentalSystem.Models;

namespace VehicleRentalSystem.Interfaces
{
    public interface IRentService
    {
        RentModel CarCalculations(RentModel rent);
        RentModel MotorcycleCalculations(RentModel rent);
        RentModel CargoVanCalculations(RentModel rent);
    }
}
