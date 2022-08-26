using ReportingService.API;
using ReportingService.API.Infastructure;
using ReportingService.Business;
using ReportingService.Data.Repositories;
using System.Data.SqlClient;
using System.Data;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
IWebHostEnvironment environment = builder.Environment;

var connectionOption = new ConnectionOption();
builder.Configuration.Bind(connectionOption);
builder.Services.AddScoped<IDbConnection>(sp => new SqlConnection(connectionOption.REPORTINGSERVICE_DB_CONNECTION_STRING));
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAccountsRepository, AccountsRepository>();
builder.Services.AddScoped<ILeadInformationsRepository, LeadInformationsRepository>();
builder.Services.AddScoped<ILeadStatisticsRepository, LeadStatisticsRepository>();
builder.Services.AddScoped<IStatisticsRepository, StatisticsRepository>();
builder.Services.AddScoped<ITransactionsRepositiry, TransactionsRepositiry>();

builder.Services.AddAutoMapper(typeof(MapperConfig));


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
