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

    }
}
