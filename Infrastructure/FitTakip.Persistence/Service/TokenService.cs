using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using FitTakip.Application.DTOs;
using FitTakip.Application.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace FitTakip.Persistence.Service;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public Token CreateAccessToken()
    {
        Token token = new();

        SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));

        SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

        token.Expiration = DateTime.UtcNow.AddMinutes(60);
        // token.Expiration = DateTime.UtcNow.AddSeconds(1);
        JwtSecurityToken securityToken = new(
            audience: _configuration["Token:Audience"],
            issuer: _configuration["Token:Issuer"],
            expires: token.Expiration,
            notBefore: DateTime.UtcNow,
            signingCredentials: signingCredentials
            );

        JwtSecurityTokenHandler tokenHandler = new();
        token.AccessToken = tokenHandler.WriteToken(securityToken);

        return token;
    }
}
