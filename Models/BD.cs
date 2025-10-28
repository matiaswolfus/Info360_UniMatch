namespace Info360_EFSI.Models;

public class ErrorViewModel
{
    public string? RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}

public class BD
{
     public static string _connectionString = @"Server=localhost;
        DataBase=info360 inicial;Integrated Security=True;TrustServerCertificate=True;";

    public static Usuario GetUsuario(int idUsuario)
    {
        Usuario miusuario = null;
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM Usuario WHERE Id = @pIdUsuario";
             miusuario = connection.QueryFirstOrDefault<Usuario>(query, new { pIdUsuario = idUsuario });
            return miusuario;
        }
    }

    public static int Login(string UserName, string Contraseña)
    {
        int id = 0;
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT Id FROM Usuario WHERE UserName = @pUserName AND Contraseña = @pcontraseña";
            id = connection.QueryFirstOrDefault<int>(query, new { pUserName = UserName, pcontraseña = Contraseña });
        }
if(id != 0){  return id;}
 else{return id = -1;}     
    }


    public static int RegistrarUsuario(string nombre, string apellido,  string contrasena, string userName)
{
    
    string query = @"
        INSERT INTO Usuario (Nombre, Apellido, [Contraseña], UserName, UltimoLogIn) 
        VALUES (@Nombre, @Apellido, @Contrasena, @UserName, @UltimoLogIn);
        SELECT CAST(SCOPE_IDENTITY() as int);";

    using (SqlConnection connection = new SqlConnection(_connectionString))
    {
        connection.Open();
        int nuevoId = connection.QuerySingle<int>(query, new 
        { 
            Nombre = nombre,
            Apellido = apellido,
         
            UserName = userName,
            UltimoLogIn = DateTime.Now,
            
            Contrasena = contrasena
        });

        return nuevoId;
    }
}


}
