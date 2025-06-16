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
        public List<TransporteEmpresa> transporte_empresas { get; set; }
        public List<TransporteVehiculo> transporte_vehiculo { get; set; }
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

    public class TransporteEmpresa
    {
        public int idempresa { get; set; }
        public string razonsocial { get; set; }
    }

    public class TransporteVehiculo
    {
        public int idvehiculo { get; set; }
        public int idempresa { get; set; }
        public string marca { get; set; }
        public string modelocarro { get; set; }
        public string matricula { get; set; }
        public string licencia { get; set; }
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

    public class AuditoriaGuiaFiltroRequest
    {
        public int IdSucursalOrigen { get; set; }
        public int IdSucursalDestino { get; set; }
        public int IdTipoGuia { get; set; }
        public int IdEstado { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public string NroDocumento { get; set; }
    }

    public class StockMultipleRequest
    {
        public string Productos { get; set; }     // Ej: "1,2,3"
        public string Sucursales { get; set; }    // Ej: "101,102"
    }

    public class EntradaDistribucionCabeceraDto
    {
        public string documento { get; set; }
        public int idempresa { get; set; }
        public string empresa { get; set; }
        public int idsucursal { get; set; }
        public string sucursalorigen { get; set; }
        public int idsucursal_destino { get; set; }
        public string sucursaldestino { get; set; }
        public int? idempresatransporte { get; set; }
        public string empresatransporte { get; set; }
        public int? idvehiculo { get; set; }
        public string placa { get; set; }
        public string licencia { get; set; }
        public string usuariocrea { get; set; }
        public string usuariomantenimiento { get; set; }
        public string observacion { get; set; }
        public string estado_finalizado { get; set; }
        public string fechatraslado { get; set; }
        public decimal valor_peso { get; set; }
        public int num_bultos { get; set; }
    }


    public class EntradaDistribucionDetalleDto
    {
        public int num_item { get; set; }
        public int codigo { get; set; }
        public string producto { get; set; }
        public decimal cantidad_guia { get; set; }
        public decimal cantidad_picking { get; set; }
        public string laboratorio { get; set; }
        public string lote { get; set; }
        public string? fecha_recepcion { get; set; }
        public string? fecha_vencimiento { get; set; }
        public int idsucursal { get; set; }
        public int idempresa { get; set; }
        public string idalmacensucursal { get; set; }
    }

    public class DistribucionGuiaDto
    {
        public EntradaDistribucionCabeceraDto Cabecera { get; set; }
        public List<EntradaDistribucionDetalleDto> Detalle { get; set; }
    }
}
