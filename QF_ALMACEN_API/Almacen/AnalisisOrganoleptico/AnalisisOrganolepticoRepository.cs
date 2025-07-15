using Dapper;
using QF_ALMACEN_API.General.Helpers;

namespace QF_ALMACEN_API.Almacen.AnalisisOrganoleptico
{
    public class AnalisisOrganolepticoRepository
    {

        readonly ServicesConnection _connectionString;

        public AnalisisOrganolepticoRepository(ServicesConnection servicesConnection, IConfiguration configuration)
        {

            _connectionString = servicesConnection;
        }

        public string listarFacturaSinAO()
        {
            return _connectionString.MetodoDatatabletostringsql("Preingreso.sp_listarFacturaSinAO", null, 4);
        }

        public string ObtenerCabeceraAO(int idFactura)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@idFactura", idFactura);
            return _connectionString.MetodoDatatabletostringsql("PreIngreso.sp_ObtenerCabeceraAO", parameter, 4);
        }

        public string CargarDetalleAO(int idFactura)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@idFactura", idFactura);
            return _connectionString.MetodoDatatabletostringsql("PreIngreso.sp_CargarDetalleAO", parameter, 4);
        }

        public string listar_resultadoAO()
        {
            return _connectionString.MetodoDatatabletostringsql("Preingreso.sp_listar_resultadoAO", null, 4);
        }

    }
}
