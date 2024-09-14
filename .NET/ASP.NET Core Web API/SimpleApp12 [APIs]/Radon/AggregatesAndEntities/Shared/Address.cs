namespace Radon.AggregatesAndEntities.Shared
{
    public class Address
    {
        public string? Country { get; set; } = null;
        public string? Voivodeship { get; set; } = null;
        public string? City { get; set; } = null;
        public string? Street { get; set; } = null;
        public string? BuildingNumber { get; set; } = null;
        public string? ApartmentNumber { get; set; } = null;
        public string? PostalCd { get; set; } = null;


        public static implicit operator Address(Institutions.CoreResponse.Level1.University university)
        {
            return new Address
            {
                Country = university.Country,
                Voivodeship = university.Voivodeship,
                City = university.City,
                PostalCd = university.PostalCd,
                Street = university.Street,
                BuildingNumber = university.BNumber,
                ApartmentNumber = university.LNumber,
            };
        }

        public static implicit operator Address(Branches.CoreResponse.Level1.Branch branch)
        {
            return new Address
            {
                Country = branch.Country,
                Voivodeship = branch.Voivodeship,
                City = branch.City,
                PostalCd = branch.PostalCode,
                Street = branch.Street,
                BuildingNumber = branch.BuildingNumber,
                ApartmentNumber = branch.ApartmentNumber,
            };
        }
    }
}
