using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using project_web.Models.DbModels;


namespace project_web.Models
{
    public class EventoAsiento:DetallesEvento
    {
        [Display(Name = "Asientos")]
        public List<AsientoPrecio> Asientos { get; set; }
    }
}
