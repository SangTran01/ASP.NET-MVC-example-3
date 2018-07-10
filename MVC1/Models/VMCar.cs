using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC1.Models
{
    public class VMCar
    {
        [Key]
        public int ID { get; set; }

        [Required, Display(Name = "Manufacturer")]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        [Range(1990, 2050)]
        public int? Year { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Owner Name")]
        public string OwnerName { get; set; }
    }
}