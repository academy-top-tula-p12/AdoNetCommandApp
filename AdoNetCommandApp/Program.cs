using Microsoft.Data.SqlClient;

string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AcademyDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;CharSet=utf8";
string commandString = "";

using (SqlConnection connection = new(connectionString))
{
    await connection.OpenAsync();

    // 1
    //SqlCommand command = new SqlCommand("CREATE DATABESE");
    //command.Connection = connection;

    // 2
    //SqlCommand command = new SqlCommand("CREATE DATABESE", connection);

    // 3
    SqlCommand command = connection.CreateCommand();
    commandString = "INSERT INTO Department (title) VALUES ('Разработка программного обеспечения')";

    
    command.CommandText = commandString;

    await command.ExecuteNonQueryAsync();
}