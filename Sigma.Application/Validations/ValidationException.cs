namespace Sigma.Application.Exceptions
{
    using Sigma.Application.Validations;
    using System.Collections.Generic;

    public class ValidationException : Exception
    {
        public IEnumerable<ValidationError> Errors { get; }

        public ValidationException(IEnumerable<ValidationError> errors) : base("One or more validation errors occurred.")
        {
            Errors = errors;
        }
    }
}