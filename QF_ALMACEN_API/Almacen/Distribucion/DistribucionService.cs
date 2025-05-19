using Microsoft.Data.SqlClient;
using QF_ALMACEN_API.Almacen.Distribucion.Models;
using System.Data;

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
    }
}
