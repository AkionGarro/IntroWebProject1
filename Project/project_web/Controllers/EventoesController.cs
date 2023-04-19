using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using project_web.Models;

namespace project_web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EventoesController : Controller
    {
        private readonly ProjectTicketContext _context;

        public EventoesController(ProjectTicketContext context)
        {
            _context = context;
        }

        // GET: Eventoes
        public async Task<IActionResult> Index()
        {
            var projectTicketContext = _context.Eventos.Include(e => e.IdEscenarioNavigation).Include(e => e.IdTipoEventoNavigation);
            return View(await projectTicketContext.ToListAsync());
        }

        // GET: Eventoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Eventos == null)
            {
                return NotFound();
            }

            var evento = await _context.Eventos
                .Include(e => e.IdEscenarioNavigation)
                .Include(e => e.IdTipoEventoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (evento == null)
            {
                return NotFound();
            }

            return View(evento);
        }

        // GET: Eventoes/Create
        public IActionResult Create()
        {
            ViewData["IdEscenario"] = new SelectList(_context.Escenarios, "Id", "Nombre");
            ViewData["IdTipoEvento"] = new SelectList(_context.TipoEventos, "Id", "Descripcion");
            return View();
        }

        // POST: Eventoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion,Fecha,IdTipoEvento,IdEscenario")] Evento evento)
        {
            if (ModelState.IsValid)
            {
                evento.CreatedAt = DateTime.Now;
                evento.UpdatedAt = DateTime.Now;
                string username = User.FindFirstValue(ClaimTypes.Name);
                evento.CreatedBy = username;
                evento.UpdatedBy = username;
                evento.Active = true;
                _context.Add(evento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEscenario"] = new SelectList(_context.Escenarios, "Id", "Nombre", evento.IdEscenario);
            ViewData["IdTipoEvento"] = new SelectList(_context.TipoEventos, "Id", "Descripcion", evento.IdTipoEvento);
            return View(evento);
        }

        // GET: Eventoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Eventos == null)
            {
                return NotFound();
            }

            var evento = await _context.Eventos.FindAsync(id);
            if (evento == null)
            {
                return NotFound();
            }
            ViewData["IdEscenario"] = new SelectList(_context.Escenarios, "Id", "Nombre", evento.IdEscenario);
            ViewData["IdTipoEvento"] = new SelectList(_context.TipoEventos, "Id", "Descripcion", evento.IdTipoEvento);
            return View(evento);
        }

        // POST: Eventoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion,Fecha,CreatedAt,CreatedBy,UpdatedAt,UpdatedBy,Active,IdTipoEvento,IdEscenario")] Evento evento)
        {
            if (id != evento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(evento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventoExists(evento.Id))
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
            ViewData["IdEscenario"] = new SelectList(_context.Escenarios, "Id", "Nombre", evento.IdEscenario);
            ViewData["IdTipoEvento"] = new SelectList(_context.TipoEventos, "Id", "Descripcion", evento.IdTipoEvento);
            return View(evento);
        }

        // GET: Eventoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Eventos == null)
            {
                return NotFound();
            }

            var evento = await _context.Eventos
                .Include(e => e.IdEscenarioNavigation)
                .Include(e => e.IdTipoEventoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (evento == null)
            {
                return NotFound();
            }

            return View(evento);
        }

        // POST: Eventoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Eventos == null)
            {
                return Problem("Entity set 'ProjectTicketContext.Eventos'  is null.");
            }
            var evento = await _context.Eventos.FindAsync(id);
            if (evento != null)
            {
                _context.Eventos.Remove(evento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventoExists(int id)
        {
          return (_context.Eventos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
