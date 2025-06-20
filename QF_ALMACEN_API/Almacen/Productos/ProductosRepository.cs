using Dapper;
using QF_ALMACEN_API.General.Helpers;

namespace QF_ALMACEN_API.Almacen.Productos
{
    public class ProductosRepository
    {

        readonly ServicesConnection _servicesConnection;

        public ProductosRepository(ServicesConnection servicesConnection, IConfiguration configuration)
        {
            _servicesConnection = servicesConnection;
        }

        public string listartipoProductos()
        {
            return _servicesConnection.MetodoDatatabletostringsql("productos.listartipoProductos", null, 2);
        }

        public string listarClase()
        {
            return _servicesConnection.MetodoDatatabletostringsql("almacen.sp_listarClase", null, 2);
        }

        public string listarSubClaseXClase(int idClase)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idClase", idClase);
            return _servicesConnection.MetodoDatatabletostringsql("almacen.sp_listarSubClaseXClase", parameters, 2);
        }

        public string listarUnidadMedida()
        {
            return _servicesConnection.MetodoDatatabletostringsql("productos.sp_listarUnidadMedida",null, 2);
        }

        public string listarProductoPresentacion()
        {
            return _servicesConnection.MetodoDatatabletostringsql("almacen.sp_listarProductoPresentacion", null, 2);
        }

        public string listarLaboratorios()
        {
            return _servicesConnection.MetodoDatatabletostringsql("laboratorio.sp_listarLaboratorios", null, 2);
        }

        public string listar_FormaFarmaceutica()
        {
            return _servicesConnection.MetodoDatatabletostringsql("Almacen.sp_listar_FormaFarmaceutica", null, 2);
        }

        public string listarTemperatura()
        {
            return _servicesConnection.MetodoDatatabletostringsql("almacen.listarTemperatura", null, 2);
        }

        public string listarTributos()
        {
            return _servicesConnection.MetodoDatatabletostringsql("almacen.sp_listarTributos", null, 2);
        }
    }
}
