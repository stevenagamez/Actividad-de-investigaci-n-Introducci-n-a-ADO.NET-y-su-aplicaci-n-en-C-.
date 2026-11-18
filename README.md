# Registro de Videojuegos – ADO.NET + SQLite

Programa de consola en C# que demuestra el acceso a datos con **ADO.NET** y **SQLite**.

**Asignatura:** Programación en C# con .NET – Semana 12  
**Autor:** STEVEN ANDRÉ AGÁMEZ OROZCO 

## Qué hace

1. Crea (si no existe) la base de datos `videojuegos.db` con `SqliteConnection`.
2. Crea la tabla `Videojuegos` con las columnas `Id`, `Titulo`, `Genero` y `Anio`.
3. Inserta 3 registros usando `SqliteCommand` y parámetros.
4. Consulta y muestra los registros con `SqliteDataReader`.
5. Administra los recursos con `using`.

## Requisitos

- [.NET SDK 8.0](https://dotnet.microsoft.com/download) o superior  
  (si usas otra versión, cambia `TargetFramework` en `RegistroVideojuegos.csproj`).

## Ejecución

```bash
git clone <url-del-repositorio>
cd RegistroVideojuegos
dotnet restore
dotnet run
```

## Salida esperada

```
Conexión establecida con la base de datos SQLite.

Insertado: The Legend of Zelda: Breath of the Wild
Insertado: Hollow Knight
Insertado: Celeste

--- Videojuegos almacenados ---
[1] The Legend of Zelda: Breath of the Wild | Aventura | 2017
[2] Hollow Knight | Metroidvania | 2017
[3] Celeste | Plataformas | 2018
```

## Tecnologías

- C# y .NET
- ADO.NET
- Microsoft.Data.Sqlite (SQLite)

## Estructura

```
RegistroVideojuegos/
├── Program.cs
├── RegistroVideojuegos.csproj
├── README.md
└── .gitignore
```
