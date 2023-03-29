using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace project_web.Models;

public partial class TipoEscenario
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public bool Active { get; set; }

    public int IdEscenario { get; set; }
    [DisplayName("Id escenario")]
    public virtual Escenario? IdEscenarioNavigation { get; set; } 
}
