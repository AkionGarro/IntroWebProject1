using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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

    public int IdEntrada { get; set; }

    [ForeignKey("User")]
    public string UserId { get; set; } = null!;

    public virtual project_ticketUser? User { get; set; } 
    public virtual Entrada? IdEntradaNavigation { get; set; }
}
