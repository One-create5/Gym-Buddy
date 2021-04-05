using System;
using System.Collections.Generic;

#nullable disable

namespace GymBuddySite.Models
{
    public partial class Category
    {
        public Category()
        {
            WorkOutPrograms = new HashSet<WorkOutProgram>();
            Workouts = new HashSet<Workout>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int WorkOutId { get; set; }

        public virtual ICollection<WorkOutProgram> WorkOutPrograms { get; set; }
        public virtual ICollection<Workout> Workouts { get; set; }
    }
}
