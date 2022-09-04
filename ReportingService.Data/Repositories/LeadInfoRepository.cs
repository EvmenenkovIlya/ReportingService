using Dapper;
using Microsoft.Extensions.Logging;
using ReportingService.Data.Dto;
using System.Data;

namespace ReportingService.Data.Repositories;

public class LeadInfoRepository : BaseRepositories, ILeadInfoRepository
{
    private readonly ILogger<LeadInfoRepository> _logger;

    public LeadInfoRepository(IDbConnection dbConnection)
        : base(dbConnection) { }

    public async Task<LeadInfoDto> GetLeadInformationDtoById(int id)
    {
        _logger.LogInformation("Data layer: Connection to data base");
        return await Connection.QuerySingleAsync<LeadInfoDto>(
                StoredProcedures.LeadInfo_GetById,
                param: new { id },
                commandType: CommandType.StoredProcedure
                );
    }

    public async Task<List<LeadInfoDto>> GetAllLeadInformationDto()
    {
        _logger.LogInformation("Data layer: Connection to data base");
        return (await Connection.QueryAsync<LeadInfoDto>
                (StoredProcedures.LeadInfo_GetAll,
                   commandType: CommandType.StoredProcedure))
                   .ToList();
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

    public async Task<string> AddLeadInformation(LeadInfoDto leadInformationDto)
    {
        _logger.LogInformation("Data layer: Connection to data base");
        return (await Connection.QuerySingleAsync<long>
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
                       leadInformationDto.RegistrationDate,
                       leadInformationDto.IsDeleted
                   },
                   commandType: CommandType.StoredProcedure
                   )).ToString();
    }

    public async Task<LeadInfoDto> UpdateLeadInformation(LeadInfoDto leadInformationDto)
    {
        _logger.LogInformation("Data layer: Connection to data base");
        return await Connection.QuerySingleOrDefaultAsync(
                StoredProcedures.LeadInfo_Update,
                param: new
                {
                    leadInformationDto.Id,
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
                    leadInformationDto.RegistrationDate,
                    leadInformationDto.IsDeleted
                },
                commandType: CommandType.StoredProcedure);
    }
}
