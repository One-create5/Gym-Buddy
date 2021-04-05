using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GymBuddySite.Models;

namespace GymBuddySite.Controllers
{
    public class MaxliftsController : Controller
    {
        private readonly GymBuddyDBContext _context;

        public MaxliftsController(GymBuddyDBContext context)
        {
            _context = context;
        }

        // GET: Maxlifts
        public async Task<IActionResult> Index()
        {
            var gymBuddyDBContext = _context.Maxlifts.Include(m => m.Workout);
            return View(await gymBuddyDBContext.ToListAsync());
        }

        // GET: Maxlifts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maxlift = await _context.Maxlifts
                .Include(m => m.Workout)
                .FirstOrDefaultAsync(m => m.MaxliftsId == id);
            if (maxlift == null)
            {
                return NotFound();
            }

            return View(maxlift);
        }

        // GET: Maxlifts/Create
        public IActionResult Create()
        {
            ViewData["WorkoutId"] = new SelectList(_context.Workouts, "Id", "Id");
            return View();
        }

        // POST: Maxlifts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaxliftsId,MaxBench,MaxSquat,MaxDeadLift,WorkoutId")] Maxlift maxlift)
        {
            if (ModelState.IsValid)
            {
                _context.Add(maxlift);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["WorkoutId"] = new SelectList(_context.Workouts, "Id", "Id", maxlift.WorkoutId);
            return View(maxlift);
        }

        // GET: Maxlifts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maxlift = await _context.Maxlifts.FindAsync(id);
            if (maxlift == null)
            {
                return NotFound();
            }
            ViewData["WorkoutId"] = new SelectList(_context.Workouts, "Id", "Id", maxlift.WorkoutId);
            return View(maxlift);
        }

        // POST: Maxlifts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaxliftsId,MaxBench,MaxSquat,MaxDeadLift,WorkoutId")] Maxlift maxlift)
        {
            if (id != maxlift.MaxliftsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(maxlift);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaxliftExists(maxlift.MaxliftsId))
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
            ViewData["WorkoutId"] = new SelectList(_context.Workouts, "Id", "Id", maxlift.WorkoutId);
            return View(maxlift);
        }

        // GET: Maxlifts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maxlift = await _context.Maxlifts
                .Include(m => m.Workout)
                .FirstOrDefaultAsync(m => m.MaxliftsId == id);
            if (maxlift == null)
            {
                return NotFound();
            }

            return View(maxlift);
        }

        // POST: Maxlifts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var maxlift = await _context.Maxlifts.FindAsync(id);
            _context.Maxlifts.Remove(maxlift);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaxliftExists(int id)
        {
            return _context.Maxlifts.Any(e => e.MaxliftsId == id);
        }
    }
}
