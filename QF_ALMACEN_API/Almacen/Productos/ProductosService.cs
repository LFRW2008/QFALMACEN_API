namespace QF_ALMACEN_API.Almacen.Productos
{
    public class ProductosService
    {

        public readonly ProductosRepository productsRepository;

        public ProductosService(ProductosRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        public string listartipoProductos()
        {
            return productsRepository.listartipoProductos();
        }

        public string listarClase()
        {
            return productsRepository.listarClase();
        }

        public string listarSubClaseXClase(int idClase)
        {
            return productsRepository.listarSubClaseXClase(idClase);
        }

        public string listarUnidadMedida()
        {
            return productsRepository.listarUnidadMedida();
        }

        public string listarProductoPresentacion()
        {
            return productsRepository.listarProductoPresentacion();
        }

        public string listarLaboratorios()
        {
            return productsRepository.listarLaboratorios();
        }

        public string listar_FormaFarmaceutica()
        {
            return productsRepository.listar_FormaFarmaceutica();
        }

        public string listarTemperatura()
        {
            return productsRepository.listarTemperatura();
        }

        public string listarTributos()
        {
            return productsRepository.listarTributos();
        }
    }
}
