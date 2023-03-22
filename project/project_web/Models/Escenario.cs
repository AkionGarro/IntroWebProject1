using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace project_web.Models;

public partial class Escenario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Localizacion { get; set; } = null!;
    [DisplayName("Creado en")]
    public DateTime CreatedAt { get; set; }
    [DisplayName("Creado por")]
    public int CreatedBy { get; set; }
    [DisplayName("Actualizado en")]
    public DateTime UpdatedAt { get; set; }
    [DisplayName("Actualizado por")]
    public int UpdatedBy { get; set; }
    [DisplayName("Activo")]
    public bool Active { get; set; }

    public virtual ICollection<Asiento> Asientos { get; } = new List<Asiento>();

    public virtual ICollection<Evento> Eventos { get; } = new List<Evento>();

    public virtual ICollection<TipoEscenario> TipoEscenarios { get; } = new List<TipoEscenario>();
}
