using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc.Rendering;

namespace GymBuddy.Models.ViewModels
{
    public class PowerliftingVM
    {
        public PowerliftWorkout PowerliftWorkout { get; set; }
        public IEnumerable<WorkoutExercise> WorkoutExercises { get; set; }

    }
}
