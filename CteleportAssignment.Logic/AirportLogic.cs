using CteleportAssignment.Domain.Interfaces;
using System;

namespace CteleportAssignment.Logic
{
    public class AirportLogic : BaseLogic
    {
        public AirportLogic(IUnitofWork uow) : base(uow)
        {
        }


        public double GetDistanceBetweenAirports(string AirPortcode1, string AirportCode2)
        {
            var location1 = GetCoordinatesForAirportCode(AirPortcode1);
            var location2 = GetCoordinatesForAirportCode(AirportCode2);

            var distInMeters = GetDistanceInMeters(location1, location2);

            var distInMiles = ConvertToMiles(distInMeters);
            return distInMiles;
        }

        private double ConvertToMiles(double distInMeters)
        {
            return distInMeters / 1609.344;
        }

        private Location GetCoordinatesForAirportCode(string airportCode)
        {
            var airport = Uow.AirportRepo.GetAirportByCode(airportCode);

            return new Location()
            {
                Latitude = airport.Latitude,
                Longitude = airport.Longitude,
            };
        }

        private double GetDistanceInMeters(Location point1, Location point2)
        {
            var d1 = Decimal.ToDouble(point1.Latitude) * (Math.PI / 180.0);
            var num1 = Decimal.ToDouble(point1.Longitude) * (Math.PI / 180.0);
            var d2 = Decimal.ToDouble(point2.Latitude) * (Math.PI / 180.0);
            var num2 = Decimal.ToDouble(point2.Longitude) * (Math.PI / 180.0) - num1;
            var d3 = Math.Pow(Math.Sin((d2 - d1) / 2.0), 2.0) + Math.Cos(d1) * Math.Cos(d2) * Math.Pow(Math.Sin(num2 / 2.0), 2.0);

            return 6376500.0 * (2.0 * Math.Atan2(Math.Sqrt(d3), Math.Sqrt(1.0 - d3)));
        }


    }

    public class Location
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
