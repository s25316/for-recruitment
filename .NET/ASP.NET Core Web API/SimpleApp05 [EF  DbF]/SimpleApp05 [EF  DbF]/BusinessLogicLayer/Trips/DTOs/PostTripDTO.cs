using System.ComponentModel.DataAnnotations;

namespace SimpleApp05__EF__DbF_.BusinessLogicLayer.Trips.DTOs
{
    public class PostTripDTO
    {
        [StringLength(120)]
        public string Name { get; set; } = null!;
        [StringLength(220)]
        public string Description { get; set; } = null!;
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int MaxPeople { get; set; }
    }
}
