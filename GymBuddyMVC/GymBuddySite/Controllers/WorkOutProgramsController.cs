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
    public class WorkOutProgramsController : Controller
    {
        private readonly GymBuddyDBContext _context;

        public WorkOutProgramsController(GymBuddyDBContext context)
        {
            _context = context;
        }

        // GET: WorkOutPrograms
        public async Task<IActionResult> Index()
        {
            var gymBuddyDBContext = _context.WorkOutPrograms.Include(w => w.Category);
            return View(await gymBuddyDBContext.ToListAsync());
        }

        // GET: WorkOutPrograms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workOutProgram = await _context.WorkOutPrograms
                .Include(w => w.Category)
                .FirstOrDefaultAsync(m => m.ProgramId == id);
            if (workOutProgram == null)
            {
                return NotFound();
            }

            return View(workOutProgram);
        }

        // GET: WorkOutPrograms/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id");
            return View();
        }

        // POST: WorkOutPrograms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProgramId,Title,Description,CategoryId,Days")] WorkOutProgram workOutProgram)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workOutProgram);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", workOutProgram.CategoryId);
            return View(workOutProgram);
        }

        // GET: WorkOutPrograms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workOutProgram = await _context.WorkOutPrograms.FindAsync(id);
            if (workOutProgram == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", workOutProgram.CategoryId);
            return View(workOutProgram);
        }

        // POST: WorkOutPrograms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProgramId,Title,Description,CategoryId,Days")] WorkOutProgram workOutProgram)
        {
            if (id != workOutProgram.ProgramId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workOutProgram);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkOutProgramExists(workOutProgram.ProgramId))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", workOutProgram.CategoryId);
            return View(workOutProgram);
        }

        // GET: WorkOutPrograms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workOutProgram = await _context.WorkOutPrograms
                .Include(w => w.Category)
                .FirstOrDefaultAsync(m => m.ProgramId == id);
            if (workOutProgram == null)
            {
                return NotFound();
            }

            return View(workOutProgram);
        }

        // POST: WorkOutPrograms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workOutProgram = await _context.WorkOutPrograms.FindAsync(id);
            _context.WorkOutPrograms.Remove(workOutProgram);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkOutProgramExists(int id)
        {
            return _context.WorkOutPrograms.Any(e => e.ProgramId == id);
        }
    }
}
