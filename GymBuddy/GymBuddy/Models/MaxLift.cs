using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Collections.Generic;

namespace GymBuddy.Models
{
    public class MaxLift
    {
        [Key]
        public int MaxLiftId { get; set; }


        [DisplayName("Max Bench")]
        [Column(TypeName = "decimal(5,2)")]
        public decimal MaxBench { get; set; }


        [DisplayName("Max Squat")]
        [Column(TypeName = "decimal(5,2)")]
        public decimal MaxSquat { get; set; }


        [DisplayName("Max Deadlift")]
        [Column(TypeName = "decimal(5,2)")]
        public decimal MaxDeadLift { get; set; }


        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }


        public ICollection<WorkoutExercise> WorkoutExercises { get; set; }


    }
}
