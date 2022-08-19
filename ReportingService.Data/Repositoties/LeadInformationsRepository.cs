using Dapper;
using ReportingService.Data.Dto;
using ReportingService.Data.Enums;
using System.Data.SqlClient;
using System.Net;
using System.Numerics;

namespace ReportingService.Data.Repositoties;

public class LeadInformationsRepository
{

    public string connectionString = ServerOptions.ConnectionOption;

    public LeadInformationDto GetLeadInformationDtoById(int id)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();

            return connection.QuerySingle<LeadInformationDto>(
                StoredProcedures.LeadInformation_GetById,
                param: new { id = id },
                commandType: System.Data.CommandType.StoredProcedure
                );
        }
    }

    public List<LeadInformationDto> GetAllLeadInformationDto()
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            return connection.Query<LeadInformationDto>
                (StoredProcedures.LeadInformation_GetAll,
                   commandType: System.Data.CommandType.StoredProcedure)
                   .ToList();
        }
    }

    public string AddLeadInformation(LeadInformationDto leadInformationDto)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();

            return connection.QuerySingle<string>
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
                   ).ToString();
        }
    }

    public LeadInformationDto UpdateLeadInformation(LeadInformationDto leadInformationDto)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();

            return connection.QuerySingleOrDefault(
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
                commandType: System.Data.CommandType.StoredProcedure
                );
        }
    }
}
