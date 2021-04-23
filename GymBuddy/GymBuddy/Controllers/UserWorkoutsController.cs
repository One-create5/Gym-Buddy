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
    public class UserWorkoutsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserWorkoutsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserWorkouts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.UserWorkouts.Include(u => u.Category);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: UserWorkouts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userWorkout = await _context.UserWorkouts
                .Include(u => u.Category)
                .FirstOrDefaultAsync(m => m.UserWorkoutId == id);
            if (userWorkout == null)
            {
                return NotFound();
            }

            return View(userWorkout);
        }

        // GET: UserWorkouts/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId");
            return View();
        }

        // POST: UserWorkouts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserWorkoutId,WorkoutDate,CategoryId")] UserWorkout userWorkout)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userWorkout);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", userWorkout.CategoryId);
            return View(userWorkout);
        }

        // GET: UserWorkouts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userWorkout = await _context.UserWorkouts.FindAsync(id);
            if (userWorkout == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", userWorkout.CategoryId);
            return View(userWorkout);
        }

        // POST: UserWorkouts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserWorkoutId,WorkoutDate,CategoryId")] UserWorkout userWorkout)
        {
            if (id != userWorkout.UserWorkoutId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userWorkout);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserWorkoutExists(userWorkout.UserWorkoutId))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", userWorkout.CategoryId);
            return View(userWorkout);
        }

        // GET: UserWorkouts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userWorkout = await _context.UserWorkouts
                .Include(u => u.Category)
                .FirstOrDefaultAsync(m => m.UserWorkoutId == id);
            if (userWorkout == null)
            {
                return NotFound();
            }

            return View(userWorkout);
        }

        // POST: UserWorkouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userWorkout = await _context.UserWorkouts.FindAsync(id);
            _context.UserWorkouts.Remove(userWorkout);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserWorkoutExists(int id)
        {
            return _context.UserWorkouts.Any(e => e.UserWorkoutId == id);
        }
    }
}
