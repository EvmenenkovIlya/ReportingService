using Dapper;
using ReportingService.Data.Dto;
using System.Data.SqlClient;

namespace ReportingService.Data.Repositories;

public class StatisticsRepository : BaseRepositories, IStatisticsRepository
{
    public StatisticsRepository(IDbConnection dbConnection)
        : base(dbConnection) { }
    public string connectionString = ServerOptions.ConnectionOption;

    public void AddStatistic(StatisticDto StatisticDto)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();

            connection.QuerySingle
                   (StoredProcedures.Statistic_Add,
                   param: new
                   {
                       Сurrency = StatisticDto.Сurrency,
                       ActiveAccountCount = StatisticDto.ActiveAccountCount,
                       AllAccountCount = StatisticDto.AllAccountCount,
                       ActiveLeadCount = StatisticDto.ActiveLeadCount,
                       DateStatistic = StatisticDto.DateStatistic,
                   },
                   commandType: System.Data.CommandType.StoredProcedure
                   );
        }
    }

    public List<StatisticDto> GetAllStatisticDto()
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            return connection.Query<StatisticDto>
                (StoredProcedures.Statistic_GetAll,
                   commandType: System.Data.CommandType.StoredProcedure)
                   .ToList();
        }
    }

    public StatisticDto GetStatisticDtoById(int id)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();

            return connection.QuerySingle<StatisticDto>(
                StoredProcedures.Statistic_GetById,
                param: new { id = id },
                commandType: System.Data.CommandType.StoredProcedure
                );
        }
    }
}
