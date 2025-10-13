using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QF_ALMACEN_API.Almacen.Distribucion.Models;

namespace QF_ALMACEN_API.Almacen.Distribucion
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistribucionController : ControllerBase
    {
        private readonly DistribucionService _distribucionService;

        public DistribucionController(DistribucionService distribucionService)
        {
            _distribucionService = distribucionService;
        }

        [HttpGet("DistribucionObtenerStock")]
        public async Task<ActionResult<DistribucionStock>> DistribucionObtenerStockAsync(string descripcion_producto, int idsucursal, int idlaboratorio, int idalmacensucursal, string idtipoproducto, string filtro_stock)
        {
            var lista = await _distribucionService.DistribucionObtenerStockAsync(descripcion_producto, idsucursal, idlaboratorio, idalmacensucursal, idtipoproducto, filtro_stock);
            return Ok(lista);
        }

        [HttpGet("DistribucionCorrelativosGuia")]
        public async Task<object> DistribucionCorrelativosGuiaAsync(int idsucursal)
        {
            var lista = await _distribucionService.DistribucionCorrelativosGuiaAsync(idsucursal);
            return Ok(lista);
        }

        //[HttpGet("VentasUltimosMeses")]
        //public async Task<ActionResult<VentasProducto>> VentasUltimosMesesAsync(string idproductos, string idsucursales, int meses)
        //{
        //    var lista = await _distribucionService.VentasUltimosMesesAsync(idproductos, idsucursales, meses);
        //    return Ok(lista);
        //}

        [HttpPost("VentasUltimosMeses")]
        public async Task<ActionResult<VentasProducto>> VentasUltimosMesesAsync([FromBody] VentasUltimosMesesRequest request)
        {
            var lista = await _distribucionService.VentasUltimosMesesAsync(request.Productos, request.Sucursales, request.Meses);
            return Ok(lista);
        }

        ////[HttpGet("DistribucionObtenerStockActualYTransito")]
        ////public async Task<ActionResult<DistribucionStockActualTransito>> DistribucionObtenerStockActualYTransitoAsync(string productos, string sucursales)
        ////{
        ////    var lista = await _distribucionService.DistribucionObtenerStockActualYTransitoAsync(productos, sucursales);
        ////    return Ok(lista);
        ////}

        [HttpPost("DistribucionObtenerStockActualYTransito")]
        public async Task<ActionResult<DistribucionStockActualTransito>> DistribucionObtenerStockActualYTransitoAsync([FromBody] StockMultipleRequest request)
        {
            var lista = await _distribucionService.DistribucionObtenerStockActualYTransitoAsync(request.Productos, request.Sucursales);
            return Ok(lista);
        }

        [HttpPost("DistribucionAsignarLotesFEFO")]
        public async Task<ActionResult<DistribucionStockActualTransito>> DistribucionAsignarLotesFEFOAsync([FromBody] List<DistribucionLotesEntradaFEFO> distribucionLotesEntradaFEFO)
        {
            var lista = await _distribucionService.DistribucionAsignarLotesFEFOAsync(distribucionLotesEntradaFEFO);
            return Ok(lista);
        }

        [HttpPost("DistribucionGenerarGuias")]
        public async Task<IActionResult> DistribucionGenerarGuiasAsync([FromBody] List<DistribucionFEFOAgregar> distribucion)
        {
            var respuesta = await _distribucionService.DistribucionGenerarGuiasAsync(distribucion); ;

            if (respuesta.Split("|")[0] == "OK")
            {
                return Ok(new { Success = true, Message = respuesta.Split("|")[1], Codigo = "" });
            }
            else
            {
                return BadRequest(new { Success = false, Message = respuesta, Codigo = "" });
            }
        }

        [HttpGet("DistribucionFiltrosAuditoria")]
        public async Task<ActionResult<AuditoriaGuiaFiltros>> DistribucionFiltrosAuditoriaAsync()
        {
            var lista = await _distribucionService.DistribucionFiltrosAuditoriaAsync();
            return Ok(lista);
        }

        //[HttpGet("DistribucionAuditoriaCabecera")]
        //public async Task<ActionResult<AuditoriaGuiaFiltros>> DistribucionAuditoriaCabeceraAsync(int idsucursal_origen, int idsucursal_destino, int idtipoguia, int idestado, string fecha_inicio, string fecha_fin, string nro_documento)
        //{
        //    var lista = await _distribucionService.DistribucionAuditoriaCabeceraAsync(idsucursal_origen, idsucursal_destino, idtipoguia, idestado, fecha_inicio, fecha_fin, nro_documento);
        //    return Ok(lista);
        //}

        [HttpPost("DistribucionAuditoriaCabecera")]
        public async Task<ActionResult<AuditoriaGuiaFiltros>> DistribucionAuditoriaCabeceraAsync([FromBody] AuditoriaGuiaFiltroRequest filtro)
        {
            var idsucursal_origen = filtro.IdSucursalOrigen;
            var idsucursal_destino = filtro.IdSucursalDestino;
            var idtipoguia = filtro.IdTipoGuia;
            var idestado = filtro.IdEstado;
            var fecha_inicio = filtro.FechaInicio;
            var fecha_fin = filtro.FechaFin;
            var nro_documento = filtro.NroDocumento;

            var lista = await _distribucionService.DistribucionAuditoriaCabeceraAsync(idsucursal_origen, idsucursal_destino, idtipoguia, idestado, fecha_inicio, fecha_fin, nro_documento);
            return Ok(lista);
        }

        [HttpGet("DistribucionAuditoriaDetalle")]
        public async Task<ActionResult<AuditoriaGuiaFiltros>> DistribucionAuditoriaDetalleAsync(string nro_documento, int idsucursal_origen,int idsucursal_destino)
        {
            var lista = await _distribucionService.DistribucionAuditoriaDetalleAsync(nro_documento, idsucursal_origen, idsucursal_destino);
            return Ok(lista);
        }

        [HttpGet("DistribucionBuscarGuia")]
        public async Task<DistribucionGuiaDto> DistribucionBuscarGuiaAsync(string nroDocumento, int idSucursalOrigen,int idSucursalDestino)
        {
            return await _distribucionService.DistribucionBuscarGuiaAsync(nroDocumento, idSucursalOrigen, idSucursalDestino);
        }

        [HttpPost("DistribucionEditarGuia")]
        public async Task<IActionResult> DistribucionEditarGuiaAsync([FromBody] string distribucionguia)
        {
            var respuesta = await _distribucionService.DistribucionEditarGuiaAsync(distribucionguia);

            if (respuesta == "OK")
            {
                return Ok(new { Success = true, Message = "CAMBIOS GUARDADOS CORRECTAMENTE!!" });
            }
            else
            {
                return BadRequest(new { Success = false, Message = respuesta });
            }
        }

        [HttpPost("DistribucionConsumoMateriaPrimaUltimosMeses")]
        public async Task<ActionResult<VentasProducto>> DistribucionConsumoMateriaPrimaUltimosMesesAsync([FromBody] VentasUltimosMesesRequest request)
        {
            var lista = await _distribucionService.DistribucionConsumoMateriaPrimaUltimosMesesAsync(request.Productos, request.Sucursales, request.Meses);
            return Ok(lista);
        }

        [HttpGet("DistribucionObtenerProductoLotes")]
        public async Task<ActionResult<DistribucionProductoLote>> DistribucionObtenerProductoLotesAsync(int idproducto, int idsucursal)
        {
            var lista = await _distribucionService.DistribucionObtenerProductoLotesAsync(idproducto, idsucursal);
            return Ok(lista);
        }


        [HttpPost("ProductoFraccionamientoRegistrar")]
        public async Task<IActionResult> ProductoFraccionamientoRegistrarAsync([FromBody] string fraccionamiento)
        {
            var respuesta = await _distribucionService.ProductoFraccionamientoRegistrarAsync(fraccionamiento);

            if (respuesta.Split("|")[0] == "OK")
            {
                return Ok(new { Success = true, Message = "CAMBIOS GUARDADOS CORRECTAMENTE!!", Codigo = respuesta.Split("|")[1] });
            }
            else
            {
                return BadRequest(new { Success = false, Message = respuesta, Codigo = "" });
            }
        }

        [HttpGet("ProductoFraccionamientoBuscar")]
        public async Task<ActionResult<ProductoFraccionamiento>> ProductoFraccionamientoBuscarAsync(int idproducto)
        {
            var lista = await _distribucionService.ProductoFraccionamientoBuscarAsync(idproducto);
            return Ok(lista);
        }

        [HttpPost("FraccionamientoSolicitudRegistrar")]
        public async Task<IActionResult> FraccionamientoSolicitudRegistrarAsync([FromBody] string fraccionamiento)
        {
            var respuesta = await _distribucionService.FraccionamientoSolicitudRegistrarAsync(fraccionamiento);

            if (respuesta.Split("|")[0] == "OK")
            {
                return Ok(new { Success = true, Message = "CAMBIOS GUARDADOS CORRECTAMENTE!!", Codigo = respuesta.Split("|")[1] });
            }
            else
            {
                return BadRequest(new { Success = false, Message = respuesta, Codigo = "" });
            }
        }

        [HttpGet("FraccionamientoSolicitudListar")]
        public async Task<ActionResult<ProductoFraccionamiento>> FraccionamientoSolicitudListarAsync(string fecha_inicial, string fecha_final)
        {
            var lista = await _distribucionService.FraccionamientoSolicitudListarAsync(fecha_inicial, fecha_final);
            return Ok(lista);
        }

        [HttpGet("FraccionamientoSolicitudBuscar")]
        public async Task<FraccionamientoSolicitudResponse> FraccionamientoSolicitudBuscarAsync(int idfraccionamientoSolicitud)
        {
            return await _distribucionService.FraccionamientoSolicitudBuscarAsync(idfraccionamientoSolicitud);
        }

        [HttpPost("FraccionamientoSolicitudGuardar")]
        public async Task<IActionResult> FraccionamientoSolicitudGuardarAsync([FromBody] string fraccionamiento)
        {
            var respuesta = await _distribucionService.FraccionamientoSolicitudGuardarAsync(fraccionamiento);

            if (respuesta.Split("|")[0] == "OK")
            {
                return Ok(new { Success = true, Message = "CAMBIOS GUARDADOS CORRECTAMENTE!!", Codigo = respuesta.Split("|")[1] });
            }
            else
            {
                return BadRequest(new { Success = false, Message = respuesta, Codigo = "" });
            }
        }

        [HttpPost("FraccionamientoSolicitudAnular")]
        public async Task<IActionResult> FraccionamientoSolicitudAnularAsync([FromBody] string fraccionamiento)
        {
            dynamic datos = JsonConvert.DeserializeObject(fraccionamiento);
            string idfraccionamientoSolicitud = (string)datos.idfraccionamientoSolicitud;
            string codigo_presentacion = (string)datos.codigo_presentacion;
            string usuario_anula = (string)datos.usuario_anula;
            var respuesta = await _distribucionService.FraccionamientoSolicitudAnularAsync(idfraccionamientoSolicitud, codigo_presentacion, usuario_anula);

            if (respuesta.Split("|")[0] == "OK")
            {
                return Ok(new { Success = true, Message = "EL CODIGO FUE ANULADO CORRECTAMENTE!!", Codigo = respuesta.Split("|")[1] });
            }
            else
            {
                return BadRequest(new { Success = false, Message = respuesta, Codigo = "" });
            }
        }

        [HttpPost("FraccionamientoSolicitudDescargar")]
        public async Task<IActionResult> FraccionamientoSolicitudDescargarAsync([FromBody] string fraccionamiento)
        {
            var respuesta = await _distribucionService.FraccionamientoSolicitudDescargarAsync(fraccionamiento);

            if (respuesta.Split("|")[0] == "OK")
            {
                return Ok(new { Success = true, Message = "SE HA GENERADO LA DESCARGA CORRECTAMENTE!!", Codigo = respuesta.Split("|")[1] });
            }
            else
            {
                return BadRequest(new { Success = false, Message = respuesta, Codigo = "" });
            }
        }

        [HttpGet("FraccionamientoUnidadesBuscar")]
        public async Task<ActionResult<ProductoFraccionamiento>> FraccionamientoUnidadesBuscarAsync(int idproducto, string numlote, string fecharecepcion, int idalmacensucursal)
        {
            var lista = await _distribucionService.FraccionamientoUnidadesBuscarAsync(idproducto, numlote, fecharecepcion, idalmacensucursal);
            return Ok(lista);
        }


        [HttpPost("DistribucionAsignarSinStock")]
        public async Task<ActionResult<DistribucionStockActualTransito>> DistribucionAsignarSinStockAsync([FromBody] List<DistribucionLotesEntradaFEFO> distribucionLotesEntradaFEFO)
        {
            var lista = await _distribucionService.DistribucionAsignarSinStockAsync(distribucionLotesEntradaFEFO);
            return Ok(lista);
        }


        [HttpPost("DistribucionAnularGuia")]
        public async Task<IActionResult> DistribucionAnularGuiaAsync([FromBody] DistribucionAnularGuiaRequest guiaRequest)
        {
            var respuesta = await _distribucionService.DistribucionAnularGuiaAsync(guiaRequest);

            if (respuesta == "OK")
            {
                return Ok(new { Success = true, Message = "LA GUIA SE ANULO CORRECTAMENTE!!", Codigo = "" });
            }
            else
            {
                return BadRequest(new { Success = false, Message = respuesta, Codigo = "" });
            }
        }
    }
}
