using System;
using System.ComponentModel.DataAnnotations;

namespace BloodpressureApi.Models.Bloodpressure
{
    public class BloodpressureUpdateDto
    {
        [Required(ErrorMessage = "Ange ett id")]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Ange ett personid")]
        public int PersonId { get; set; }

        //upper pressure
        [Required(ErrorMessage = "Ange systolisk värde")]
        public int Systolic { get; set; }

        //lower pressure
        [Required(ErrorMessage = "Ange diastolisk värde")]
        public int Diastolic { get; set; }

        [Required(ErrorMessage = "Ange hjärtfrekvens")]
        public int Heartrate { get; set; }

        [Required(ErrorMessage = "Ange ett datum")]
        public DateTime Date { get; set; }

        public string Time { get; set; }

        public string Comment { get; set; }
    }
}
