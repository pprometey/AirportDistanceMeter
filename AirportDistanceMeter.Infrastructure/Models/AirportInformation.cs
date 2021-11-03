namespace AirportDistanceMeter.Infrastructure.Models
{
    public class AirportInformation
    {
        public string Country { get; set; }
        public string City_iata { get; set; }
        public string Iata { get; set; }
        public string City { get; set; }
        public string Timezone_Region_Name { get; set; }
        public string Country_Iata { get; set; }
        public int Rating { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Hubs { get; set; }
        public Location Location { get; set; }
    }

    public class Location
    {
        public double Lon { get; set; }
        public double Lat { get; set; }

    }
}
