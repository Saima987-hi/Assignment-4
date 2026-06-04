using Microsoft.Data.SqlClient;
using App8_TodoWithDatabase.Models;

namespace App8_TodoWithDatabase.Services;

public class TodoDbService
{
    private readonly string _connectionString;

    public TodoDbService(IConfiguration config)
    {
        _connectionString = config.GetConnectionString("DefaultConnection")!;
        InitializeDatabase();
    }

    private void InitializeDatabase()
    {
        using var conn = new SqlConnection(_connectionString);
        conn.Open();
        var cmd = conn.CreateCommand();
        cmd.CommandText = @"
            IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='TodoItems' AND xtype='U')
            CREATE TABLE TodoItems (
                Id          INT           PRIMARY KEY IDENTITY(1,1),
                Task        NVARCHAR(500) NOT NULL,
                IsCompleted INT           NOT NULL DEFAULT 0,
                CreatedAt   NVARCHAR(100) NOT NULL
            );";
        cmd.ExecuteNonQuery();
    }

    public List<TodoItem> GetAll()
    {
        var items = new List<TodoItem>();
        using var conn = new SqlConnection(_connectionString);
        conn.Open();
        var cmd = conn.CreateCommand();
        cmd.CommandText = "SELECT Id, Task, IsCompleted, CreatedAt FROM TodoItems ORDER BY Id DESC;";
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            items.Add(new TodoItem
            {
                Id = reader.GetInt32(0),
                Task = reader.GetString(1),
                IsCompleted = reader.GetInt32(2) == 1,
                CreatedAt = DateTime.Parse(reader.GetString(3))
            });
        }
        return items;
    }

    public void Add(string task)
    {
        using var conn = new SqlConnection(_connectionString);
        conn.Open();
        var cmd = conn.CreateCommand();
        cmd.CommandText = "INSERT INTO TodoItems (Task, IsCompleted, CreatedAt) VALUES (@task, 0, @date);";
        cmd.Parameters.AddWithValue("@task", task);
        cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("o"));
        cmd.ExecuteNonQuery();
    }

    public void Delete(int id)
    {
        using var conn = new SqlConnection(_connectionString);
        conn.Open();
        var cmd = conn.CreateCommand();
        cmd.CommandText = "DELETE FROM TodoItems WHERE Id = @id;";
        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
    }

    public void Update(int id, string task, bool isCompleted)
    {
        using var conn = new SqlConnection(_connectionString);
        conn.Open();
        var cmd = conn.CreateCommand();
        cmd.CommandText = "UPDATE TodoItems SET Task = @task, IsCompleted = @done WHERE Id = @id;";
        cmd.Parameters.AddWithValue("@task", task);
        cmd.Parameters.AddWithValue("@done", isCompleted ? 1 : 0);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
    }

    public void DeleteAll()
    {
        using var conn = new SqlConnection(_connectionString);
        conn.Open();
        var cmd = conn.CreateCommand();
        cmd.CommandText = "DELETE FROM TodoItems;";
        cmd.ExecuteNonQuery();
    }
}