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

        public string listarPrincipioActivo()
        {
            return productsRepository.listarPrincipioActivo();
        }

        public string listarAccionFarmacologica()
        {
            return productsRepository.listarAccionFarmacologica();
        }

        public string insertarEditarProducto(string jsonProducto)
        {
            return productsRepository.insertarEditarProducto(jsonProducto);
        }

        public string listarProducto(int idproducto)
        {
            return productsRepository.listarProducto(idproducto);
        }

        public string InsertarEditar_PrincipioActivo(string jsonPrincipioActivo)
        {
            return productsRepository.InsertarEditar_PrincipioActivo(jsonPrincipioActivo);
        }

        public string InsertarEditarAccionFarma(string jsonAccionFarma)
        {
            return productsRepository.InsertarEditarAccionFarma(jsonAccionFarma);
        }

        public string insertarEditarRegistroSanitario(string jsonRegSanitario)
        {
            return productsRepository.insertarEditarRegistroSanitario(jsonRegSanitario);
        }


        public string listarAccionFarmaXProducto(int idproducto)
        {
            return productsRepository.listarAccionFarmaXProducto(idproducto);
        }

        public string listarPrincipioActivoXProducto(int idproducto)
        {
            return productsRepository.listarPrincipioActivoXProducto(idproducto);
        }

        public string listarRegistroSanitarioXProducto(int idproducto)
        {
            return productsRepository.listarRegistroSanitarioXProducto(idproducto);
        }

        public string actualizarEstadoDTPrincipioActivo(int idproducto, int idprincipio)
        {
            return productsRepository.actualizarEstadoDTPrincipioActivo(idproducto,idprincipio);
        }

        public string actualizarEstadoDTAccionFarma(int idproducto, int idaccionfarma)
        {
            return productsRepository.actualizarEstadoDTAccionFarma(idproducto, idaccionfarma);
        }
        //LISTADO TOTAL DE PRODUCTOS PARA EDITAR Y SELECCIONAR
        public string listarProductos(string codigo)
        {
            return productsRepository.listarProductos(codigo);
        }

        public string obtenerProducto(string codigoProducto)
        {
            return productsRepository.obtenerProducto(codigoProducto);
        }

    }
}
