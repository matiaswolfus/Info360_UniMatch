namespace Info360_EFSI.Models;
using System.Data.SqlClient;
using System.Data;             
using Dapper;

public class ErrorViewModel
{
    public string? RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}

public class BD
{
     public static string _connectionString =
        @"Server=localhost;Database=[info360 Unimatch];Integrated Security=True;TrustServerCertificate=True;";


    public static Usuario GetUsuario(int idUsuario)
    {
        Usuario miusuario = null;
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM Usuario WHERE idUsuario = @idUsuario";
            miusuario = connection.QueryFirstOrDefault<Usuario>(query, new { idUsuario });
            return miusuario;
        }
    }

    public static int Login(string username, string contrasenia)
    {
        int id = 0;
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT idUsuario FROM Usuario WHERE username = @pusername AND contrasenia = @pcontrasenia";
            id = connection.QueryFirstOrDefault<int>(query, new { pusername = username, pcontrasenia = contrasenia });
        }
        if(id != 0)
        {
            return id;
        }
        else
        {
            return id = -1;
        }     
    }


  public static int RegistrarUsuario(
    string nombre, 
    string apellido,  
    string contrasenia, 
    string username, 
    string? fotoTituloUni, 
    string? carrera, 
    string? facultad,
    string gmail, 
    bool rol)
{
    string query = @"
        INSERT INTO Usuario (
            nombre, apellido, contrasenia, username, fotoTituloUni, 
            idCarrera, idFacultad, gmail, rol
        )
        VALUES (
            @nombre,
            @apellido,
            @contrasenia,
            @username,
            @fotoTituloUni,
            (SELECT idCarrera FROM Carrera WHERE nombre = @carrera),        -- puede ser NULL
            (SELECT idFacultad FROM Facultad WHERE nombre = @facultad),      -- puede ser NULL
            @gmail,
            @rol
        );

        SELECT CAST(SCOPE_IDENTITY() AS INT);";

    using (SqlConnection connection = new SqlConnection(_connectionString))
    {
        connection.Open();

        var nuevoId = connection.QuerySingle<int>(
            query,
            new {
                nombre = nombre,
                apellido = apellido,
                contrasenia = contrasenia,
                username = username,
                fotoTituloUni = (object?)fotoTituloUni ?? DBNull.Value,
                carrera = (object?)carrera ?? DBNull.Value,
                facultad = (object?)facultad ?? DBNull.Value,
                gmail = gmail,
                rol = rol
            }
        );

        return nuevoId;
    }
}
    public static DataTable InfoPorNombreYFacultad(string nombreCarrera, string nombreFacultad)
    {
        string connectionString = "Server=localhost;Database=info360_Unimatch;Trusted_Connection=True;";
        string query = @"
            SELECT 
                Carrera.idCarrera,
                Carrera.nombre AS NombreCarrera,
                Carrera.descripcion,
                Carrera.duracion,
                Carrera.cantMaterias,                                               
                Facultad.idFacultad,
                Facultad.nombre AS NombreFacultad,
                Facultad.direccion,
                Facultad.contacto,
                Facultad.precio,
                Facultad.tipoGestion
            FROM Carrera
            INNER JOIN Facultad ON Carrera.idFacultad = Facultad.idFacultad
            WHERE Carrera.nombre = @nombreCarrera
              AND Facultad.nombre = @nombreFacultad;
        ";

        using (SqlConnection conexion = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand(query, conexion))
        {
            cmd.Parameters.AddWithValue("@nombreCarrera", nombreCarrera);
            cmd.Parameters.AddWithValue("@nombreFacultad", nombreFacultad);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
    }

    public static Facultad InfoUniversidad(int id)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Facultad WHERE idFacultad = @id";
            return connection.QueryFirstOrDefault<Facultad>(sql, new {id});
        }
    }

   public static Carrera InfoCarrera(int iDCarrera)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Carrera WHERE idCarrera = @iDCarrera;";
            return connection.QueryFirstOrDefault<Carrera>(sql, new { iDCarrera });
        }
    }
    
 public static List<Resenia> VerReseña(int id)
    {
     List<Resenia> Resenias = new List<Resenia>();
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
           string sql = @"
SELECT Resenia.mensaje, Usuario.nombre, Usuario.fotoTituloUni
FROM Resenia 
INNER JOIN Usuario ON Rsenia.idUsuario = Usuario.idUsuario
INNER JOIN Facultad ON Resenia.idFacultad = Facultad.idFacultad
WHERE Facultad.idFacultad = @id";


         Resenias  = connection.Query<Resenia>(sql).ToList();  
        }
     return Resenias;
    }
 
  public static Usuario verInfoUsuario(int iDUsuario)
  {
    using (SqlConnection connection = new SqlConnection(_connectionString))
        {     
            string sql = "SELECT * FROM Usuario WHERE Usuario.idUsuario = @idUsuario"; 
        
            return connection.QueryFirstOrDefault<Usuario>(sql, new { iDUsuario });
        }
  }
   
    
public static List<Carrera> infoCarreras()
{
    List<Carrera> Carreras= new List<Carrera>();
    using (SqlConnection connection = new SqlConnection (_connectionString))
    {
        string sql = "SELECT * FROM Carrera";
        Carreras = connection.Query<Carrera>(sql).ToList();
        return Carreras;
    }
    
}



public static List<Facultad> infoUniversidades()
{
    List<Facultad> facultades = new List<Facultad>();
    using (SqlConnection connection = new SqlConnection (_connectionString))
    {
        string sql = "SELECT * FROM Facultad";
        facultades = connection.Query<Facultad>(sql).ToList();
        
    }
    return facultades;
}



public static List<OpinionFacultad> OpinionesU(int idFacultad)
    {
        
        List<OpinionFacultad> opiniones = new List<OpinionFacultad>();
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
string sql = @"
SELECT Resenia.*, Usuario.username, Usuario.fotoPerfil
FROM Resenia 
INNER JOIN Usuario ON Resenia.idUsuario = Usuario.idUsuario
WHERE Resenia.idFacultad = @idFacultad";
            opiniones = connection.Query<OpinionFacultad>(sql).ToList();
        }
        return opiniones;
    }



public static List<OpinionCarrera> OpinionesC(int idFacultad)
    {
        
        List<OpinionCarrera> opiniones = new List<OpinionCarrera>();
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            string sql = "SELECT ReseniaCarrera.*, Usuario.Username, Usuario.fotoPerfil FROM ReseniaCarrera WHERE R.idCarrera = @idCarrera INNER JOIN Usuario ON ReseniaCarrera.idUsuario = Usuario.idUusario ";
            opiniones = connection.Query<OpinionCarrera>(sql).ToList();
        }
        return opiniones;
    }


public static Resenia GuardarReseniaU(int idFacultad, string mensaje, int idUsuario)
{
    using (SqlConnection connection = new SqlConnection(_connectionString))
    {
        connection.Open();

        string sql = @"
            INSERT INTO Resenia (mensaje, idFacultad, idUsuario)
            VALUES (@mensaje, @idFacultad, @idUsuario);
            SELECT CAST(SCOPE_IDENTITY() AS INT);";

        int newId = connection.QuerySingle<int>(sql, new { mensaje, idFacultad, idUsuario });

        return connection.QueryFirstOrDefault<Resenia>
        (
            "SELECT * FROM Resenia WHERE idResenia = @idResenia", new { id = newId }
        );
    }
}




    


