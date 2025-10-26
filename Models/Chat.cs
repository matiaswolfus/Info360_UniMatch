public class Chat{
public int Id {get; private set;}
public int IdUsuario {get; private set;}
public string mensaje {get; private set;}
public datetime fechaHora {get; private set;}

public Chat(int Id, int IdUsuario, string mensaje, datetime fehcaHora)
{
  this.Id = Id;
  this.IdUsuario = idUsuario;
  this.mensaje = mensaje;
  thise.fechaHora = fechaHora;
}

}
