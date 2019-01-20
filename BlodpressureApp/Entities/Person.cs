using BloodpressureApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodpressureApp.Entities
{
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MinLength(10)]
        [MaxLength(10)]
        public string Personnummer { get; set; }

        public string Firstname { get; set; }

        [Required]
        [MaxLength(200)]
        public string Lastname { get; set; }

        public DateTime Birthday { get; set; }

        public IEnumerable<Weight> Weight { get; set; } = new List<Weight>();

        public ICollection<Bloodpressure> PressureList { get; set; } = new List<Bloodpressure>();
    }
}
