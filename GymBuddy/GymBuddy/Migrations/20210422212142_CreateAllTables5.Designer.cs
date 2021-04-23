﻿// <auto-generated />
using System;
using GymBuddy.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GymBuddy.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210422212142_CreateAllTables5")]
    partial class CreateAllTables5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GymBuddy.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("GymBuddy.Models.Exercise", b =>
                {
                    b.Property<int>("ExerciseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ExerciseId");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("GymBuddy.Models.MaxLift", b =>
                {
                    b.Property<int>("MaxLiftId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("MaxBench")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("MaxDeadLift")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("MaxSquat")
                        .HasColumnType("decimal(5,2)");

                    b.HasKey("MaxLiftId");

                    b.ToTable("MaxLifts");
                });

            modelBuilder.Entity("GymBuddy.Models.UserWorkout", b =>
                {
                    b.Property<int>("UserWorkoutId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("WorkoutDate")
                        .HasColumnType("datetime2");

                    b.HasKey("UserWorkoutId");

                    b.HasIndex("CategoryId");

                    b.ToTable("UserWorkouts");
                });

            modelBuilder.Entity("GymBuddy.Models.WorkoutExercise", b =>
                {
                    b.Property<int>("WorkoutExerciseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ExerciseId")
                        .HasColumnType("int");

                    b.Property<int>("MaxLiftId")
                        .HasColumnType("int");

                    b.Property<int>("Reps")
                        .HasColumnType("int");

                    b.Property<int>("UserWorkoutId")
                        .HasColumnType("int");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(5,2)");

                    b.HasKey("WorkoutExerciseId");

                    b.HasIndex("ExerciseId");

                    b.HasIndex("MaxLiftId");

                    b.HasIndex("UserWorkoutId");

                    b.ToTable("WorkoutExercises");
                });

            modelBuilder.Entity("GymBuddy.Models.UserWorkout", b =>
                {
                    b.HasOne("GymBuddy.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("GymBuddy.Models.WorkoutExercise", b =>
                {
                    b.HasOne("GymBuddy.Models.Exercise", "Exercise")
                        .WithMany("WorkoutExercises")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GymBuddy.Models.MaxLift", "MaxLift")
                        .WithMany("WorkoutExercises")
                        .HasForeignKey("MaxLiftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GymBuddy.Models.UserWorkout", "UserWorkout")
                        .WithMany("WorkoutExercises")
                        .HasForeignKey("UserWorkoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");

                    b.Navigation("MaxLift");

                    b.Navigation("UserWorkout");
                });

            modelBuilder.Entity("GymBuddy.Models.Exercise", b =>
                {
                    b.Navigation("WorkoutExercises");
                });

            modelBuilder.Entity("GymBuddy.Models.MaxLift", b =>
                {
                    b.Navigation("WorkoutExercises");
                });

            modelBuilder.Entity("GymBuddy.Models.UserWorkout", b =>
                {
                    b.Navigation("WorkoutExercises");
                });
#pragma warning restore 612, 618
        }
    }
}
