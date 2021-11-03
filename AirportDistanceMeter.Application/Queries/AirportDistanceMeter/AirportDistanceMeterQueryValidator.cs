using AirportDistanceMeter.Domain.Constants;
using FluentValidation;

namespace AirportDistanceMeter.Application.Queries.AirportDistanceMeter
{
    public class AirportDistanceMeterQueryValidator : AbstractValidator<AirportDistanceMeterQuery>
    {
        public AirportDistanceMeterQueryValidator()
        {
            RuleFor(x => x.DepartureAirportCode)
                .NotEmpty()
                .Matches(IataAirportCodeConst.RegexPattern).WithMessage(IataAirportCodeConst.ErrorMessage);

            RuleFor(x => x.DestinationAirportCode)
                .NotEmpty()
                .Matches(IataAirportCodeConst.RegexPattern).WithMessage(IataAirportCodeConst.ErrorMessage);
        }
    }
}

