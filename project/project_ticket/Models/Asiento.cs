using System;
using System.Collections.Generic;

namespace project_ticket.Models;

/// <summary>
/// tipos de asiento del escenario
/// </summary>
public partial class Asiento
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public int Cantidad { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public bool Active { get; set; }

    public int IdEscenario { get; set; }

    public virtual Escenario IdEscenarioNavigation { get; set; } = null!;
}
