namespace Sigma.Application.Validations;

using FluentValidation;

using MediatR;

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators ?? throw new ArgumentNullException(nameof(validators));

        if (!_validators.Any())
        {
            throw new InvalidOperationException("No validators were registered.");
        }
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);

        var validationTasks = _validators.Select(validator => validator.ValidateAsync(context, cancellationToken));
        var validationFailures = await Task.WhenAll(validationTasks);

        var errors = validationFailures
            .SelectMany(validationResult => validationResult.Errors)
            .Where(error => error != null)
            .Select(error => new ValidationError(error.PropertyName, error.ErrorMessage))
            .ToList();

        if (errors.Any())
        {
            throw new Exceptions.ValidationException(errors);
        }

        return await next();
    }
}