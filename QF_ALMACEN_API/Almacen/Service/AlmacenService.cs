using QF_ALMACEN_API.Almacen.Data;

namespace QF_ALMACEN_API.Almacen.Service
{
    public class AlmacenService
    {

        private readonly AlmacenRepository _AlmacenRepository;

        public AlmacenService(AlmacenRepository almacenRepository)
        {
            _AlmacenRepository = almacenRepository;
        }

       public string listarOrdenCompra_Almacen()
        {
            return _AlmacenRepository.listarOrdenCompra_Almacen();
        }
        public string listarProveedores_Almacen()
        {
            return _AlmacenRepository.listarProveedores_Almacen();
        }

        public string buscarOrdenCompra_Almacen(int idOC)
        {
            return _AlmacenRepository.buscarOrdenCompra_Almacen(idOC);
        }

        public string listarDetalleCompras_Almacen(int idOC)
        {
            return _AlmacenRepository.listarDetalleCompras_Almacen(idOC);
        }

        public string buscarLote_X_producto(int idproducto)
        {
            return _AlmacenRepository.buscarLote_X_producto(idproducto);
        }
        public string listarDocumentoTributario()
        {
            return _AlmacenRepository.listarDocumentoTributario();
        }

        public string listarEstadosPreIngreso()
        {
            return _AlmacenRepository.listarEstadosPreIngreso();
        }

        public string listarEstadoBuscarOCPre()
        {
            return _AlmacenRepository.listarEstadoBuscarOCPre();
        }

        public string listarOCConPreingreso()
        {
            return _AlmacenRepository.listarOCConPreingreso();
        }
        public string buscarPreingreso_X_ID(int idOC)
        {
            return _AlmacenRepository.buscarPreingreso_X_ID(idOC);
        }

        public string listarDetalle_PreIngreso_X_idOC(int idOC)
        {
            return _AlmacenRepository.listarDetalle_PreIngreso_X_idOC(idOC);
        }

    }
}
