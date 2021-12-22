using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using UsersAPI.Database;
using UsersAPI.Database.Repository;
using UsersAPI.Models;

namespace UserAPI.Tests.Fixture;

public class ApiFixture : IDisposable
{
    public IList<User> FakeDatabase { get; } = new List<User>();

    public const string MySqlConnectionString =
        "Server=host.docker.internal;port=3306;Database=devops-project;Uid=root;Pwd=azerty123;";

    public IUserRepository Repository { get; }

    public ApiFixture()
    {
        DapperFactory dapperFactory = new(MySqlConnectionString);
        Repository = new UserRepository(dapperFactory);
        InitializeDatabase(dapperFactory);
    }

    public void Dispose()
    {
        foreach (User user in FakeDatabase) Repository.DeleteUser(user.Id!.Value);
    }

    private void InitializeDatabase(DapperFactory factory)
    {
        using IDbConnection connection = factory.CreateConnection();

        for (var i = 0; i < 3; i++)
        {
            User user = new( $"First Name : {i + 1}", $"Last Name : {i + 1}", i + 1 * 10);
            user.Id = Repository.CreateUser(user).GetAwaiter().GetResult();
            FakeDatabase.Add(user);
        }
    }
}