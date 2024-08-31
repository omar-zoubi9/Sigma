namespace Sigma.Application.DI;

using FluentValidation;
using FluentValidation.AspNetCore;

using MediatR;

using Microsoft.Extensions.DependencyInjection;
using Sigma.Application.Command.Candidate;
using Sigma.Application.Validations;
using Sigma.Application.Validations.Candidate;

public static class DependenciesConfigurator
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.ConfigureValidation();
    }

    private static void ConfigureValidation(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();

        services.AddTransient<IValidator<CandidateCommand>, CandidateValidator>();

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
    }
}