using ReportingService.API;
using ReportingService.API.Infastructure;
using System.Data.SqlClient;
using System.Data;
using ReportingService.API.Extensions;
using ReportingService.API.Middleware;

var builder = WebApplication.CreateBuilder(args);

var connectionOption = new ConnectionOptions();
builder.Configuration.Bind(connectionOption);
builder.Services.AddScoped<IDbConnection>(sp => new SqlConnection(connectionOption.REPORTING_SERVICE_DB_CONNECTION_STRING));
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDataLayerRepositotories();
builder.Services.AddBusinessLayerServices();

builder.Services.AddAutoMapper();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseMiddleware<CustomExceptionHandlerMiddleware>();
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
