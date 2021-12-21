using Microsoft.AspNetCore.Mvc;
using UsersAPI.Database.Repository;
using UsersAPI.Models;
using ILogger = Serilog.ILogger;

namespace UsersAPI.Controllers;

[Route("api/[controller]")]
public class UserController : Controller
{
    private readonly ILogger _logger;
    private readonly IUserRepository _repository;


    public UserController(ILogger logger, IUserRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }

    [HttpGet("fetch-user/{id:int}")]
    public async Task<IActionResult> GetUser(int id)
    {
        User? user = await _repository.GetUser(id).ConfigureAwait(false);
        string clientIp = Request.Host.Value;

        if (user == null)
        {
            _logger.Information("User with id {@Id} wasn't found the client with IP : {@IP}", id, clientIp);
            return NotFound();
        }

        _logger.Information("User with id {@Id} retrieved for client with IP : {@IP}", id, clientIp);
        return Ok(user);
    }

    [HttpGet("fetch-users")]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _repository.GetUsers().ConfigureAwait(false);

        string clientIp = Request.Host.Value;

        if (!users.Any())
        {
            _logger.Information("No user was found for the client with IP : {@IP}", clientIp);
            return NotFound();
        }

        _logger.Information("All Users was retrieved for client with IP : {@IP}", clientIp);
        return Ok(users);
    }
}