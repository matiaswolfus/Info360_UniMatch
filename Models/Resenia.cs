namespace Info360_EFSI.Models;
using Newtonsoft.Json;

public class Resenia{
    [JsonProperty("idResenia")]

    public int  idResenia { get; private set; }

    [JsonProperty("mensaje")]

    public string mensaje { get; private set; }

    [JsonProperty("usuarioResenia")]
    public int usuarioResenia { get; private set; }

    [JsonProperty("idFacultad")]
    public int idFacultad { get; private set; }

    [JsonProperty("idUsuario")]
    public int idUsuario { get; private set; }

    public Resenia(int idResenia, string mensaje, int usuarioResenia)
    {
        this.idResenia = idResenia;
        this.mensaje = mensaje;
        this.usuarioResenia = usuarioResenia;

    }

}
