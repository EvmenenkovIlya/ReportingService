using ReportingService.Data.Enums;

namespace ReportingService.Data.Dto;

public class LeadInfoDto
{
    public int Id { get; set; }
    public int LeadId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Patronymic { get; set; }
    public DateOnly BirthDate { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Passport { get; set; }
    public short City { get; set; }
    public string Address { get; set; }
    public Role Role { get; set; }
    public DateOnly RegistrationDate { get; set; }
    public bool IsDeleted { get; set; }
}
