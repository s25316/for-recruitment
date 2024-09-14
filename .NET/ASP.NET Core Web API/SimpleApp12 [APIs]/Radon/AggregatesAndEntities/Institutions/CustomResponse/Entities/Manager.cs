namespace Radon.AggregatesAndEntities.Institutions.CustomResponse.Entities
{
    public class Manager
    {
        public string? Function { get; set; } = null;
        public string? Name { get; set; } = null;
        public string? Surname { get; set; } = null;
        public string? OtherNames { get; set; } = null;
        public string? SurnamePrefix { get; set; } = null;


        public static implicit operator Manager(CoreResponse.Level1.University university)
        {
            return new Manager
            {
                Function = university.ManagerFunction,
                Name = university.ManagerName,
                Surname = university.ManagerSurname,
                OtherNames = university.ManagerOtherNames,
                SurnamePrefix = university.ManagerSurnamePrefix,
            };
        }
    }
}
