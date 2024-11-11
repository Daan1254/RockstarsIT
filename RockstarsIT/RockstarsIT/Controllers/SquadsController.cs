using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RockstarsIT.Data;
using RockstarsIT.Models;

namespace RockstarsIT.Controllers
{
    public class SquadsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SquadsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Squads
        public async Task<IActionResult> Index()
        {
            return View(await _context.Squads.ToListAsync());
        }

        // GET: Squads/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var squads = await _context.Squads
                .FirstOrDefaultAsync(m => m.name == id);
            if (squads == null)
            {
                return NotFound();
            }

            return View(squads);
        }

        // GET: Squads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Squads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("name,description")] Squads squads)
        {
            if (ModelState.IsValid)
            {
                _context.Add(squads);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(squads);
        }

        // GET: Squads/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var squads = await _context.Squads.FindAsync(id);
            if (squads == null)
            {
                return NotFound();
            }
            return View(squads);
        }

        // POST: Squads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("name,description")] Squads squads)
        {
            if (id != squads.name)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(squads);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SquadsExists(squads.name))
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
            return View(squads);
        }

        // GET: Squads/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var squads = await _context.Squads
                .FirstOrDefaultAsync(m => m.name == id);
            if (squads == null)
            {
                return NotFound();
            }

            return View(squads);
        }

        // POST: Squads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var squads = await _context.Squads.FindAsync(id);
            if (squads != null)
            {
                _context.Squads.Remove(squads);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SquadsExists(string id)
        {
            return _context.Squads.Any(e => e.name == id);
        }
    }
}
