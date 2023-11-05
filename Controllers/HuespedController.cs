using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoP1_final.Data;
using ProyectoP1_final.Models;

namespace ProyectoP1_final.Controllers
{
    public class HuespedController : Controller
    {
        private readonly ProyectoP1_finalContext _context;

        public HuespedController(ProyectoP1_finalContext context)
        {
            _context = context;
        }

        // GET: Huesped
        public async Task<IActionResult> Index()
        {
              return _context.Huesped != null ? 
                          View(await _context.Huesped.ToListAsync()) :
                          Problem("Entity set 'ProyectoP1_finalContext.Huesped'  is null.");
        }

        // GET: Huesped/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Huesped == null)
            {
                return NotFound();
            }

            var huesped = await _context.Huesped
                .FirstOrDefaultAsync(m => m.HuespedID == id);
            if (huesped == null)
            {
                return NotFound();
            }

            return View(huesped);
        }

        // GET: Huesped/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Huesped/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HuespedID,NombreHuesped")] Huesped huesped)
        {
            if (ModelState.IsValid)
            {
                _context.Add(huesped);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(huesped);
        }

        // GET: Huesped/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Huesped == null)
            {
                return NotFound();
            }

            var huesped = await _context.Huesped.FindAsync(id);
            if (huesped == null)
            {
                return NotFound();
            }
            return View(huesped);
        }

        // POST: Huesped/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HuespedID,NombreHuesped")] Huesped huesped)
        {
            if (id != huesped.HuespedID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(huesped);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HuespedExists(huesped.HuespedID))
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
            return View(huesped);
        }

        // GET: Huesped/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Huesped == null)
            {
                return NotFound();
            }

            var huesped = await _context.Huesped
                .FirstOrDefaultAsync(m => m.HuespedID == id);
            if (huesped == null)
            {
                return NotFound();
            }

            return View(huesped);
        }

        // POST: Huesped/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Huesped == null)
            {
                return Problem("Entity set 'ProyectoP1_finalContext.Huesped'  is null.");
            }
            var huesped = await _context.Huesped.FindAsync(id);
            if (huesped != null)
            {
                _context.Huesped.Remove(huesped);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HuespedExists(int id)
        {
          return (_context.Huesped?.Any(e => e.HuespedID == id)).GetValueOrDefault();
        }
    }
}
