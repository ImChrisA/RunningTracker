using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Runtracker.Data;
using Runtracker.Models;

namespace Runtracker.Controllers
{
    public class RunningRoutesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RunningRoutesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RunningRoutes
        public async Task<IActionResult> Index()
        {
            return View(await _context.RunningRoute.ToListAsync());
        }

        // GET: RunningRoutes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var runningRoute = await _context.RunningRoute
                .FirstOrDefaultAsync(m => m.ID == id);
            if (runningRoute == null)
            {
                return NotFound();
            }

            return View(runningRoute);
        }

        // GET: RunningRoutes/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: RunningRoutes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,DistanceKm,Time,Notes")] RunningRoute runningRoute)
        {
            if (ModelState.IsValid)
            {
                _context.Add(runningRoute);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(runningRoute);
        }

        // GET: RunningRoutes/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var runningRoute = await _context.RunningRoute.FindAsync(id);
            if (runningRoute == null)
            {
                return NotFound();
            }
            return View(runningRoute);
        }

        // POST: RunningRoutes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,DistanceKm,Time,Notes")] RunningRoute runningRoute)
        {
            if (id != runningRoute.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(runningRoute);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RunningRouteExists(runningRoute.ID))
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
            return View(runningRoute);
        }

        // GET: RunningRoutes/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var runningRoute = await _context.RunningRoute
                .FirstOrDefaultAsync(m => m.ID == id);
            if (runningRoute == null)
            {
                return NotFound();
            }

            return View(runningRoute);
        }

        // POST: RunningRoutes/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var runningRoute = await _context.RunningRoute.FindAsync(id);
            if (runningRoute != null)
            {
                _context.RunningRoute.Remove(runningRoute);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RunningRouteExists(int id)
        {
            return _context.RunningRoute.Any(e => e.ID == id);
        }
    }
}
