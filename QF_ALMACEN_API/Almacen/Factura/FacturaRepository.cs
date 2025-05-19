using Dapper;
using QF_ALMACEN_API.General.Helpers;
using System.Runtime.CompilerServices;

namespace QF_ALMACEN_API.Almacen.Factura
{
    public class FacturaRepository
    {
        readonly ServicesConnection _connectionString;

        public FacturaRepository(ServicesConnection servicesConnection, IConfiguration configuration) {

            _connectionString = servicesConnection;
        }  

        public string listaTPago()
        {
            return _connectionString.MetodoDatatabletostringsql("contabilidad.ListaTPago_V2", null, 1);
        }

        public string ListaCPago()
        {
            return _connectionString.MetodoDatatabletostringsql("contabilidad.ListaCPago_V2", null, 1);
        }

        public string listar_PreIngreso_Factura()
        {
            return _connectionString.MetodoDatatabletostringsql("Preingreso.sp_listar_PreIngreso_Factura", null, 4);
        }
        
        public string buscar_FacturaXid(int idFactura)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idFactura", idFactura);
            return _connectionString.MetodoDatatabletostringsql("PreIngreso.sp_buscar_FacturaXid", parameters, 4);
        }

        public string buscar_Detalle_Factura(int idFactura)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idFactura", idFactura);
            return _connectionString.MetodoDatatabletostringsql("PreIngreso.sp_buscar_Detalle_Factura", parameters, 4);
        }

        public string aprobar_Factura(int idUsuario, int idFactura,  int idPreIngreso)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@usuario", idUsuario);
            parameters.Add("@idFactura", idFactura);
            parameters.Add("@idPreIngreso", idPreIngreso);
            return _connectionString.MetodoRespuestasql("PreIngreso.sp_aprobar_Factura", parameters, 150, 4);
        }

        public string buscar_ultima_compra_Producto(int idProducto)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idProducto", idProducto);
            return _connectionString.MetodoDatatabletostringsql("Factura.sp_buscar_ultima_compra_Producto", parameters, 4);
        }

        public string ListaPrecio_X_Producto(int idproducto)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idproducto", idproducto);
            return _connectionString.MetodoDatatabletostringsql("Factura.sp_ListaPrecio_X_Producto", parameters, 4);
        }

        public string ActualizarCostos(string jsonFactura)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@jsonFactura", jsonFactura);
            return _connectionString.MetodoRespuestasql("Factura.sp_ActualizarCostos", parameters, 150, 4);
        }

        public string ObtenerLote_AprobarFactura(int idFactura)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@idFactura", idFactura);
            return _connectionString.MetodoDatatabletostringsql("Factura.ObtenerLote_AprobarFactura", parameter, 4);
        }


        public string retirarLotes_al_AnularFactura(int idFactura, int idSucursal, int idUsuario, string userName)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@idFactura", idFactura);
            parameter.Add("@idSucursal", idSucursal);
            parameter.Add("@idUsuario", idUsuario);
            parameter.Add("@userName", userName);
            return _connectionString.MetodoRespuestasql("Factura.sp_retirarLotes_al_AnularFactura_TEST", parameter, 150, 4);
        }

        public string ingresarLotes_AprobarFactura(int idFactura, int idSucursal, int idUsuario, string userName)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@idFactura", idFactura);
            parameter.Add("@idSucursal", idSucursal);
            parameter.Add("@idUsuario", idUsuario);
            parameter.Add("@userName", userName);

            return _connectionString.MetodoRespuestasql("Factura.sp_ingresarLotes_TEST", parameter, 150, 4);
        }

    }
}
