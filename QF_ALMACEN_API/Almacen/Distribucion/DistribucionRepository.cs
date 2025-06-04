using Dapper;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
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

        public async Task<object> DistribucionCorrelativosGuiaAsync(int idsucursal)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "[almacen].[sp_DistribucionCorrelativosGuia]";
                var parameters = new {idsucursal};
                return await connection.QueryAsync<object>(query, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<VentasProducto>> VentasUltimosMesesAsync(string idproductos, string idsucursales, int meses)
        {
            using (var connection = new SqlConnection(_sigeConnection))
            {
                var query = "[qfpharma].[sp_DistribucionVentasUltimosMeses]";
                var parameters = new { idproductos, idsucursales, meses};
                return await connection.QueryAsync<VentasProducto>(query, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<DistribucionStockActualTransito>> DistribucionObtenerStockActualYTransitoAsync(string productos, string sucursales)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "[almacen].[sp_DistribucionObtenerStockActualYTransito]";
                var parameters = new { productos, sucursales};
                return await connection.QueryAsync<DistribucionStockActualTransito>(query, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<DistribucionLotesSalidaFEFO>> DistribucionAsignarLotesFEFOAsync(List<DistribucionLotesEntradaFEFO> distribucionLotesEntradaFEFO)
        {
            var json = JsonConvert.SerializeObject(distribucionLotesEntradaFEFO);
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "[almacen].[sp_DistribucionAsignarLotesFEFO]";
                var parameters = new { @jsonRequests=json };
                return await connection.QueryAsync<DistribucionLotesSalidaFEFO>(query, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<string> DistribucionGenerarGuiasAsync(List<DistribucionFEFOAgregar> distribucion)
        {
            try
            {
                var json_distribucion = JsonConvert.SerializeObject(distribucion);        
                using (var connection = new SqlConnection(_connectionString))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@json_distribucion", json_distribucion);
                    parameters.Add("@respuesta", dbType: DbType.String, size: 100, direction: ParameterDirection.Output);

                    var query = "almacen.sp_DistribucionGenerarGuias";

                    await connection.ExecuteAsync(query, parameters, commandType: CommandType.StoredProcedure);

                    var respuesta = parameters.Get<string>("@respuesta");

                    if (string.IsNullOrEmpty(respuesta))
                    {
                        return "ERROR: No se recibió respuesta del procedimiento.";
                    }

                    return respuesta;
                }
            }
            catch (SqlException ex)
            {
                return $"ERROR SQL: {ex.Message}";
            }
            catch (Exception ex)
            {
                return $"ERROR GENERAL: {ex.Message}";
            }
        }

        public async Task<AuditoriaGuiaFiltros> DistribucionFiltrosAuditoriaAsync()
        {
            using var connection = new SqlConnection(_connectionString);

            using var multi = await connection.QueryMultipleAsync(
                "[almacen].[sp_DistribucionFiltrosAuditoria]", commandType: CommandType.StoredProcedure);

            var estados = (await multi.ReadAsync<EstadoGuia>()).ToList();
            var tipos = (await multi.ReadAsync<TipoGuia>()).ToList();

            return new AuditoriaGuiaFiltros
            {
                estadosguia = estados,
                tiposguia = tipos
            };
        }

        public async Task<IEnumerable<GuiaAuditoriaCabecera>> DistribucionAuditoriaCabeceraAsync(int idsucursal_origen, int idsucursal_destino, int idtipoguia, int idestado, string fecha_inicio, string fecha_fin, string nro_documento)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "[almacen].[sp_DistribucionAuditoriaCabecera]";
                var parameters = new { idsucursal_origen, idsucursal_destino, idtipoguia, idestado, fecha_inicio, fecha_fin, nro_documento };
                return await connection.QueryAsync<GuiaAuditoriaCabecera>(query, parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
