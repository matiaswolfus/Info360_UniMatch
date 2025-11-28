namespace Info360_EFSI.Models;
using Newtonsoft.Json;

public class OpinionFacultad{
    [JsonProperty("idResenia")]
    public int idResenia { get; set; }

    [JsonProperty("mensaje")]
    public string mensaje { get; set; }

    [JsonProperty("usuarioResenia")]
    public int usuarioResenia { get; set; }

    [JsonProperty("idFacultad")]
    public int idFacultad { get; set; }

    [JsonProperty("idUsuario")]
    public int idUsuario { get; set; }
    
    [JsonProperty("username")]
    public string username { get; set; }
    
    [JsonProperty("fotoPerfil")]
    public string fotoPerfil { get; set; }

    public OpinionFacultad()
    {
    }

    public OpinionFacultad(int idResenia, string mensaje, int usuarioResenia, string username, string fotoPerfil, int idFacultad)
    {
        this.idResenia = idResenia;
        this.mensaje = mensaje;
        this.usuarioResenia = usuarioResenia;
        this.username = username;
        this.fotoPerfil = fotoPerfil;
        this.idFacultad = idFacultad;
    }
}