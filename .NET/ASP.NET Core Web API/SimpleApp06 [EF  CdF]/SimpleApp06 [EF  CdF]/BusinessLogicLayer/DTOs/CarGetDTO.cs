namespace SimpleApp06__EF__CdF_.BusinessLogicLayer.DTOs
{
    public class CarGetDTO
    {
        public int IdCar { get; set; }
        public string Make { get; set; } = null!;
        public int PropductionYear { get; set; }
        public virtual IEnumerable<CarDetailesGetDTO> Owners { get; set; } = new List<CarDetailesGetDTO>();
    }
}
