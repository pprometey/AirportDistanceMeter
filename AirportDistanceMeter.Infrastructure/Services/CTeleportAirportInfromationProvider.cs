using AirportDistanceMeter.Domain.Models;
using AirportDistanceMeter.Infrastructure.Abstractions;
using AirportDistanceMeter.Infrastructure.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AirportDistanceMeter.Infrastructure.Services
{
    public class CTeleportAirportInfromationProvider : IAirportInformationService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _client;

        private readonly string _endpoint = "https://places-dev.cteleport.com/airports/";
        public CTeleportAirportInfromationProvider(IConfiguration configuration, IHttpClientFactory clientFactory)
        {
            _configuration = configuration;
            _endpoint = _configuration["CTeleportAirportInfromationProvider:AirportsEndpoint"] ?? this._endpoint;
            _client = clientFactory.CreateClient("AirportDistanceMeter");

        }

        public async Task<AirportInformation> GetAirportInformationAsync(IataAirportCode airportCode)
        {
            var response = new HttpResponseMessage();

            response = await _client.GetAsync(_endpoint + airportCode.Value);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var jsonObject = JObject.Parse(content);
                return _ = jsonObject.ToObject<AirportInformation>();
            }
            else throw new HttpRequestException($"Get airport information request by IATA code: {airportCode} has finished with result {(int)response.StatusCode}: {response.ReasonPhrase}");

        }

    }
}
