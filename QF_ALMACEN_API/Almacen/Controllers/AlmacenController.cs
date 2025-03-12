using Microsoft.AspNetCore.Mvc;
using QF_ALMACEN_API.Almacen.Service;

namespace QF_ALMACEN_API.Almacen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlmacenController : ControllerBase
    {

        private readonly AlmacenService _AlmacenService;

        public AlmacenController(AlmacenService almacenService)
        {
            _AlmacenService = almacenService;
        }

        //metodos finales

        [HttpGet("listarOrdenCompra_Almacen")]
        public string listarOrdenCompra_Almacen()
        {
            return _AlmacenService.listarOrdenCompra_Almacen();
        }

        [HttpGet("listarProveedores_Almacen")]
        public string listarProveedores_Almacen()
        {
            return _AlmacenService.listarProveedores_Almacen();
        }

        [HttpGet("buscarOrdenCompra_Almacen")]
        public string buscarOrdenCompra_Almacen(int idOC)
        {
            return _AlmacenService.buscarOrdenCompra_Almacen(idOC);
        }
        [HttpGet("listarDetalleCompras_Almacen")]
        public string listarDetalleCompras_Almacen(int idOC)
        {
            return _AlmacenService.listarDetalleCompras_Almacen(idOC);
        }




    }
}
