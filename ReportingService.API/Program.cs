using ReportingService.API;
using ReportingService.API.Infastructure;
using ReportingService.Data.Repositories;
using System.Data.SqlClient;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

var connectionOption = new ConnectionOptions();
builder.Configuration.Bind(connectionOption);
builder.Services.AddScoped<IDbConnection>(sp => new SqlConnection(connectionOption.REPORTING_SERVICE_DB_CONNECTION_STRING));
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// move to extension method
builder.Services.AddScoped<IAccountsRepository, AccountsRepository>();
builder.Services.AddScoped<ILeadInfoRepository, LeadInfoRepository>();
builder.Services.AddScoped<ILeadOverallStatisticsRepository, LeadOverallStatisticsRepository>();
builder.Services.AddScoped<IStatisticsRepository, StatisticsRepository>();
builder.Services.AddScoped<ITransactionsRepository, TransactionsRepository>();

builder.Services.AddAutoMapper(typeof(BusinessModelsMapperConfig));


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
