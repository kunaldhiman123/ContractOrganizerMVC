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
    public class adminsController : Controller
    {
        private readonly ContractOrganizerContext _context;

        public adminsController(ContractOrganizerContext context)
        {
            _context = context;
        }

        // GET: admins
        public async Task<IActionResult> Index()
        {
            return View(await _context.admin.ToListAsync());
        }

        // GET: admins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admin = await _context.admin
                .FirstOrDefaultAsync(m => m.id == id);
            if (admin == null)
            {
                return NotFound();
            }

            return View(admin);
        }

        // GET: admins/Create
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Correct()
        {
            return View();
        }

        public IActionResult inCorrect()
        {
            return View();
        }

        // POST: admins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Email,Password")] admin admin)
        {
            if (admin.Email.Equals("admin@gmail.com") && admin.Password.Equals("admin")) {
                return RedirectToAction(nameof(Correct));
            }
            else{
                return RedirectToAction(nameof(inCorrect));

            }

        }

        // GET: admins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admin = await _context.admin.FindAsync(id);
            if (admin == null)
            {
                return NotFound();
            }
            return View(admin);
        }

        // POST: admins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Email,Password")] admin admin)
        {
            if (id != admin.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(admin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!adminExists(admin.id))
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
            return View(admin);
        }

        // GET: admins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admin = await _context.admin
                .FirstOrDefaultAsync(m => m.id == id);
            if (admin == null)
            {
                return NotFound();
            }

            return View(admin);
        }

        // POST: admins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var admin = await _context.admin.FindAsync(id);
            _context.admin.Remove(admin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool adminExists(int id)
        {
            return _context.admin.Any(e => e.id == id);
        }
    }
}
