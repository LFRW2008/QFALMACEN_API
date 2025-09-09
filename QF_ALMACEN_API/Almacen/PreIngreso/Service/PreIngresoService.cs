using QF_ALMACEN_API.Almacen.Factura;
using QF_ALMACEN_API.Almacen.PreIngreso.Data;

namespace QF_ALMACEN_API.Almacen.PreIngreso.Service
{
    public class PreIngresoService
    {

        private readonly PreIngresoRepository _PreIngresoRepository;

        public PreIngresoService(PreIngresoRepository preIngresoRepository)
        {
            _PreIngresoRepository = preIngresoRepository;
        }

        public string listarOrdenCompra_Almacen()
        {
            return _PreIngresoRepository.listarOrdenCompra_Almacen();
        }
        public string listarProveedores_Almacen()
        {
            return _PreIngresoRepository.listarProveedores_Almacen();
        }

        public string buscarOrdenCompra_Almacen(int idOC)
        {
            return _PreIngresoRepository.buscarOrdenCompra_Almacen(idOC);
        }

        public string listarDetalleCompras_Almacen(int idOC)
        {
            return _PreIngresoRepository.listarDetalleCompras_Almacen(idOC);
        }

        public string buscarLote_X_producto(int idproducto)
        {
            return _PreIngresoRepository.buscarLote_X_producto(idproducto);
        }
        public string listarDocumentoTributario()
        {
            return _PreIngresoRepository.listarDocumentoTributario();
        }

        public string listarEstadosPreIngreso()
        {
            return _PreIngresoRepository.listarEstadosPreIngreso();
        }

        public string listarEstadoBuscarOCPre()
        {
            return _PreIngresoRepository.listarEstadoBuscarOCPre();
        }

        public string listarOCConPreingreso()
        {
            return _PreIngresoRepository.listarOCConPreingreso();
        }
        public string buscarPreingreso_X_ID(int idOC)
        {
            return _PreIngresoRepository.buscarPreingreso_X_ID(idOC);
        }

        public string listarDetalle_PreIngreso_X_idOC(int idOC)
        {
            return _PreIngresoRepository.listarDetalle_PreIngreso_X_idOC(idOC);
        }

        public string insertar_PreIngreso_Factura(string jsonPreIngreso)
        {
            return _PreIngresoRepository.insertar_PreIngreso_Factura(jsonPreIngreso);
        }
        public string listarTemperaturas()
        {
            return _PreIngresoRepository.listarTemperaturas();
        }
        public string listar_fabricantes()
        {
            return _PreIngresoRepository.listar_fabricantes();
        }

        public string LotesPI_a_ProductoLote(string jsonLotes)
        {
            return _PreIngresoRepository.LotesPI_a_ProductoLote(jsonLotes);
        }

        public string AnularPreIngresoLotes(string jsonLotes, int idPreingreso)
        {
            return _PreIngresoRepository.AnularPreIngresoLotes(jsonLotes, idPreingreso);
        }

        public string ListarFacturas_PreIngreso(int idPreIngreso)
        {
            return _PreIngresoRepository.ListarFacturas_PreIngreso(idPreIngreso);
        }

        public string listar_Preingresos()
        {
            return _PreIngresoRepository.listar_Preingresos();
        }

        public string obtenerEstadoPreIngreso(int idPreingreso)
        {
            return _PreIngresoRepository.obtenerEstadoPreIngreso(idPreingreso);
        }


    }
}
