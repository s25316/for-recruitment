using System.ComponentModel.DataAnnotations;

namespace SimpleApp07__EF__CdF_.BusinessLogicLayer.DTOs.Movie
{
    public class MoviePostDTO
    {
        [MaxLength(60)] 
        public string Name { get; set; } = null!;
        //public DateOnly RelizeDate { get; set; }
        [Range(1, int.MaxValue)]
        public int Year { get; set; }
        [Range(1, 12)]
        public int Month { get; set; }
        [Range(1, 31)]
        public int Day { get; set; }
    }
}
