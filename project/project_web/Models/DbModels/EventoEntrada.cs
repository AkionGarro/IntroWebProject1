using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace project_web.Models.DbModels
{
    public class EventoEntrada:CompraCliente
    {
        [Display(Name = "Entradas")]
        public List<EntradasCantidad> Entradas { get; set; }
    }
}
