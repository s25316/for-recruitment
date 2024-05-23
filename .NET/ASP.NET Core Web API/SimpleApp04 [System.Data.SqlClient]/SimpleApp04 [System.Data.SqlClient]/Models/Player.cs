using System.ComponentModel.DataAnnotations;

namespace SimpleApp04__System.Data.SqlClient_.Models
{
    public class Player
    {
        public int IdPlayer { get; set; }
        [StringLength(30)]
        public required string FirstName { get; set; }
        [StringLength(50)]
        public required string LastName { get; set; }
        public required DateTime DateOfBirth { get; set; }
    }
}
