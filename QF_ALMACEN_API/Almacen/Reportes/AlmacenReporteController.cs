using Microsoft.AspNetCore.Mvc;
using QF_ALMACEN_API.Almacen.Reportes;
using QF_ALMACEN_API.Almacen.Reportes.Modelo;

namespace QF_ALMACEN_API.Almacen.Reportes
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlmacenReporteController : ControllerBase
    {
        private readonly AlmacenReporteService _service;

        public AlmacenReporteController(AlmacenReporteService service)
        {
            _service = service;
        }

        [HttpGet("ReporteAjustes")]
        public async Task<IActionResult> ReporteAjustes(
            DateTime fechaInicio,
            DateTime fechaFin,
            int? idsucursal = null,
            string? movimiento = null,
            int idempresa = 1000)
        {
            var data = await _service.Reporte(fechaInicio, fechaFin, idsucursal, movimiento, idempresa);
            return Ok(data);
        }

        [HttpGet("ListarSucursales")]
        public async Task<IActionResult> ListarSucursales()
        {
            var data = await _service.ListarSucursales();
            return Ok(data);
        }

        [HttpGet("ListarEmpresas")]
        public async Task<IActionResult> ListarEmpresas()
        {

            var data = await _service.ListarEmpresas();
            return Ok(data);

        }

        [HttpGet("ListarMovimientos")]
        public IActionResult ListarMovimientos()
        {
            return Ok(new List<MovimientoDTO>
        {
            new MovimientoDTO{ Id="E", Nombre="ENTRADA"},
            new MovimientoDTO{ Id="S", Nombre="SALIDA"}
        });
        }

    }

}
