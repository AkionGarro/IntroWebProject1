using System;
using System.Collections.Generic;
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
    [Authorize]
    public class ComprasController : Controller
    {
        private readonly ProjectTicketContext _context;

        public ComprasController(ProjectTicketContext context)
        {
            _context = context;
        }

        // GET: Compras
        public async Task<IActionResult> Index()
        {

            var projectTicketContext = _context.Compras.Include(c => c.IdEntradaNavigation).Include(c => c.User);
            return View(await projectTicketContext.ToListAsync());
        }

        // GET: Compras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Compras == null)
            {
                return NotFound();
            }

            var compra = await _context.Compras
                .Include(c => c.IdEntradaNavigation)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (compra == null)
            {
                return NotFound();
            }

            return View(compra);
        }

        // GET: Compras/Create
        public IActionResult Create()
        {
            ViewData["IdEntrada"] = new SelectList(_context.Entradas, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "UserName");
            return View();
        }

        // POST: Compras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cantidad,FechaReserva,FechaPago,IdEntrada,UserId")] Compra compra)
        {
            if (ModelState.IsValid)
            {
                compra.CreatedAt = DateTime.Now;
                compra.UpdatedAt = DateTime.Now;
                string username = User.FindFirstValue(ClaimTypes.Name);
                compra.CreatedBy = username;
                compra.UpdatedBy = username;
                compra.Active = true;
                _context.Add(compra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEntrada"] = new SelectList(_context.Entradas, "Id", "Id", compra.IdEntrada);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "UserName", compra.UserId);
            return View(compra);
        }

        // GET: Compras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Compras == null)
            {
                return NotFound();
            }

            var compra = await _context.Compras.FindAsync(id);
            if (compra == null)
            {
                return NotFound();
            }
            ViewData["IdEntrada"] = new SelectList(_context.Entradas, "Id", "Id", compra.IdEntrada);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "UserName", compra.UserId);
            return View(compra);
        }

        // POST: Compras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Cantidad,FechaReserva,FechaPago,CreatedAt,CreatedBy,UpdatedAt,UpdatedBy,Active,IdEntrada,UserId")] Compra compra)
        {
            if (id != compra.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(compra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompraExists(compra.Id))
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
            ViewData["IdEntrada"] = new SelectList(_context.Entradas, "Id", "Id", compra.IdEntrada);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "UserName", compra.UserId);
            return View(compra);
        }

        // GET: Compras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Compras == null)
            {
                return NotFound();
            }

            var compra = await _context.Compras
                .Include(c => c.IdEntradaNavigation)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (compra == null)
            {
                return NotFound();
            }

            return View(compra);
        }

        // POST: Compras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Compras == null)
            {
                return Problem("Entity set 'ProjectTicketContext.Compras'  is null.");
            }
            var compra = await _context.Compras.FindAsync(id);
            if (compra != null)
            {
                _context.Compras.Remove(compra);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompraExists(int id)
        {
          return (_context.Compras?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
