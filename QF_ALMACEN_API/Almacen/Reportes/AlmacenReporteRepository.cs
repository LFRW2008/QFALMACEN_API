using Dapper;
using Microsoft.Data.SqlClient;
using QF_ALMACEN_API.Almacen.Reportes.Modelo;
using System.Data;

namespace QF_ALMACEN_API.Almacen.Reportes
{
    public class AlmacenReporteRepository
    {
        private readonly string _connectionString;

        public AlmacenReporteRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("SislabConnection");
        }

        // --- REPORTE PRINCIPAL ---
        public async Task<List<AlmacenReporteDTO>> ObtenerReporte(
            DateTime fechaInicio,
            DateTime fechaFin,
            int? idsucursal,
            string? movimiento,
            int idempresa)
        {
            using var connection = new SqlConnection(_connectionString);

            var p = new DynamicParameters();
            p.Add("@fechaInicio", fechaInicio);
            p.Add("@fechaFin", fechaFin);
            p.Add("@idsucursal", idsucursal);
            p.Add("@movimiento", movimiento);
            p.Add("@idempresa", idempresa);

            var datos = await connection.QueryAsync<AlmacenReporteDTO>(
                "almacen.sp_reporte_ajustes_manuales",
                p,
                commandType: CommandType.StoredProcedure);

            return datos.ToList();
        }

        // --- LISTAR EMPRESAS ---
        public async Task<List<EmpresaDTO>> ListarEmpresas()
        {
            using var cn = new SqlConnection(_connectionString);

            var data = await cn.QueryAsync<EmpresaDTO>(
                "principal.sp_ListarEmpresas",
                commandType: CommandType.StoredProcedure
            );

            return data.ToList();
        }

        // --- LISTAR SUCURSALES ---
        public async Task<List<SucursalDTO>> ListarSucursales()
        {
            using var cn = new SqlConnection(_connectionString);

            var data = await cn.QueryAsync<SucursalDTO>(
                "principal.sp_ListarSucursales",
                commandType: CommandType.StoredProcedure
            );

            return data.ToList();
        }
    }
}
