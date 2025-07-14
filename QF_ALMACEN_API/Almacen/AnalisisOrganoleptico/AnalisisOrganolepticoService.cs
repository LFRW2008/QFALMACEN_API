namespace QF_ALMACEN_API.Almacen.AnalisisOrganoleptico
{
    public class AnalisisOrganolepticoService
    {

        public readonly AnalisisOrganolepticoRepository analisisOrganolepticoRepository;

        public AnalisisOrganolepticoService(AnalisisOrganolepticoRepository _analisisOrganolepticoRepository)
        {

            analisisOrganolepticoRepository = _analisisOrganolepticoRepository;

        }

        public string listarFacturaSinAO()
        {
            return analisisOrganolepticoRepository.listarFacturaSinAO();
        }

        public string ObtenerCabeceraAO(int idFactura)
        {
            string resultado = analisisOrganolepticoRepository.ObtenerCabeceraAO(idFactura);
            if (string.IsNullOrEmpty(resultado))
            {
                return "No se encontraron datos para la factura especificada.";
            }
            return resultado;
        }

        public string CargarDetalleAO(int idFactura)
        {
            string resultado = analisisOrganolepticoRepository.CargarDetalleAO(idFactura);
            if (string.IsNullOrEmpty(resultado))
            {
                return "No se encontraron detalles para la factura especificada.";
            }
            return resultado;
        }


    }
}
