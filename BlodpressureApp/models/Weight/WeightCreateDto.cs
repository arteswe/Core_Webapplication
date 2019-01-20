using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BloodpressureApp.Models.Weight
{
    public class WeightCreateDto
    {
        [Required(ErrorMessage = "Ange ett värde")]
        public double Weigth { get; set; }

        [Required(ErrorMessage = "Ange ett personnummer")]
        public string Personnummer { get; set; }

        [Required(ErrorMessage = "Ange ett datum")]
        public DateTime Date { get; set; }
    }
}
