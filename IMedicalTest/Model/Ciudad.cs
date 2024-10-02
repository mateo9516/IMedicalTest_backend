using System;
using System.Collections.Generic;

namespace IMedicalTest.Model;

public partial class Ciudad
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal Latitud { get; set; }

    public decimal Longitud { get; set; }

    public virtual ICollection<Clima> Climas { get; set; } = new List<Clima>();

    public virtual ICollection<Historico> Historicos { get; set; } = new List<Historico>();

    public virtual ICollection<Noticium> Noticia { get; set; } = new List<Noticium>();
}
