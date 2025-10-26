

namespace Info360_EFSI.Models;

public class Usuario{

    public int id {get; private set;}
    public string Nombre { get; private set; }
     public string Contraseña { get;  set; }
      public string Apellido { get;  set; }
      public string Email { get;  set; }
       public string Username { get;  set; }
      public string fotoTituloUni {get; set;}
    public string carrera {get; set;}
    ´public int idFacultad {get; set;}

     public Usuario(string Nombre, int FotoTituloUni, string carrera, int idFacultad, int id, string Contraseña, string Apellido, string Email, string Username){
     this.Nombre = Nombre;
        this.id = id;
         this.carrera = carrera;
         this.idFacultad = idFacultad
        this.FotoTituloUni = FotoTituloUni; 
     this.Contraseña = Contraseña;
      this.Email = Email;
      this.Apellido = Apellido;
      this.Username = Username;
}
}
