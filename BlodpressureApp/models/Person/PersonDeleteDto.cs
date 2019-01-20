using System;
using System.ComponentModel.DataAnnotations;

namespace BloodpressureApp.Models
{
    public class PersonDeleteDto
    {
        [Required(ErrorMessage = "Ange ett personnummer")]
        public string PersonNummer { get; set; }

        [Required(ErrorMessage = "Ange ett efternamn")]
        public string Lastname { get; set; }

    }
}
