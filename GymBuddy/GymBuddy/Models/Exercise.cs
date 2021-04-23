using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GymBuddy.Models
{
    public class Exercise
    {
        [Key]
        public int ExerciseId { get; set; }

        public string Name { get; set; }

       public ICollection<WorkoutExercise> WorkoutExercises { get; set; }

    }
}
