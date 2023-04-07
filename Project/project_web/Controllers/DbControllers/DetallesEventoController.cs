using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mysqlx.Cursor;
using project_web.Models.DbModels;
using project_web.Models;
using Microsoft.AspNetCore.Authorization;

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
        public ActionResult Create()
        {
            return View();
        }

        // POST: DetallesEventoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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
