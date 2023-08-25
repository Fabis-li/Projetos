using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using NDDTraining.Domain.Models;
using Microsoft.IdentityModel.Tokens;
using NDDTraining.Domain.Services.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NDDTraining.Domain.Services.Security
{
    public static class TokenService
    {
        public static string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, user.Email)
                    // new Claim(ClaimTypes.Role, user.Role),
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

         public static string GenerateRefreshToken() //Método para gerar o RT
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        public static ClaimsPrincipal GetPrincipalFromExpiredToken(string token) //Recupera o Claims Principal
        {                                                                       //de TE (token expirado)
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Settings.Secret)),
                ValidateIssuer = false,
                ValidateAudience = false,
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var secutiryToken);

            if (secutiryToken is not JwtSecurityToken jwtSecurityToken)
                throw new SecurityTokenException("Invalid token");

            return principal;
        }

        private static List<Tuple<string, string>> _refreshsTokens = new List<Tuple<string, string>>();

       public static void SaveRefreshToken(string username, string refreshToken)
            => _refreshsTokens.Add(new Tuple<string, string>(username, refreshToken));
  
        public static string GetRefreshToken(string username)
            => _refreshsTokens.FirstOrDefault(x => x.Item1 == username).Item2;

        public static void DeleteRefreshToken(string username, string refreshToken)
        {
            var item = _refreshsTokens.FirstOrDefault(x => x.Item1 == username && x.Item2 == refreshToken);
            _refreshsTokens.Remove(item);
        }

    }
}