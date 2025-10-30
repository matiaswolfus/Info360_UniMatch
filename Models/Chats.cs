namespace Info360_EFSI.Models;
public class Chats{
public int Id {get; private set;}
public int IdUsuario {get; private set;}
public string mensaje {get; private set;}
public DateTime fechaHora {get; private set;}

public Chats(int Id, int IdUsuario, string mensaje, DateTime fehcaHora)
{
  this.Id = Id;
  this.IdUsuario = IdUsuario;
  this.mensaje = mensaje;
  this.fechaHora = fechaHora;
}

}