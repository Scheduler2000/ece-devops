using UserAPI.Tests.Fixture;
using UsersAPI.Database.Repository;
using UsersAPI.Models;
using Xunit;

namespace UserAPI.Tests;

public class ApiTests : IClassFixture<ApiFixture>
{
    private readonly ApiFixture _fixture;

    public ApiTests(ApiFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void CreateUser()
    {
        // arrange
        IUserRepository database = _fixture.Repository;
        var createdUser = new User("Miles", "Davis", 65);
        

        // act
        int id = database.CreateUser(createdUser).GetAwaiter().GetResult();
        createdUser.Id = id;

        User? retrievedCreatedUser = database.GetUser(id).GetAwaiter().GetResult();

        bool assertion = createdUser.Equals(retrievedCreatedUser);
        database.DeleteUser(id);

        //assert
        Assert.True(assertion);
    }

    [Fact]
    public void ReadUser()
    {
        // arrange

        IUserRepository database = _fixture.Repository;
        User target = _fixture.FakeDatabase[0];

        // act
        User? retrieved = database.GetUser(target.Id!.Value).Result;

        //assert
        Assert.True(retrieved!.Equals(target));
    }

    [Fact]
    public void UpdateUser()
    {
        // arrange

        IUserRepository database = _fixture.Repository;
        User target = _fixture.FakeDatabase[1];

        // act
        target.Age += 2;
        database.UpdateUser(target);

        User? modified = database.GetUser(target.Id!.Value).GetAwaiter().GetResult();

        //assert
        Assert.True(target.Equals(modified));
    }

    [Fact]
    public void DeleteUser()
    {
        // arrange

        IUserRepository database = _fixture.Repository;
        User target = _fixture.FakeDatabase[2];

        // act
        database.DeleteUser(target.Id!.Value);

        User? retrieved = database.GetUser(target.Id!.Value).GetAwaiter().GetResult();

        //assert
        Assert.True(retrieved == null);
    }
}