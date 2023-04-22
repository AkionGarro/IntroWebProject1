using System.ComponentModel.DataAnnotations.Schema;

namespace project_web.Models.DbModels
{
    public class Pdf
    {
        public int IdCompra { get; set; }

        public int Cantidad { get; set; }

        public DateTime fechaPago { get; set; }

        [ForeignKey("User")]
        public string? UserId { get; set; }

        public string? Nombre { get; set; }

        public string? Telefono { get; set; }
        public int IdEntrada { get; set; }

        public int PrecioEntrada { get; set; }

        public int IdEvento { get; set; }

        public string? DescripcionEvento { get; set; }

        public int tipoEvento { get; set; }
        public string? DescripcionTipoEvento { get; set; }

        public int idEscenario { get; set; }

        public string? nombreEscenario { get; set; }




    }
}
