using Microsoft.AspNetCore.Mvc;
using QF_ALMACEN_API.Almacen.Factura.Modelo;

namespace QF_ALMACEN_API.Almacen.Factura
{
    [Route("api/[controller]")]
    public class FacturaController : Controller
    {
        readonly FacturaService _FacturaService;

        public FacturaController(FacturaService facturaService)
        {
            _FacturaService = facturaService;
        }

        [HttpGet("listaTPago")]
        public string listaTPago()
        {
            return _FacturaService.listaTPago();
        }

        [HttpGet("ListaCPago")]
        public string ListaCPago()
        {
            return _FacturaService.ListaCPago();
        }
        [HttpGet("listar_PreIngreso_Factura")]
        public string listar_PreIngreso_Factura()
        {
            return _FacturaService.listar_PreIngreso_Factura();
        }
        [HttpGet("buscar_FacturaXid")]
        public string buscar_FacturaXid(int idFactura)
        {
            return _FacturaService.buscar_FacturaXid(idFactura);
        }
        [HttpGet("buscar_Detalle_Factura")]
        public string buscar_Detalle_Factura(int idFactura)
        {
            return _FacturaService.buscar_Detalle_Factura(idFactura);
        }
        [HttpGet("aprobar_Factura")]
        public string aprobar_Factura(int idUsuario, int idFactura, int idPreIngreso)
        {
            return _FacturaService.aprobar_Factura(idUsuario, idFactura, idPreIngreso);
        }
        [HttpGet("buscar_ultima_compra_Producto")]
        public string buscar_ultima_compra_Producto(int idProducto)
        {
            return _FacturaService.buscar_ultima_compra_Producto(idProducto);
        }
        [HttpGet("ListaPrecio_X_Producto")]
        public string ListaPrecio_X_Producto(int idproducto)
        {
            return _FacturaService.ListaPrecio_X_Producto(idproducto);
        }
        [HttpPost("ActualizarCostos")]
        public string ActualizarCostos([FromBody] string jsonFactura)
        {
            return _FacturaService.ActualizarCostos(jsonFactura);
        }

        [HttpGet("ObtenerLote_AprobarFactura")]
        public string ObtenerLote_AprobarFactura(int idFactura)
        {
            return _FacturaService.ObtenerLote_AprobarFactura(idFactura);
        }
        [HttpGet("retirarLotes_al_AnularFactura")]
        public string retirarLotes_al_AnularFactura(int idFactura, int idSucursal, int idUsuario, string userName)
        {
            return _FacturaService.retirarLotes_al_AnularFactura(idFactura, idSucursal, idUsuario, userName);
        }
        [HttpGet("ingresarLotes_AprobarFactura")]
        public string ingresarLotes_AprobarFactura(int idFactura, int idSucursal, int idUsuario, string userName)
        {
            return _FacturaService.ingresarLotes_AprobarFactura(idFactura,idSucursal,idUsuario,userName);
        }

        [HttpGet("listarFactura")]
        public string listarFactura(int idEstado)
        {
            return _FacturaService.listarFactura(idEstado);
        }

        [HttpGet("obtenerActaRecepcion")]
        public string obtenerActaRecepcion(int idFactura)
        {
            return _FacturaService.obtenerActaRecepcion(idFactura);
        }


        [HttpGet("ubigeos")]
        public IActionResult ubigeos()
        {
            var lista = _FacturaService.ubigeos();

            return Ok(lista);
        }



    }
}
