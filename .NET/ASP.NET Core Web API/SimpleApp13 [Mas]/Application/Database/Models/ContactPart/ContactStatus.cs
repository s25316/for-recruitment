namespace Application.Database.Models.ContactPart
{
    public class ContactStatus
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<HistoryOfContact> HistoryOfContacts { get; set; } = new List<HistoryOfContact>();
    }
}
