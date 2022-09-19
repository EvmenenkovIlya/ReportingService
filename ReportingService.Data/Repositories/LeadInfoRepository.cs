using Dapper;
using Microsoft.Extensions.Logging;
using ReportingService.Data.Dto;
using System.Data;
using System.Data.SqlClient;

namespace ReportingService.Data.Repositories;

public class LeadInfoRepository : BaseRepositories, ILeadInfoRepository
{
    private readonly ILogger<LeadInfoRepository> _logger;

    public LeadInfoRepository(IDbConnection dbConnection, ILogger<LeadInfoRepository> logger)
        : base(dbConnection)
    {
        _logger = logger;
    }
    public async Task AddLeadInfo(LeadInfoDto leadInformationDto)
    {
        _logger.LogInformation("Data layer: Connection to data base");
        await Connection.QuerySingleAsync<long>
                   (StoredProcedures.LeadInfo_Add,
                   param: new
                   {
                       leadInformationDto.LeadId,
                       leadInformationDto.FirstName,
                       leadInformationDto.LastName,
                       leadInformationDto.Patronymic,
                       leadInformationDto.BirthDate,
                       leadInformationDto.Phone,
                       leadInformationDto.Email,
                       leadInformationDto.Passport,
                       leadInformationDto.City,
                       leadInformationDto.Address,
                       leadInformationDto.Role,
                       leadInformationDto.RegistrationDate
                   },
                   commandType: CommandType.StoredProcedure
                   );
    }
    public async Task<List<LeadInfoDto>> GetAllLeadInfoDto()
    {
        _logger.LogInformation("Data layer: Connection to data base");
        return (await Connection.QueryAsync<LeadInfoDto>
                (StoredProcedures.LeadInfo_GetAll,
                   commandType: CommandType.StoredProcedure))
                   .ToList();
    }

    public async Task<LeadInfoDto> GetLeadInfoDtoByLeadId(int leadId)
    {
        _logger.LogInformation("Data layer: Connection to data base");
        return await Connection.QuerySingleAsync<LeadInfoDto>(
                StoredProcedures.LeadInfo_GetByLeadId,
                param: new { LeadId = leadId },
                commandType: CommandType.StoredProcedure
                );
    }

    public async Task<List<int>> GetCelebrateIdsByDate(DateTime date)
    {
        _logger.LogInformation("Data layer: Connection to data base");
        return (await Connection.QueryAsync<int>
                (StoredProcedures.Leadinfo_GetCelebrateIdsByDate,
                    param: new { date },
                   commandType: CommandType.StoredProcedure))
                   .ToList();
    }

    public async Task UpdateLeadInfo(LeadInfoDto leadInformationDto)
    {
        _logger.LogInformation("Data layer: Connection to data base");
        await Connection.QuerySingleOrDefaultAsync(
                StoredProcedures.LeadInfo_Update,
                param: new
                {
                    leadInformationDto.LeadId,
                    leadInformationDto.FirstName,
                    leadInformationDto.LastName,
                    leadInformationDto.Patronymic,
                    leadInformationDto.BirthDate,
                    leadInformationDto.Phone,
                    leadInformationDto.Email,
                    leadInformationDto.Passport,
                    leadInformationDto.City,
                    leadInformationDto.Address,
                    leadInformationDto.Role,
                    leadInformationDto.RegistrationDate
                },
                commandType: CommandType.StoredProcedure);
    }

    public async Task DeleteLeadInfo(int leadId)
    {
        _logger.LogInformation($"LeadInfoRepository: Delete leadInfo with LeadId = {leadId}");
        await Connection.QuerySingleAsync
            (StoredProcedures.LeadInfo_Delete,
            commandType: CommandType.StoredProcedure);
    }

    public async Task UpdateLeadsStatus(List<int> vipIds)
    {
        DataTable data = new DataTable();
        data.Columns.Add("id", typeof(int));
        vipIds.ForEach(x => data.Rows.Add(x));

        _logger.LogInformation("Data layer: Connection to data base");
        await Connection.QuerySingleAsync
            (StoredProcedures.LeadInfo_UpdateLeadsStatus,
                param: new
                {
                    ids = data
                },
                commandType: CommandType.StoredProcedure);
    }
}
