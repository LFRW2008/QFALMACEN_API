using Dapper;
using Microsoft.Data.SqlClient;
using QF_ALMACEN_API.Almacen.Distribucion.Models;
using System.Data;

namespace QF_ALMACEN_API.Almacen.Distribucion
{
    public class DistribucionRepository
    {
        private readonly string? _connectionString;
        private readonly string? _sigeConnection;
        public DistribucionRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SislabConnection");
            _sigeConnection = configuration.GetConnectionString("SigeConnection");
        }

        public async Task<IEnumerable<DistribucionStock>> DistribucionObtenerStockAsync(string descripcion_producto ,int idsucursal,int idlaboratorio,int idalmacensucursal)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "[almacen].[sp_DistribucionObtenerStock]";
                var parameters = new { descripcion_producto,idsucursal,idlaboratorio,idalmacensucursal };
                return await connection.QueryAsync<DistribucionStock>(query, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<object> ObtenerCorrelativoGuiaAsync(int idsucursal)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "[almacen].[sp_ObtenerCorrelativoGuia]";
                var parameters = new {idsucursal};
                return await connection.QueryAsync<object>(query, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<VentasProducto>> VentasUltimosMesesAsync(string descripcion_producto, int idsucursal, int idlaboratorio, int idalmacensucursal)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "[qfpharma].[sp_VentasUltimosMeses]";
                var parameters = new { descripcion_producto, idsucursal, idlaboratorio, idalmacensucursal };
                return await connection.QueryAsync<VentasProducto>(query, parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
