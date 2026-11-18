using Microsoft.Data.Sqlite;

const string cadenaConexion = "Data Source=videojuegos.db";

// using garantiza que la conexión se cierre y libere al terminar
using var conexion = new SqliteConnection(cadenaConexion);
conexion.Open();
Console.WriteLine("Conexión establecida con la base de datos SQLite.\n");

// 1. Crear la tabla (4 columnas)
using (var crear = conexion.CreateCommand())
{
    crear.CommandText = @"
        CREATE TABLE IF NOT EXISTS Videojuegos (
            Id      INTEGER PRIMARY KEY AUTOINCREMENT,
            Titulo  TEXT    NOT NULL,
            Genero  TEXT    NOT NULL,
            Anio    INTEGER NOT NULL
        );";
    crear.ExecuteNonQuery();
}

// Limpiar para que la demo no duplique registros al ejecutarla varias veces
using (var limpiar = conexion.CreateCommand())
{
    limpiar.CommandText = "DELETE FROM Videojuegos;";
    limpiar.ExecuteNonQuery();
}

// 2. Insertar registros usando parámetros
var juegos = new (string Titulo, string Genero, int Anio)[]
{
    ("The Legend of Zelda: Breath of the Wild", "Aventura", 2017),
    ("Hollow Knight", "Metroidvania", 2017),
    ("Celeste", "Plataformas", 2018)
};

foreach (var juego in juegos)
{
    using var insertar = conexion.CreateCommand();
    insertar.CommandText =
        "INSERT INTO Videojuegos (Titulo, Genero, Anio) VALUES ($titulo, $genero, $anio);";
    insertar.Parameters.AddWithValue("$titulo", juego.Titulo);
    insertar.Parameters.AddWithValue("$genero", juego.Genero);
    insertar.Parameters.AddWithValue("$anio", juego.Anio);
    insertar.ExecuteNonQuery();
    Console.WriteLine($"Insertado: {juego.Titulo}");
}

// 3. Consultar y mostrar con DataReader
Console.WriteLine("\n--- Videojuegos almacenados ---");
using var consulta = conexion.CreateCommand();
consulta.CommandText = "SELECT Id, Titulo, Genero, Anio FROM Videojuegos;";

using var lector = consulta.ExecuteReader();
while (lector.Read())
{
    int id = lector.GetInt32(0);
    string titulo = lector.GetString(1);
    string genero = lector.GetString(2);
    int anio = lector.GetInt32(3);
    Console.WriteLine($"[{id}] {titulo} | {genero} | {anio}");
}
