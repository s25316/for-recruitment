
namespace Application.Database.Models.ContactPart
{
    public class HistoryOfContact
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
        public bool IsReaded { get; set; } = false;
        public string FirstMessage { get; set; } = null!;
        public string? ClientMessage { get; set; } = null;
        public string? LastMessage { get; set; } = null;

        //FK
        public int IdStatus { get; set; }
        public virtual ContactStatus Status { get; set; } = null!;

        public virtual HistoryOfContactClient? HistoryOfContactClient { get; set; } = null;
        public virtual HistoryOfContactCompany? HistoryOfContactCompany { get; set; } = null;
    }
}
