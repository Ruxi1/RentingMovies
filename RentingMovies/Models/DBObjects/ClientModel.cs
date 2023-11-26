using System.ComponentModel.DataAnnotations;

namespace RentingMovies.Models.DBObjects
{
    public class ClientModel
    {
        public Guid IdClient { get; set; }
        [StringLength(500, ErrorMessage = "String too long(max 500 chars)")]
        public string Name { get; set; }
        [StringLength(50, ErrorMessage = "String too long(max 50 chars)")]
        public string Email { get; set; }
        [StringLength(20, ErrorMessage = "String too long(max 20 chars)")]
        public string Phone { get; set; }
    }
}
