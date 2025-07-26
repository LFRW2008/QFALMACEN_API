using Azure.Core;
using QF_ALMACEN_API.Almacen.Factura.Modelo;
using System.Diagnostics.CodeAnalysis;

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

        public string ListaPrecio_X_Producto(int idproducto)
        {
            return _FacturaRepository.ListaPrecio_X_Producto(idproducto);
        }

        public string ActualizarCostos(string jsonFactura)
        {
            return _FacturaRepository.ActualizarCostos(jsonFactura);
        }

        public string ObtenerLote_AprobarFactura(int idFactura)
        {
            return _FacturaRepository.ObtenerLote_AprobarFactura(idFactura);
        }

        public string retirarLotes_al_AnularFactura(int idFactura, int idSucursal, int idUsuario, string userName)
        {
            return _FacturaRepository.retirarLotes_al_AnularFactura(idFactura, idSucursal, idUsuario, userName);
        }

        public string ingresarLotes_AprobarFactura(int idFactura, int idSucursal, int idUsuario, string userName)
        {
            return _FacturaRepository.ingresarLotes_AprobarFactura(idFactura, idSucursal, idUsuario, userName);
        }

        public string listarFactura(int idEstado)
        {
            return _FacturaRepository.listarFactura(idEstado);
        }

        public string obtenerActaRecepcion(int idFactura)
        {
            return _FacturaRepository.obtenerActaRecepcion(idFactura);
        }

        public List<Ubigeo> ubigeos()
        {
            return _FacturaRepository.ObtenerUbigeo();
        }

    }
}
