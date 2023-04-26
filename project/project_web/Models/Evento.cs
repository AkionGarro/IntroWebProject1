using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace project_web.Models;

public partial class Evento
{
    public int Id { get; set; }

    [Display(Name = "Descripción")]
    public string Descripcion { get; set; } = null!;

    public DateTime Fecha { get; set; }
    [Display(Name = "Creado el")]
    public DateTime CreatedAt { get; set; }
    [Display(Name = "Creado por")]
    public string? CreatedBy { get; set; }
    [Display(Name = "Actualizado el")]
    public DateTime UpdatedAt { get; set; }
    [Display(Name = "Actualizado por")]
    public string? UpdatedBy { get; set; }
    [Display(Name = "Activo")]
    public bool Active { get; set; }
    [Display(Name = "Tipo de evento")]
    public int IdTipoEvento { get; set; }
    [Display(Name = "Tipo de escenario")]
    public int IdEscenario { get; set; }

    public virtual ICollection<Entrada> Entrada { get; } = new List<Entrada>();

    public virtual Escenario? IdEscenarioNavigation { get; set; }

    public virtual TipoEvento? IdTipoEventoNavigation { get; set; } 
}
