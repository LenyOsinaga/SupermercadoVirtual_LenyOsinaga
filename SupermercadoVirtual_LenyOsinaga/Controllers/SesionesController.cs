using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupermercadoVirtual_LenyOsinaga.Herramientas;
using SupermercadoVirtual_LenyOsinaga.Models;
//using SupermercadoVirtual_LenyOsinaga.ParaView;

namespace SupermercadoVirtual_LenyOsinaga.Controllers
{
    public class SesionesController : Controller
    {
        //[Route("Principal")]
        public IActionResult Index()
        {
            HttpContext.Session.SetString("usuario", "admin"); // llave - valor
            if (HttpContext.Session.GetInt32("edad") == null)
                HttpContext.Session.SetInt32("edad", new Random().Next());

            Producto producto = new Producto
            {
                id = 1,
                nombre = "Laptop",
                precio = 1500.00,
                imagen = "laptop.jpg"
            };
            // {"Id":"p01","Nombre":"Laptop","Precio":1500.00,"Cantidad":10,"Foto":"laptop.jpg"}
            ConversorJson.SetObjetoAjson(HttpContext.Session, "prod", producto);
            List<Producto> productos = new List<Producto>
            {
                new Producto { id=1, nombre="Laptop", precio=1500.00, imagen="laptop.jpg"},
                new Producto { id=2, nombre="Mouse", precio=20.00, imagen ="mouse.jpg"},
                //new Producto { Id="p03", Nombre="netbook", Precio=900.00, Cantidad=100 , Foto ="netbook.jpg"}
            };
            ConversorJson.SetObjetoAjson(HttpContext.Session, "prods", productos);
            return View();
        }
        [Route("index")]
        [Route("./")]
        [Route("~/")]
        public IActionResult Productos()
        {
            ProductoModel productoModel = new ProductoModel();
            ViewBag.Productos = productoModel.getTodo();
            return View();
            
        }
    }
}
