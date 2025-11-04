

namespace Info360_EFSI.Models;
using Newtonsoft.Json;

public class Usuario{

    [JsonProperty("idUsuario")]

    public int  idUsuario { get; private set; }

    [JsonProperty("nombre")]

    public string nombre { get; private set; }

    [JsonProperty("apellido")]
    public string apellido { get; private set; }

    [JsonProperty("fotoTituloUni")]
    public string fotoTituloUni { get; private set; }

    [JsonProperty("carrera")]
    public string carrera { get; private set; }

   [JsonProperty("gmail")]

    public int  gmail { get; private set; }

    [JsonProperty("contrasenia")]

    public string contrasenia { get; private set; }

    [JsonProperty("username")]
    public string username { get; private set; }

    [JsonProperty("idFacultad")]
    public string idFacultad { get; private set; }

    [JsonProperty("rol")]
    public string rol { get; private set; }

        public Usuario(int idUsuario, string nombre, string apellido, string fotoTituloUni, string carrera, int gmail, string contrasenia, string username, string rol)
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
    }
}
