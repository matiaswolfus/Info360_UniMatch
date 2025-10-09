

namespace Info360_EFSI.Models;

public class Usuario{
    
    public string Nombre { get; private set; }
     public string Contraseña { get;  set; }
      public string Email { get;  set; }
       public string Universidad { get;  set; }
       public string Carrera { get;  set; }


     public Usuario(string Nombre, string Contraseña, string Email, string Carrera, string Universidad){
     this.Nombre = Nombre;
     this.Contraseña = Contraseña;
      this.Email = Email;
      this.Carrera = Carrera;
      this.Universidad = Universidad;
}
}