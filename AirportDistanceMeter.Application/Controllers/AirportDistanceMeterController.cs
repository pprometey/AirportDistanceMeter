using AirportDistanceMeter.Application.Queries.AirportDistanceMeter;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AirportDistanceMeter.Application.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AirportDistanceMeterController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AirportDistanceMeterController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get distance  between two airports
        /// </summary>
        /// <param name="departureAirportCode">Departure airport IATA code</param>
        /// <param name="destinationAirportCode">Destination airport IATA code</param>
        /// <returns></returns>
        [HttpGet("{departureAirportCode}/{destinationAirportCode}")]
        [ProducesResponseType(typeof(AirportDistanceMeterViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<AirportDistanceMeterViewModel>> GetDistanceBetweenTwoAirports(string departureAirportCode, string destinationAirportCode)
        {
            return Ok(await _mediator.Send(new AirportDistanceMeterQuery
            {
                DepartureAirportCode = departureAirportCode,
                DestinationAirportCode = destinationAirportCode
            }));
        }
    }
}
