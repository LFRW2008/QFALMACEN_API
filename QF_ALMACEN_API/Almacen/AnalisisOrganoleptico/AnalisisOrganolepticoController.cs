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
        [HttpGet("ObtenerCabeceraAO")]
        public string ObtenerCabeceraAO(int idFactura)
        {
            return analisisOrganolepticoService.ObtenerCabeceraAO(idFactura);
        }

        [HttpGet("CargarDetalleAO")]
        public string CargarDetalleAO(int idFactura)
        {
            return analisisOrganolepticoService.CargarDetalleAO(idFactura);
        }

        [HttpGet("CargarDetalleAO_X_AO")]
        public string CargarDetalleAO_X_AO(int idAO)
        {
            return analisisOrganolepticoService.CargarDetalleAO_X_AO(idAO);
        }

        [HttpGet("listar_resultadoAO")]
        public string listar_resultadoAO()
        {
            return analisisOrganolepticoService.listar_resultadoAO();
        }

        [HttpGet("listarAO")]
        public string listarAO()
        {
            return analisisOrganolepticoService.listarAO();
        }

        [HttpPost("InsertUpdateAO")]
        public string InsertUpdateAO([FromBody] string jsonAO)
        {
            return analisisOrganolepticoService.InsertUpdateAO(jsonAO);
        }

        [HttpGet("ObtenerDetalleImpresion")]
        public string ObtenerDetalleImpresion(int idanalisisOrganoleptico)
        {
            return analisisOrganolepticoService.ObtenerDetalleImpresion(idanalisisOrganoleptico);
        }

    }
}
