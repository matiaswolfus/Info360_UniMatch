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
     public static string _connectionString = @"Server=localhost;
        DataBase=info360_inicial;Integrated Security=True;TrustServerCertificate=True;"; 

    public static Usuario GetUsuario(int idUsuario)
    {
        Usuario miusuario = null;
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM Usuario WHERE idUsuario = @idUsuario";
             miusuario = connection.QueryFirstOrDefault<Usuario>(query, new { pidUsuario = idUsuario });
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


    public static int RegistrarUsuario(string nombre, string apellido,  string contrasenia, string username, string fotoTituloUni, string carrera, string gmail)
{
    
    string query = @"
        INSERT INTO Usuario (nombre, apellido, contrasenia, username, fotoTituloUni, carrera, gmail) 
        VALUES (@nombre, @apellido, @contrasenia, @username, @fotoTituloUni, @carrera, @gmail);
        SELECT CAST(SCOPE_IDENTITY() as int);";

    using (SqlConnection connection = new SqlConnection(_connectionString))
    {
        connection.Open();
        int nuevoId = connection.QuerySingle<int>(query, new 
        { 
            nombre = nombre,
            apellido = apellido,
         
            username = username,
            fotoTituloUni = fotoTituloUni,
            
            contrasenia = contrasenia,
            carrera = carrera,
            gmail = gmail
        });

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

    public static Universidad InfoUniversidad(int id)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Universidad WHERE id = @id";
            return connection.QueryFirstOrDefault<Universidad>(sql, new { id });
        }
    }

   public static Carrera InfoCarrera(int id)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string sql = "   SELECT * FROM Carrera WHERE id = @id;";
            return connection.QueryFirstOrDefault<Carrera>(sql, new { id });
        }
    }
    
 public static List<Resenia> VerReseña(int id)
    {
     List<Resenia> Resenias = new List<Resenia>();
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string sql = "SELECT Resenia.mensaje, Usuario.nombre, Usuario.foto FORM Resenia WHERE Facultad.Id = @Id INNER JOIN Usuario ON Resenia.idUsuario = Usuario.id INNER JOIN Facultad ON Resenia.idFacultad  = Facultad .id";

         Resenias  = connection.Query<Resenia>(sql).ToList();  
        }
     return Resenias;
    }
 public static Chats Chats(int id)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string sql = "SELECT Chat.mensaje, Usuario.Foto, Chat .facultad, Usuario.Username FROM Chat WHERE id = @id,INNER JOIN Usuario ON Chat.idUsuario = Usuario.id";
            return connection.QueryFirstOrDefault<Chats>(sql, new { id });
        }
    }
  public static Usuario verInfoUsuario(int iDUsuario)
  {
    using (SqlConnection connection = new SqlConnection(_connectionString))
        {     
            string sql = "SELECT * FROM Usuario WHERE Usuario.idUsuario = @iDUsuario"; 
        
            return connection.QueryFirstOrDefault<Usuario>(sql, new { iDUsuario });
        }
  }
   }
    

    


