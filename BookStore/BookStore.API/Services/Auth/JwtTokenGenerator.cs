using BookStore.API.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace BookStore.API.Services.Auth
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly IConfiguration _configuration;
        


        public JwtTokenGenerator(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Generate(AppUser user)
        {
            
            // Claims
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name , user.UserName),
                new Claim(ClaimTypes.Email , user.Email),
            };

                //SecretKey
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secert"]));

                var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // token 
                var token = new JwtSecurityToken(
                   issuer: _configuration["JWT:ValidIssuer"],
                   audience: _configuration["JWT:ValidAudience"],
                   claims: claims,
                   expires: DateTime.Now.AddMinutes(10),
                   signingCredentials: cred);

                return new JwtSecurityTokenHandler().WriteToken(token);
           
            
        }
    }
}
