using Dapper;
using ReportingService.Data.Dto;
using System.Data;

namespace ReportingService.Data.Repositories;

public class LeadOverallStatisticsRepository : BaseRepositories, ILeadOverallStatisticsRepository
{
    public LeadOverallStatisticsRepository(IDbConnection dbConnection)
        : base(dbConnection) { }

    public async Task AddLeadStatistic(LeadOverallStatisticsDto leadStatisticDto)
    {
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
        return (await Connection.QueryAsync<LeadOverallStatisticsDto>
                (StoredProcedures.LeadOverallStatistic_GetAll,
                   commandType: CommandType.StoredProcedure))
                   .ToList();
    }

    public async Task<List<int>> GetLeadIdsWithNecessaryTransactionsCount(int transactionsCount, DateTime date)
    {
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

    public async Task<List<int>> GetLeadsIdsWithDifferenceOfMore13000()
    {
        return (await Connection.QueryAsync<int>
               (StoredProcedures.LeadOverallStatistic_GetLeadsIdsWithDifferenceOfMore13000,
                  commandType: CommandType.StoredProcedure))
                  .ToList();
    }

    public async Task<LeadOverallStatisticsDto> GetLeadStatisticDtoById(int id)
    {
        return await Connection.QuerySingleAsync<LeadOverallStatisticsDto>(
                StoredProcedures.LeadOverallStatistic_GetById,
                param: new { id },
                commandType: CommandType.StoredProcedure
                );
    }

    public async Task UpdateLeadStatisticDto(LeadOverallStatisticsDto leadStatisticDto)
    {
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
