namespace Sigma.Infrastructure.DI;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

using Sigma.Domain.AggregateModels.CandidateAggregate;
using Sigma.Infrastructure.Repositories;

public static class DependenciesConfigurator
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddServices();
    }

    private static void AddServices(this IServiceCollection services)
    {
        services.TryAddScoped<ICandidateRepository, CandidateRepository>();
    }
}