using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodpressureApp.Models
{
    [NotMapped]
    public class PersonDto
    {
        [Required]
        [MaxLength(10)]
        [MinLength(10)]
        public string Personnummer { get; set; }

        [Required(ErrorMessage = "Ange ett förnamn")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Ange ett efternamn")]
        public string Lastname { get; set; }

        public DateTime Birthday { get; set; }
       
        public IEnumerable<WeightDto> Weight { get; set; } = new List<WeightDto>();

        public ICollection<BloodpressureDto> PressureList { get; set; } = new List<BloodpressureDto>();
    }
}
