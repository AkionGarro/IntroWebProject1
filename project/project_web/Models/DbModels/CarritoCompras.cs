using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace project_web.Models.DbModels
{
    public class CarritoCompras
    {
        [Display(Name = "Id Compra")]
        public int Id { get; set; }

        [Display(Name = "Tipo de Asiento")]
        public string? Asiento { get; set; }

        [Display(Name = "Cantidad")]
        public int Cantidad { get; set; }

        [Display(Name = "Evento")]
        public string? Evento { get; set; }

        [Display(Name = "fecha reserva")]
        public DateTime FechaReserva { get; set; }


        [Display(Name = "Código de entrada")]
        public int IdEntrada { get; set; }


        [Display(Name = "Total")]
        public Decimal Total { get; set; }
    }
}
