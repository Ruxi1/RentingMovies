using System.ComponentModel.DataAnnotations;

namespace RentingMovies.Models.DBObjects
{
    public class RentingModel
    {
        public Guid IdRenting { get; set; }
        public Guid IdMovie { get; set; }
        public Guid IdClient { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }
    }
}
