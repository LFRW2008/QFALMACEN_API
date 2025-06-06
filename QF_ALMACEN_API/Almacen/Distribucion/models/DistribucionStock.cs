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
        public string idtipoproducto { get; set; }
        public string filtro_stock { get; set; }
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

    public class DistribucionLotesEntradaFEFO
    {
        public int idsucursal_envia { get; set; }
        public int idproducto { get; set; }
        public int cantidad { get; set; }
        public int idsucursal_recibe { get; set; }
        public string idalmacensucursal_envia { get; set; }
    }

    public class DistribucionLotesSalidaFEFO
    {
        public int idsucursal_recibe { get; set; }
        public int idproducto_envia { get; set; }
        public string numlote_envia { get; set; }
        public string fecharecepcion_envia { get; set; }
        public int idsucursal_envia { get; set; }
        public int idempresa_envia { get; set; }
        public int idalmacensucursal_envia { get; set; }
        public decimal cantidad_enviada { get; set; }
        public decimal cantidad_total { get; set; }
        public int num_item {  get; set; }
    }

    public class DistribucionFEFOAgregar
    {
        public int idsucursal_recibe { get; set; }
        public int idproducto_envia { get; set; }
        public string numlote_envia { get; set; }
        public string fecharecepcion_envia { get; set; }
        public int idsucursal_envia { get; set; }
        public int idempresa_envia { get; set; }
        public int idalmacensucursal_envia { get; set; }
        public decimal cantidad_enviada { get; set; }
        public decimal cantidad_total { get; set; }
        public int idcorrelativo { get; set; }
        public string num_serie { get; set; }
        public int idempleado { get; set; }
        public int num_item { get; set; }
    }

    public class AuditoriaGuiaFiltros
    {
        public List<EstadoGuia> estadosguia { get; set; }
        public List<TipoGuia> tiposguia { get; set; }
    }

    public class EstadoGuia
    {
        public int idestado { get; set; }
        public string descripcion { get; set; }
        public string ubicacion { get; set; }
    }

    public class TipoGuia
    {
        public int idtipoguia { get; set; }
        public string descripcion { get; set; }
    }

    public class GuiaAuditoriaCabecera
    {
        public string nro_documento { get; set; }
        public string origen { get; set; }
        public string destino { get; set; }
        public DateTime fecha_traslado { get; set; }
        public string tipo_guia { get; set; }
        public string estado { get; set; }
    }

    public class GuiaAuditoriaDetalle
    {
        public int num_item { get; set; }
        public int codigo { get; set; }
        public string producto { get; set; }
        public decimal cantidad_guia { get; set; }
        public int cantidad_picking { get; set; }
        public string laboratorio { get; set; }
        public string lote { get; set; }
        public DateTime fecha_recepcion { get; set; }
        public DateTime fecha_vencimiento { get; set; }
    }
}
