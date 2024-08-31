namespace Sigma.Infrastructure.DI;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Sigma.Domain.AggregateModels.CandidateAggregate;
using Sigma.Infrastructure.Factories;

public static class DependenciesConfigurator
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddServices(configuration);
    }

    private static void AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICandidateRepositoryFactory, CandidateRepositoryFactory>(provider =>
        {
            return new CandidateRepositoryFactory(configuration["AppSettings:CsvFilePath"], configuration["AppSettings:RepositpryType"]);
        });
    }
}