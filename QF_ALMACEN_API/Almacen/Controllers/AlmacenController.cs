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
        [HttpGet("buscarLote_X_producto")]
        public string buscarLote_X_producto(int idproducto)
        {
            return _AlmacenService.buscarLote_X_producto(idproducto);
        }
        [HttpGet("listarDocumentoTributario")]
        public string listarDocumentoTributario()
        {
            return _AlmacenService.listarDocumentoTributario();
        }
        [HttpGet("listarEstadosPreIngreso")]
        public string listarEstadosPreIngreso()
        {
            return _AlmacenService.listarEstadosPreIngreso();
        }
        [HttpGet("listarEstadoBuscarOCPre")]
        public string listarEstadoBuscarOCPre()
        {
            return _AlmacenService.listarEstadoBuscarOCPre();
        }
        [HttpGet("listarOCConPreingreso")]
        public string listarOCConPreingreso()
        {
            return _AlmacenService.listarOCConPreingreso();
        }
        [HttpGet("buscarPreingreso_X_ID")]
        public string buscarPreingreso_X_ID(int idOC)
        {
            return _AlmacenService.buscarPreingreso_X_ID(idOC);
        }
        [HttpGet("listarDetalle_PreIngreso_X_idOC")]
        public string listarDetalle_PreIngreso_X_idOC(int idOC)
        {
            return _AlmacenService.listarDetalle_PreIngreso_X_idOC(idOC);
        }


    }
}
