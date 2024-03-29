﻿using System;
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
    public class TipoEscenariosController : Controller
    {
        private readonly ProjectTicketContext _context;

        public TipoEscenariosController(ProjectTicketContext context)
        {
            _context = context;
        }

        // GET: TipoEscenarios
        public async Task<IActionResult> Index()
        {
            var projectTicketContext = _context.TipoEscenarios.Include(t => t.IdEscenarioNavigation);
            return View(await projectTicketContext.ToListAsync());
        }

        // GET: TipoEscenarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoEscenarios == null)
            {
                return NotFound();
            }

            var tipoEscenario = await _context.TipoEscenarios
                .Include(t => t.IdEscenarioNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoEscenario == null)
            {
                return NotFound();
            }

            return View(tipoEscenario);
        }

        // GET: TipoEscenarios/Create
        public IActionResult Create()
        {
            ViewData["IdEscenario"] = new SelectList(_context.Escenarios, "Id", "Nombre");
            return View();
        }

        // POST: TipoEscenarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion,IdEscenario")] TipoEscenario tipoEscenario)
        {
            if (ModelState.IsValid)
            {
                tipoEscenario.CreatedAt = DateTime.Now;
                tipoEscenario.UpdatedAt = DateTime.Now;
                string username = User.FindFirstValue(ClaimTypes.Name);
                tipoEscenario.CreatedBy = username;
                tipoEscenario.UpdatedBy = username;
                tipoEscenario.Active = true;
                _context.Add(tipoEscenario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEscenario"] = new SelectList(_context.Escenarios, "Id", "", tipoEscenario.IdEscenario);
            return View(tipoEscenario);
        }

        // GET: TipoEscenarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoEscenarios == null)
            {
                return NotFound();
            }

            var tipoEscenario = await _context.TipoEscenarios.FindAsync(id);
            if (tipoEscenario == null)
            {
                return NotFound();
            }
            ViewData["IdEscenario"] = new SelectList(_context.Escenarios, "Id", "Nombre", tipoEscenario.IdEscenario);
            return View(tipoEscenario);
        }

        // POST: TipoEscenarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion,CreatedAt,CreatedBy,UpdatedAt,UpdatedBy,Active,IdEscenario")] TipoEscenario tipoEscenario)
        {
            if (id != tipoEscenario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoEscenario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoEscenarioExists(tipoEscenario.Id))
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
            ViewData["IdEscenario"] = new SelectList(_context.Escenarios, "Id", "Nombre", tipoEscenario.IdEscenario);
            return View(tipoEscenario);
        }

        // GET: TipoEscenarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoEscenarios == null)
            {
                return NotFound();
            }

            var tipoEscenario = await _context.TipoEscenarios
                .Include(t => t.IdEscenarioNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoEscenario == null)
            {
                return NotFound();
            }

            return View(tipoEscenario);
        }

        // POST: TipoEscenarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoEscenarios == null)
            {
                return Problem("Entity set 'ProjectTicketContext.TipoEscenarios'  is null.");
            }
            var tipoEscenario = await _context.TipoEscenarios.FindAsync(id);
            if (tipoEscenario != null)
            {
                _context.TipoEscenarios.Remove(tipoEscenario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoEscenarioExists(int id)
        {
          return (_context.TipoEscenarios?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
