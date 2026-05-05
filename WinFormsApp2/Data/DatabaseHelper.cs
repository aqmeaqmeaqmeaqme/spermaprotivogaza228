using System.Data;
using Microsoft.Data.Sqlite;

namespace WinFormsApp2.Data;

public static class DatabaseHelper
{
    private static readonly string DbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "gym.db");
    private static readonly string ConnectionString = $"Data Source={DbPath}";

    public static int ExecuteNonQuery(string query, params SqliteParameter[] parameters)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();
        using var command = new SqliteCommand(query, connection);
        if (parameters.Length > 0) command.Parameters.AddRange(parameters);
        return command.ExecuteNonQuery();
    }

    public static object? ExecuteScalar(string query, params SqliteParameter[] parameters)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();
        using var command = new SqliteCommand(query, connection);
        if (parameters.Length > 0) command.Parameters.AddRange(parameters);
        return command.ExecuteScalar();
    }

    public static SqliteDataReader ExecuteReader(string query, params SqliteParameter[] parameters)
    {
        var connection = new SqliteConnection(ConnectionString);
        connection.Open();
        var command = new SqliteCommand(query, connection);
        if (parameters.Length > 0) command.Parameters.AddRange(parameters);
        return command.ExecuteReader(CommandBehavior.CloseConnection);
    }

    public static DataTable GetDataTable(string query, params SqliteParameter[] parameters)
    {
        using var reader = ExecuteReader(query, parameters);
        var dt = new DataTable();
        dt.Load(reader);
        return dt;
    }

    public static int CreateUser(string login, string password, string role = "User")
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();
        using var command = new SqliteCommand(
            "INSERT INTO Users(Name,Email,Password,Role) VALUES(@name,@email,@password,@role); SELECT last_insert_rowid();",
            connection);
        command.Parameters.AddWithValue("@name", login);
        command.Parameters.AddWithValue("@email", login);
        command.Parameters.AddWithValue("@password", password);
        command.Parameters.AddWithValue("@role", role);
        return Convert.ToInt32(command.ExecuteScalar());
    }

    public static void CreateDevice(int userId, string type, string model = "Не указано")
    {
        ExecuteNonQuery(
            "INSERT INTO Devices(UserId,Type,Model) VALUES(@userId,@type,@model)",
            new SqliteParameter("@userId", userId),
            new SqliteParameter("@type", type),
            new SqliteParameter("@model", model));
    }

    public static DataTable GetExerciseProgress(int userId, int exerciseId)
    {
        return GetDataTable(@"
SELECT w.Date, e.Name AS Exercise, l.Sets, l.Reps, l.Weight
FROM ExerciseLogs l
JOIN Workouts w ON w.Id = l.WorkoutId
JOIN Exercises e ON e.Id = l.ExerciseId
WHERE w.UserId = @uid AND l.ExerciseId = @eid
ORDER BY w.Date DESC",
            new SqliteParameter("@uid", userId),
            new SqliteParameter("@eid", exerciseId));
    }

    public static DataTable GetUserExercises(int userId)
    {
        return GetDataTable(@"
SELECT DISTINCT e.Id, e.Name
FROM Exercises e
JOIN ExerciseLogs l ON l.ExerciseId = e.Id
JOIN Workouts w ON w.Id = l.WorkoutId
WHERE w.UserId = @uid
ORDER BY e.Name",
            new SqliteParameter("@uid", userId));
    }
}
