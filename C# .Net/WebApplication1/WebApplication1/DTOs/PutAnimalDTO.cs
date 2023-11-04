using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTOs
{
    public class PutAnimalDTO
    {
        [Required]
        [StringLength(200, ErrorMessage = "Not longer 200 signs")]
        public string Name { get; set; }
        [Required]
        [StringLength(200, ErrorMessage = "Not longer 200 signs")]
        public string Description { get; set; }
        [Required]
        [StringLength(200, ErrorMessage = "Not longer 200 signs")]
        public string Category { get; set; }
        [Required]
        [StringLength(200, ErrorMessage = "Not longer 200 signs")]
        public string Area { get; set; }
    }
}
