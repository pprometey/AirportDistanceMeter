using AirportDistanceMeter.Domain.Constants;
using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AirportDistanceMeter.Domain.Models
{
    public record IataAirportCode
    {

        public IataAirportCode(string value)
        {

            if (Regex.IsMatch(value, IataAirportCodeConst.RegexPattern, RegexOptions.IgnoreCase))
            {
                Value = value;
            }
            else
            {
                throw new ValidationException(new List<ValidationFailure>()
                {
                    new ValidationFailure(nameof(value), IataAirportCodeConst.ErrorMessage, value)
                });
            }

        }

        public string Value { get; private set; }
    }
}
