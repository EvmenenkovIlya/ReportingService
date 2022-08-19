using Dapper;
using ReportingService.Data.Dto;
using System.Data.SqlClient;

namespace ReportingService.Data.Repositoties;

public class LeadStatisticsRepository
{
    public string connectionString = ServerOptions.ConnectionOption;

    public void AddLeadStatistic(LeadStatisticDto leadStatisticDto)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();

            connection.QuerySingle
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
                       TransactionCountForTwoMontht = leadStatisticDto.TransactionCountForTwoMontht
                   },
                   commandType: System.Data.CommandType.StoredProcedure
                   );
        }
    }

    public List<LeadStatisticDto> GetAllLeadStatisticDto()
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            return connection.Query<LeadStatisticDto>
                (StoredProcedures.LeadStatistic_GetAll,
                   commandType: System.Data.CommandType.StoredProcedure)
                   .ToList();
        }
    }

    public LeadStatisticDto GetLeadStatisticDtoById(int id)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();

            return connection.QuerySingle<LeadStatisticDto>(
                StoredProcedures.LeadStatistic_GetById,
                param: new { id = id },
                commandType: System.Data.CommandType.StoredProcedure
                );
        }
    }

    public void UpdateLeadStatisticDto(LeadStatisticDto leadStatisticDto)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();

            connection.QuerySingleOrDefault(
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
                    TransactionCountForTwoMontht = leadStatisticDto.TransactionCountForTwoMontht
                },
                commandType: System.Data.CommandType.StoredProcedure
                );
        }
    }
}
