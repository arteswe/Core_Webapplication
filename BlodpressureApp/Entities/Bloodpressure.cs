using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodpressureApp.Entities
{
    public class Bloodpressure

    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("PersonId")]
        public Person Person { get; set; }
      
        public int? PersonId { get; set; }

        //upper pressure
        public int Systolic { get; set; }

        //lower pressure
        public int Diastolic { get; set; }

        public int Heartrate { get; set; }

        public DateTime Date { get; set; }

        public string Time { get; set; }

        public string  Comment{ get; set; }
    }
}
