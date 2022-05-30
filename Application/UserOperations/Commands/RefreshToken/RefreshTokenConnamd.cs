
using FilmsApi.DBO;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using FilmsApi.Entities;
using FilmsApi.TokenOperations;
using FilmsApi.TokenOperations.Models;

namespace FilmsApi.Application.UserOperations.Commands.RefreshToken;

public class RefreshTokenCommand
{
    public string RefreshToken { get; set; }
    private readonly IFilmsDbContext _dbContext;
    private readonly IMapper _mapper;

    private readonly IConfiguration _configuration;

    public RefreshTokenCommand(IFilmsDbContext context, IMapper mapper, IConfiguration configuration)
    {
        _dbContext = context;
        _mapper = mapper;
        _configuration = configuration;
    }
    public Token Handle()
    {
        var user = _dbContext.Users.FirstOrDefault(ctx => ctx.RefreshToken == RefreshToken && ctx.RefreshTokenExpireDate > DateTime.Now);
        if(user is not null)
        {
            TokenHandler handler = new TokenHandler(_configuration);
            Token token = handler.CreateAccessToken(user);

            user.RefreshToken = token.RefreshToken;
            user.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);

            _dbContext.SaveChanges();
            
            return token;
        }
        else 
            throw new InvalidOperationException("Geçerli bir refresh token bulunamadı!");
    }
}
