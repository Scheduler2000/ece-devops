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

    [HttpPost("create-user")]
    public async Task<IActionResult> CreateUser([FromBody] User user)
    {
        string clientIp = Request.Host.Value;

        try
        {
            int id = await _repository.CreateUser(user).ConfigureAwait(false);
            user.Id = id;

            _logger.Information("User {@User} has been created by client with IP : {@IP}", user, clientIp);
            return Created($"fetch-user/{id}", user);
        }
        catch (Exception e)
        {
            _logger.Information("Error during creation of the user {@User} : {@Exception} for the client with IP : {@IP}", user,
                e.Message, clientIp);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPut("update-user/{id:int}")]
    public async Task<IActionResult> UpdateUser(int id, [FromBody] User user)
    {
        string clientIp = Request.Host.Value;

        try
        {
            if (await _repository.GetUser(id).ConfigureAwait(false) == null)
                return NotFound();
            
            user.Id = id;
            await _repository.UpdateUser(user).ConfigureAwait(false);
            
            _logger.Information("User {@User} has been updated by client with IP : {@IP}", user, clientIp);

            return NoContent();
        }
        catch (Exception e)
        {
            _logger.Information("Error during update of the user {@User} : {@Exception} for the client with IP : {@IP}", user,
                e.Message, clientIp);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpDelete("delete-user/{id:int}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        string clientIp = Request.Host.Value;
        User? user = default;
        
        try
        {
            user = await _repository.GetUser(id).ConfigureAwait(false);
            if (user == null)
                return NotFound();

            await _repository.DeleteUser(id).ConfigureAwait(false);
            _logger.Information("User {@User} has been deleted by client with IP : {@IP}", user, clientIp);

            return NoContent();
        }
        catch (Exception e)
        {
            _logger.Information("Error during update of the user {@User} : {@Exception} for the client with IP : {@IP}", user,
                e.Message, clientIp);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}