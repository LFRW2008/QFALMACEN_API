using Dapper;
using QF_ALMACEN_API.General.Helpers;
using System.Data;

namespace QF_ALMACEN_API.Almacen.PreIngreso.Data
{
    public class PreIngresoRepository
    {

        private readonly ServicesConnection _connectionString;

        public PreIngresoRepository(ServicesConnection servicesConnection, IConfiguration configuration)
        {
            _connectionString = servicesConnection;
           
        }

        //metodos :D!

        public string listarOrdenCompra_Almacen()
        {
            return _connectionString.MetodoDatatabletostringsql("compras.sp_listarOrdenCompra_Almacen", null, 1);
        }

        public string listarProveedores_Almacen()
        {
            return _connectionString.MetodoDatatabletostringsql("almacen.sp_listarProveedores", null, 1);
        }

        public string buscarOrdenCompra_Almacen(int idOC)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@idOC", idOC);
            return _connectionString.MetodoDatatabletostringsql("Almacen.sp_BuscarOrdenCompra_Almacen", parametros, 1);
        }

        public string listarDetalleCompras_Almacen(int idOC)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@idOC", idOC);
            return _connectionString.MetodoDatatabletostringsql("Almacen.listarDetalleCompras_Almacen", parametros, 1);

        }

        public string buscarLote_X_producto(int idProducto)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@idProducto", idProducto);
            return _connectionString.MetodoDatatabletostringsql("almacen.sp_buscarLote_X_producto", parametros, 4);
        }

        public string listarDocumentoTributario()
        {
            return _connectionString.MetodoDatatabletostringsql("PreIngreso.sp_listarDocumentoTributario", null, 4);

        }

        public string listarEstadosPreIngreso()
        {
            return _connectionString.MetodoDatatabletostringsql("PreIngreso.sp_listarEstadosPreIngreso", null, 4);
        }

        public string listarEstadoBuscarOCPre()
        {
            return _connectionString.MetodoDatatabletostringsql("PreIngreso.sp_listarEstadoBuscarOCPre", null, 4);
        }

        public string listarOCConPreingreso()
        {
            return _connectionString.MetodoDatatabletostringsql("almacen.sp_listarOCConPreingreso", null, 1);
        }

        public string buscarPreingreso_X_ID(int idOC)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@idOC", idOC);
            return _connectionString.MetodoDatatabletostringsql("Almacen.sp_buscarPreingreso_X_ID", parameters, 1);
        }

        public string listarDetalle_PreIngreso_X_idOC(int idOC)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@idOC", idOC);
            return _connectionString.MetodoDatatabletostringsql("PreIngreso.sp_listarDetalle_PreIngreso_X_idOC", parameters, 4);
        }

        public string insertar_PreIngreso_Factura(string jsonPreIngreso)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@jsonPreingreso", jsonPreIngreso);
            return _connectionString.MetodoRespuestasql("almacen.sp_insertar_PreIngreso_Factura_TEST", parameters, 1000, 4);
        }

        public string listarTemperaturas()
        {
            return _connectionString.MetodoDatatabletostringsql("almacen.sp_listarTemperaturas", null, 4);
        }

        public string listar_fabricantes()
        {
            return _connectionString.MetodoDatatabletostringsql("Almacen.sp_listar_fabricantes", null, 1);
        }
    }
}
