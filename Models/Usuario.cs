namespace Info360_EFSI.Models;
using Newtonsoft.Json;

public class Usuario
{
    [JsonProperty("idUsuario")]
    public int idUsuario { get; set; }

    [JsonProperty("nombre")]
    public string nombre { get; set; }

    [JsonProperty("apellido")]
    public string apellido { get; set; }

    [JsonProperty("fotoTituloUni")]
    public string fotoTituloUni { get; set; }

    [JsonProperty("carrera")]
    public string carrera { get; set; }

    [JsonProperty("gmail")]
    public string gmail { get; set; }

    [JsonProperty("contrasenia")]
    public string contrasenia { get; set; }

    [JsonProperty("username")]
    public string username { get; set; }

    [JsonProperty("idFacultad")]
    public int idFacultad { get; set; }

    [JsonProperty("rol")]
    public bool rol { get; set; }

    [JsonProperty("fotoPerfil")]
    public string? fotoPerfil { get; set; }

    public Usuario() { }

    public Usuario(int idUsuario, string nombre, string apellido, string fotoTituloUni, string carrera, string gmail, string contrasenia, string username, bool rol, int idFacultad, string? fotoPerfil)
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
        this.idFacultad = idFacultad;
        this.fotoPerfil = fotoPerfil;
    }
}
