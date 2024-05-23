namespace SimpleApp08__EF__CdF_.BusinessLogicLayer.Doctor.DTOs
{
    public class PrescriptionMedicamentGetDTO
    {
        public int IdMedicament { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Type { get; set; } = null!;
        public int? Dose { get; set; } = null;
        public string Details { get; set; } = null!;
    }
}
