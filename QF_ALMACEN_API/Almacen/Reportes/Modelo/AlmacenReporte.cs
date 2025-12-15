namespace QF_ALMACEN_API.Almacen.Reportes.Modelo
{
    public class AlmacenReporteDTO
    {
        public int idinventario { get; set; }
        public string producto { get; set; }
        public string lote { get; set; }
        public DateTime fecha_movimiento { get; set; }
        public string sucursal { get; set; }
        public string usuario { get; set; }
        public int cantidad { get; set; }
        public string movimiento { get; set; }
        public double stock_anterior { get; set; }
        public double stock_actual { get; set; }
        public string detalle { get; set; }
        public int idempresa { get; set; }
        public string empresa { get; set; }
    }

    public class EmpresaDTO
    {
        public int idempresa { get; set; }
        public string nombre { get; set; }
    }

    public class SucursalDTO
    {
        public int idsucursal { get; set; }
        public string nombreSucursal { get; set; }
    }

    public class MovimientoDTO
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
    }


}
