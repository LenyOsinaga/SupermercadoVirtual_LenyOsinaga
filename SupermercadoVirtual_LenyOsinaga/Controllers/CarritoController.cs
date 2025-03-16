using Microsoft.AspNetCore.Mvc;
using SupermercadoVirtual_LenyOsinaga.Herramientas;
using SupermercadoVirtual_LenyOsinaga.Models;

namespace SupermercadoVirtual_LenyOsinaga.Controllers
{
    public class CarritoController : Controller
    {
        public IActionResult Index()
        {
            var carrito = ConversorJson.GetObjetoDesdeJson<List<Elemento>>(HttpContext.Session, "carrito");
            ViewBag.carrito = carrito;
            ViewBag.total = carrito.Sum(elemento => elemento.producto.precio * elemento.cantidad);
            return View();
        }
        public IActionResult Agregar (int id)
        {
            ProductoModel productoModel = new ProductoModel();
            // No existe la variable de sesion carrito
            if (ConversorJson.GetObjetoDesdeJson<List<Elemento>>(HttpContext.Session, "carrito") == null)
                {
                List<Elemento> carrito = new List<Elemento>();
                carrito.Add(new Elemento { producto = productoModel.getById(id), cantidad = 1 });
                ConversorJson.SetObjetoAjson(HttpContext.Session, "carrito", carrito);
            }
            else {
                // Si existe la variable de sesion carrito
                List<Elemento> carrito = ConversorJson.GetObjetoDesdeJson<List<Elemento>>(HttpContext.Session, "carrito");
                // Crear metodo auxiliara para obtener indice del producto
                int indice = ExisteProducto(id);
                if (indice != -1)
                {
                    // Si ya existe el producto en el carrito
                    carrito[indice].cantidad++;
                }
                else
                {
                    // Si no existe el producto en el carrito
                    carrito.Add(new Elemento { producto = productoModel.getById(id), cantidad = 1 });
                }
                ConversorJson.SetObjetoAjson(HttpContext.Session, "carrito", carrito);
            }

            return RedirectToAction("Index");
        }
        [Route("Quitar/{id}")]
        public IActionResult Quitar(int id)
        {
            List<Elemento> carrito = ConversorJson.GetObjetoDesdeJson<List<Elemento>>(HttpContext.Session, "carrito");
            int indice = ExisteProducto(id);
            if (indice != -1)
            {
                if (carrito[indice].cantidad > 1)
                {
                    carrito[indice].cantidad--;
                }
                else
                {
                    carrito.RemoveAt(indice);
                }
            }
            // carrito.RemoveAt(indice);
            ConversorJson.SetObjetoAjson(HttpContext.Session, "carrito", carrito);
            return RedirectToAction("Index");
        }
        [NonAction]
        private int ExisteProducto(int id)
        {
            List<Elemento> carrito = ConversorJson.GetObjetoDesdeJson<List<Elemento>>(HttpContext.Session, "carrito");
            for (int i=0; i < carrito.Count;i++)
            {
               //if (carrito[i].producto.id.Equals(id))
               if (carrito[i].producto.id == id)
                    return i;
            }
            return -1;
        }
        public IActionResult FinCompra(double l_total)
        {
            List<Elemento> carrito = ConversorJson.GetObjetoDesdeJson<List<Elemento>>(HttpContext.Session, "carrito");
            carrito.Clear();
            ConversorJson.SetObjetoAjson(HttpContext.Session, "carrito", carrito);
            ViewBag.total = l_total;
            return View();
            
        }
    }
}
