

namespace Info360_EFSI.Models;

public class Universidad{
     
      public string Nombre { get; private set; }
      public string Descrpcion { get;  set; }
        public string Ubicacion { get;  set; }
        public string Becas { get;  set; }
        
        public string Cuota { get;  set; }
         public string TipoGestion { get;  set; }

     public List<Carrera> Carreras { get; set; } = new List<Carrera>();
    
     

     public Universidad(string TipoGestion, string Cuota, string Nombre, string Descripcion, string Ubicacion, string Becas, List<Carrera> Carreras , List<Extracurriculares> Extra,  List<Docentes> Docentes){
    
}
}