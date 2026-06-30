using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
public class AccesoDatos
{
    public List<Producto> LeerJson(string archivoJson)
    {
        using var archivoAbierto = new FileStream(archivoJson, FileMode.Open);
        using var leer = new StreamReader(archivoAbierto, Encoding.UTF8);
        string texto = leer.ReadToEnd();
        // Console.WriteLine(texto);
        var lista = JsonSerializer.Deserialize<List<Producto>>(texto);

        return lista;
    }

    public void GuardarJson(string nombreArchivo, List<ReporteProducto> lista)
    {
        var opciones = new JsonSerializerOptions 
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };
        string textoJson = JsonSerializer.Serialize(lista, opciones);
        using var nuevoArchivoJson = new FileStream(nombreArchivo, FileMode.Create);
        using var escribir = new StreamWriter(nuevoArchivoJson, Encoding.UTF8);
        escribir.Write(textoJson);
    }
}