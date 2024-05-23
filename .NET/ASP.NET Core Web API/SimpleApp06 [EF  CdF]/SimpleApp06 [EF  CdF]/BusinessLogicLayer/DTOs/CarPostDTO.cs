using SimpleApp06__EF__CdF_.ValidationAtributes;
using System.ComponentModel.DataAnnotations;

namespace SimpleApp06__EF__CdF_.BusinessLogicLayer.DTOs
{
    public class CarPostDTO
    {
        [StringLength(15)]
        public string Make { get; set; } = null!;
        [YearAtribute]
        public int PropductionYear { get; set; } = DateTime.Now.Year;      
    }
}
