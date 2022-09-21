using ReportingService.API.Infastructure;
using System.Data.SqlClient;
using System.Data;
using ReportingService.API.Extensions;
using ReportingService.API.Middleware;
using NLog;
using NLog.Web;
using ReportingService.Business.Services;

var builder = WebApplication.CreateBuilder(args);


var connectionOption = new ConnectionOptions();
builder.Configuration.Bind(connectionOption);
builder.Host.UseNLog();
LogManager.Configuration.Variables[$"{builder.Environment: LOG_DIRECTORY}"] = "Logs";
builder.Services.AddScoped<IDbConnection>(sp => new SqlConnection(connectionOption.REPORTING_CONNECTION_STRING));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDataLayerRepositories();
builder.Services.AddBusinessLayerServices();
builder.Services.AddHostedService<Worker>(); 

builder.Services.AddConsumers();

builder.Services.AddAutoMapper();

var app = builder.Build();

app.ConfigureHeathCheck();
app.UseMiddleware<CustomExceptionHandlerMiddleware>();
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();