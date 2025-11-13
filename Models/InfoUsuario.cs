

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

        public Usuario(int idUsuario, string nombre, string apellido, string fotoTituloUni, string carrera, int gmail, string contrasenia, string username, bool rol, int idFacultad, int idCarrera, string Facultad)
    {
        this.idUsuario = idUsuario;
        this.nombre = nombre;
        this.apellido = apellido;
        this.fotoTituloUni = fotoTituloUni;
        this.carrera = carrera;
        this.gmail = gmail;
        this.contrasenia = contrasenia;
        this.username = username;
        this.rol = rol;
        this.idCarerra = idCarerra;
        this.idFacultad = idFacultad;
        this.Facultad = Facultad;
    }
}
