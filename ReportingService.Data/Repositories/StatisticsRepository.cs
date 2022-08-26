using System.Data;

namespace ReportingService.Data.Repositories;

public class StatisticsRepository : BaseRepositories, IStatisticsRepository
{
    public StatisticsRepository(IDbConnection dbConnection)
        : base(dbConnection) { }
}
