using System;
using System.Collections.Generic;

namespace SpecialTicketWeb.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public int Telefono { get; set; }

    public int Rol { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public bool Active { get; set; }

    public virtual ICollection<Compra> Compras { get; } = new List<Compra>();
}
