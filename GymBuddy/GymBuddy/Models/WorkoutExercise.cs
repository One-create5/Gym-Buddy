using System;
using System.Collections.Generic;
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

        public int Reps { get; set; }


        [Column(TypeName = "decimal(5,2)")]
        public decimal Weight { get; set; }


        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }


        public int MaxLiftId { get; set; }
        public MaxLift MaxLift { get; set; }

        public int UserWorkoutId { get; set; }
        public UserWorkout UserWorkout { get; set; }

    }
}
