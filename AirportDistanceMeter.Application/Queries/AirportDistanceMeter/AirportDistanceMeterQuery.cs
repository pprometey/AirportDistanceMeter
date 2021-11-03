using MediatR;

namespace AirportDistanceMeter.Application.Queries.AirportDistanceMeter
{
    /// <summary>
    /// Query class for airport distance meter
    /// </summary>
    public class AirportDistanceMeterQuery : IRequest<AirportDistanceMeterViewModel>
    {
        /// <summary>
        /// Departure airport IATA code
        /// </summary>
        public string DepartureAirportCode { get; set; }

        /// <summary>
        /// Destination airport IATA code
        /// </summary>
        public string DestinationAirportCode { get; set; }
    }
}
