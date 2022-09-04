using Dapper;
using Microsoft.Extensions.Logging;
using ReportingService.Data.Dto;
using System.Data;

namespace ReportingService.Data.Repositories;

public class LeadOverallStatisticsRepository : BaseRepositories, ILeadOverallStatisticsRepository
{
    private readonly ILogger<LeadOverallStatisticsRepository> _logger;

    public LeadOverallStatisticsRepository(IDbConnection dbConnection)
        : base(dbConnection) { }

    public async Task AddLeadStatistic(LeadOverallStatisticsDto leadStatisticDto)
    {
        _logger.LogInformation("Data layer: Connection to data base");
        await Connection.QuerySingleAsync
                   (StoredProcedures.LeadOverallStatistic_Add,
                   param: new
                   {
                       leadStatisticDto.LeadId,
                       leadStatisticDto.TransferSum,
                       leadStatisticDto.DepositsSum,
                       leadStatisticDto.WithdrawSum,
                       leadStatisticDto.DateStatistics,
                       leadStatisticDto.DepositsCount,
                       leadStatisticDto.WithdrawalsCount,
                       leadStatisticDto.TransfersCount,
                       leadStatisticDto.TransactionCountForTwoMonth
                   },
                   commandType: CommandType.StoredProcedure
                   );
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
                    leadStatisticDto.TransactionCountForTwoMonth
                },
                commandType: CommandType.StoredProcedure
                );
    }
}
