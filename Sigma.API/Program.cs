using Sigma.API.MappingProfiles;
using Sigma.Application.DI;
using Sigma.Infrastructure.DI;

var builder = WebApplication.CreateBuilder(args);

ConfigureAutoMapper(builder.Services);

ConfigureMediator(builder.Services);

AddAppServices(builder.Services, builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

static void ConfigureMediator(IServiceCollection services)
{
    services.AddMediatR(config =>
    {
        config.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
    });
}

static void ConfigureAutoMapper(IServiceCollection services)
{
    services.AddAutoMapper(typeof(CandidateProfile).Assembly);
}

static void AddAppServices(IServiceCollection services, IConfiguration configuration)
{
    services.AddInfrastructureServices(configuration);
    services.AddApplicationServices();
}