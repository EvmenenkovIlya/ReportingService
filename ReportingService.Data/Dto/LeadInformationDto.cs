using ReportingService.Data.Enums;

namespace ReportingService.Data.Dto;

public class LeadInformationDto
{
    public int Id { get; set; }
    public long LeadId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Patranomyc { get; set; }
    public DateOnly Date { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Passport { get; set; }
    public string City { get; set; }
    public string Address { get; set; }
    public Role Role { get; set; }
    public DateOnly RegistrationDate { get; set; }
    public bool IsDeleted { get; set; }
}
