using Domain.Entites.DocumentPart;
using Domain.Entites.PriorityPart;
using Domain.ValueObjects;

namespace Domain.Entites.PersonPart
{
    public class Person
    {
        //Static Data
        private static int _minAge = 18;

        //Non Static Data
        public Guid? Id { get; set; }
        public string FirstName { get; private set; } = null!;
        public string? HandName { get; private set; } = null;
        public string LastName { get; private set; } = null!;
        public DateTime BirthDate { get; private set; }
        public string Email { get; private set; } = null!;
        public string PhoneNumber { get; private set; } = null!;
        public string Pesel { get; private set; } = null!;

        public Age Age { get; private set; } = null!;
        //Adderess

        //References
        public Priority Priority { get; private set; } = null!;
        public List<Document> Documents { get; private set; } = new List<Document>();

        //Overlapping 
        public Employee? Employee { get; set; } = null;
        public Client? Client { get; set; } = null;

        //Cosntructors
        public Person
            (
            Guid? id,
            string firstName,
            string? handName,
            string lastName,
            DateTime birthDate,
            string email,
            string phoneNumber,
            string pesel,
            bool isPep,
            string lastPositionOfPep
            )
        {
            Id = id;
            FirstName = firstName;
            HandName = handName;
            LastName = lastName;
            BirthDate = birthDate;
            Email = email;
            PhoneNumber = phoneNumber;

            Age = new Age(birthDate, _minAge);
            if (isPep)
            {
                Priority = new Priority
                {
                    Person = this,
                    CurrentPep = new Pep
                    {
                        LastPositionPep = lastPositionOfPep,
                    },
                };
            }
            else
            {
                Priority = new Priority
                {
                    Person = this,
                    CurrentNormalPerson = new NormalPerson(),
                };
            }
        }

        public Person
            (
            string firstName,
            string? handName,
            string lastName,
            DateTime birthDate,
            string email,
            string phoneNumber,
            string pesel,
            bool isPep,
            string? lastPositionOfPep
            ) : this
            (null, firstName, handName, lastName, birthDate, email, phoneNumber, pesel, isPep, lastPositionOfPep)
        { }

        //Methods
        //CreateProfile() :Bool
        //GetPrsonByPesel(string pesel) :Person
        //DeleteProfile() :Person
        //UpdateFullData() :Person
        public Person GetFullData() => this;

        public static void ChangeMinAgeOfPerson(int age) => _minAge = age;

        public bool SetDocument(Document document)
        {
            if (document.IsValid())
            {
                Documents.Add(document);
                return true;
            }
            return false;
        }

    }
}
