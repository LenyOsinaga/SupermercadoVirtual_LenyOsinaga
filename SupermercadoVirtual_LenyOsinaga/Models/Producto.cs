namespace SupermercadoVirtual_LenyOsinaga.Models
{
    public class Producto
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public double precio { get; set; }
        public string imagen { get; set; }
    }
    public class Elemento
    {
        public Producto producto { get; set; }
        public int cantidad { get; set; }
    }

}
