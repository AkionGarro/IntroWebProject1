using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SpecialTicket.Models.Models;

public partial class TipoEscenario
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    [Display(Name = "Creado el")]
    public DateTime CreatedAt { get; set; }

    [Display(Name = "Creado por")]
    public string? CreatedBy { get; set; }
    [Display(Name = "Actualizado el")]
    public DateTime UpdatedAt { get; set; }

    [Display(Name = "Actualizado por")]
    public string? UpdatedBy { get; set; }

    public bool Active { get; set; }
    [Display(Name = "Escenario")]
    public int IdEscenario { get; set; }
    public virtual Escenario? IdEscenarioNavigation { get; set; } 
}
