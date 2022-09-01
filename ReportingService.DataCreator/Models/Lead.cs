using System.Data;

namespace ReportingService.DataCreator.Models
{
    public class Lead : IModel

    {
        public int? Id { get; set; }
        //public int LeadId { get; set; }
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
            LeadId = Int32.Parse(parts[0]);
            FirstName = parts[1];
            LastName = parts[2];
            Patronymic = parts[3];
            BirthDate = DateTime.Parse(parts[4]);
            Email = parts[5];
            Phone = parts[6];
            Passport = parts[7];
            City = Int16.Parse(parts[8]);
            Address = parts[9];
            Role = Int16.Parse(parts[10]);
            RegistrationDate = DateTime.Parse(parts[11]);
            IsDeleted = Boolean.Parse(parts[12]);
        }

        public override string ToCsvRow()
        {
            return $"{LeadId};{FirstName};{LastName};{Patronymic};{BirthDate};{Email};{Phone};{Passport};{City};{Address};{Role};{RegistrationDate};{IsDeleted}";
        }
    }
}
