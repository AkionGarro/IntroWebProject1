using System;
using System.Collections.Generic;

namespace SpecialTicket.Models.Models;

public partial class Entrada
{
    public Entrada()
    {
        Compras = new HashSet<Compra>();
    }
    public int Id { get; set; }

    public string TipoAsiento { get; set; } = null!;

    public int Disponibles { get; set; }

    public decimal Precio { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public bool Active { get; set; }

    public int IdEvento { get; set; }

    public virtual ICollection<Compra> Compras { get; } = new List<Compra>();

    public virtual Evento? IdEventoNavigation { get; set; } 
}
