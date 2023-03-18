using System;
using System.Collections.Generic;

namespace project_web.Models;

public partial class Compra
{
    public int Id { get; set; }

    public int Cantidad { get; set; }

    public DateTime FechaReserva { get; set; }

    public DateTime FechaPago { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public int Active { get; set; }

    public string IdCliente { get; set; } = null!;

    public int IdEntrada { get; set; }

    public virtual Entrada IdEntradaNavigation { get; set; } = null!;
}
