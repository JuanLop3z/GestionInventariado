namespace InventarioBackend.Models
{
    public class MovimientoRequest
    {
        public int ProductoId { get; set; }
        public string Tipo { get; set; }
        public int Cantidad { get; set; }
    }
}
