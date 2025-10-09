
namespace Info360_EFSI.Models;


public class Docentes{
    public string Nombre { get; private set; }
 
      public string Email { get;  set; }
       public string Cargo { get;  set; }


     public Docentes(string Nombre, string Cargo, string Email){
     this.Nombre = Nombre;
  
      this.Email = Email;
     
      this.Cargo = Cargo;


     }

}