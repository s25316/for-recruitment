namespace SimpleApp06__EF__CdF_.BusinessLogicLayer.DTOs
{
    public class PersonDetailsGetDTO
    {
        public int IdCar { get; set; }
        public string Make { get; set; } = null!;
        public int PropductionYear { get; set; }
        public bool MainOwner { get; set; }
    }
}
