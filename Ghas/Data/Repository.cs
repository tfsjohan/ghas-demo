using Ghas.Models;
using Microsoft.Data.SqlClient;

namespace Ghas.Data;

public class Repository : IRepository
{
    public Person? GetPerson(string id)
    {
        using var connection =
            new SqlConnection("Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;");

        connection.Open();
        using var command = new SqlCommand(
            "SELECT * FROM Persons WHERE Id = '" + id + "'",
            connection);

        using var reader = command.ExecuteReader();
        if (reader.Read())
        {
            return new Person
            {
                Name = reader.GetString(0),
                Age = reader.GetInt32(1)
            };
        }

        return null;
    }

    public Person GetAdministrator()
    {
        const string id = "admin";
        using var connection =
            new SqlConnection("Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;");

        connection.Open();
        using var command = new SqlCommand(
            "SELECT * FROM Persons WHERE Id = '" + id + "'",
            connection);

        using var reader = command.ExecuteReader();
        if (reader.Read())
        {
            return new Person
            {
                Name = reader.GetString(0),
                Age = reader.GetInt32(1)
            };
        }

        throw new InvalidOperationException("Administrator not found");
    }
}