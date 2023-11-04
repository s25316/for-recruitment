using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Animal
    {
        
        /*
        IdAnimal int  NOT NULL IDENTITY,
        Name nvarchar(200)  NOT NULL,
        Description nvarchar(200)  NULL,
        Category nvarchar(200)  NOT NULL,
        Area nvarchar(200)  NOT NULL,
        CONSTRAINT Animal_pk PRIMARY KEY  (IdAnimal)
         */
        [Required]
        public int IdAnimal { get; set; }
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
        [StringLength (200, ErrorMessage = "Not longer 200 signs")]
        public string Area { get; set; }
    }
}
