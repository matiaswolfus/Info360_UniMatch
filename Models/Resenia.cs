namespace Info360_EFSI.Models;

public class Resenia{
    public string Mensaje {get; private set;}
    public int idFacultad {get; private set;}
    public int idResenia {get; private set;}
    public int idUsuario {get; private set;}

public Resenia (string Mensaje, int idFacultad, int idResenia, int idUsuario)
{
    this.Mensaje = Mensaje;
    this.idFacultad = idFacultad;
    this.idResenia = idResenia;
    this.idUsuario = idUsuario;
    
}



}
