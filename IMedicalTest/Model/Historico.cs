using System;
using System.Collections.Generic;

namespace IMedicalTest.Model;

public partial class Historico
{
    public int Id { get; set; }

    public DateTime Hora { get; set; }

    public int TipoBusquedaId { get; set; }

    public int CiudadId { get; set; }

    public virtual Ciudad Ciudad { get; set; } = null!;

    public virtual TipoBusquedum TipoBusqueda { get; set; } = null!;
}
