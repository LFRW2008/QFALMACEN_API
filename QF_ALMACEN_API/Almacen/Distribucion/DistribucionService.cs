using Dapper;
using Microsoft.Data.SqlClient;
using QF_ALMACEN_API.Almacen.Distribucion.Models;
using System.Data;
using System.Diagnostics.Metrics;

namespace QF_ALMACEN_API.Almacen.Distribucion
{
    public class DistribucionService
    {
        private readonly DistribucionRepository _distribucionRepository;

        public DistribucionService(DistribucionRepository distribucionRepository)
        {
            _distribucionRepository = distribucionRepository;
        }

        public async Task<IEnumerable<DistribucionStock>> DistribucionObtenerStockAsync(string descripcion_producto, int idsucursal, int idlaboratorio, int idalmacensucursal)
        {
            return await _distribucionRepository.DistribucionObtenerStockAsync(descripcion_producto, idsucursal, idlaboratorio, idalmacensucursal);
        }

        public async Task<object> DistribucionCorrelativosGuiaAsync(int idsucursal)
        {
            return await _distribucionRepository.DistribucionCorrelativosGuiaAsync(idsucursal);
        }

        public async Task<IEnumerable<VentasProducto>> VentasUltimosMesesAsync(string idproductos, string idsucursales, int meses)
        {
            return await _distribucionRepository.VentasUltimosMesesAsync(idproductos, idsucursales, meses);
        }

        public async Task<IEnumerable<DistribucionStockActualTransito>> DistribucionObtenerStockActualYTransitoAsync(string productos, string sucursales)
        {
            return await _distribucionRepository.DistribucionObtenerStockActualYTransitoAsync(productos, sucursales);
        }

        public async Task<IEnumerable<DistribucionLotesSalidaFEFO>> DistribucionAsignarLotesFEFOAsync(List<DistribucionLotesEntradaFEFO> distribucionLotesEntradaFEFO)
        {
            return await _distribucionRepository.DistribucionAsignarLotesFEFOAsync(distribucionLotesEntradaFEFO);
        }

        public async Task<string> DistribucionGenerarGuiasAsync(List<DistribucionFEFOAgregar> distribucion)
        {
            return await _distribucionRepository.DistribucionGenerarGuiasAsync(distribucion);
        }
    }
}
