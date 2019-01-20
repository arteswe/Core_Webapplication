using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodpressureApp.Models
{
    [NotMapped]
    public class BloodpressureDto
    {
        
        public string Personnummer { get; set; }
        //upper pressurean
        public int Systolic { get; set; }
        //lower pressure
        public int Diastolic { get; set; }

        public int Heartrate { get; set; }
        
        public DateTime Date { get; set; }

        public string Time { get; set; }

    }
}
