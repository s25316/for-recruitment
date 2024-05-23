using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MAS04.Models
{
    internal class BankProfile
    {
        //Magic Numbers 
        private static readonly int _minAgeForCreateingProfile = 18;
        //
        private static Dictionary<string, BankProfile> _clients =
            new Dictionary<string, BankProfile>();

        public string PassportNumber { get; private set; } = null!;
        public DateOnly BirthDate { get; private set; }
        public string FirstName { get; private set; } = null!;
        public string LastName { get; private set; } = null!;

        public BankProfile(string passportNumber, DateOnly birthDate,
            string firstName, string lastName)
        {
            SetBirthDate(birthDate);
            SetUniqueDocument(passportNumber);
            FirstName = firstName;
            LastName = lastName;
        }

        private void SetBirthDate(DateOnly birthDate) 
        {
            var today = DateOnly.FromDateTime(DateTime.Now);
            if (birthDate > today) { throw new Exception("Age can`t be in future"); }

            var age = new DateOnly().AddDays(today.DayNumber - birthDate.DayNumber)
                .AddDays(-1);

            var minAge = new DateOnly().AddYears(_minAgeForCreateingProfile);
            var isAvaliable = (age >= minAge);

            if (isAvaliable)
            {
                BirthDate = birthDate;
            }
            else
            {
                throw new Exception(string.Format(
                    "Age of client should be not less {0}, Now to this pearson {1}", 
                    _minAgeForCreateingProfile, (age.Year - 1)));
            }
        }

        private void SetUniqueDocument(string passportNumber) 
        {
            if (!_clients.ContainsKey(passportNumber))
            {
                PassportNumber = passportNumber;
                _clients.Add(PassportNumber, this);
            }
            else
            {
                var commentPart1 = $"Exist Client with this Passport: {passportNumber}";
                var commentPart2 = string.Format("{0} {1}",
                    "check data of this client and client wich have the same ",
                    "Document, correct both option call POLICE pobably You find a Fraud");
                string fullComment = string.Format("{0}, {1}", commentPart1, commentPart2);
                throw new Exception(fullComment);
            }
        }
        public override string ToString()
        {
            return $"Profile of Client: {FirstName} {LastName}, Document: {PassportNumber
                }, Birth Date: {BirthDate}";
        }
    }
}
