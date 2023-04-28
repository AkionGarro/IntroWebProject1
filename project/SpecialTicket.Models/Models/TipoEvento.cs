using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SpecialTicket.Models.Models;

public partial class TipoEvento
{
    public int Id { get; set; }

    public string? Descripcion { get; set; } = null!;

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

    public virtual ICollection<Evento> Eventos { get; } = new List<Evento>();
}
