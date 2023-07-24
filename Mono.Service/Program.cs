using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Mono.Service.Mapper;
using Mono.Service.MonoDbContext;
using Mono.Service.Services;
using Serilog;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Text.Json;
using Mono.Service.Interfaces;

//No need to use Ninject in .NET core
//NinjectWebCommon.Start();

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Error()
    .Enrich.FromLogContext()
    .WriteTo.File($@"{Directory.GetCurrentDirectory()}\Logs\log.txt")
    .CreateLogger();

var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new MappingProfile());
});

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<MonoContext>(opts =>
{
    opts.UseSqlServer(
    builder.Configuration["ConnectionStrings:Default"]);
});

builder.Services.AddLogging(loggingBuilder =>
    loggingBuilder.AddSerilog(dispose: true));

var mapper = config.CreateMapper();

builder.Services.AddControllers().AddJsonOptions(x => 
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Mono API",
        Description = "A sample Web API.",
        Contact = new OpenApiContact
        {
            Name = "Marin Mikleušević",
            Email = "mikleusevicmarin@gmail.com",
            Url = new Uri("https://www.linkedin.com/in/marin-mikleušević-80aaaa145/")
        },
        Version = "v1"
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    c.IncludeXmlComments(xmlPath);
});

string[] origins = builder.Configuration["Addresses:Origins"]!.Split(';');

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
        builder.WithOrigins(origins)
           .AllowAnyMethod()
           .AllowAnyHeader()
           .AllowCredentials());
});

builder.Services.AddSingleton(mapper);

// Instead of Ninject
builder.Services.AddScoped<IVehicleMakeService, VehicleMakeService>();
builder.Services.AddScoped<IVehicleModelService, VehicleModelService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
