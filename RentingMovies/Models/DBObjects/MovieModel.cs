using System.ComponentModel.DataAnnotations;

namespace RentingMovies.Models.DBObjects
{
    public class MovieModel
    {
        public Guid IdMovie { get; set; }
        [StringLength(500, ErrorMessage ="String too long(max 500 chars)")]
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int AvailableQuantity { get; set; }
        public float Price { get; set; }
        [DisplayFormat(DataFormatString="{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
