using System.Data;

namespace ReportingService.DataCreator.Models
{
    public class Lead : IModel

    {
        public int? Id { get; set; }
        public int LeadId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Passport { get; set; }
        public short City { get; set; }
        public string Address { get; set; }
        public int Role { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool IsDeleted { get; set; }

        public Lead(string line)
        {
            string[] parts = line.Split(';');
            Id = null;
            LeadId = Int32.Parse(parts[1]);
            FirstName = parts[2];
            LastName = parts[3];
            Patronymic = parts[4];
            BirthDate = DateTime.Parse(parts[5]);
            Email = parts[6];
            Phone = parts[7];
            Passport = parts[8];
            City = Int16.Parse(parts[9]);
            Address = parts[10];
            Role = Int16.Parse(parts[11]);
            RegistrationDate = DateTime.Parse(parts[12]);
            IsDeleted = Boolean.Parse(parts[13]);
        }

        public override string ToCsvRow()
        {
            return $"{null};{LeadId};{FirstName};{LastName};{Patronymic};{BirthDate};{Email};{Phone};{Passport};{City};{Address};{Role};{RegistrationDate};{IsDeleted}";
        }
    }
}
