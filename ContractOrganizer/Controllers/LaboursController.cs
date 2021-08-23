using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContractOrganizer.Data;
using ContractOrganizer.Models;

namespace ContractOrganizer.Controllers
{
    public class LaboursController : Controller
    {
        private readonly ContractOrganizerContext _context;

        public LaboursController(ContractOrganizerContext context)
        {
            _context = context;
        }

        // GET: Labours
        public async Task<IActionResult> Index()
        {
            return View(await _context.Labour.ToListAsync());
        }

        // GET: Labours/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labour = await _context.Labour
                .FirstOrDefaultAsync(m => m.id == id);
            if (labour == null)
            {
                return NotFound();
            }

            return View(labour);
        }

        // GET: Labours/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Labours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Name,Contact,Address,dTime")] Labour labour)
        {
            if (ModelState.IsValid)
            {
                _context.Add(labour);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(labour);
        }

        // GET: Labours/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labour = await _context.Labour.FindAsync(id);
            if (labour == null)
            {
                return NotFound();
            }
            return View(labour);
        }

        // POST: Labours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Name,Contact,Address,dTime")] Labour labour)
        {
            if (id != labour.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(labour);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LabourExists(labour.id))
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
            return View(labour);
        }

        // GET: Labours/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labour = await _context.Labour
                .FirstOrDefaultAsync(m => m.id == id);
            if (labour == null)
            {
                return NotFound();
            }

            return View(labour);
        }

        // POST: Labours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var labour = await _context.Labour.FindAsync(id);
            _context.Labour.Remove(labour);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LabourExists(int id)
        {
            return _context.Labour.Any(e => e.id == id);
        }
    }
}
