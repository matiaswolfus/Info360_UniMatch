namespace Info360_EFSI.Models;
using System.Data.SqlClient;
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
            string query = "SELECT * FROM Usuario WHERE idUsuario = @pidUsuario";
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


}
