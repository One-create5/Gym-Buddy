using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymBuddy.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace GymBuddy.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opt) : base(opt)
        {

        }

        //public MaxLift MaxLift { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Exercise> Exercises { get; set; }

        public DbSet<MaxLift> MaxLifts { get; set; }

        public DbSet<UserWorkout> UserWorkouts { get; set; }

        public DbSet<WorkoutExercise> WorkoutExercises { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
