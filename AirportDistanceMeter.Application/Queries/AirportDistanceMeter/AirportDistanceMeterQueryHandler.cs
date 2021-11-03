using AirportDistanceMeter.Application.Repositories;
using AirportDistanceMeter.Domain.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AirportDistanceMeter.Application.Queries.AirportDistanceMeter
{
    public class AirportDistanceMeterQueryHandler : IRequestHandler<AirportDistanceMeterQuery, AirportDistanceMeterViewModel>
    {
        private readonly IAirportDistanceMeterQueryRepository _airportDistanceMeterQueryRepository;

        public AirportDistanceMeterQueryHandler(IAirportDistanceMeterQueryRepository airportDistanceMeterQueryRepository)
        {
            _airportDistanceMeterQueryRepository = airportDistanceMeterQueryRepository;
        }

        public async Task<AirportDistanceMeterViewModel> Handle(AirportDistanceMeterQuery request,
            CancellationToken cancellationToken)
        {
            return await _airportDistanceMeterQueryRepository.GetDistanceBetweenTwoAirportsAsync(
                new IataAirportCode(request.DepartureAirportCode), new IataAirportCode(request.DestinationAirportCode));
        }
    }
}
