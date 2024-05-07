using Microsoft.Data.SqlClient;
using AdoNetCommandApp;

List<Teacher> teachers = new()
{
    new(){ LastName = "Иванов",
           FirstName = "Роман",
           BirthDate = new(1999, 10, 20),
           Phone = "(999) 134-35-23",
           Salary = 90000,
           DepartmentId = 4 },
    new(){ LastName = "Кузнецов",
           FirstName = "Сергей",
           BirthDate = new(1985, 5, 12),
           Phone = "(903) 234-66-00",
           Salary = 110000,
           DepartmentId = 5 },
    new(){ LastName = "Романов",
           FirstName = "Иван",
           BirthDate = new(2000, 2, 27),
           Phone = "(953) 333-44-55",
           Salary = 85000,
           DepartmentId = 4 },
    new(){ LastName = "Алексеев",
           FirstName = "Семен",
           BirthDate = new(1997, 6, 4),
           Phone = "(906) 876-11-67",
           Salary = 112000,
           DepartmentId = 6 },
    new(){ LastName = "Дмитриев",
           FirstName = "Виктор",
           BirthDate = new(1988, 7, 25),
           Phone = "(902) 786-31-31",
           Salary = 105000,
           DepartmentId = 7 }
};
List<string> departs = new() { "Графика и дизайн", "Разработка веб приложений", "Разработка на Python" };


string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AcademyDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;";
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

    // NON QUERY

    //commandString = "INSERT INTO Department (title) VALUES (N'Разработка программного обеспечения')";
    //commandString = "INSERT INTO Department (title) VALUES";
    //foreach (string depart in departs)
    //    commandString += $"(N'{depart}'),";
    //Console.WriteLine(commandString.Remove(commandString.Length - 1));

    //commandString = @" SET DATEFORMAT dmy

    //                    INSERT INTO Teacher 
    //                    (last_name, first_name,
    //                     birth_date, phone,
    //                     department_id, salary) VALUES ";

    //foreach (var t in teachers)
    //    commandString += @$"(N'{ t.LastName }', N'{ t.FirstName }', 
    //                         CONVERT(DATETIME, '{ t.BirthDate.ToString() }'),
    //                         '{ t.Phone }',
    //                         { t.DepartmentId }, { t.Salary } ),";

    //Console.WriteLine(commandString.Remove(commandString.Length - 1));

    //commandString = "UPDATE Teacher SET Phone = '(906) 876-11-00' WHERE id = 18";

    //command.CommandText = commandString.Remove(commandString.Length - 1);

    //command.CommandText = commandString;
    //await command.ExecuteNonQueryAsync();



    // SCALAR

    //commandString = "SELECT MIN(salary) FROM Teacher";    

    //command.CommandText = commandString;
    //var minSalary = await command.ExecuteScalarAsync();
    //Console.WriteLine($"Minimal salary: {minSalary}");

    //commandString = "SELECT MAX(salary) FROM Teacher";

    //command.CommandText = commandString;
    //var maxSalary = await command.ExecuteScalarAsync();
    //Console.WriteLine($"Maximall salary: {maxSalary}");

    //commandString = "SELECT AVG(salary) FROM Teacher";

    //command.CommandText = commandString;
    //var avgSalary = await command.ExecuteScalarAsync();
    //Console.WriteLine($"Avg salary: {avgSalary}");


    // READER
    commandString = "SELECT * FROM Teacher";
    command.CommandText = commandString;

    using (SqlDataReader reader = await command.ExecuteReaderAsync())
    {
        if (!reader.HasRows) return;

        Console.WriteLine(new String('-', 50));

        Console.Write("| ");
        for (int i = 0; i < reader.FieldCount; i++)
            Console.Write($"{reader.GetName(i)}\t| ");
        Console.WriteLine();

        Console.WriteLine(new String('-', 50));

        while (await reader.ReadAsync())
        {
            Console.Write("| ");
            //for (int i = 0; i < reader.FieldCount; i++)
            //    Console.Write($"{reader.GetValue(i)}\t| ");

            Console.Write($"{ reader.GetInt32(0) }\t| ");
            Console.Write($"{reader.GetString(1)}\t| ");
            Console.Write($"{reader.GetString(2)}\t| ");
            Console.Write($"{reader.GetDateTime(3).ToShortDateString() }\t| ");
            Console.Write($"{reader.GetString(4)}\t| ");
            Console.Write($"{reader.GetInt32(5)}\t| ");
            Console.Write($"{reader.GetDecimal(6)}\t| ");

            Console.WriteLine();
        }
    }

    Console.WriteLine(new String('-', 50));
}