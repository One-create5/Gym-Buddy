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
    public class PowerliftWorkoutsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PowerliftWorkoutsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PowerliftWorkouts
        public async Task<IActionResult> Index()
        {
            var user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var powerliftingContext = _context.PowerliftWorkouts.Where(p => p.ApplicationId == user);

            //return View(await _context.PowerliftWorkouts.ToListAsync());
            return View(await powerliftingContext.ToListAsync());
        }

        // GET: PowerliftWorkouts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var powerliftWorkout = await _context.PowerliftWorkouts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (powerliftWorkout == null)
            {
                return NotFound();
            }

            PowerliftingVM powerliftingVM = new()
            {
                PowerliftWorkout = powerliftWorkout,
                WorkoutExercises = _context.WorkoutExercises
            };
            

            return View(powerliftingVM);
        }

        // GET: PowerliftWorkouts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PowerliftWorkouts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,WorkoutDate,Title,MaxBench,MaxSquat,MaxDeadLift, ApplicationId")] PowerliftWorkout powerliftWorkout)
        {

            PowerliftingVM powerliftingVM = new() 
            {
                PowerliftWorkout = powerliftWorkout,
                WorkoutExercises = _context.WorkoutExercises
            };

            if (ModelState.IsValid)
            {
                powerliftingVM.PowerliftWorkout.ApplicationId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                _context.Add(powerliftingVM.PowerliftWorkout);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(powerliftingVM);
        }

        // GET: PowerliftWorkouts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var powerliftWorkout = await _context.PowerliftWorkouts.FindAsync(id);
            if (powerliftWorkout == null)
            {
                return NotFound();
            }
            return View(powerliftWorkout);
        }

        // POST: PowerliftWorkouts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,WorkoutDate,Title,MaxBench,MaxSquat,MaxDeadLift")] PowerliftWorkout powerliftWorkout)
        {
            if (id != powerliftWorkout.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(powerliftWorkout);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PowerliftWorkoutExists(powerliftWorkout.Id))
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
            return View(powerliftWorkout);
        }

        // GET: PowerliftWorkouts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var powerliftWorkout = await _context.PowerliftWorkouts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (powerliftWorkout == null)
            {
                return NotFound();
            }

            return View(powerliftWorkout);
        }

        // POST: PowerliftWorkouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var powerliftWorkout = await _context.PowerliftWorkouts.FindAsync(id);
            _context.PowerliftWorkouts.Remove(powerliftWorkout);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PowerliftWorkoutExists(int id)
        {
            return _context.PowerliftWorkouts.Any(e => e.Id == id);
        }
    }
}
