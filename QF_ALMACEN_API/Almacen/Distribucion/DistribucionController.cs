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
        public async Task<ActionResult<DistribucionStock>> DistribucionObtenerStockAsync(string descripcion_producto, int idsucursal, int idlaboratorio, int idalmacensucursal)
        {
            var lista = await _distribucionService.DistribucionObtenerStockAsync(descripcion_producto, idsucursal, idlaboratorio, idalmacensucursal);
            return Ok(lista);
        }

        [HttpGet("DistribucionCorrelativosGuia")]
        public async Task<object> DistribucionCorrelativosGuiaAsync(int idsucursal)
        {
            var lista = await _distribucionService.DistribucionCorrelativosGuiaAsync(idsucursal);
            return Ok(lista);
        }

        [HttpGet("VentasUltimosMeses")]
        public async Task<ActionResult<VentasProducto>> VentasUltimosMesesAsync(string idproductos, string idsucursales, int meses)
        {
            var lista = await _distribucionService.VentasUltimosMesesAsync(idproductos, idsucursales, meses);
            return Ok(lista);
        }

        [HttpGet("DistribucionObtenerStockActualYTransito")]
        public async Task<ActionResult<DistribucionStockActualTransito>> DistribucionObtenerStockActualYTransitoAsync(string productos, string sucursales)
        {
            var lista = await _distribucionService.DistribucionObtenerStockActualYTransitoAsync(productos, sucursales);
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

        [HttpGet("DistribucionAuditoriaCabecera")]
        public async Task<ActionResult<AuditoriaGuiaFiltros>> DistribucionAuditoriaCabeceraAsync(int idsucursal_origen, int idsucursal_destino, int idtipoguia, int idestado, string fecha_inicio, string fecha_fin, string nro_documento)
        {
            var lista = await _distribucionService.DistribucionAuditoriaCabeceraAsync(idsucursal_origen, idsucursal_destino, idtipoguia, idestado, fecha_inicio, fecha_fin, nro_documento);
            return Ok(lista);
        }
    }
}
