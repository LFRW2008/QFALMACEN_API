using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<AuditoriaGuiaFiltros>> DistribucionAuditoriaDetalleAsync(string nro_documento, int idsucursal_origen)
        {
            var lista = await _distribucionService.DistribucionAuditoriaDetalleAsync(nro_documento, idsucursal_origen);
            return Ok(lista);
        }

        [HttpGet("DistribucionBuscarGuia")]
        public async Task<DistribucionGuiaDto> DistribucionBuscarGuiaAsync(string nroDocumento, int idSucursalOrigen)
        {
            return await _distribucionService.DistribucionBuscarGuiaAsync(nroDocumento, idSucursalOrigen);
        }
    }
}
