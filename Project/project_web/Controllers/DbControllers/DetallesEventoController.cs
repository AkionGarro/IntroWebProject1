using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mysqlx.Cursor;
using project_web.Models.DbModels;
using project_web.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace project_web.Controllers.DbControllers
{
    [Authorize]
    public class DetallesEventoController : Controller
    {
        private readonly ProjectTicketContext _context;

        public DetallesEventoController(ProjectTicketContext context)
        {
            _context = context;
        }


        // GET: DetallesEventoController
        public async Task<IActionResult> Index()
        {
            var listaEventos1 = _context.Eventos
                .Join(_context.TipoEventos, x => x.IdTipoEvento, tev => tev.Id,(evnt,tev) =>  new {eventoT = evnt, tipoevento=tev })
                .Join(_context.Escenarios, y => y.eventoT.IdEscenario, esc => esc.Id, (ev, esc) => new { eventoE = ev, escenarioA = esc })
                .Join(_context.TipoEscenarios,z => z.escenarioA.Id,te => te.IdEscenario, (esc,te) => new {escenarioB =esc , tipoEscenario = te })
                .OrderBy(e => e.escenarioB.eventoE.eventoT.Id)
                .Select(m => new DetallesEvento
                {
                    Id = m.escenarioB.eventoE.eventoT.Id,
                    Descripcion = m.escenarioB.eventoE.eventoT.Descripcion,
                    TipoEvento = m.escenarioB.eventoE.tipoevento.Descripcion,
                    Fecha = m.escenarioB.eventoE.eventoT.Fecha,
                    TipoEscenario = m.tipoEscenario.Descripcion,
                    Escenario = m.escenarioB.escenarioA.Nombre,
                    Localizacion = m.escenarioB.escenarioA.Localizacion
                });
        
            return View(await listaEventos1.ToListAsync());
        }

        // GET: DetallesEventoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DetallesEventoController/Create
        public async Task<IActionResult> Create(int? id)
        {
            if (id == null) { return NotFound(); }

            var evento = await _context.Eventos
                                       .Include(esc => esc.IdEscenarioNavigation)
                                            .ThenInclude(tesc => tesc.TipoEscenarios)
                                       .Include(te => te.IdTipoEventoNavigation)
                                       .Where(e => e.Active && e.Id == id)
                                       .Select(e => new DetallesEvento
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

            var asientos = await (from E in _context.Eventos
                                  join ESC in _context.Escenarios on E.IdEscenario equals ESC.Id
                                  join AS in _context.Asientos on ESC.Id equals AS.IdEscenario
                                  where E.Active && AS.Active && E.Id == id
                                  orderby E.Id ascending
                                  select new AsientoPrecio
                                  {
                                      Id = AS.Id,
                                      Descripcion = AS.Descripcion,
                                      Cantidad = AS.Cantidad,
                                      Precio = 0
                                  }).ToListAsync();

            if (asientos == null) { return NotFound(); }

            var eventoAsientos = new EventoAsiento
            {
                Id = evento.Id,
                Descripcion = evento.Descripcion,
                TipoEvento = evento.TipoEvento,
                Fecha = evento.Fecha,
                TipoEscenario = evento.TipoEscenario,
                Escenario = evento.Escenario,
                Localizacion = evento.Localizacion,
                Asientos = asientos
            };

            if (eventoAsientos == null) { return NotFound(); }

            return View(eventoAsientos);
        }

        // POST: DetallesEventoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var form = collection.ToList();
                    var idEvento = Int32.Parse(form[0].Value);
                    //verificar primero si ya existen las entradas porque solo se pueden crear una vez
                    var entradasEvento = await _context.Entradas.FirstOrDefaultAsync(m => m.IdEvento == idEvento);
                    if (entradasEvento == null)//si entradas no han sido creadas --> crearlas
                    {
                        var descripciones = form[1].Value.ToList();
                        var cantidades = form[2].Value.ToList();
                        var precios = form[3].Value.ToList();
                        string username = User.FindFirstValue(ClaimTypes.Name);
                        for (var i = 0; i < descripciones.Count(); i++)
                        {
                            var entrada = new Entrada();
                            entrada.IdEvento = idEvento;
                            entrada.TipoAsiento = descripciones[i];
                            entrada.Disponibles = Int32.Parse(cantidades[i]);
                            entrada.Precio = Decimal.Parse(precios[i]);
                            entrada.CreatedAt = DateTime.Now;
                            entrada.CreatedBy = username;
                            entrada.UpdatedAt = DateTime.Now;
                            entrada.UpdatedBy = username;
                            entrada.Active = true;
                            _context.Add(entrada);
                            await _context.SaveChangesAsync();
                        }
                        TempData["Success"] = "Las Entradas fueron creadas exitosamente...";
                    }
                    else //mandar las entradas ya han sido creadas no se pueden volver a crear
                    {
                        TempData["Error"] = "Error, Las entradas ya fueron creadas...";
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DetallesEventoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DetallesEventoController/Edit/5
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

        // GET: DetallesEventoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DetallesEventoController/Delete/5
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
