using System.ComponentModel.DataAnnotations;

namespace SimpleApp04__System.Data.SqlClient_.Models
{
    public class Championship
    {
        public int IdChampionship { get; set; }
        [StringLength(100)]
        public required string OfficialName { get; set; }
        public required int Year { get; set; }
    }
}
