namespace AirportDistanceMeter.Application.Queries.AirportDistanceMeter
{
    /// <summary>
    /// View model class for airport distance meter
    /// </summary>
    public class AirportDistanceMeterViewModel
    {
        public AirportDistanceMeterViewModel(double distance)
        {
            this.Distance = distance;
        }

        /// <summary>
        /// Distance between two airports
        /// </summary>
        public double Distance { get; set; }
    }
}
