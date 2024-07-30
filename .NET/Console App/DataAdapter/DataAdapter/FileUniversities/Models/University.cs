using System.Text;

namespace DataAdapter.FileUniversities.Models
{
    public class University
    {
        //Values
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public DateOnly CreatedDate { get; set; }
        public string Type { get; set; } = null!;
        public DateOnly? LiquidationDate { get; set; }
        public string? REGON { get; set; } = null;
        public string? NIP { get; set; } = null;
        public string? WWW { get; set; } = null;
        public string? Email { get; set; } = null;
        public string? PhoneNumber { get; set; } = null;
        public string? Country { get; set; } = null;
        public string? Wojewodstwo { get; set; } = null;
        public string? Street { get; set; } = null;
        public string? BuildingAndApartment { get; set; } = null;
        public string? ZipCode { get; set; } = null;
        public string? City { get; set; } = null;

        //Magic numbers for Parsing
        private static readonly int _positionInListId = 1;
        private static readonly int _positionInListName = 2;
        private static readonly int _positionInListCreatedDate = 3;
        private static readonly int _positionInListType = 5;
        private static readonly int _positionInListLiquidationDate = 9;
        private static readonly int _positionInListREGON = 12;
        private static readonly int _positionInListNIP = 13;
        private static readonly int _positionInListWWW = 18;
        private static readonly int _positionInListEmail = 19;
        private static readonly int _positionInListPhoneNumber = 20;
        private static readonly int _positionInListCountry = 22;
        private static readonly int _positionInListWojewodstwo = 23;
        private static readonly int _positionInListStreet = 24;
        private static readonly int _positionInListBuildingAndApartment = 25;
        private static readonly int _positionInListZipCode = 26;
        private static readonly int _positionInListCity = 27;

        public static implicit operator University(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new Exception("Empty text of University");
            }

            var list = text.Split("\",\"").ToList();
            if (list.Count() <= 27)
            {
                throw new Exception("Shold be min 27 columns");
            }

            return new University
            {
                Id = Guid.Parse(list[_positionInListId]),
                Name = list[_positionInListName],
                CreatedDate = DateOnly.ParseExact(list[_positionInListCreatedDate],
                "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),

                Type = list[_positionInListType],
                LiquidationDate = string.IsNullOrEmpty(list[_positionInListLiquidationDate]) ?
                null : DateOnly.ParseExact(list[_positionInListLiquidationDate], "yyyy-MM-dd",
                System.Globalization.CultureInfo.InvariantCulture),

                REGON = string.IsNullOrEmpty(list[_positionInListREGON]) ?
                null : list[_positionInListREGON],
                NIP = string.IsNullOrEmpty(list[_positionInListNIP]) ?
                null : list[_positionInListNIP],
                WWW = string.IsNullOrEmpty(list[_positionInListWWW]) ?
                null : list[_positionInListWWW],
                Email = string.IsNullOrEmpty(list[_positionInListEmail]) ?
                null : list[_positionInListEmail],
                PhoneNumber = string.IsNullOrEmpty(list[_positionInListPhoneNumber]) ?
                null : list[_positionInListPhoneNumber],
                Country = string.IsNullOrEmpty(list[_positionInListCountry]) ?
                null : list[_positionInListCountry],
                Wojewodstwo = string.IsNullOrEmpty(list[_positionInListWojewodstwo]) ?
                null : list[_positionInListWojewodstwo],
                Street = string.IsNullOrEmpty(list[_positionInListStreet]) ?
                null : list[_positionInListStreet],
                BuildingAndApartment = string.IsNullOrEmpty(list[_positionInListBuildingAndApartment]) ?
                null : list[_positionInListBuildingAndApartment],
                ZipCode = string.IsNullOrEmpty(list[_positionInListZipCode]) ?
                null : list[_positionInListZipCode],
                City = string.IsNullOrEmpty(list[_positionInListCity]) ?
                null : list[_positionInListCity],
            };
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"Id {Id} \t");
            stringBuilder.Append($"Name {Name} \t");
            stringBuilder.Append($"Created {CreatedDate.ToString()} \t");
            stringBuilder.Append($"Type {Type} \t");
            stringBuilder.Append($"LiquidationDate {LiquidationDate.ToString()} \t");
            stringBuilder.Append($"REGON {REGON} \t");
            stringBuilder.Append($"NIP {NIP} \t");
            stringBuilder.Append($"WWW {WWW} \t");
            stringBuilder.Append($"Email {Email} \t");
            stringBuilder.Append($"PhoneNumber {PhoneNumber} \t");
            stringBuilder.Append($"Country {Country} \t");
            stringBuilder.Append($"Wojewodstwo {Wojewodstwo} \t");
            stringBuilder.Append($"Street {Street} \t");
            stringBuilder.Append($"Building And Apartment {BuildingAndApartment} \t");
            stringBuilder.Append($"Zip Code {ZipCode} \t");
            stringBuilder.Append($"City {City}");
            return stringBuilder.ToString();
        }
    }
}
