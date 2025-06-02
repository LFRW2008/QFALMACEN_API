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
    }
}
