namespace TP_Ahorcado.Models;
public class Chat{
public int Id {get; private set;}
public int IdUsuario {get; private set;}
public string mensaje {get; private set;}
public DateTime fechaHora {get; private set;}

public Chat(int Id, int IdUsuario, string mensaje, DateTime fehcaHora)
{
  this.Id = Id;
  this.IdUsuario = IdUsuario;
  this.mensaje = mensaje;
  this.fechaHora = fechaHora;
}

}
