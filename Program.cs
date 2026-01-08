using MySql.Data.MySqlClient;
using TaskManager.Data;

try
{
    using var connection = new MySqlConnection(DatabaseConfig.ConnectionString);
    connection.Open();
    Console.WriteLine("✅ Conectado ao MySQL com sucesso!");
}
catch (Exception ex)
{
    Console.WriteLine("❌ Erro na conexão:");
    Console.WriteLine(ex.Message);
}

Console.ReadKey();
return;