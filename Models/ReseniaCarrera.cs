namespace Info360_EFSI.Models;
using Newtonsoft.Json;

public class ReseniaCarrera{
    [JsonProperty("idResenia")]

    public int  idResenia { get; private set; }

    [JsonProperty("mensaje")]

    public string mensaje { get; private set; }



    [JsonProperty("idCarrera")]
    public int idCarerra { get; private set; }

    [JsonProperty("idUsuario")]
    public int idUsuario { get; private set; }

    public ReseniaCarrera(int idResenia, string mensaje, int idUsuario, int idCarrera)
    {
        this.idResenia = idResenia;
        this.mensaje = mensaje;
        this.idUsuario = idUsuario;
       this.idCarerra = idCarerra;
    }

}
