using ReportingService.API;
using ReportingService.Business;
using ReportingService.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

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

builder.Services.AddAutoMapper(typeof(MapperConfigStorageAPI));
builder.Services.AddAutoMapper(typeof(MapperConfigStorageBusiness));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
