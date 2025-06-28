using Microsoft.AspNetCore.Mvc;

namespace QF_ALMACEN_API.Almacen.Productos
{
    [Route("api/[controller]")]

    public class ProductosController : Controller
    {
        ProductosService productosService;

        public ProductosController(ProductosService _productosService) {
            productosService = _productosService;
        }

        [HttpGet("listartipoProductos")]
        public string listartipoProductos()
        {
            return productosService.listartipoProductos();
        }

        [HttpGet("listarClase")]
        public string listarClase()
        {
            return productosService.listarClase();
        }
        [HttpGet("listarSubClaseXClase")]
        public string listarSubClaseXClase(int idClase)
        {
            return productosService.listarSubClaseXClase(idClase);
        }
        [HttpGet("listarUnidadMedida")]
        public string listarUnidadMedida()
        {
            return productosService.listarUnidadMedida();
        }

        [HttpGet("listarProductoPresentacion")]
        public string listarProductoPresentacion()
        {
            return productosService.listarProductoPresentacion();
        }

        [HttpGet("listarLaboratorios")]
        public string listarLaboratorios()
        {
            return productosService.listarLaboratorios();
        }

        [HttpGet("listar_FormaFarmaceutica")]
        public string listar_FormaFarmaceutica() 
        {
            return productosService.listar_FormaFarmaceutica();
        }

        [HttpGet("listarTemperatura")]
        public string listarTemperatura()
        {
            return productosService.listarTemperatura();
        }

        [HttpGet("listarTributos")]
        public string listarTributos()
        {
            return productosService.listarTributos();
        }

        [HttpGet("listarPrincipioActivo")]
        public string listarPrincipioActivo()
        {
            return productosService.listarPrincipioActivo();
        }

        [HttpGet("listarAccionFarmacologica")]
        public string listarAccionFarmacologica()
        {
            return productosService.listarAccionFarmacologica();
        }

        [HttpPost("insertarEditarProducto")]
        public string insertarEditarProducto([FromBody] string jsonProducto)
        {
            return productosService.insertarEditarProducto(jsonProducto);
        }

        [HttpGet("listarProducto")]
        public string listarProducto(int idproducto)
        {
            return productosService.listarProducto(idproducto);
        }

        [HttpPost("InsertarEditar_PrincipioActivo")]
        public string InsertarEditar_PrincipioActivo([FromBody] string jsonPrincipioActivo)
        {
            return productosService.InsertarEditar_PrincipioActivo(jsonPrincipioActivo);
        }

        [HttpPost("InsertarEditarAccionFarma")]
        public string InsertarEditarAccionFarma([FromBody] string jsonAccionFarma)
        {
            return productosService.InsertarEditarAccionFarma(jsonAccionFarma);
        }

        [HttpPost("insertarEditarRegistroSanitario")]
        public string insertarEditarRegistroSanitario([FromBody]string jsonRegSanitario)
        {
            return productosService.insertarEditarRegistroSanitario(jsonRegSanitario);
        }


        [HttpGet("listarAccionFarmaXProducto")]
        public string listarAccionFarmaXProducto(int idproducto)
        {
            return productosService.listarAccionFarmaXProducto(idproducto);
        }

        [HttpGet("listarPrincipioActivoXProducto")]
        public string listarPrincipioActivoXProducto(int idproducto)
        {
            return productosService.listarPrincipioActivoXProducto(idproducto);
        }

        [HttpGet("listarRegistroSanitarioXProducto")]
        public string listarRegistroSanitarioXProducto(int idproducto)
        {
            return productosService.listarRegistroSanitarioXProducto(idproducto);
        }

        [HttpGet("actualizarEstadoDTPrincipioActivo")]
        public string actualizarEstadoDTPrincipioActivo(int idproducto, int idprincipio)
        {
            return productosService.actualizarEstadoDTPrincipioActivo(idproducto, idprincipio);
        }

        [HttpGet("actualizarEstadoDTAccionFarma")]
        public string actualizarEstadoDTAccionFarma(int idproducto, int idaccionfarma)
        {
            return productosService.actualizarEstadoDTAccionFarma(idproducto, idaccionfarma);
        }

        [HttpGet("listarProductos")]
        public string listarProductos(string? codigo)
        {
            return productosService.listarProductos(codigo);
        }

    }
}
