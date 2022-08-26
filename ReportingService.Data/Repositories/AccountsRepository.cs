using Dapper;
using ReportingService.Data.Dto;
using System.Data.SqlClient;

namespace ReportingService.Data.Repositories;

public class AccountsRepository : IAccountsRepository
{
    public string connectionString = ServerOptions.ConnectionOption;

    public void AddAccount(AccountDto accountDto)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();

            connection.QuerySingle
                   (StoredProcedures.Account_Add,
                   param: new
                   {
                       LeadId = accountDto.LeadId,
                       Currency = accountDto.Currency,
                       Status = accountDto.Status
                   },
                   commandType: System.Data.CommandType.StoredProcedure
                   );
        }
    }

    public List<AccountDto> GetAllAccountDto()
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            return connection.Query<AccountDto>
                (StoredProcedures.Account_GetAll,
                   commandType: System.Data.CommandType.StoredProcedure)
                   .ToList();
        }
    }

    public AccountDto GetAccountDtoById(int id)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();

            return connection.QuerySingle<AccountDto>(
                StoredProcedures.Account_GetById,
                param: new { id = id },
                commandType: System.Data.CommandType.StoredProcedure
                );
        }
    }

    public void UpdateAccount(AccountDto accountDto)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();

            connection.QuerySingleOrDefault(
            StoredProcedures.Account_Update,
                param: new
                {
                    Id = accountDto.Id,
                    LeadId = accountDto.LeadId,
                    Currency = accountDto.Currency,
                    Status = accountDto.Status
                },
                commandType: System.Data.CommandType.StoredProcedure
                );
        }
    }
}
