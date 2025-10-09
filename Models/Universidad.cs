

namespace Info360_EFSI.Models;

public class Universidad{
     
      public string Nombre { get; private set; }
      public string Descrpcion { get;  set; }
        public string Ubicacion { get;  set; }
        public string Becas { get;  set; }
        
     public List<Carrera> Carreras { get; set; } = new List<Carrera>();
      public List<Extracurriculares> Extra { get; set; } = new List<Extracurriculares>();
      public List<Docentes> Docentes { get; set; } = new List<Docentes>();

     public Universidad(string Nombre, string Descripcion, string Ubicacion, string Becas, List<Carrera> Carreras , List<Extracurriculares> Extra,  List<Docentes> Docentes){
    
}
}