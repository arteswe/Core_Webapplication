using System;
using System.ComponentModel.DataAnnotations;

namespace BloodpressureApp.Models
{
    public class PersonCreateDto
    {
        [Required(ErrorMessage = "Ange ett personnummer")]
        public string PersonNummer { get; set; }

        [Required(ErrorMessage = "Ange ett förnamn")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Ange ett efternamn")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Ange ett födelsedatum")]
        public DateTime Birthday { get; set; }
        
    }
}
