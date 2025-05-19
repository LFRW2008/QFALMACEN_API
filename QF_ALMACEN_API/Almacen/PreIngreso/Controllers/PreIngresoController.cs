using Microsoft.AspNetCore.Mvc;
using QF_ALMACEN_API.Almacen.Factura;
using QF_ALMACEN_API.Almacen.PreIngreso.Service;

namespace QF_ALMACEN_API.Almacen.PreIngreso.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreIngresoController : ControllerBase
    {

        private readonly PreIngresoService _PreIngresoService;

        public PreIngresoController(PreIngresoService preIngresoService)
        {
            _PreIngresoService = preIngresoService;
        }

        //metodos finales

        [HttpGet("listarOrdenCompra_Almacen")]
        public string listarOrdenCompra_Almacen()
        {
            return _PreIngresoService.listarOrdenCompra_Almacen();
        }

        [HttpGet("listarProveedores_Almacen")]
        public string listarProveedores_Almacen()
        {
            return _PreIngresoService.listarProveedores_Almacen();
        }

        [HttpGet("buscarOrdenCompra_Almacen")]
        public string buscarOrdenCompra_Almacen(int idOC)
        {
            return _PreIngresoService.buscarOrdenCompra_Almacen(idOC);
        }
        [HttpGet("listarDetalleCompras_Almacen")]
        public string listarDetalleCompras_Almacen(int idOC)
        {
            return _PreIngresoService.listarDetalleCompras_Almacen(idOC);
        }
        [HttpGet("buscarLote_X_producto")]
        public string buscarLote_X_producto(int idproducto)
        {
            return _PreIngresoService.buscarLote_X_producto(idproducto);
        }
        [HttpGet("listarDocumentoTributario")]
        public string listarDocumentoTributario()
        {
            return _PreIngresoService.listarDocumentoTributario();
        }
        [HttpGet("listarEstadosPreIngreso")]
        public string listarEstadosPreIngreso()
        {
            return _PreIngresoService.listarEstadosPreIngreso();
        }
        [HttpGet("listarEstadoBuscarOCPre")]
        public string listarEstadoBuscarOCPre()
        {
            return _PreIngresoService.listarEstadoBuscarOCPre();
        }
        [HttpGet("listarOCConPreingreso")]
        public string listarOCConPreingreso()
        {
            return _PreIngresoService.listarOCConPreingreso();
        }
        [HttpGet("buscarPreingreso_X_ID")]
        public string buscarPreingreso_X_ID(int idOC)
        {
            return _PreIngresoService.buscarPreingreso_X_ID(idOC);
        }
        [HttpGet("listarDetalle_PreIngreso_X_idOC")]
        public string listarDetalle_PreIngreso_X_idOC(int idOC)
        {
            return _PreIngresoService.listarDetalle_PreIngreso_X_idOC(idOC);
        }
        [HttpPost("insertar_PreIngreso_Factura")]
        public string insertar_PreIngreso_Factura([FromBody] string jsonPreIngreso)
        {
            return _PreIngresoService.insertar_PreIngreso_Factura(jsonPreIngreso);
        }
        [HttpGet("listarTemperaturas")]
        public string listarTemperaturas()
        {
            return _PreIngresoService.listarTemperaturas();
        }
        [HttpGet("listar_fabricantes")]
        public string listar_fabricantes()
        {
            return _PreIngresoService.listar_fabricantes();
        }
        [HttpPost("LotesPI_a_ProductoLote")]
        public string LotesPI_a_ProductoLote([FromBody] string jsonLotes)
        {
            return _PreIngresoService.LotesPI_a_ProductoLote(jsonLotes);
        }
        [HttpPost("AnularPreIngresoLotes")]
        public string AnularPreIngresoLotes([FromBody] string jsonLotes)
        {
            return _PreIngresoService.AnularPreIngresoLotes(jsonLotes);
        }
        [HttpGet("ListarFacturas_PreIngreso")]
        public string ListarFacturas_PreIngreso(int idPreIngreso)
        {
            return _PreIngresoService.ListarFacturas_PreIngreso(idPreIngreso);
        }

    }
}
