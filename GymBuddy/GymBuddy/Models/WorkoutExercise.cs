using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GymBuddy.Models
{
    public class WorkoutExercise
    {
        [Key]
        public int WorkoutExerciseId { get; set; }

        public string Name { get; set; }

        public int Sets { get; set; }
        public int Reps { get; set; }

        [DisplayName("One Rep Max")]
        [Column(TypeName = "decimal(5,2)")]
        public decimal? OneRepMax { get; set; }

        [DisplayName("Rate of Perceived Exertion")]
        public int? RPE { get; set; }

    }
}
