namespace Sigma.UnitTest.Services;

using Microsoft.Extensions.Configuration;

using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

public class ApplicationServiceTestsBase
{
    private static IConfiguration configuration;

    public static IConfiguration Configuration
    {
        get { return configuration ??= GetConfiguration(); }
    }

    private static IConfiguration GetConfiguration()
    {
        var configurationBuilder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true)
            .AddEnvironmentVariables();

        return configurationBuilder.Build();
    }
}