﻿using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace project_web.Models;

public partial class Escenario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Localizacion { get; set; } = null!;
   
    public DateTime CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public bool Active { get; set; }

    public virtual ICollection<Asiento> Asientos { get; } = new List<Asiento>();

    public virtual ICollection<Evento> Eventos { get; } = new List<Evento>();

    public virtual ICollection<TipoEscenario> TipoEscenarios { get; } = new List<TipoEscenario>();
}
