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

        public string listarPrincipioActivo()
        {
            return _servicesConnection.MetodoDatatabletostringsql("Almacen.sp_listarPrincipioActivo", null, 2);
        }

        public string listarAccionFarmacologica()
        {
            return _servicesConnection.MetodoDatatabletostringsql("Almacen.sp_listarAccionFarmacologica", null, 2);
        }

        public string insertarEditarProducto(string jsonProducto)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@jsonProducto", jsonProducto);
            return _servicesConnection.MetodoRespuestasql("Productos.sp_Insertar_Editar_Productos_MERGE", parameters, 50, 2);
        }

        public string listarProducto(int idproducto)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@idproducto", idproducto);
            return _servicesConnection.MetodoDatatabletostringsql("productos.sp_listar_productos", parameter, 2);
        }

        public string InsertarEditar_PrincipioActivo(string jsonPrincipioActivo)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@jsonPrincipioActivo", jsonPrincipioActivo);

            return _servicesConnection.MetodoRespuestasql("Productos.InsertarEditar_PrincipioActivo", parameter,50, 2);
        }

        public string InsertarEditarAccionFarma(string jsonAccionFarma)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@jsonAccionFarma", jsonAccionFarma);
            return _servicesConnection.MetodoRespuestasql("almacen.sp_InsertarEditarAccionFarma", parameter, 50, 2);
        }

        public string insertarEditarRegistroSanitario(string jsonRegSanitario)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@jsonRegSanitario", jsonRegSanitario);

            return _servicesConnection.MetodoRespuestasql("Almacen.sp_insertarEditarRegistroSanitario", parameter, 50, 2);
        }

        public string listarAccionFarmaXProducto(int idproducto)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idproducto", idproducto);
            return _servicesConnection.MetodoDatatabletostringsql("almacen.sp_listarAccionFarmaXProducto", parameters, 2);
        }

        public string listarPrincipioActivoXProducto(int idproducto)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idproducto", idproducto);
            return _servicesConnection.MetodoDatatabletostringsql("almacen.sp_listarPrincipioActivoXProducto", parameters, 2);
        }

        public string listarRegistroSanitarioXProducto(int idproducto)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idproducto", idproducto);
            return _servicesConnection.MetodoDatatabletostringsql("Almacen.sp_listarRegistroSanitarioXProducto", parameters, 2);
        }

        public string actualizarEstadoDTPrincipioActivo(int idproducto, int idprincipio)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idproducto", idproducto);
            parameters.Add("@idprincipio", idprincipio);

            return _servicesConnection.EjecutarProcedimiento("almacen.sp_actualizarEstadoDTPrincipioActivo", parameters, 2);
        }

        public string actualizarEstadoDTAccionFarma(int idproducto, int idaccionfarma)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idproducto", idproducto);
            parameters.Add("@idaccionfarma", idaccionfarma);

            return _servicesConnection.EjecutarProcedimiento("almacen.sp_actualizarEstadoDTAccionFarma", parameters, 2);
        }
        
        public string listarProductos(string codigo)
        {
            if(codigo == null)
            {
                codigo = "";
            }

            var parameter = new DynamicParameters();
            parameter.Add("@codigo", codigo);
            return _servicesConnection.MetodoDatatabletostringsql("Productos.sp_listarProductos", parameter, 2);
        }

        public string obtenerProducto(string codigoProducto)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@codigoProducto", codigoProducto);

            return _servicesConnection.MetodoDatatabletostringsql("almacen.sp_obtenerProducto", parameter, 2);

        }
    }
}
