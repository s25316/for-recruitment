namespace SimpleApp06__EF__CdF_.BusinessLogicLayer.DTOs
{
    public class CarDetailesGetDTO
    {
        public int IdPerson { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string? DrivingLicence { get; set; } = null;
        public bool MainOwner { get; set; }
    }
}
