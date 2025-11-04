
namespace Info360_EFSI.Models;
using Newtonsoft.Json;



public class Carrera{
    
    [JsonProperty("idCarrera")]/*Agregar string foto*/

    public int  idCarrera { get; private set; }

    [JsonProperty("idFacultad")]

    public int idFacultad { get; private set; }

    [JsonProperty("cantMaterias")]
    public int cantMaterias { get; private set; }

    [JsonProperty("duracion")]
    public int duracion { get; private set; }

    [JsonProperty("nombre")]
    public string nombre { get; private set; }

    [JsonProperty("descripcion")]
    public string descripcion {get; private set;}

    public Carrera(int  idCarrera, int cantMaterias , int duracion , string nombre , string descripcion)
    {
        this.idCarrera = idCarrera;
        this.cantMaterias = cantMaterias;
        this.duracion = duracion;
        this.nombre = nombre;
        this.descripcion = descripcion;
    }
}