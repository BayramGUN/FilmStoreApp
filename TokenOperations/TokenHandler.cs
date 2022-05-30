using System.IdentityModel.Tokens.Jwt;
using System.Text;
using FilmsApi.Entities;
using FilmsApi.TokenOperations.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace FilmsApi.TokenOperations;

public class TokenHandler
{
    public IConfiguration Configuration { get; set; }
    public TokenHandler(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    public Token CreateAccessToken(User user)
    {
        Token tokenModel = new Token();

        SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:SecurityKey"]));

        SigningCredentials credintials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        tokenModel.Expiration = DateTime.Now.AddMinutes(20);
        JwtSecurityToken securityToken = new JwtSecurityToken(
            issuer:Configuration["Token:Issuer"],
            audience:Configuration["Token:Audience"],
            expires:tokenModel.Expiration,
            notBefore: DateTime.Now,
            signingCredentials: credintials
        );
        
        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

        //Token is existed
        tokenModel.AccessToken = tokenHandler.WriteToken(securityToken);
        tokenModel.RefreshToken = CreateRefreshToken();
        
        return tokenModel;
    }
    public string CreateRefreshToken()
    {
        return Guid.NewGuid().ToString();
    }
}