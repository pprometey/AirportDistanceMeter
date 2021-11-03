using AirportDistanceMeter.Application.Queries.AirportDistanceMeter;
using AirportDistanceMeter.Domain.Models;
using System.Threading.Tasks;

namespace AirportDistanceMeter.Application.Repositories
{
    public interface IAirportDistanceMeterQueryRepository
    {
        Task<AirportDistanceMeterViewModel> GetDistanceBetweenTwoAirportsAsync(
            IataAirportCode departureAirportCode, IataAirportCode destinationAirportCod);
    }
}
