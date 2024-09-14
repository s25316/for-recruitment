using Domain.Entites.PersonPart;
using Domain.ValueObjects;

namespace Domain.Entites.DocumentPart
{
    public class Document
    {
        //Needed for database if not exist
        public Guid? Id { get; set; } = null;

        public DocumentNumber Number { get; private set; } = null!;
        public string Country { get; private set; } = null!; //Polska 
        public DateTime From { get; private set; }
        public DateTime? To { get; private set; }
        public DocumentType DocumentType { get; private set; }

        //References
        public Person Person { get; set; } = null!;


        //Constructors
        public Document
           (
           Guid? id,
           string number,
           string country,
           DateTime from,
           DateTime? to,
           DocumentType type,
           Person person
           )
        {
            Id = id;
            Number = new DocumentNumber(number);
            Country = country;
            From = from;
            To = to;
            DocumentType = type;
            Person = person;
            person.Documents.Add(this);
        }

        public Document
            (
            string number,
            string country,
            DateTime from,
            DateTime? to,
            DocumentType type,
            Person person
            ) : this(null, number, country, from, to, type, person)
        { }

        //Methods
        //Save()

        public bool IsValid()
        {
            var today = DateTime.Today;
            return From < today && To > today;
        }

    }
}
