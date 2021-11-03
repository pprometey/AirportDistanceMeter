using AirportDistanceMeter.Infrastructure.Abstractions;
using AirportDistanceMeter.Infrastructure.Models;
using System;
using System.Threading.Tasks;

namespace AirportDistanceMeter.Infrastructure.Services
{
    public class HaversineDistanceMeterProvider : IAirportDistanceMeterService
    {
        private const double _radiusEarthInMiles = 3956;

        public Task<double> GetDistanceAsync(Location departureLocation, Location destinationLocation)
        {
            return Task.Run(() => GetDistance(departureLocation.Lat, departureLocation.Lon,
                destinationLocation.Lat, destinationLocation.Lon));

        }

        private static double GetDistance(double lat1, double lon1, double lat2, double lon2)
        {
            // The math module contains a function named ToRadians which converts from degrees to radians.
            lon1 = ToRadians(lon1);
            lon2 = ToRadians(lon2);
            lat1 = ToRadians(lat1);
            lat2 = ToRadians(lat2);

            // Haversine formula
            double dlon = lon2 - lon1;
            double dlat = lat2 - lat1;
            double a = Math.Pow(Math.Sin(dlat / 2), 2) +
                       Math.Cos(lat1) * Math.Cos(lat2) *
                       Math.Pow(Math.Sin(dlon / 2), 2);

            double c = 2 * Math.Asin(Math.Sqrt(a));

            // calculate the result
            return (c * _radiusEarthInMiles);
        }

        private static double ToRadians(double angleIn10thofaDegree)
        {
            return (angleIn10thofaDegree * Math.PI) / 180;
        }
    }
}
