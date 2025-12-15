using QF_ALMACEN_API.Almacen.Reportes.Modelo;

namespace QF_ALMACEN_API.Almacen.Reportes
{
    public class AlmacenReporteService
    {
        private readonly AlmacenReporteRepository repo;

        public AlmacenReporteService(AlmacenReporteRepository repo)
        {
            this.repo = repo;
        }

        public Task<List<AlmacenReporteDTO>> Reporte(
            DateTime fechaInicio,
            DateTime fechaFin,
            int? idsucursal,
            string? movimiento,
            int idempresa)
        {
            return repo.ObtenerReporte(fechaInicio, fechaFin, idsucursal, movimiento, idempresa);
        }

        public Task<List<EmpresaDTO>> ListarEmpresas()
        {
            return repo.ListarEmpresas();
        }

        public Task<List<SucursalDTO>> ListarSucursales()
        {
            return repo.ListarSucursales();
        }
    }
}
