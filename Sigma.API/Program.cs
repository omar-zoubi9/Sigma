using AutoMapper;

using Sigma.API.MappingProfiles;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ConfigureAutoMapper(builder);

ConfigureMediator(builder.Services);

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
    services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(typeof(Program).Assembly));
}

static void ConfigureAutoMapper(WebApplicationBuilder builder)
{
    builder.Services.AddSingleton(provider => new MapperConfiguration(configuration =>
    {
        // configuration.ConfigureApplicationMapperProfiles(provider);
        configuration.AddProfile(new CandidateProfile());
    }).CreateMapper());
}