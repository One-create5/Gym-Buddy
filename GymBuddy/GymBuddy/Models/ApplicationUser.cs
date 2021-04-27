using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace GymBuddy.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<PowerliftWorkout> PowerliftWorkouts { get; set; }

        public ICollection<BodyBuildingWorkout> BodyBuildingWorkouts { get; set; }

        public ICollection<PowerBuildingWorkout> PowerBuildingWorkouts { get; set; }
    }
}
