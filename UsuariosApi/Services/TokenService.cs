﻿
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UsuariosApi.Models;

namespace UsuariosApi.Services
{
    public class TokenService
    {
        public string GenerateToken(Usuario usuario)
        {
            Claim[] claims = new Claim[]
            {
                new Claim("username", usuario.UserName),
                new Claim("id", usuario.Id),
                new Claim(ClaimTypes.DateOfBirth,usuario.DataNascimento.ToString()),
                new Claim("loginTimestamp", DateTime.UtcNow.ToString()),
            };

            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("9999ggghffuyf95212145"));

            var signingCredentials =
                new SigningCredentials(chave,
                SecurityAlgorithms.Aes128CbcHmacSha256);

            var token = new JwtSecurityToken
                (
                    expires: DateTime.Now.AddMinutes(10),
                    claims: claims,
                    signingCredentials: signingCredentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        
    }
}