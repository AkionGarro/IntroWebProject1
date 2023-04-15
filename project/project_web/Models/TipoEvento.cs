using System;
using System.Collections.Generic;

namespace project_web.Models;

public partial class TipoEvento
{
    public int Id { get; set; }

    public string? Descripcion { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public bool Active { get; set; }

    public virtual ICollection<Evento> Eventos { get; } = new List<Evento>();
}
