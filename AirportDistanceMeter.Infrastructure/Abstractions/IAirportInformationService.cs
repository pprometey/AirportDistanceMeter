using AirportDistanceMeter.Domain.Models;
using AirportDistanceMeter.Infrastructure.Models;
using System.Threading.Tasks;

namespace AirportDistanceMeter.Infrastructure.Abstractions
{
    public interface IAirportInformationService
    {
        public Task<AirportInformation> GetAirportInformationAsync(IataAirportCode airportCode);
    }
}
