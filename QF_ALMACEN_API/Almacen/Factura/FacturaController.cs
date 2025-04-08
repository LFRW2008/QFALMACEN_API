using Microsoft.AspNetCore.Mvc;

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

    }
}
