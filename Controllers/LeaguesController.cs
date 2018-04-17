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
    public class LeaguesController : Controller
    {
        private readonly SportsLeaguesDbContext _context;

        public LeaguesController(SportsLeaguesDbContext context)
        {
            _context = context;    
        }

        // GET: Leagues
        public async Task<IActionResult> Index()
        {
            var sportsLeaguesDbContext = _context.Leauges.Include(l => l.Sport);
            return View(await sportsLeaguesDbContext.ToListAsync());
        }

        // GET: Leagues/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var league = await _context.Leauges
                .Include(l => l.Sport)
                .SingleOrDefaultAsync(m => m.LeagueId == id);
            if (league == null)
            {
                return NotFound();
            }

            return View(league);
        }

        // GET: Leagues/Create
        public IActionResult Create()
        {
            ViewData["SportId"] = new SelectList(_context.Sports, "SportId", "SportId");
            return View();
        }

        // POST: Leagues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LeagueId,Name,Description,SportId")] League league)
        {
            if (ModelState.IsValid)
            {
                _context.Add(league);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["SportId"] = new SelectList(_context.Sports, "SportId", "SportId", league.SportId);
            return View(league);
        }

        // GET: Leagues/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var league = await _context.Leauges.SingleOrDefaultAsync(m => m.LeagueId == id);
            if (league == null)
            {
                return NotFound();
            }
            ViewData["SportId"] = new SelectList(_context.Sports, "SportId", "SportId", league.SportId);
            return View(league);
        }

        // POST: Leagues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LeagueId,Name,Description,SportId")] League league)
        {
            if (id != league.LeagueId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(league);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeagueExists(league.LeagueId))
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
            ViewData["SportId"] = new SelectList(_context.Sports, "SportId", "SportId", league.SportId);
            return View(league);
        }

        // GET: Leagues/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var league = await _context.Leauges
                .Include(l => l.Sport)
                .SingleOrDefaultAsync(m => m.LeagueId == id);
            if (league == null)
            {
                return NotFound();
            }

            return View(league);
        }

        // POST: Leagues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var league = await _context.Leauges.SingleOrDefaultAsync(m => m.LeagueId == id);
            _context.Leauges.Remove(league);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool LeagueExists(int id)
        {
            return _context.Leauges.Any(e => e.LeagueId == id);
        }
    }
}
