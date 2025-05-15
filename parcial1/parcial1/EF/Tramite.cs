using System;
using System.Collections.Generic;

namespace parcial1.EF;

public partial class Tramite
{
    public int Id { get; set; }

    public int TitularId { get; set; }

    public int ProductoId { get; set; }

    public DateTime? FechaTramite { get; set; }

    public virtual Producto Producto { get; set; } = null!;

    public virtual Titulare Titular { get; set; } = null!;
}
