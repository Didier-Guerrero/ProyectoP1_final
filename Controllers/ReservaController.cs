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
    public class ReservaController : Controller
    {
        private readonly ProyectoP1_finalContext _context;

        public ReservaController(ProyectoP1_finalContext context)
        {
            _context = context;
        }

        // GET: Reserva
        public async Task<IActionResult> Index()
        {
            var proyectoP1_finalContext = _context.Reserva.Include(r => r.Habitacion).Include(r => r.Huesped);
            return View(await proyectoP1_finalContext.ToListAsync());
        }

        // GET: Reserva/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Reserva == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reserva
                .Include(r => r.Habitacion)
                .Include(r => r.Huesped)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // GET: Reserva/Create
        public IActionResult Create()
        {
            ViewData["HabitacionID"] = new SelectList(_context.Habitacion, "HabitacionID", "HabitacionID");
            ViewData["HuespedID"] = new SelectList(_context.Huesped, "HuespedID", "HuespedID");
            return View();
        }

        // POST: Reserva/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FechaReserva,HabitacionID,HuespedID")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reserva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HabitacionID"] = new SelectList(_context.Habitacion, "HabitacionID", "HabitacionID", reserva.HabitacionID);
            ViewData["HuespedID"] = new SelectList(_context.Huesped, "HuespedID", "HuespedID", reserva.HuespedID);
            return View(reserva);
        }

        // GET: Reserva/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Reserva == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reserva.FindAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }
            ViewData["HabitacionID"] = new SelectList(_context.Habitacion, "HabitacionID", "HabitacionID", reserva.HabitacionID);
            ViewData["HuespedID"] = new SelectList(_context.Huesped, "HuespedID", "HuespedID", reserva.HuespedID);
            return View(reserva);
        }

        // POST: Reserva/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("ID,FechaReserva,HabitacionID,HuespedID")] Reserva reserva)
        {
            if (id != reserva.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reserva);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaExists(reserva.ID))
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
            ViewData["HabitacionID"] = new SelectList(_context.Habitacion, "HabitacionID", "HabitacionID", reserva.HabitacionID);
            ViewData["HuespedID"] = new SelectList(_context.Huesped, "HuespedID", "HuespedID", reserva.HuespedID);
            return View(reserva);
        }

        // GET: Reserva/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Reserva == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reserva
                .Include(r => r.Habitacion)
                .Include(r => r.Huesped)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // POST: Reserva/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.Reserva == null)
            {
                return Problem("Entity set 'ProyectoP1_finalContext.Reserva'  is null.");
            }
            var reserva = await _context.Reserva.FindAsync(id);
            if (reserva != null)
            {
                _context.Reserva.Remove(reserva);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaExists(int? id)
        {
          return (_context.Reserva?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
