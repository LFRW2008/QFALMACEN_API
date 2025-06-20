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
    }
}
