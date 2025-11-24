namespace Info360_EFSI.Models;
using Newtonsoft.Json;

public class ReseniaCarrera
{
    [JsonProperty("idReseniaCarrera")]
    public int idReseniaCarrera { get; private set; }

    [JsonProperty("mensaje")]
    public string mensaje { get; private set; }

    [JsonProperty("idCarrera")]
    public int idCarrera { get; private set; }

    [JsonProperty("idUsuario")]
    public int idUsuario { get; private set; }

    public ReseniaCarrera() { }

    public ReseniaCarrera(int idReseniaCarrera, string mensaje, int idUsuario, int idCarrera)
    {
        this.idReseniaCarrera = idReseniaCarrera;
        this.mensaje = mensaje;
        this.idUsuario = idUsuario;
        this.idCarrera = idCarrera;
    }
}
