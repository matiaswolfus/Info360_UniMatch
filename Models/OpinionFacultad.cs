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
   [JsonProperty("nombreUsuario")]
   public string NombreUsuario { get; private set; }
      [JsonProperty("fotoUsuario")]
   public string fotoUsuario { get; private set; }
    public OpinionFacultad(int idResenia, string mensaje, int usuarioResenia, string NombreUsuario , string fotoUsuario,int idFacultad)
    {
        this.idResenia = idResenia;
        this.mensaje = mensaje;
        this.usuarioResenia = usuarioResenia;
        this.NombreUusario = NombreUsuario;
        this.fotoUsuario = fotoUsuario;
        this.idFacultad = idFacultad;
    }

}
