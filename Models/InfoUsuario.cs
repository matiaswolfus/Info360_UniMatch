

namespace Info360_EFSI.Models;
using Newtonsoft.Json;

public class InfoUsuario{

    [JsonProperty("idUsuario")]

    public int  idUsuario { get; private set; }

    [JsonProperty("nombre")]

    public string nombre { get; private set; }

    [JsonProperty("apellido")]
    public string apellido { get; private set; }


    [JsonProperty("carrera")]
    public string carrera { get; private set; }

    [JsonProperty("username")]
    public string username { get; private set; }

    [JsonProperty("idFacultad")]
    public int idFacultad { get; private set; }
    
    [JsonProperty("idCarrera")]
    public int idCarrera { get; private set; }
    
    [JsonProperty("Facultad")]
    public string Facultad { get; private set; }

    [JsonProperty("rol")]
    public bool rol { get; private set; }

        public InfoUsuario(int idUsuario, string nombre, string apellido,  string carrera, string username, bool rol, int idFacultad, int idCarrera, string Facultad)
    {
        this.idUsuario = idUsuario;
        this.nombre = nombre;
        this.apellido = apellido;
        this.carrera = carrera;
        this.username = username;
        this.rol = rol;
        this.idCarrera = idCarrera;
        this.idFacultad = idFacultad;
        this.Facultad = Facultad;
    }
}
