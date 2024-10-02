using System;
using System.Collections.Generic;

namespace IMedicalTest.Model;

public partial class Noticium
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string? Autor { get; set; }

    public string? UrlImagen { get; set; }

    public string? Url { get; set; }

    public DateTime Fecha { get; set; }

    public int CiudadId { get; set; }

    public virtual Ciudad Ciudad { get; set; } = null!;
}
