namespace QF_ALMACEN_API.Almacen.Distribucion.Models
{
    public class DistribucionStock
    {
        public int idproducto { get; set; }
        public string codigoproducto { get; set; } = "NINGUNO";
        public string nombre_producto { get; set; } = string.Empty;
        public int idlaboratorio { get; set; }
        public string laboratorio { get; set; } = "NINGUNO";
        public decimal stock { get; set; }
        public string ventas { get; set; } = "A";
    }
}
