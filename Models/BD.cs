using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace Info360_EFSI.Models;

public class ErrorViewModel
{
    public string? RequestId { get; set; }
    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}

public static class BD
{
    public static string _connectionString = @"Server=.\SQLEXPRESS;Database=info360 Unimatch;Integrated Security=True;TrustServerCertificate=True;";



    public static Usuario GetUsuario(int idUsuario)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM Usuario WHERE idUsuario = @idUsuario";
            return connection.QueryFirstOrDefault<Usuario>(query, new { idUsuario });
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
        if (id != 0)
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
            carrera, idFacultad, gmail, rol
        )
        VALUES (
            @nombre,
            @apellido,
            @contrasenia,
            @username,
            @fotoTituloUni,
            @carrera,
            (SELECT idFacultad FROM Facultad WHERE nombre = @facultad),
            @gmail,
            @rol
        );

        SELECT CAST(SCOPE_IDENTITY() AS INT);";

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            var nuevoId = connection.QuerySingle<int>(
                query,
                new
                {
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

        using (SqlConnection conexion = new SqlConnection(_connectionString))
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

    public static Facultad InfoUniversidad(int idFacultad)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Facultad WHERE idFacultad = @idFacultad";
            return connection.QueryFirstOrDefault<Facultad>(sql, new { idFacultad });
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
            INNER JOIN Usuario ON Resenia.idUsuario = Usuario.idUsuario
            INNER JOIN Facultad ON Resenia.idFacultad = Facultad.idFacultad
            WHERE Facultad.idFacultad = @id";


            Resenias = connection.Query<Resenia>(sql).ToList();
        }
        return Resenias;
    }

    public static Usuario verInfoUsuario(int iDUsuario)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Usuario WHERE Usuario.idUsuario = @iDUsuario";

            return connection.QueryFirstOrDefault<Usuario>(sql, new { iDUsuario });
        }
    }


    public static List<Carrera> infoCarreras()
    {
        List<Carrera> Carreras = new List<Carrera>();
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Carrera";
            Carreras = connection.Query<Carrera>(sql).ToList();
            return Carreras;
        }

    }



    public static List<Facultad> infoUniversidades()
    {
        List<Facultad> facultades = new List<Facultad>();
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Facultad";
            facultades = connection.Query<Facultad>(sql).ToList();

        }
        return facultades;
    }



    public static List<OpinionFacultad> OpinionesU(int idFacultad)
    {

        List<OpinionFacultad> opiniones = new List<OpinionFacultad>();
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string sql = @"
                SELECT Resenia.*, Usuario.username, Usuario.fotoPerfil
                FROM Resenia 
                INNER JOIN Usuario ON Resenia.idUsuario = Usuario.idUsuario
                WHERE Resenia.idFacultad = @idFacultad";
            opiniones = connection.Query<OpinionFacultad>(sql, new { idFacultad }).ToList();
        }
        return opiniones;
    }



    public static List<OpinionCarrera> OpinionesC(int idCarrera)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string sql = @"
            SELECT ReseniaCarrera.*, Usuario.username, Usuario.fotoPerfil
            FROM ReseniaCarrera
            INNER JOIN Usuario ON ReseniaCarrera.idUsuario = Usuario.idUsuario
            WHERE ReseniaCarrera.idCarrera = @idCarrera";

            return connection.Query<OpinionCarrera>(sql, new { idCarrera }).ToList();
        }
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

            return connection.QueryFirstOrDefault<Resenia>("SELECT * FROM Resenia WHERE idResenia = @idResenia", new { idResenia = newId });
        }
    }

    public static ReseniaCarrera GuardarReseniaC(int idCarrera, string mensaje, int idUsuario)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            string sql = @"
            INSERT INTO ReseniaCarrera (mensaje, idCarrera, idUsuario)
            VALUES (@mensaje, @idCarrera, @idUsuario);

            SELECT CAST(SCOPE_IDENTITY() AS INT);";

            int newId = connection.QuerySingle<int>(sql, new { mensaje, idCarrera, idUsuario });

            return connection.QueryFirstOrDefault<ReseniaCarrera>(
                "SELECT * FROM ReseniaCarrera WHERE idReseniaCarrera = @idResenia",
                new { idResenia = newId }
            );
        }
    }
    public static int GetIdCarrera(string nombreCarrera, int idFacultad)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            // Usamos COLLATE Latin1_General_CI_AI para ignorar mayúsculas/minúsculas y ACENTOS con el COLLATE porque me tiraba error
            string sql = "SELECT idCarrera FROM Carrera WHERE LTRIM(RTRIM(nombre)) COLLATE Latin1_General_CI_AI = @nombreCarrera AND idFacultad = @idFacultad";
            int id = connection.QueryFirstOrDefault<int>(sql, new { nombreCarrera = nombreCarrera.Trim(), idFacultad });

            if (id == 0)
            {
                sql = "SELECT TOP 1 idCarrera FROM Carrera WHERE LTRIM(RTRIM(nombre)) COLLATE Latin1_General_CI_AI = @nombreCarrera";
                id = connection.QueryFirstOrDefault<int>(sql, new { nombreCarrera = nombreCarrera.Trim() });
            }
            return id;
        }
    }
}
