using Azure.Core;

namespace QF_ALMACEN_API.Almacen.Factura
{
    public class FacturaService
    {

        public readonly FacturaRepository _FacturaRepository;

        public FacturaService(FacturaRepository facturaRepository)
        {
            _FacturaRepository = facturaRepository;
        }

        public string listaTPago()
        {
            return _FacturaRepository.listaTPago();
        }

        public string ListaCPago()
        {
            return _FacturaRepository.ListaCPago();
        }

        public string listar_PreIngreso_Factura()
        {
            return _FacturaRepository.listar_PreIngreso_Factura();
        }
        public string buscar_FacturaXid(int idFactura)
        {
            return _FacturaRepository.buscar_FacturaXid(idFactura);
        }

        public string buscar_Detalle_Factura(int idFactura)
        {
            return _FacturaRepository.buscar_Detalle_Factura(idFactura);
        }

        public string aprobar_Factura(int idUsuario, int idFactura, int idPreIngreso)
        {
            return _FacturaRepository.aprobar_Factura(idUsuario, idFactura, idPreIngreso);
        }

        public string buscar_ultima_compra_Producto(int idProducto)
        {
            return _FacturaRepository.buscar_ultima_compra_Producto(idProducto);
        }

    }
}
