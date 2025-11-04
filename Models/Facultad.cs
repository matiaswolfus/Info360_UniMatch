
using Newtonsoft.Json;
namespace Info360_EFSI.Models;

public class Facultad{
    
    [JsonProperty("idFacultad")]

    public int  idFacultad { get; private set; }

    [JsonProperty("nombre")]

    public string nombre { get; private set; }

    [JsonProperty("direccion")]
    public string direccion { get; private set; }

    [JsonProperty("contacto")]
    public string contacto { get; private set; }

    [JsonProperty("nombre")]
    public int precio { get; private set; }

    [JsonProperty("fotoFacultad")]
    public string fotoFacultad {get; private set;}

        [JsonProperty("tipoGestion")]
    public bool tipoGestion { get; private set; }

    [JsonProperty("cantCarreras")]
    public int cantCarreras {get; private set;}

    public Facultad(int idFacultad, string nombre, string direccion, string contacto, int precio, string fotoFacultad, bool tipoGestion, int cantCarreras)
    {
        this.idFacultad = idFacultad;
        this.nombre = nombre;
        this.direccion = direccion;
        this.contacto = contacto;
        this.precio = precio;
        this.fotoFacultad = fotoFacultad;
        this.tipoGestion = tipoGestion;
        this.cantCarreras = cantCarreras;
    }
}