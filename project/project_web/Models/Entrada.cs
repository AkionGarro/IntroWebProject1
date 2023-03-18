using System;
using System.Collections.Generic;

namespace project_web.Models;

public partial class Entrada
{
    public int Id { get; set; }

    public string TipoAsiento { get; set; } = null!;

    public int Disponibles { get; set; }

    public decimal Precio { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public bool Active { get; set; }

    public int IdEvento { get; set; }

    public virtual ICollection<Compra> Compras { get; } = new List<Compra>();

    public virtual Evento IdEventoNavigation { get; set; } = null!;
}
