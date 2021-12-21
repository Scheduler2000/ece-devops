using UsersAPI.Models;

namespace UsersAPI.Database.Repository;

public interface IUserRepository
{
    public Task<IEnumerable<User>> GetUsers();

    public Task<User?> GetUser(int id);

    public Task CreateUser(User user);

    public Task UpdateUser(User user);

    public Task DeleteUser(int id);

}