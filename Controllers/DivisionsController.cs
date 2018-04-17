using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportLeague.Models;

namespace SportLeague.Controllers
{
    public class DivisionsController : Controller
    {
        private readonly SportsLeaguesDbContext _context;

        public DivisionsController(SportsLeaguesDbContext context)
        {
            _context = context;    
        }

        // GET: Divisions
        public async Task<IActionResult> Index()
        {
            var sportsLeaguesDbContext = _context.Divisions.Include(d => d.League);
            return View(await sportsLeaguesDbContext.ToListAsync());
        }

        // GET: Divisions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var division = await _context.Divisions
                .Include(d => d.League)
                .SingleOrDefaultAsync(m => m.DivisionId == id);
            if (division == null)
            {
                return NotFound();
            }

            return View(division);
        }

        // GET: Divisions/Create
        public IActionResult Create()
        {
            ViewData["LeagueId"] = new SelectList(_context.Leauges, "LeagueId", "LeagueId");
            return View();
        }

        // POST: Divisions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DivisionId,Name,Description,LeagueId")] Division division)
        {
            if (ModelState.IsValid)
            {
                _context.Add(division);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["LeagueId"] = new SelectList(_context.Leauges, "LeagueId", "LeagueId", division.LeagueId);
            return View(division);
        }

        // GET: Divisions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var division = await _context.Divisions.SingleOrDefaultAsync(m => m.DivisionId == id);
            if (division == null)
            {
                return NotFound();
            }
            ViewData["LeagueId"] = new SelectList(_context.Leauges, "LeagueId", "LeagueId", division.LeagueId);
            return View(division);
        }

        // POST: Divisions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DivisionId,Name,Description,LeagueId")] Division division)
        {
            if (id != division.DivisionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(division);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DivisionExists(division.DivisionId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["LeagueId"] = new SelectList(_context.Leauges, "LeagueId", "LeagueId", division.LeagueId);
            return View(division);
        }

        // GET: Divisions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var division = await _context.Divisions
                .Include(d => d.League)
                .SingleOrDefaultAsync(m => m.DivisionId == id);
            if (division == null)
            {
                return NotFound();
            }

            return View(division);
        }

        // POST: Divisions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var division = await _context.Divisions.SingleOrDefaultAsync(m => m.DivisionId == id);
            _context.Divisions.Remove(division);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool DivisionExists(int id)
        {
            return _context.Divisions.Any(e => e.DivisionId == id);
        }
    }
}
