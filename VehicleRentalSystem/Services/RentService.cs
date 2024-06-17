using VehicleRentalSystem.Data;
using VehicleRentalSystem.Interfaces;
using VehicleRentalSystem.Models;

namespace VehicleRentalSystem.Services
{
    public class RentService : IRentService
    {
        private readonly IRentModel _rentModel;
        public RentService(IRentModel rentModel) 
        {
            _rentModel = rentModel;
        }

        public RentModel CarCalculations(RentModel rent)
        {
            if(rent.RentedVehicle.Type != CarTypes.Car)
            {
                return null;
            }

            ReturnedAhead(rent, 20, 15);
            rent.RentalCostPerDay = rent.RentalCost / rent.ActualDaysRented;

            rent.InsuranceCostPerDay = rent.RentedVehicle.Value * 0.0001m;

            rent.InsuranceCost = rent.InsuranceCostPerDay * rent.ActualDaysRented;

            if (rent.RentedVehicle.SafetyRating > 4)
            {
                rent.InsuranceCost -= rent.InsuranceCost * (10 / 100);
                return rent;
            }

            return rent;
        }

        public RentModel MotorcycleCalculations(RentModel rent)
        {
            if (rent.RentedVehicle.Type != CarTypes.Motorcycles)
            {
                return null;
            }

            ReturnedAhead(rent, 15, 10);
            rent.RentalCostPerDay = rent.RentalCost / rent.ActualDaysRented;

            rent.InsuranceCostPerDay = rent.RentedVehicle.Value * 0.0002m;

            rent.InsuranceCost = rent.InsuranceCostPerDay * rent.ActualDaysRented;

            if (rent.RentedVehicle.RidersAge < 25)
            {
                rent.InsuranceAddition = rent.InsuranceCost * 0.2m;
                return rent;
            }

            return rent;
        }

        public RentModel CargoVanCalculations(RentModel rent)
        {
            if (rent.RentedVehicle.Type != CarTypes.CargoVan)
            {
                return null;
            }

            ReturnedAhead(rent, 50, 40);
            rent.RentalCostPerDay = rent.RentalCost / rent.ActualDaysRented;

            rent.InsuranceCostPerDay = rent.RentedVehicle.Value * 0.0003m;

            rent.InsuranceCost = rent.InsuranceCostPerDay * rent.ActualDaysRented;

            if (rent.RentedVehicle.DriversExperience > 5)
            {
                rent.InsuranceAddition = rent.InsuranceCost * 0.15m;
                return rent;
            }

            return rent;
        }

        private RentModel ReturnedAhead(RentModel rent, int rentPerDay, int discountedRent)
        {
            int halfRent = discountedRent / 2;

            var actualRentDays = rent.ActualReturnDate - rent.StartDate;
            var rentDays = (int)actualRentDays.TotalDays;
            rent.ActualDaysRented = rentDays;

            var reservedRentalDays = rent.EndDate - rent.StartDate;
            var resRentalDays = (int)reservedRentalDays.TotalDays;
            rent.ReservedRentalDays = resRentalDays;

            rent.RentalCost = rentDays * rentPerDay;

            var restOfTheDays = rent.ActualReturnDate.Day - rentDays;

            if (rentDays > 7)
            {
                rent.RentalCost = rentDays * discountedRent;
                return rent;
            }

            rent.RentalCost += restOfTheDays * halfRent;

            return rent;
        }
    }
}
