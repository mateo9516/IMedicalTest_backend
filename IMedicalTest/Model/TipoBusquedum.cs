using System;
using System.Collections.Generic;

namespace IMedicalTest.Model;

public partial class TipoBusquedum
{
    public int Id { get; set; }

    public string Tipo { get; set; } = null!;

    public virtual ICollection<Historico> Historicos { get; set; } = new List<Historico>();
}
