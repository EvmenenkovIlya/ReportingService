using IncredibleBackendContracts.Enums;


namespace ReportingService.Business.Models;

public class UpdateLeadInfo
{
    public int LeadId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Patronymic { get; set; }
    public DateTime BirthDate { get; set; }
    public string Phone { get; set; }
    public City City { get; set; }
    public string Address { get; set; }


    public override string ToString()
    {
        return $"Lead Updated info: LeadId = {LeadId}, FirstName = {FirstName[0]}., LastName = {LastName[0]}., Patronymic = {Patronymic[0]}.," +
               $"BirthDate = {BirthDate}, City = {City}, Phone = {Phone[0..3]}, Address = {Address[0..5]}";
    }
}