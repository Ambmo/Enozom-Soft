using System;
using Microsoft.Data.Sqlite;

namespace ConsoleApp
{
    class Program
    {

        static void Main(string[] args)
        {
            using (var connection = new SqliteConnection("Data Source=C:/DB/Chinook_Sqlite.sqlite"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                SELECT sum(total) as total_invoices 
                from Invoice 
                WHERE CustomerId = $CustomerId
                ";
                command.Parameters.AddWithValue("$CustomerId", 2);//for ex
                //we can implement a function here to take whichever customer id we want

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //var salary = reader.GetString(1);
                        var total = reader.GetString(0);

                        //Console.WriteLine($"Hello, {number},Mr. {name2}-{name1}!");
                        Console.WriteLine($"Total Salary for the selected customer {total} ");
                    }
                }
            }
        }
    }
}
