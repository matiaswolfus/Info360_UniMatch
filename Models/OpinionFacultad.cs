namespace Info360_EFSI.Models;
using Newtonsoft.Json;

public class OpinionFacultad{
    [JsonProperty("idResenia")]

    public int  idResenia { get; private set; }

    [JsonProperty("mensaje")]

    public string mensaje { get; private set; }

    [JsonProperty("usuarioResenia")]
    public int usuarioResenia { get; private set; }/*Comentario*/

    [JsonProperty("idFacultad")]
    public int idFacultad { get; private set; }

    [JsonProperty("idUsuario")]
    public int idUsuario { get; private set; }
   [JsonProperty("username")]
   public string username { get; private set; }
      [JsonProperty("fotoPerfil")]
   public string fotoPerfil { get; private set; }
    public OpinionFacultad(int idResenia, string mensaje, int usuarioResenia, string username , string fotoPerfil,int idFacultad)
    {
        this.idResenia = idResenia;
        this.mensaje = mensaje;
        this.usuarioResenia = usuarioResenia;
        this.username = username;
        this.fotoPerfil = fotoPerfil;
        this.idFacultad = idFacultad;
    }

}
