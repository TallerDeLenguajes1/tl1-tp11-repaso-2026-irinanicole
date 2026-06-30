using System.Text.Json.Serialization;
/*
Investigar y aprender bien clases de LINQ:
- lista.Where().ToList() // arma una lista con 'objetos' seleccionados
- lista.Select().ToList() // arma una lista con 'atributos' selccionados
- lista.Find(); => devuelve un objeto de la lista (?
- lista.Count(); => devuelve una cantidad entera
*/
public class Producto
{
    public int Id { get ; set; }
    public string Nombre { get; set; }
    public double Precio { get; set; }
    public int Stock { get; set; }
    public string Categoria { get; set; }

    // CAMPOS AGREGADOS
    public double ValorTotalStock { get; set; }
    public bool NecesitaRepo { get; set; }

    public double CalcularValorTotalStock()
    {
        return Precio*Stock;
    }

    public bool NecesitaReposicion()
    {
        if (Stock < 3)
        {
            return true;
        }
        return false;
    }

}
