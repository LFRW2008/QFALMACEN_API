using QF_ALMACEN_API.General.Helpers;

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
    }
}
