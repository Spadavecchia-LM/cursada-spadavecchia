using System;
using System.Collections.Generic;

namespace parcial1.EF;

public partial class Titulare
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Dni { get; set; } = null!;

    public virtual ICollection<Tramite> Tramites { get; set; } = new List<Tramite>();
}
