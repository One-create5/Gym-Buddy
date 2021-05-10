using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GymBuddy.Data;
using GymBuddy.Models;
using System.Security.Claims;
using GymBuddy.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace GymBuddy.Controllers
{
    [Authorize]
    public class PowerBuildingWorkoutsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PowerBuildingWorkoutsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PowerBuildingWorkouts
        public async Task<IActionResult> Index()
        {
            var user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var powerBuildingContext = _context.PowerBuildingWorkouts.Where(p => p.ApplicationId == user);
            return View(await powerBuildingContext.ToListAsync());
        }

        // GET: PowerBuildingWorkouts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var powerBuildingWorkout = await _context.PowerBuildingWorkouts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (powerBuildingWorkout == null)
            {
                return NotFound();
            }

            PowerbuildingVM powerbuildingVM = new()
            {
                PowerBuildingWorkout = powerBuildingWorkout,
                WorkoutExercises = _context.WorkoutExercises
            };

            return View(powerbuildingVM);
        }

        // GET: PowerBuildingWorkouts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PowerBuildingWorkouts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,WorkoutDate,Title,MaxBench,MaxSquat,MaxDeadLift,ApplicationId")] PowerBuildingWorkout powerBuildingWorkout)
        {

            PowerbuildingVM powerbuildingVM = new() 
            {
                PowerBuildingWorkout = powerBuildingWorkout,
                WorkoutExercises = _context.WorkoutExercises
            };

            if (ModelState.IsValid)
            {
                powerbuildingVM.PowerBuildingWorkout.ApplicationId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                _context.Add(powerbuildingVM.PowerBuildingWorkout);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(powerbuildingVM);
        }

        // GET: PowerBuildingWorkouts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var powerBuildingWorkout = await _context.PowerBuildingWorkouts.FindAsync(id);
            if (powerBuildingWorkout == null)
            {
                return NotFound();
            }
            return View(powerBuildingWorkout);
        }

        // POST: PowerBuildingWorkouts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,WorkoutDate,Title,MaxBench,MaxSquat,MaxDeadLift,ApplicationId")] PowerBuildingWorkout powerBuildingWorkout)
        {
            if (id != powerBuildingWorkout.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(powerBuildingWorkout);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PowerBuildingWorkoutExists(powerBuildingWorkout.Id))
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
            return View(powerBuildingWorkout);
        }

        // GET: PowerBuildingWorkouts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var powerBuildingWorkout = await _context.PowerBuildingWorkouts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (powerBuildingWorkout == null)
            {
                return NotFound();
            }

            return View(powerBuildingWorkout);
        }

        // POST: PowerBuildingWorkouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var powerBuildingWorkout = await _context.PowerBuildingWorkouts.FindAsync(id);
            _context.PowerBuildingWorkouts.Remove(powerBuildingWorkout);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PowerBuildingWorkoutExists(int id)
        {
            return _context.PowerBuildingWorkouts.Any(e => e.Id == id);
        }
    }
}
