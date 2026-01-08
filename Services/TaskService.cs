using MySql.Data.MySqlClient;
using TaskManager.Models;
using TaskManager.Data;

namespace TaskManager.Services;

public class TaskService
{
    public void CreateTask(string title, string description)
    {
        try
        {
            using var connection = new MySqlConnection(DatabaseConfig.ConnectionString);
            connection.Open();

            var sql = @"INSERT INTO tasks (title, description, is_completed, created_at)
                        VALUES (@title, @description, false, @createdAt)";

            using var cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@title", title);
            cmd.Parameters.AddWithValue("@description", description);
            cmd.Parameters.AddWithValue("@createdAt", DateTime.Now);

            cmd.ExecuteNonQuery();
            Console.WriteLine("✅ Tarefa criada com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Erro ao criar tarefa: {ex.Message}");
        }
    }

    public void ListTasks()
    {
        try
        {
            using var connection = new MySqlConnection(DatabaseConfig.ConnectionString);
            connection.Open();

            var sql = "SELECT * FROM tasks";
            using var cmd = new MySqlCommand(sql, connection);
            using var reader = cmd.ExecuteReader();

            if (!reader.HasRows)
            {
                Console.WriteLine("📭 Nenhuma tarefa cadastrada.");
                return;
            }

            while (reader.Read())
            {
                int id = reader.GetInt32("id");
                string title = reader.GetString("title");
                string description = reader.GetString("description");
                bool completed = reader.GetBoolean("is_completed");

                Console.WriteLine($"{id} - {(completed ? "[X]" : "[ ]")} {title} | {description}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Erro ao listar tarefas: {ex.Message}");
        }
    }

    public void CompleteTask(int id)
    {
        try
        {
            using var connection = new MySqlConnection(DatabaseConfig.ConnectionString);
            connection.Open();

            var sql = "UPDATE tasks SET is_completed = true WHERE id = @id";
            using var cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@id", id);

            int rows = cmd.ExecuteNonQuery();

            Console.WriteLine(rows > 0
                ? "✅ Tarefa concluída!"
                : "❌ Tarefa não encontrada.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Erro ao concluir tarefa: {ex.Message}");
        }
    }

    public void DeleteTask(int id)
    {
        try
        {
            using var connection = new MySqlConnection(DatabaseConfig.ConnectionString);
            connection.Open();

            var sql = "DELETE FROM tasks WHERE id = @id";
            using var cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@id", id);

            int rows = cmd.ExecuteNonQuery();

            Console.WriteLine(rows > 0
                ? "🗑️ Tarefa removida!"
                : "❌ Tarefa não encontrada.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Erro ao remover tarefa: {ex.Message}");
        }
    }
}