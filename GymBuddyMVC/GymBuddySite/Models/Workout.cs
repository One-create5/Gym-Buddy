using System;
using System.Collections.Generic;

#nullable disable

namespace GymBuddySite.Models
{
    public partial class Workout
    {
        public Workout()
        {
            Maxlifts = new HashSet<Maxlift>();
        }

        public int Id { get; set; }
        public int? WorkoutId { get; set; }
        public string Name { get; set; }
        public int? Reps { get; set; }
        public decimal? Weight { get; set; }
        public int? Sets { get; set; }

        public virtual Category WorkoutNavigation { get; set; }
        public virtual ICollection<Maxlift> Maxlifts { get; set; }
    }
}
