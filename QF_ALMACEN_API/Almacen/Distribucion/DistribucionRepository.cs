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

        public async Task<IEnumerable<DistribucionStock>> DistribucionObtenerStockAsync(string descripcion_producto ,int idsucursal,int idlaboratorio,int idalmacensucursal, string idtipoproducto, string filtro_stock)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "[almacen].[sp_DistribucionObtenerStock]";
                var parameters = new { descripcion_producto,idsucursal,idlaboratorio,idalmacensucursal, idtipoproducto, filtro_stock };
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
            var transportes = (await multi.ReadAsync<TransporteEmpresa>()).ToList();
            var vehiculos = (await multi.ReadAsync<TransporteVehiculo>()).ToList();
            var almacenes = (await multi.ReadAsync<AlmacenSucursal>()).ToList();
            var empresas = (await multi.ReadAsync<Empresa>()).ToList();
            var tipoproductos = (await multi.ReadAsync<TipoProductos>()).ToList();

            return new AuditoriaGuiaFiltros
            {
                estadosguia = estados,
                tiposguia = tipos,
                transporte_empresas=transportes,
                transporte_vehiculo=vehiculos,
                almacen_sucursal=almacenes,
                empresas= empresas,
                tipoproductos= tipoproductos
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

        public async Task<IEnumerable<GuiaAuditoriaDetalle>> DistribucionAuditoriaDetalleAsync(string nro_documento, int idsucursal_origen)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "[almacen].[sp_DistribucionAuditoriaDetalle]";
                var parameters = new { nro_documento , idsucursal_origen };
                return await connection.QueryAsync<GuiaAuditoriaDetalle>(query, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<DistribucionGuiaDto> DistribucionBuscarGuiaAsync(string nroDocumento, int idSucursalOrigen)
        {
            using var connection = new SqlConnection(_connectionString);

            var parameters = new DynamicParameters();
            parameters.Add("@nro_documento", nroDocumento, DbType.String);
            parameters.Add("@idsucursal_origen", idSucursalOrigen, DbType.Int32);

            using var multi = await connection.QueryMultipleAsync(
                "[almacen].[sp_DistribucionBuscarGuia]",
                param: parameters,
                commandType: CommandType.StoredProcedure
            );

            var cabecera = (await multi.ReadAsync<EntradaDistribucionCabeceraDto>()).ToList();
            var detalle = (await multi.ReadAsync<EntradaDistribucionDetalleDto>()).ToList();

            return new DistribucionGuiaDto
            {
                Cabecera = cabecera.FirstOrDefault(),
                Detalle = detalle
            };
        }

        public async Task<string> DistribucionEditarGuiaAsync(string distribucionguia)
        {
            try
            {
                //var json_distribucion = JsonConvert.SerializeObject(distribucionguia);
                using (var connection = new SqlConnection(_connectionString))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@jsonguia", distribucionguia);
                    parameters.Add("@respuesta", dbType: DbType.String, size: 100, direction: ParameterDirection.Output);

                    var query = "[almacen].[sp_DistribucionEditarGuia]";

                    await connection.ExecuteAsync(query, parameters, commandType: CommandType.StoredProcedure);

                    var respuesta = parameters.Get<string>("@respuesta");

                    if (string.IsNullOrEmpty(respuesta))
                    {
                        return "ERROR: NO SE RECIBIÓ RESPUESTA DEL PROCEDIMIENTO.";
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
    }
}
