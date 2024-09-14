using Application.Database.Models.PersonPart;

namespace Application.Database.Models.ContactPart
{
    public class HistoryOfContactClient
    {
        //PK FK
        public Guid Id { get; set; }
        public virtual HistoryOfContact Contact { get; set; } = null!;

        //FK Depratment
        public Guid DepratmentId { get; set; }
        public virtual Depratment Depratment { get; set; } = null!;

        //FK Client
        public Guid ClientId { get; set; }
        public virtual Client Client { get; set; } = null!;

    }
}
