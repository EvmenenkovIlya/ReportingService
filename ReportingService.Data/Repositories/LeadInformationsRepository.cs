using Dapper;
using ReportingService.Data.Dto;
using System.Data;

namespace ReportingService.Data.Repositories;

public class LeadInformationsRepository : BaseRepositories, ILeadInformationsRepository
{
    public LeadInformationsRepository(IDbConnection dbConnection)
        : base(dbConnection) { }

    public async Task<LeadInformationDto> GetLeadInformationDtoById(int id)
    {
        return await Connection.QuerySingleAsync<LeadInformationDto>(
                StoredProcedures.LeadInformation_GetById,
                param: new { id = id },
                commandType: System.Data.CommandType.StoredProcedure
                );
    }

    public async Task<List<LeadInformationDto>> GetAllLeadInformationDto()
    {
        return (await Connection.QueryAsync<LeadInformationDto>
                (StoredProcedures.LeadInformation_GetAll,
                   commandType: System.Data.CommandType.StoredProcedure))
                   .ToList();
    }

    public async Task<List<int>> GetAllBirthdayIds()
    {
        return (await Connection.QueryAsync<int>
                (StoredProcedures.LeadInformation_GetTodayBirthdayIds,
                   commandType: System.Data.CommandType.StoredProcedure))
                   .ToList();
    }

    public async Task<string> AddLeadInformation(LeadInformationDto leadInformationDto)
    {
        return (await Connection.QuerySingleAsync<long>
                   (StoredProcedures.LeadInformation_Add,
                   param: new
                   {
                       LeadId = leadInformationDto.LeadId,
                       FirstName = leadInformationDto.FirstName,
                       LastName = leadInformationDto.LastName,
                       Patronymic = leadInformationDto.Patronymic,
                       BirthDate = leadInformationDto.BirthDate,
                       Phone = leadInformationDto.Phone,
                       Email = leadInformationDto.Email,
                       Passport = leadInformationDto.Passport,
                       City = leadInformationDto.City,
                       Address = leadInformationDto.Address,
                       Role = leadInformationDto.Role,
                       RegistrationDate = leadInformationDto.RegistrationDate,
                       IsDeleted = leadInformationDto.IsDeleted
                   },
                   commandType: System.Data.CommandType.StoredProcedure
                   )).ToString();
    }

    public async Task<LeadInformationDto> UpdateLeadInformation(LeadInformationDto leadInformationDto)
    {
        return await Connection.QuerySingleOrDefaultAsync(
                StoredProcedures.LeadInformation_Update,
                param: new
                {
                    Id = leadInformationDto.Id,
                    LeadId = leadInformationDto.LeadId,
                    FirstName = leadInformationDto.FirstName,
                    LastName = leadInformationDto.LastName,
                    Patronymic = leadInformationDto.Patronymic,
                    BirthDate = leadInformationDto.BirthDate,
                    Phone = leadInformationDto.Phone,
                    Email = leadInformationDto.Email,
                    Passport = leadInformationDto.Passport,
                    City = leadInformationDto.City,
                    Address = leadInformationDto.Address,
                    Role = leadInformationDto.Role,
                    RegistrationDate = leadInformationDto.RegistrationDate,
                    IsDeleted = leadInformationDto.IsDeleted
                },
                commandType: System.Data.CommandType.StoredProcedure);
    }
}
