namespace SupermercadoVirtual_LenyOsinaga.Models
{
    public class ProductoModel
    {
        private List<SupermercadoVirtual_LenyOsinaga.Models.Producto> productos;
        public ProductoModel()
        {
            productos = new List<SupermercadoVirtual_LenyOsinaga.Models.Producto>()
            {
                new SupermercadoVirtual_LenyOsinaga.Models.Producto {id = 1, nombre = "Atún VanCamps", precio=12.00, imagen="atun.jpg"  },
                new SupermercadoVirtual_LenyOsinaga.Models.Producto {id = 2, nombre = "Queso Menonita", precio=45.00, imagen="queso.jpeg"  }
            };
        }
        public List<SupermercadoVirtual_LenyOsinaga.Models.Producto> getTodo()
        {
            return productos;
        }
        public SupermercadoVirtual_LenyOsinaga.Models.Producto getById(int id)
        {
            //return productos.FirstOrDefault(p => p.id == id);
            //return productos.Find(p => p.id == id);
            //return productos.SingleOrDefault(p => p.id == id );
            return productos.Single(p => p.id == id);
        }
    }
}
