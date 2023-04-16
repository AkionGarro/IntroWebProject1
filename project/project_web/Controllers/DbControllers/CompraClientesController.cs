using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using project_web.Models;
using project_web.Models.DbModels;

namespace project_web.Controllers.DbControllers
{
    public class CompraClientesController : Controller
    {
        private readonly ProjectTicketContext _context;

        public CompraClientesController(ProjectTicketContext context)
        {
            _context = context;
        }

        // GET: CompraClienteController
        public async Task<IActionResult> Index()
        {
            var listaEventos3 = (from E in _context.Eventos
                                 join TE in _context.TipoEventos on E.IdTipoEvento equals TE.Id
                                 join ESC in _context.Escenarios on E.IdEscenario equals ESC.Id
                                 join TESC in _context.TipoEscenarios on ESC.Id equals TESC.IdEscenario
                                 where E.Active
                                 orderby E.Id ascending
                                 select new CompraCliente
                                 {
                                     Id = E.Id,
                                     Descripcion = E.Descripcion,
                                     TipoEvento = TE.Descripcion,
                                     Fecha = E.Fecha,
                                     TipoEscenario = TESC.Descripcion,
                                     Escenario = ESC.Nombre,
                                     Localizacion = ESC.Localizacion
                                 }).ToListAsync();
            //------------------------------Fin consultas--------------------------------------------------------------------------------------

            return View(await listaEventos3); //fin Método ActionResult
        }

        // GET: CompraClienteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CompraClienteController/Create
        public async Task<IActionResult> Create(int? id)
        {
            if (id == null) { return NotFound(); }

            var evento = await _context.Eventos
                                       .Include(esc => esc.IdEscenarioNavigation)
                                            .ThenInclude(tesc => tesc.TipoEscenarios)
                                       .Include(te => te.IdTipoEventoNavigation)
                                       .Where(e => e.Active && e.Id == id)
                                       .Select(e => new CompraCliente
                                       {
                                           Id = e.Id,
                                           Descripcion = e.Descripcion,
                                           TipoEvento = e.IdTipoEventoNavigation.Descripcion,
                                           Fecha = e.Fecha,
                                           TipoEscenario = e.IdEscenarioNavigation.TipoEscenarios.Select(te => te.Descripcion).FirstOrDefault(),
                                           Escenario = e.IdEscenarioNavigation.Nombre,
                                           Localizacion = e.IdEscenarioNavigation.Localizacion
                                       }).FirstOrDefaultAsync();
            if (evento == null) { return NotFound(); }
            var entradas = await (from E in _context.Entradas
                                  join EVE in _context.Eventos on id equals EVE.Id where EVE.Active && E.Active 
                                  orderby E.Id ascending
                                  select new EntradasCantidad
                                  {
                                      Id = E.Id,
                                      TipoAsiento = E.TipoAsiento ,
                                      Disponibles = E.Disponibles,
                                      Precio = E.Precio,
                                      Cantidad = 0
                                  }).ToListAsync();

            if (entradas == null) { return NotFound(); }
            var eventoEntrada = new EventoEntrada
            {
                Id = evento.Id,
                Descripcion = evento.Descripcion,
                TipoEvento = evento.TipoEvento,
                Fecha = evento.Fecha,
                TipoEscenario = evento.TipoEscenario,
                Escenario = evento.Escenario,
                Localizacion = evento.Localizacion,
                Entradas = entradas
            };

            if (eventoEntrada == null) { return NotFound(); }

            return View(eventoEntrada);
        }

        // POST: CompraClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    
                    var form = collection.ToList();
                    var idEntrada = form[4].Value.ToList();
                    var tipoAsiento = form[5].Value.ToList();
                    var disponibles = form[6].Value.ToList();
                    var precios = form[7].Value.ToList();
                    var cantidad = form[8].Value.ToList();
                    string username = User.FindFirstValue(ClaimTypes.Name);
                    string UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    for (var i = 0; i < tipoAsiento.Count(); i++) {
                        var compra = new Compra();
                        compra.IdEntrada = Int32.Parse(idEntrada[i]);
                        compra.Cantidad = Int32.Parse(cantidad[i]);
                        compra.FechaReserva = DateTime.Now;
                        compra.FechaPago = DateTime.Now;
                        compra.CreatedBy = username;
                        compra.UpdatedBy = username;
                        compra.UpdatedAt= DateTime.Now;
                        compra.CreatedAt = DateTime.Now;
                        compra.Active = true;
                        compra.UserId = UserId;
                        _context.Add(compra);
                        await _context.SaveChangesAsync();  
                    }
                    TempData["Success"] = "Las Entradas fueron creadas exitosamente...";
                }
 
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CompraClienteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CompraClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CompraClienteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CompraClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
