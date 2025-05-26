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
        public int idproducto_sige { get; set; }
        public string idtipo { get; set; }
    }

    public class VentasProducto
    {
        public int idproducto { get; set; }
        public int idsucursal { get; set; }
        public string periodo { get; set; }
        public int cantidadventas { get; set; }
    }

    public class DistribucionStockActualTransito
    {
        public int idproducto { get; set; }
        public int idsucursal { get; set; }
        public decimal stockactual { get; set; }
        public decimal stocktraansito { get; set; }
    }
}
