using Application.Database.Models.PersonPart;

namespace Application.Database.Models.CompanyPart
{
    public class EmploymentHistory
    {
        public Guid Id { get; set; }
        public DateTime From { get; set; }
        public DateTime? To { get; set; } = null;
        public string Position { get; set; } = null!;

        //FK Company
        public Guid CompanyId { get; set; }
        public virtual Company Company { get; set; } = null!;
        //FK Employee
        public Guid EmployeeId { get; set; }
        public virtual Employee Employee { get; set; } = null!;
    }
}
