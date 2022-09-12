using EmployeeAPI.Model.Domain;
using EmployeeAPI.Repositories;
using Microsoft.AspNetCore.Routing.Matching;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EmployeeAPI.Services
{
    public class JwtAuthenticationManager:IJwtAuthenticationManager
    {
        //private readonly IDictionary<string , string> user = new Dictionary<string , string>()
        //{
            
        //    {"user1","password1" },
        //    {"user2","password2" }
        //};

        private readonly IEmployeeRepository employeeRepository;
        private readonly string key;
        public JwtAuthenticationManager(IEmployeeRepository employeeRepository, string key)
        {
            this.key = key;
            this.employeeRepository = employeeRepository;

        }
        public string Authenticate(string Username, string Password)
        {
            var employees = employeeRepository.GetAllEmployees();
            //if (!user.Any(u => u.Key == username && u.Value == password))
            //{
            //return null;
            //}
            if (!employees.Any(employees => employees.username == Username && employees.password == Password))
            {
                return null;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, Username)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),
                                SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            //return token.ToString();
            return tokenHandler.WriteToken(token);
        }
    }
}
    