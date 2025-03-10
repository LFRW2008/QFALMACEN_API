using Microsoft.AspNetCore.Mvc;
using QF_ALMACEN_API.Almacen.Service;

namespace QF_ALMACEN_API.Almacen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlmacenController : ControllerBase
    {

        private readonly AlmacenService _AlmacenService;

        public AlmacenController(AlmacenService almacenService)
        {
            _AlmacenService = almacenService;
        }

        //metodos finales

        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok(new { message = "API funcionando correctamente" });
        }


    }
}
