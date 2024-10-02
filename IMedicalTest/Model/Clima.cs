using System;
using System.Collections.Generic;

namespace IMedicalTest.Model;

public partial class Clima
{
    public int Id { get; set; }

    public DateTime FechaActualizacion { get; set; }

    public decimal Temperatura { get; set; }

    public string? Descripcion { get; set; }

    public decimal? VelocidadViento { get; set; }

    public decimal? Precipitacion { get; set; }

    public decimal? Humedad { get; set; }

    public decimal? Visibilidad { get; set; }

    public int CiudadId { get; set; }

    public virtual Ciudad Ciudad { get; set; } = null!;
}
