using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using SpecialTicket.Models.Models.DbModels;


namespace SpecialTicket.Models.Models.DbModels
{
    public class EventoAsiento:DetallesEvento
    {
        [Display(Name = "Asientos")]
        public List<AsientoPrecio> Asientos { get; set; }
    }
}
