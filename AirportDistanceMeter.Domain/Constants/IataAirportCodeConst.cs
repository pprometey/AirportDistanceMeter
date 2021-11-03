namespace AirportDistanceMeter.Domain.Constants
{
    public static class IataAirportCodeConst
    {
        public const string RegexPattern = @"^[A-Za-z]{3}$";
        public const string ErrorMessage = "Invalid IATA airport code"; //or = ErrorMessages.IataAirportCodeErrorMessage
    }
}
