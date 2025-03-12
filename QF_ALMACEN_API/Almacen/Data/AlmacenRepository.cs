using Dapper;
using QF_ALMACEN_API.General.Helpers;
using System.Data;

namespace QF_ALMACEN_API.Almacen.Data
{
    public class AlmacenRepository
    {

        private readonly ServicesConnection _connectionString;

        public AlmacenRepository(ServicesConnection servicesConnection, IConfiguration configuration)
        {
            _connectionString = servicesConnection;
            //_connectionString = configuration.GetConnectionString("AlmacenConnection");
        }

        //metodos :D!

        public string listarOrdenCompra_Almacen() 
        {
            return _connectionString.MetodoDatatabletostringsql("compras.sp_listarOrdenCompra_Almacen", null,1);
        }

        public string listarProveedores_Almacen()
        {
            return _connectionString.MetodoDatatabletostringsql("almacen.sp_listarProveedores",null, 1);
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
    }
}
