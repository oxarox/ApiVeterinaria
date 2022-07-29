using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NetCoreAPIMySQL.Data.Repositories;
using NetCoreAPIMySQL.Model;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;

namespace Siglo21APIRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginController(IUsuarioRepository usuarioRepository, IConfiguration config)
        {
            _config = config;
            _usuarioRepository = usuarioRepository;
        }
        [AllowAnonymous]


        [HttpPost]
        public IActionResult Login([FromBody] Usuario usuario)
        {
            IActionResult response = Unauthorized();
            Usuario user = AuthenticateUser(usuario);

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }

        private string GenerateJSONWebToken(Usuario userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private Usuario AuthenticateUser(Usuario login)
        {
            //Usuario user = _usuarioRepository.comprobarCredencialesUsuario(login.nombre_usuario, login.password);
            Usuario user = null;
            //Validate the User Credentials    
            //Demo Purpose, I have Passed HardCoded User Information    
            if (login.nombre_usuario == "Jignesh")
            {
                //user = new Usuario { Username = "Jignesh Trivedi", EmailAddress = "test.btest@gmail.com" };
                user = new Usuario
                {
                    id_usuario = 0,
                    nombre_usuario = "string",
                    password = "string",
                    cargo = "string",
                    token = "string"
                };
            }
            return user;
        }
    } 
}
