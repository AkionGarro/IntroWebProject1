using System.ComponentModel.DataAnnotations;
using System;


namespace project_web.Models
{
    public class DetallesEvento
    {
        [Display(Name = "Id Evento")]
        public int Id { get; set; }


        [Display(Name ="Descripción")]
        public string Descripcion { get; set; }

        [Display(Name = "Tipo Evento")]
        public string TipoEvento { get; set; }


        [Display(Name = "Fecha")]
        public DateTime Fecha { get; set; }


        [Display(Name = "Tipo Escenario")]
        public string TipoEscenario { get; set; }


        [Display(Name = "Escenario")]
        public string Escenario { get; set; }

        [Display(Name = "Localización")]
        public string Localizacion { get; set; }

    }
}
