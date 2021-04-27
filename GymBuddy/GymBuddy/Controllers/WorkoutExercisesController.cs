using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GymBuddy.Data;
using GymBuddy.Models;

namespace GymBuddy.Controllers
{
    public class WorkoutExercisesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WorkoutExercisesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WorkoutExercises
        public async Task<IActionResult> Index()
        {
            return View(await _context.WorkoutExercises.ToListAsync());
        }

        // GET: WorkoutExercises/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workoutExercise = await _context.WorkoutExercises
                .FirstOrDefaultAsync(m => m.WorkoutExerciseId == id);
            if (workoutExercise == null)
            {
                return NotFound();
            }

            return View(workoutExercise);
        }

        // GET: WorkoutExercises/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WorkoutExercises/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WorkoutExerciseId,Name,Sets,Reps,OneRepMax,RPE")] WorkoutExercise workoutExercise)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workoutExercise);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workoutExercise);
        }

        // GET: WorkoutExercises/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workoutExercise = await _context.WorkoutExercises.FindAsync(id);
            if (workoutExercise == null)
            {
                return NotFound();
            }
            return View(workoutExercise);
        }

        // POST: WorkoutExercises/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WorkoutExerciseId,Name,Sets,Reps,OneRepMax,RPE")] WorkoutExercise workoutExercise)
        {
            if (id != workoutExercise.WorkoutExerciseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workoutExercise);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkoutExerciseExists(workoutExercise.WorkoutExerciseId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(workoutExercise);
        }

        // GET: WorkoutExercises/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workoutExercise = await _context.WorkoutExercises
                .FirstOrDefaultAsync(m => m.WorkoutExerciseId == id);
            if (workoutExercise == null)
            {
                return NotFound();
            }

            return View(workoutExercise);
        }

        // POST: WorkoutExercises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workoutExercise = await _context.WorkoutExercises.FindAsync(id);
            _context.WorkoutExercises.Remove(workoutExercise);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkoutExerciseExists(int id)
        {
            return _context.WorkoutExercises.Any(e => e.WorkoutExerciseId == id);
        }
    }
}
