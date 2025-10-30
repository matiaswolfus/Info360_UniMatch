

namespace Info360_EFSI.Models;

public class Universidad{
     
     public int id {get; set;} 
     public string Nombre { get; private set; }
      public string direccion { get;  set; }
     public string contacto {get; set;}
        public string fotoFacultad { get;  set; }
        public string Becas { get;  set; }
     public int cantCarreras {get; set;}        
        public string Cuota { get;  set; }
         public string TipoGestion { get;  set; }

   

     public Universidad(string TipoGestion, string contacto, int id, string Cuota, string Nombre, string direccion, string fotoFacultad,  int cantCarreras)
     {

          this.id = id;
          this.Nombre = Nombre;
          this.direccion = direccion;
          this.contacto = contacto;
          this.fotoFacultad = fotoFacultad;
          this.Becas = Becas;
          this.cantCarreras = cantCarreras;
          this.Cuota = this.Cuota;
          this.TipoGestion = TipoGestion;
      }
}
