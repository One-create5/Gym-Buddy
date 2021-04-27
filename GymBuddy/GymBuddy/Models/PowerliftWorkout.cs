using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GymBuddy.Models
{
    public class PowerliftWorkout
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Workout Date")]
        public DateTime WorkoutDate { get; set; }

        public String Title { get; set; }

        [DisplayName("Max Bench")]
        [Column(TypeName = "decimal(5,2)")]
        public decimal MaxBench { get; set; }


        [DisplayName("Max Squat")]
        [Column(TypeName = "decimal(5,2)")]
        public decimal MaxSquat { get; set; }


        [DisplayName("Max Deadlift")]
        [Column(TypeName = "decimal(5,2)")]
        public decimal MaxDeadLift { get; set; }

        public String ApplicationId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }


    }
}
