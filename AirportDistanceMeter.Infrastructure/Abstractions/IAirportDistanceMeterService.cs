using AirportDistanceMeter.Infrastructure.Models;
using System.Threading.Tasks;

namespace AirportDistanceMeter.Infrastructure.Abstractions
{
    public interface IAirportDistanceMeterService
    {
        Task<double> GetDistanceAsync(Location departureLocation, Location destinationLocation);
    }
}
