using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodpressureApp.Entities
{
    public class Weight
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public double Weigth { get; set; }

        [ForeignKey("PersonId")]
        public Person Person { get; set; }
        public int PersonId { get; set; }

        public DateTime Date { get; set; }
    }
}
