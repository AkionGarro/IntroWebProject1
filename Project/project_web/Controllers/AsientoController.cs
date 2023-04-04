using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using project_web.Models;

namespace project_web.Controllers
{
    public class AsientoController : Controller
    {
        private readonly ProjectTicketContext _context;

        public AsientoController(ProjectTicketContext context)
        {
            _context = context;
        }

        // GET: Asiento
        public async Task<IActionResult> Index()
        {
        
            var projectTicketContext = _context.Asientos.Include(a => a.IdEscenarioNavigation);
            return View(await projectTicketContext.ToListAsync());
        }

        // GET: Asiento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Asientos == null)
            {
                return NotFound();
            }

            var asiento = await _context.Asientos
                .Include(a => a.IdEscenarioNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (asiento == null)
            {
                return NotFound();
            }

            return View(asiento);
        }

        // GET: Asiento/Create
        public IActionResult Create()
        {
            ViewData["IdEscenario"] = new SelectList(_context.Escenarios, "Id", "Nombre");
            return View();
        }

        // POST: Asiento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion,Cantidad,CreatedAt,CreatedBy,UpdatedAt,UpdatedBy,Active,IdEscenario")] Asiento asiento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asiento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEscenario"] = new SelectList(_context.Escenarios, "Id", "Nombre", asiento.IdEscenario);
            
            return View(asiento);
        }

        // GET: Asiento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Asientos == null)
            {
                return NotFound();
            }

            var asiento = await _context.Asientos.FindAsync(id);
            if (asiento == null)
            {
                return NotFound();
            }
            ViewData["IdEscenario"] = new SelectList(_context.Escenarios, "Id", "Nombre", asiento.IdEscenario);
            return View(asiento);
        }

        // POST: Asiento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion,Cantidad,CreatedAt,CreatedBy,UpdatedAt,UpdatedBy,Active,IdEscenario")] Asiento asiento)
        {
            if (id != asiento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asiento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsientoExists(asiento.Id))
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
            ViewData["IdEscenario"] = new SelectList(_context.Escenarios, "Id", "Nombre", asiento.IdEscenario);
            return View(asiento);
        }

        // GET: Asiento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Asientos == null)
            {
                return NotFound();
            }

            var asiento = await _context.Asientos
                .Include(a => a.IdEscenarioNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (asiento == null)
            {
                return NotFound();
            }

            return View(asiento);
        }

        // POST: Asiento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Asientos == null)
            {
                return Problem("Entity set 'ProjectTicketContext.Asientos'  is null.");
            }
            var asiento = await _context.Asientos.FindAsync(id);
            if (asiento != null)
            {
                _context.Asientos.Remove(asiento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsientoExists(int id)
        {
          return (_context.Asientos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
