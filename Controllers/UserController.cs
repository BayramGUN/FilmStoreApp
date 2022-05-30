using FilmsApi.DBO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using FilmsApi.Application.UserOperations.Commands.CreateUser;
using FilmsApi.Application.UserOperations.Commands.CreateToken;
using FilmsApi.TokenOperations.Models;
using FilmsApi.Application.UserOperations.Commands.RefreshToken;

namespace FilmsApi.Controllers;

[ApiController]
[Route("[controller]s")]
public class UserController : ControllerBase
{
    private readonly IFilmsDbContext _context;
    private readonly IMapper _mapper;
    readonly IConfiguration _configuration;
    public UserController(IFilmsDbContext context, IConfiguration configuration,IMapper mapper)
    {
        _context = context;
        _configuration = configuration;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult CreateUser([FromBody] CreateUserModel newUser)
    {
        CreateUserCommand command = new CreateUserCommand(_context, _mapper);
        command.Model = newUser;
        command.Handle();
        return Ok();
    }

    [HttpPost("connect/token")]
    public ActionResult<Token> CreateToken([FromBody] CreateTokenModel login)
    {
        CreateTokenCommand command = new CreateTokenCommand(_context, _mapper, _configuration);
        command.Model = login;
        var token = command.Handle();
        return token;
    }  
    [HttpGet("refreshToken")]
    public ActionResult<Token> RefreshToken([FromQuery] string token)
    {
        RefreshTokenCommand command = new RefreshTokenCommand(_context, _mapper, _configuration);
        command.RefreshToken = token;
        var resultToken = command.Handle();
        return resultToken;
    }  
}