using Application.Database.Models.CompanyPart;

namespace Application.Database.Models.ContactPart
{
    public class HistoryOfContactCompany
    {
        //PK FK
        public Guid Id { get; set; }
        public virtual HistoryOfContact Contact { get; set; } = null!;

        //FK Depratment
        public Guid DepratmentId { get; set; }
        public virtual Depratment Depratment { get; set; } = null!;

        //FK Company
        public Guid CompanyId { get; set; }
        public virtual Company Company { get; set; } = null!;
    }
}
