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
}
