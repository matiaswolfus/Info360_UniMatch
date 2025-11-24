namespace Info360_EFSI.Models;
using Newtonsoft.Json;

public class OpinionCarrera
{
    public int idReseniaCarrera { get; set; }
    public string mensaje { get; set; }
    public int idUsuario { get; set; }
    public int idCarrera { get; set; }
    public string username { get; set; }
    public string fotoPerfil { get; set; }

    public OpinionCarrera() { }

    public OpinionCarrera(int idReseniaCarrera, string mensaje, int idUsuario, int idCarrera, string username, string fotoPerfil)
    {
        this.idReseniaCarrera = idReseniaCarrera;
        this.mensaje = mensaje;
        this.idUsuario = idUsuario;
        this.idCarrera = idCarrera;
        this.username = username;
        this.fotoPerfil = fotoPerfil;
    }
}
