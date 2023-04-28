using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpecialTicket.Models.Models;

public partial class Compra
{

    public int Id { get; set; }

    public int Cantidad { get; set; }

    public DateTime FechaReserva { get; set; }

    public DateTime FechaPago { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public bool Active { get; set; }

    public int IdEntrada { get; set; }

    [ForeignKey("User")]
    public string? UserId { get; set; }

    public virtual project_ticketUser? User { get; set; } 
    public virtual Entrada? IdEntradaNavigation { get; set; }
}
