using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace SupermercadoVirtual_LenyOsinaga.Herramientas
{
    public static class ConversorJson
    {
        // Objetos C# -> JSON

        public static void SetObjetoAjson(this ISession sesion, string llave, object p)
        {
            sesion.SetString(llave, JsonConvert.SerializeObject(p));
        }

        // JSON -> Objetos C#

        public static T GetObjetoDesdeJson<T>(this ISession sesion, string llave)
        {
            var valor = sesion.GetString(llave);
            return valor == null ? default(T) : JsonConvert.DeserializeObject<T>(valor);
        } 
        
    }
}
