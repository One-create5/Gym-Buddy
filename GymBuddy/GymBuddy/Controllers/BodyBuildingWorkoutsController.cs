using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GymBuddy.Data;
using GymBuddy.Models;
using GymBuddy.Models.ViewModels;
using System.Security.Claims;

namespace GymBuddy.Controllers
{
    public class BodyBuildingWorkoutsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BodyBuildingWorkoutsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BodyBuildingWorkouts
        public async Task<IActionResult> Index()
        {
            var user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var bodybuildingContext = _context.BodyBuildingWorkouts.Where(p => p.ApplicationId == user);

            return View(await bodybuildingContext.ToListAsync());
        }

        // GET: BodyBuildingWorkouts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bodyBuildingWorkout = await _context.BodyBuildingWorkouts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bodyBuildingWorkout == null)
            {
                return NotFound();
            }

            BodybuildingVM bodybuildingVM = new() 
            {
                BodyBuildingWorkout = bodyBuildingWorkout,
                WorkoutExercises = _context.WorkoutExercises
            };

            return View(bodybuildingVM);
        }

        // GET: BodyBuildingWorkouts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BodyBuildingWorkouts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,WorkoutDate,Title,MaxBench,MaxSquat,MaxDeadLift,ApplicationId")] BodyBuildingWorkout bodyBuildingWorkout)
        {
            BodybuildingVM bodybuildingVM = new() 
            {
                BodyBuildingWorkout = bodyBuildingWorkout,
                WorkoutExercises = _context.WorkoutExercises
            };

            if (ModelState.IsValid)
            {
                bodybuildingVM.BodyBuildingWorkout.ApplicationId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                _context.Add(bodybuildingVM.BodyBuildingWorkout);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bodybuildingVM);
        }

        // GET: BodyBuildingWorkouts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bodyBuildingWorkout = await _context.BodyBuildingWorkouts.FindAsync(id);
            if (bodyBuildingWorkout == null)
            {
                return NotFound();
            }
            return View(bodyBuildingWorkout);
        }

        // POST: BodyBuildingWorkouts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,WorkoutDate,Title,MaxBench,MaxSquat,MaxDeadLift,ApplicationId")] BodyBuildingWorkout bodyBuildingWorkout)
        {
            if (id != bodyBuildingWorkout.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bodyBuildingWorkout);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BodyBuildingWorkoutExists(bodyBuildingWorkout.Id))
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
            return View(bodyBuildingWorkout);
        }

        // GET: BodyBuildingWorkouts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bodyBuildingWorkout = await _context.BodyBuildingWorkouts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bodyBuildingWorkout == null)
            {
                return NotFound();
            }

            return View(bodyBuildingWorkout);
        }

        // POST: BodyBuildingWorkouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bodyBuildingWorkout = await _context.BodyBuildingWorkouts.FindAsync(id);
            _context.BodyBuildingWorkouts.Remove(bodyBuildingWorkout);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BodyBuildingWorkoutExists(int id)
        {
            return _context.BodyBuildingWorkouts.Any(e => e.Id == id);
        }
    }
}
