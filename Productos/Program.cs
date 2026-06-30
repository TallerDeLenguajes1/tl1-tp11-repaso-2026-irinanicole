using System.Text.Json;

// 1. Leer el archivo productos1.json
var rutaArchivoJson = Path.Combine(Directory.GetCurrentDirectory(), "productos1.json");

if (File.Exists(rutaArchivoJson))
{
    // 2. Deserializar el contenido a una lista.
    var acceso = new AccesoDatos(); 
    // List<Producto> listaProductos = acceso.LeerJson(rutaArchivoJson);
    List<Producto> listaProductos = acceso.LeerJson("productos1.json");
    // Console.WriteLine(listaProductos.Count());
    
    // 3. Modificar los datos: 
    // List<Producto> listaProductosModificada = new List<Producto>();
    foreach (var item in listaProductos)
    {
        // (a) Calcular el ValorTotalStock de cada producto (Precio x Stock)
        item.ValorTotalStock = item.CalcularValorTotalStock();

        // (b) Agregar una propiedad booleana NecesitaRepo que sea true si el stock es menor a 3
        item.NecesitaRepo = item.NecesitaReposicion();
    }
    
    // 4. Filtrar: Generar una nueva lista que contenga únicamente el Nombre, ValorTotalStock y NecesitaRepo. 
    var listaReportes = listaProductos.Select( rep => new ReporteProducto
    {
        Nombre = rep.Nombre,
        ValorTotalStock = rep.ValorTotalStock,
        NecesitaRepo = rep.NecesitaRepo
    }).ToList();
    // Console.WriteLine(listaReportes.Count());
    
    // 5. Serializar este nuevo resultado.     
    // 6. Grabar el resultado en un nuevo archivo llamado Reporte.json
    acceso.GuardarJson("Reporte.json", listaReportes);

    // Compruebo que esté todo en orden
    var nuevoArchivo = Path.Combine(Directory.GetCurrentDirectory(), "Reporte.json");
    var lista = acceso.LeerJson(nuevoArchivo);
}