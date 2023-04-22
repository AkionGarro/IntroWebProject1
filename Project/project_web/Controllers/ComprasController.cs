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
using project_web.Models.DbModels;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace project_web.Controllers
{
    [Authorize(Roles = "Admin,Worker")]
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

            var projectTicketContext = _context.Compras.Include(c => c.IdEntradaNavigation).Include(c => c.User).Where(c => c.Active == true);
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


        [HttpGet]
        public async Task<IActionResult> Imprimir(int? id)
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
            else
            {
                compra.FechaPago = DateTime.Now;
                _context.Update(compra);
                await _context.SaveChangesAsync();
            }
            ViewData["IdEntrada"] = new SelectList(_context.Entradas, "Id", "Id", compra.IdEntrada);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "UserName", compra.UserId);


            return View(compra);
        }


        [HttpPost, ActionName("Imprimir")]
        public async Task<IActionResult> ImprimirConfirmed(int id)
        {
            if (_context.Compras == null)
            {
                return Problem("Entity set 'ProjectTicketContext.Compras'  is null.");
            }
            var compra = await _context.Compras.FindAsync(id);
            if (compra != null)
            {
               /* compra.Active = false;
                _context.Update(compra);
                await _context.SaveChangesAsync();
               */

                var pdf = (from C in _context.Compras
                           join ENT in _context.Entradas on C.IdEntrada equals ENT.Id
                           join EVNT in _context.Eventos on ENT.IdEvento equals EVNT.Id
                           join TEVNT in _context.TipoEventos on EVNT.IdTipoEvento equals TEVNT.Id
                           join ESC in _context.Escenarios on EVNT.IdEscenario equals ESC.Id
                           join USR in _context.Users on C.UserId equals USR.Id
                           where C.IdEntrada == id

                           select new Pdf
                           {
                               IdCompra = C.Id,
                               Cantidad = C.Cantidad,
                               fechaPago = C.FechaPago,
                               UserId = USR.Id,
                               Nombre = USR.UserName,
                               Telefono = USR.PhoneNumber,
                               IdEntrada = ENT.Id,
                               PrecioEntrada = (int)ENT.Precio,
                               IdEvento = EVNT.Id,
                               DescripcionEvento = EVNT.Descripcion,
                               tipoEvento = TEVNT.Id,
                               DescripcionTipoEvento = TEVNT.Descripcion,
                               idEscenario = ESC.Id,
                               nombreEscenario = ESC.Nombre

                           }).ToList();

                Document doc = new Document(PageSize.A4, 20f, 20f, 30f, 30f);
                MemoryStream ms = new MemoryStream();
                PdfWriter.GetInstance(doc, ms);
                doc.Open();

                // Agregar contenido al documento
                foreach (var item in pdf)
                {
                    doc.Add(new Paragraph("Id de Compra: " + item.IdCompra));
                    doc.Add(new Paragraph("Cantidad: " + item.Cantidad));
                    doc.Add(new Paragraph("Fecha de Pago: " + item.fechaPago));
                    doc.Add(new Paragraph("Id de Usuario: " + item.UserId));
                    doc.Add(new Paragraph("Nombre de Usuario: " + item.Nombre));
                    doc.Add(new Paragraph("Teléfono de Usuario: " + item.Telefono));
                    doc.Add(new Paragraph("Id de Entrada: " + item.IdEntrada));
                    doc.Add(new Paragraph("Precio de Entrada: " + item.PrecioEntrada));
                    doc.Add(new Paragraph("Id de Evento: " + item.IdEvento));
                    doc.Add(new Paragraph("Descripción de Evento: " + item.DescripcionEvento));
                    doc.Add(new Paragraph("Id de Tipo de Evento: " + item.tipoEvento));
                    doc.Add(new Paragraph("Descripción de Tipo de Evento: " + item.DescripcionTipoEvento));
                    doc.Add(new Paragraph("Id de Escenario: " + item.idEscenario));
                    doc.Add(new Paragraph("Nombre de Escenario: " + item.nombreEscenario));
                    doc.Add(new Paragraph("\n"));
                }

                // Cerrar el documento
                doc.Close();

                // Guardar el archivo PDF en disco
                byte[] pdfBytes = ms.ToArray();
                return File(pdfBytes, "application/pdf", "archivo.pdf");

            }




            return RedirectToAction(nameof(Index));
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
