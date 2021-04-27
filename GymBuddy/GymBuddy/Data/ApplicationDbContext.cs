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


        public DbSet<WorkoutExercise> WorkoutExercises { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<PowerliftWorkout> PowerliftWorkouts { get; set; }

        public DbSet<BodyBuildingWorkout> BodyBuildingWorkouts { get; set; }

        public DbSet<PowerBuildingWorkout> PowerBuildingWorkouts { get; set; }
    }
}
