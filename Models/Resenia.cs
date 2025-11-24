namespace Info360_EFSI.Models;
using Newtonsoft.Json;

public class Resenia
{
    [JsonProperty("idResenia")]
    public int idResenia { get; set; }

    [JsonProperty("mensaje")]
    public string? mensaje { get; set; }

    [JsonProperty("idFacultad")]
    public int idFacultad { get; set; }

    [JsonProperty("idUsuario")]
    public int idUsuario { get; set; }

    // Parameterless constructor for Dapper
    public Resenia()
    {
    }

    public Resenia(int idResenia, string mensaje, int idUsuario, int idFacultad)
    {
        this.idResenia = idResenia;
        this.mensaje = mensaje;
        this.idUsuario = idUsuario;
        this.idFacultad = idFacultad;
    }

}
