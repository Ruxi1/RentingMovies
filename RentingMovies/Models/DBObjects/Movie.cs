using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentingMovies.Models.DBObjects
{
    public partial class Movie
    {
        
        [Key]
        public Guid IdMovie { get; set; }
        public string Name { get; set; } = null!;
        public int Quantity { get; set; }
        public int AvailableQuantity { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; }

        //public virtual ICollection<Renting> Rentings { get; set; }
    }
}
