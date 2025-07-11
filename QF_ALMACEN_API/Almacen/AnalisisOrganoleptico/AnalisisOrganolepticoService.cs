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

    }
}
