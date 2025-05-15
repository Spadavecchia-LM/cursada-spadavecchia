using System;
using System.Collections.Generic;

namespace parcial1.EF;

public partial class Producto
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public int Precio { get; set; }

    public bool Activo { get; set; }

    public virtual ICollection<Tramite> Tramites { get; set; } = new List<Tramite>();
}
