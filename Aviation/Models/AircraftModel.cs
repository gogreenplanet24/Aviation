using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aviation.Models
{
    public class AircraftModel
    {
        [Display(Name = "ID")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Make is required.")]
        public string Make { get; set; }

        [Required(ErrorMessage = "Model is required.")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Registration is required.")]
        public string Registration { get; set; }

        [Required(ErrorMessage = "Location is required.")]
        public string Location { get; set; }
        public string TimeStamp { get; set; }
        
    }
}