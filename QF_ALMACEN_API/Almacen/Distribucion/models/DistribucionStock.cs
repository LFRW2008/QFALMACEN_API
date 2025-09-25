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
        public int idgrupo { get; set; }
        //public decimal stock_sistema { get; set; }

        public string unidad { get; set; }
        public decimal presentacion { get; set; }
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
        public decimal cantidad { get; set; }
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

        public string fechatraslado { get; set; }
        public string tipoguia { get; set; }
        public int es_guiafactura { get; set; }
    }

    public class AuditoriaGuiaFiltros
    {
        public List<EstadoGuia> estadosguia { get; set; }
        public List<TipoGuia> tiposguia { get; set; }
        public List<TransporteEmpresa> transporte_empresas { get; set; }
        public List<TransporteVehiculo> transporte_vehiculo { get; set; }
        public List<AlmacenSucursal> almacen_sucursal { get; set; }
        public List<Empresa> empresas { get; set; }
        public List<TipoProductos> tipoproductos { get; set; }
    }

    public class EstadoGuia
    {
        public int idestado { get; set; }
        public string descripcion { get; set; }
        public string codequiv { get; set; }
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

    public class AlmacenSucursal
    {
        public int idsucursal { get; set; }
        public int idalmacen { get; set; }
        public string descripcion { get; set; }
        public string ubicaciones { get; set; }
        public string almacenes_sucursal { get; set; }
    }

    public class Empresa
    {
        public int idempresa { get; set; }
        public string descripcion { get; set; }
    }

    public class TipoProductos
    {
        public string idtipo { get; set; }
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

        public int idsucursal { get; set; }
        public int idsucursal_destino { get; set; }
        public int idempresa_destino { get; set; }
        public string estado_venta { get; set; }
        public bool es_guiafactura { get; set; }
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

    public class VentasUltimosMesesRequest
    {
        public string Productos { get; set; }
        public string Sucursales { get; set; }
        public int Meses { get; set; }
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
        public string sucursaldestino_ruc { get; set; }
        public int? idempresatransporte { get; set; }
        public string empresatransporte { get; set; }
        public int? idvehiculo { get; set; }
        public string placa { get; set; }
        public string licencia { get; set; }
        public string usuariocrea { get; set; }
        public string usuariocrea_nombre { get; set; }
        public string usuariomodifica_nombre { get; set; }
        public string observacion { get; set; }
        public string estado_finalizado { get; set; }
        public string fechatraslado { get; set; }
        public decimal valor_peso { get; set; }
        public int num_bultos { get; set; }

        public string nro_documento { get; set; }
        public string num_serie { get; set; }
        public string fechaingreso { get; set; }

        public string punto_partida { get; set; }
        public string punto_llegada { get; set; }
        public string ruc_empresa { get; set; }
        public string conductor { get; set; }
        public string conductor_documentoidentidad { get; set; }
        public string vehiculo_marcamodelo { get; set; }
        public string tipo_guia { get; set; }

        public string mtc { get; set; }
        public string unidad { get; set; }
        public string ubigeo_llegada { get; set; }
        public string ubigeo_partida { get; set; }
        public string tarjeta_circulacion { get; set;}
        public int? idventa { get; set; }
        public string datos_venta { get; set; }
        public int? es_guiafactura { get; set; }
    }


    public class EntradaDistribucionDetalleDto
    {
        public int num_item { get; set; }
        public int idproducto { get; set; }
        public string descripcion { get; set; }
        public decimal cantidad_lote { get; set; }
        public decimal cantidad_picking { get; set; }
        public string razonsocial { get; set; }
        public string numero_lote { get; set; }
        public string? fecha_recibimiento { get; set; }
        public string? fecha_validez { get; set; }
        public int idsucursal { get; set; }
        public int idempresa { get; set; }
        public string idalmacensucursal { get; set; }
        public string usuariocrea { get; set; }
        public string fechacrea { get; set; }
        public string fechaingreso { get; set; }

        public string unidad_medida { get; set; }
        public decimal precio_venta { get; set; }
        public decimal valor_venta { get; set; }
        public string idtipo { get; set; }
        
    }

    public class DistribucionGuiaDto
    {
        public EntradaDistribucionCabeceraDto Cabecera { get; set; }
        public List<EntradaDistribucionDetalleDto> Detalle { get; set; }
    }

    public class DistribucionProductoLote
    {
        public int idproducto { get; set; }
        public string numlote { get; set; }
        public string descripcion_almacen { get; set; }
        public DateTime fechavalidez { get; set; }
        public DateTime fecharecepcion { get; set; }
        public string idalmacensucursal { get; set; }
        public decimal stock_sistema { get; set; }
        public decimal stock_transito { get; set; }

        // Propiedad calculada para el stock final
        public decimal stock_final
        {
            get
            {
                return stock_sistema - stock_transito;
            }
        }
    }

    public class VentasProducto
    {
        public int idproducto { get; set; }
        public int idsucursal { get; set; }
        public string periodo { get; set; }
        public decimal cantidadventas { get; set; }
        public decimal stock_transito { get; set; }
        public decimal stock_solicitado { get; set; }
        public decimal stock_actual { get; set; }
        
    }


    public class ProductoFraccionamiento
    {
        public int idfraccionamiento { get; set; }
        public int idproducto { get; set; }
        public string codigo_presentacion { get; set; }
        public decimal equivalencia { get; set; }
        public int usuariocrea { get; set; }
    }


    public class FraccionamientoSolicitudDTO
    {
        public int idfraccionamientoSolicitud { get; set; }
        public int idproducto { get; set; }
        public string producto { get; set; }
        public string numlote { get; set; }
        public DateTime fecharecepcion { get; set; }
        public int idalmacensucursal { get; set; }
        public string descripcion_almacen { get; set; }
        public decimal stock_sistema { get; set; }
        public decimal stock_transito { get; set; }
        public DateTime fechacrea { get; set; }
        public string username { get; set; }
        public string situacion { get; set; }
    }

    public class FraccionamientoSolicitudDetalleDTO
    {
        public string codigo_presentacion { get; set; }
        public string codigo_sublote { get; set; }
        public decimal equivalencia { get; set; }
        public decimal cantidad { get; set; }
        public decimal total { get; set; }
        public decimal total_real { get; set; }
        public string situacion { get; set; }
    }

    public class ConjugadoLoteDTO
    {
        public string codigo_presentacion { get; set; }   // clave del sublote
        public int idproducto { get; set; }
        public string descripcion { get; set; }
        public int cantidad { get; set; }
        public string numlote { get; set; }
        public DateTime fecharecepcion { get; set; }
        public int idalmacensucursal { get; set; }
        public int idsucursal { get; set; }
    }

    public class FraccionamientoSolicitudResponse
    {
        public FraccionamientoSolicitudDTO cabecera { get; set; }
        public List<FraccionamientoSolicitudDetalleDTO> detalle { get; set; }
        public List<ConjugadoLoteDTO> conjugados_sublotes { get; set; }
    }

    public class FraccionamientoUnidadesDTO
    {
        public string codigo_sublote { get; set; }
        public decimal equivalencia { get; set; }
        public decimal cantidad { get; set; }
        public decimal total { get; set; }
    }
}
