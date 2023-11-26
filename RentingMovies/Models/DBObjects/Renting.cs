using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentingMovies.Models.DBObjects
{
    public partial class Renting
    {
        [Key]
        public Guid IdRenting { get; set; }
        public Guid IdMovie { get; set; }
        public Guid IdClient { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

       
    }
}
