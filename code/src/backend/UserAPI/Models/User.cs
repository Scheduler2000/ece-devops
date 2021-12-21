using System.ComponentModel.DataAnnotations;

namespace UsersAPI.Models;

public class User
{
    [Key] public int? Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public int Age { get; set; }

    public User(int? id, string firstName, string lastName, int age)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Age = age;
    }

    public User(string firstName, string lastName, int age) : this(null, firstName, lastName, age)
    {
    }
}