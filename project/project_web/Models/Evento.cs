using System;
using System.Collections.Generic;

namespace project_web.Models;

public partial class Evento
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public bool Active { get; set; }

    public int IdTipoEvento { get; set; }

    public int IdEscenario { get; set; }

    public virtual ICollection<Entrada> Entrada { get; } = new List<Entrada>();

    public virtual Escenario IdEscenarioNavigation { get; set; } = null!;

    public virtual TipoEvento IdTipoEventoNavigation { get; set; } = null!;
}
