using AirportDistanceMeter.Application.Queries.AirportDistanceMeter;
using AirportDistanceMeter.Application.Repositories;
using AirportDistanceMeter.Domain.Models;
using AirportDistanceMeter.Infrastructure.Abstractions;
using System.Threading.Tasks;

namespace AirportDistanceMeter.Infrastructure.Repositories
{
    public class AirportDistanceMeterQueryRepository : IAirportDistanceMeterQueryRepository
    {
        private readonly IAirportInformationService _airportInformationService;
        private readonly IAirportDistanceMeterService _airportDistanceMeterService;

        public AirportDistanceMeterQueryRepository(IAirportInformationService airportInformationService,
            IAirportDistanceMeterService airportDistanceMeterService)
        {
            _airportInformationService = airportInformationService;
            _airportDistanceMeterService = airportDistanceMeterService;
        }

        public async Task<AirportDistanceMeterViewModel> GetDistanceBetweenTwoAirportsAsync(
            IataAirportCode departureAirportCode, IataAirportCode destinationAirportCode)
        {

            var departureAirport = await _airportInformationService.GetAirportInformationAsync(departureAirportCode);
            var destinationAirport = await _airportInformationService.GetAirportInformationAsync(destinationAirportCode);

            var distance = await _airportDistanceMeterService.GetDistanceAsync(departureAirport.Location, destinationAirport.Location);
            return new AirportDistanceMeterViewModel(distance);
        }
    }
}
