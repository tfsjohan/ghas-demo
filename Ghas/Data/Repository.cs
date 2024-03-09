using Ghas.Models;
using Microsoft.Data.SqlClient;

namespace Ghas.Data;

public class Repository(IConfiguration configuration) : IRepository
{
    public Person? GetPerson(string id)
    {
        using var connection =
            new SqlConnection(configuration.GetConnectionString("DefaultConnection"));

        connection.Open();
        using var command = new SqlCommand(
            $"SELECT * FROM Persons WHERE Id = '{id}'",
            connection);

        using var reader = command.ExecuteReader();
        if (reader.Read())
        {
            return new Person
            {
                Id = reader.GetString(0),
                Name = reader.GetString(1),
                Age = reader.GetInt32(2),
                Description = reader.GetString(3)
            };
        }

        return null;
    }

    public Person GetAdministrator()
    {
        const string id = "admin";
        using var connection =
            new SqlConnection(configuration.GetConnectionString("DefaultConnection"));

        connection.Open();
        using var command = new SqlCommand(
            $"SELECT * FROM Persons WHERE Id = '{id}'",
            connection);

        using var reader = command.ExecuteReader();
        if (reader.Read())
        {
            return new Person
            {
                Id = reader.GetString(0),
                Name = reader.GetString(1),
                Age = reader.GetInt32(2),
                Description = reader.GetString(3)
            };
        }

        throw new InvalidOperationException("Administrator not found");
    }

    public void SavePerson(Person person)
    {
        using var connection =
            new SqlConnection(configuration.GetConnectionString("DefaultConnection"));

        connection.Open();

        /*
         * This is clearly a very bad way to insert data into a database.
         * It is vulnerable to SQL injection attacks.
         * Yet, CodeQL does not flag this as a security vulnerability.
         * This is because CodeQL does not have a built-in taint analysis for SQL queries and Asp.net model binding.
         * However, CodeQL does have a taint analysis for HTTP requests.
         * This is why CodeQL is able to detect the SQL injection vulnerability in the Ghas/Controllers/PersonController.cs file.
         */
        using var command = new SqlCommand(
            $"INSERT INTO Persons (Id, Name, Age, Description) " +
            $"VALUES ('{person.Id}', '{person.Name}', {person.Age}, '{person.Description}')",
            connection);

        command.ExecuteNonQuery();
    }
}