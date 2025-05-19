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
    }
}
