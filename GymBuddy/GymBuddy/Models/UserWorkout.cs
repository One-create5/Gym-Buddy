using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GymBuddy.Models
{
    public class UserWorkout
    {
        [Key]
        public int UserWorkoutId { get; set; }

        [DisplayName("Workout Date")]
        public DateTime WorkoutDate { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<WorkoutExercise> WorkoutExercises { get; set; }

    }
}
