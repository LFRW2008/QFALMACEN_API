using Microsoft.AspNetCore.Mvc;

namespace QF_ALMACEN_API.Almacen.AnalisisOrganoleptico
{
    [Route("api/[controller]")]
    public class AnalisisOrganolepticoController : ControllerBase
    {
        public readonly AnalisisOrganolepticoService analisisOrganolepticoService;
        public AnalisisOrganolepticoController(AnalisisOrganolepticoService _analisisOrganolepticoService)
        {
            analisisOrganolepticoService = _analisisOrganolepticoService;
        }

        [HttpGet("listarFacturaSinAO")]
        public string listarFacturaSinAO()
        {
           return analisisOrganolepticoService.listarFacturaSinAO();
        }

    }
}
