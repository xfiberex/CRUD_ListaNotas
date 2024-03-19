using System;
using System.Collections.Generic;

namespace ListaNotas.Entity;

public partial class Tarea
{
    public int IdTarea { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public bool? EsActivo { get; set; }

    public DateTime? FechaRegistro { get; set; }
}
