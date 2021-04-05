using System;
using System.Collections.Generic;

#nullable disable

namespace GymBuddySite.Models
{
    public partial class Maxlift
    {
        public Maxlift()
        {
            Customers = new HashSet<Customer>();
        }

        public int MaxliftsId { get; set; }
        public decimal? MaxBench { get; set; }
        public decimal? MaxSquat { get; set; }
        public decimal? MaxDeadLift { get; set; }
        public int? WorkoutId { get; set; }

        public virtual Workout Workout { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
