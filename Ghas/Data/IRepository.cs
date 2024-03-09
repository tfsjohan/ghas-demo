using Ghas.Models;

namespace Ghas.Data;

public interface IRepository
{
    public Person? GetPerson(string id);

    public Person GetAdministrator();

    public Person AddPerson(Person person);

    public void UpdatePerson(Person person);
}