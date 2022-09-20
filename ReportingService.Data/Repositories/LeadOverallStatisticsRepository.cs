using Dapper;
using Microsoft.Extensions.Logging;
using ReportingService.Data.Dto;
using System.Data;
using System.Data.SqlClient;

namespace ReportingService.Data.Repositories;

public class LeadOverallStatisticsRepository : BaseRepositories, ILeadOverallStatisticsRepository
{
    private readonly ILogger<LeadOverallStatisticsRepository> _logger;

    public LeadOverallStatisticsRepository(IDbConnection dbConnection, ILogger<LeadOverallStatisticsRepository> logger)
        : base(dbConnection)
    {
        _logger = logger;
    }

    public async Task AddLeadStatistic(List<LeadOverallStatisticsDto> statistics)
    {
        DataTable data = new DataTable();
        data.Columns.Add("DateStatistic", typeof(DateTime));
        data.Columns.Add("LeadId", typeof(int));
        data.Columns.Add("DepositsSum", typeof(decimal));
        data.Columns.Add("WithdrawSum", typeof(decimal));
        data.Columns.Add("TransferSum", typeof(decimal));
        data.Columns.Add("DepositsCount", typeof(int));
        data.Columns.Add("WithdrawalsCount", typeof(int));
        data.Columns.Add("TransfersCount", typeof(int));

        statistics.ForEach(s =>
        {
            DataRow dr = data.NewRow();
            dr["DateStatistic"] = s.DateStatistics;
            dr["LeadId"] = s.LeadId;
            dr["DepositsSum"] = s.DepositsSum;
            dr["WithdrawSum"] = s.WithdrawSum;
            dr["TransferSum"] = s.TransferSum;
            dr["DepositsCount"] = s.DepositsCount;
            dr["WithdrawalsCount"] = s.WithdrawalsCount;
            dr["TransfersCount"] = s.TransfersCount;

            data.Rows.Add(dr);
        });



        await Connection.QuerySingleAsync
            (StoredProcedures.LeadOverallStatistic_AddDayStatistic,
                param: new
                {
                    Statistics = data
                },
                commandType: CommandType.StoredProcedure);
    }

    public async Task<List<LeadOverallStatisticsDto>> GetOverallStatisiticsByDate(DateTime date)
    {
        _logger.LogInformation("Data layer: Connection to data base");
        return (await Connection.QueryAsync<LeadOverallStatisticsDto>
                   (StoredProcedures.LeadOverallStatistic_GetLeadOverallStatisticByDate,
                   param: new
                   {
                       date
                   },
                   commandType: CommandType.StoredProcedure
                   )).ToList();
    }

    public async Task<List<LeadOverallStatisticsDto>> GetAllLeadStatisticDto()
    {
        _logger.LogInformation("Data layer: Connection to data base");
        return (await Connection.QueryAsync<LeadOverallStatisticsDto>
                (StoredProcedures.LeadOverallStatistic_GetAll,
                   commandType: CommandType.StoredProcedure))
                   .ToList();
    }

    public async Task<List<int>> GetLeadIdsWithNecessaryTransactionsCount(int transactionsCount, DateTime date)
    {
        _logger.LogInformation("Data layer: Connection to data base");
        return (await Connection.QueryAsync<int>
                (StoredProcedures.LeadOverallStatistic_GetLeadIdsWithNecessaryTransactionsCount,
                param: new
                {
                    date,
                    transactionsCount,
                },
                commandType: CommandType.StoredProcedure))
                   .ToList();
    }

    public async Task<List<int>> GetLeadsIdsWithNecessaryAmountDifference(decimal amountDifference, DateTime date)
    {
        _logger.LogInformation("Data layer: Connection to data base");
        return (await Connection.QueryAsync<int>
               (StoredProcedures.LeadOverallStatistic_GetLeadsIdsWithNecessaryAmountDifference,
               param: new
               {
                   date,
                   amountDifference,
               },
                  commandType: CommandType.StoredProcedure))
                  .ToList();
    }

    public async Task<LeadOverallStatisticsDto> GetLeadStatisticDtoById(int id)
    {
        _logger.LogInformation("Data layer: Connection to data base");
        return await Connection.QuerySingleAsync<LeadOverallStatisticsDto>(
                StoredProcedures.LeadOverallStatistic_GetById,
                param: new { id },
                commandType: CommandType.StoredProcedure
                );
    }

    public async Task UpdateLeadStatisticDto(LeadOverallStatisticsDto leadStatisticDto)
    {
        _logger.LogInformation("Data layer: Connection to data base");
        await Connection.QuerySingleOrDefaultAsync(
            StoredProcedures.LeadOverallStatistic_Update,
                param: new
                {
                    leadStatisticDto.Id,
                    leadStatisticDto.LeadId,
                    leadStatisticDto.TransferSum,
                    leadStatisticDto.DepositsSum,
                    leadStatisticDto.WithdrawSum,
                    leadStatisticDto.DateStatistics,
                    leadStatisticDto.DepositsCount,
                    leadStatisticDto.WithdrawalsCount,
                    leadStatisticDto.TransfersCount,
                },
                commandType: CommandType.StoredProcedure
                );
    }
}
