using System;
using System.Collections.Generic;

namespace InventarioDB.DataBase.Models;

public partial class Productos
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int Cantidad { get; set; }
}
