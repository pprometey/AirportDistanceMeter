using FluentValidation;
using System.Collections.Generic;

namespace Common.Infrastructure.Tools.Errors.Models
{
    public class ValidationErrors
    {
        public List<ValidationError> Errors { get; set; } = new List<ValidationError>();
    }

    public class ValidationError
    {
        public string Location { get; set; }
        public string Param { get; set; }
        public string Value { get; set; }
        public string Msg { get; set; }
    }

    public static partial class Errors
    {
        public static ValidationErrors ToBadRequestObjectResult(this ValidationException validationException)
        {
            var errors = new ValidationErrors();
            foreach (var e in validationException.Errors)
            {
                var validationError = new ValidationError()
                {
                    Location = "params",
                    Param = e.PropertyName,
                    Value = e.AttemptedValue.ToString(),
                    Msg = e.ErrorMessage
                };
                errors.Errors.Add(validationError);
            }
            return errors;
        }
    }
}
