using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentingMovies.Models.DBObjects
{
    public partial class Client
    {
        
        [Key]
        public Guid IdClient { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;

        //public virtual ICollection<Renting> Rentings { get; set; }
    }
}
