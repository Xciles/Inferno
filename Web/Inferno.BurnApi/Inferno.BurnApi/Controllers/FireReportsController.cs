using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Inferno.BurnApi.Data;
using Inferno.BurnApi.Domain;

namespace Inferno.BurnApi.Controllers
{
    public class FireReportsController : Controller
    {
        private readonly InfernoDbContext _context;

        public FireReportsController(InfernoDbContext context)
        {
            _context = context;
        }

        // GET: FireReports
        public async Task<IActionResult> Index()
        {
            var infernoDbContext = _context.FireReports;
            return View(await infernoDbContext.ToListAsync());
        }

        // GET: FireReports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fireReport = await _context.FireReports
                .SingleOrDefaultAsync(m => m.Id == id);
            if (fireReport == null)
            {
                return NotFound();
            }

            return View(fireReport);
        }

        // GET: FireReports/Create
        public IActionResult Create()
        {
            ViewData["DroneAssignmentId"] = new SelectList(_context.DroneAssignments, "Id", "Id");
            return View();
        }

        // POST: FireReports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CoordinateAsJson,FireSeverity,TimeStamp,DroneAssignmentId")] FireReport fireReport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fireReport);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(fireReport);
        }

        // GET: FireReports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fireReport = await _context.FireReports.SingleOrDefaultAsync(m => m.Id == id);
            if (fireReport == null)
            {
                return NotFound();
            }
            return View(fireReport);
        }

        // POST: FireReports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CoordinateAsJson,FireSeverity,TimeStamp,DroneAssignmentId")] FireReport fireReport)
        {
            if (id != fireReport.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fireReport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FireReportExists(fireReport.Id))
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
            return View(fireReport);
        }

        // GET: FireReports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fireReport = await _context.FireReports

                .SingleOrDefaultAsync(m => m.Id == id);
            if (fireReport == null)
            {
                return NotFound();
            }

            return View(fireReport);
        }

        // POST: FireReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fireReport = await _context.FireReports.SingleOrDefaultAsync(m => m.Id == id);
            _context.FireReports.Remove(fireReport);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool FireReportExists(int id)
        {
            return _context.FireReports.Any(e => e.Id == id);
        }
    }
}
