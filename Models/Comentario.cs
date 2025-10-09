namespace Info360_EFSI.Models;


public class Comentario{
    public Usuario Comentarista { get; private set; }
 
      public string Opinion { get;  set; }
       
        public List<Respuesta> Respuestas { get; set; } = new List<Respuesta>();

     public Comentario( Usuario Comentarista, string Opinion, List<Respuesta> Respuestas ){
            this.Comentarista = Comentarista;
            


     }

}