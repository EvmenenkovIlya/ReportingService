using Dapper;
using ReportingService.Data.Dto;
using System.Data;
using System.Data.SqlClient;

namespace ReportingService.Data.Repositories;

public class LeadStatisticsRepository : BaseRepositories, ILeadStatisticsRepository
{
    public LeadStatisticsRepository(IDbConnection dbConnection)
        : base(dbConnection) { }

    public async Task AddLeadStatistic(LeadStatisticDto leadStatisticDto)
    {
        await Connection.QuerySingleAsync
                   (StoredProcedures.LeadStatistic_Add,
                   param: new
                   {
                       LeadId = leadStatisticDto.LeadId,
                       TransferSum = leadStatisticDto.TransferSum,
                       DepositsSum = leadStatisticDto.DepositsSum,
                       WithdrawSum = leadStatisticDto.WithdrawSum,
                       DateStatistic = leadStatisticDto.DateStatistic,
                       DepositCount = leadStatisticDto.DepositCount,
                       WithdrawCount = leadStatisticDto.WithdrawCount,
                       TransferCount = leadStatisticDto.TransferCount,
                       TransactionCountForTwoMonth = leadStatisticDto.TransactionCountForTwoMonth
                   },
                   commandType: System.Data.CommandType.StoredProcedure
                   );
    }

    public async Task<List<LeadStatisticDto>> GetAllLeadStatisticDto()
    {
        return (await Connection.QueryAsync<LeadStatisticDto>
                (StoredProcedures.LeadStatistic_GetAll,
                   commandType: System.Data.CommandType.StoredProcedure))
                   .ToList();
    }

    public async Task<LeadStatisticDto> GetLeadStatisticDtoById(int id)
    {
        return await Connection.QuerySingleAsync<LeadStatisticDto>(
                StoredProcedures.LeadStatistic_GetById,
                param: new { id = id },
                commandType: System.Data.CommandType.StoredProcedure
                );
    }

    public async Task UpdateLeadStatisticDto(LeadStatisticDto leadStatisticDto)
    {
        await Connection.QuerySingleOrDefaultAsync(
            StoredProcedures.LeadStatistic_Update,
                param: new
                {
                    Id = leadStatisticDto.Id,
                    LeadId = leadStatisticDto.LeadId,
                    TransferSum = leadStatisticDto.TransferSum,
                    DepositsSum = leadStatisticDto.DepositsSum,
                    WithdrawSum = leadStatisticDto.WithdrawSum,
                    DateStatistic = leadStatisticDto.DateStatistic,
                    DepositCount = leadStatisticDto.DepositCount,
                    WithdrawCount = leadStatisticDto.WithdrawCount,
                    TransferCount = leadStatisticDto.TransferCount,
                    TransactionCountForTwoMonth = leadStatisticDto.TransactionCountForTwoMonth
                },
                commandType: System.Data.CommandType.StoredProcedure
                );
    }
}
