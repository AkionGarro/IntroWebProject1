using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project_web.Models;
using project_web.Models.DbModels;

namespace project_web.Controllers.DbControllers
{
    public class BoleteriaClientes : Controller
    {
        private readonly ProjectTicketContext _context;
        public BoleteriaClientes(ProjectTicketContext context)
        {
            _context = context;
        }

        // GET: BoleteriaClientes
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

            return View(await listaEventos3); //fin M
        }

        // GET: BoleteriaClientes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BoleteriaClientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BoleteriaClientes/Create
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

        // GET: BoleteriaClientes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BoleteriaClientes/Edit/5
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

        // GET: BoleteriaClientes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BoleteriaClientes/Delete/5
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
