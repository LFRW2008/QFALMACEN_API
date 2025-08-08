using Dapper;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
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

        public async Task<IEnumerable<DistribucionStock>> DistribucionObtenerStockAsync(string descripcion_producto, int idsucursal, int idlaboratorio, int idalmacensucursal, string idtipoproducto, string filtro_stock)
        {
            return await _distribucionRepository.DistribucionObtenerStockAsync(descripcion_producto, idsucursal, idlaboratorio, idalmacensucursal, idtipoproducto, filtro_stock);
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

        public async Task<AuditoriaGuiaFiltros> DistribucionFiltrosAuditoriaAsync()
        {
            return await _distribucionRepository.DistribucionFiltrosAuditoriaAsync();
        }

        public async Task<IEnumerable<GuiaAuditoriaCabecera>> DistribucionAuditoriaCabeceraAsync(int idsucursal_origen, int idsucursal_destino, int idtipoguia, int idestado, string fecha_inicio, string fecha_fin, string nro_documento)
        {
            return await _distribucionRepository.DistribucionAuditoriaCabeceraAsync(idsucursal_origen, idsucursal_destino, idtipoguia, idestado, fecha_inicio,fecha_fin, nro_documento);
        }

        public async Task<IEnumerable<GuiaAuditoriaDetalle>> DistribucionAuditoriaDetalleAsync(string nro_documento, int idsucursal_origen)
        {
            return await _distribucionRepository.DistribucionAuditoriaDetalleAsync(nro_documento, idsucursal_origen);
        }

        public async Task<DistribucionGuiaDto> DistribucionBuscarGuiaAsync(string nroDocumento, int idSucursalOrigen)
        {
            return await _distribucionRepository.DistribucionBuscarGuiaAsync(nroDocumento, idSucursalOrigen);
        }

        public async Task<string> DistribucionEditarGuiaAsync(string distribucionguia)
        {
            return await _distribucionRepository.DistribucionEditarGuiaAsync(distribucionguia);
        }

        public async Task<IEnumerable<VentasProducto>> DistribucionConsumoMateriaPrimaUltimosMesesAsync(string idproductos, string idsucursales, int meses)
        {
            return await _distribucionRepository.DistribucionConsumoMateriaPrimaUltimosMesesAsync(idproductos, idsucursales, meses);
        }

        public async Task<IEnumerable<DistribucionProductoLote>> DistribucionObtenerProductoLotesAsync(int idproducto, int idsucursal)
        {
            return await _distribucionRepository.DistribucionObtenerProductoLotesAsync(idproducto, idsucursal);
        }

        public async Task<string> ProductoFraccionamientoRegistrarAsync(string fraccionamiento)
        {
            return await _distribucionRepository.ProductoFraccionamientoRegistrarAsync(fraccionamiento);
        }

        public async Task<IEnumerable<ProductoFraccionamiento>> ProductoFraccionamientoBuscarAsync(int idproducto)
        {
            return await _distribucionRepository.ProductoFraccionamientoBuscarAsync(idproducto);
        }
    }
}
