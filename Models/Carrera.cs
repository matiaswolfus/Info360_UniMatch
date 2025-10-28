
namespace Info360_EFSI.Models;


public class Carrera{
    public Universidad  idUni { get; private set; }

    public int CantMaterias { get; private set; }

    public int Duracion { get; private set; }

    public string Nombre { get; private set; }

    public string Descripcion { get; private set; }

    public Carrera(Universidad  idUni, int CantMaterias , int Duracion , string Nombre , string Descripcion)
    {
        this.idUni = idUni;
        this.CantMaterias = CantMaterias;
        this.Duracion = Duracion;
        this.Nombre = Nombre;
        this.Descripcion = Descripcion;
    }
}