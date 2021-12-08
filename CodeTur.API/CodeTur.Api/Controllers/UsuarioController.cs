using CodeTur.Comum.Commands;
using CodeTur.Dominio.Commands.Usuario;
using CodeTur.Dominio.Entidades;
using CodeTur.Dominio.Handlers.Usuarios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CodeTur.Api.Controllers
{

    [Route("v1/conta")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [Route("cadastro")]
        [HttpPost]
        public GenericCommandResult SignUp(CadastroUsuarioCommand command, [FromServices] CadastroUsuarioHandle handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }


        [Route("login")]
        [HttpPost]
        public GenericCommandResult SignIn(LoginCommand command, [FromServices] LoginHandle handler)
        {
            var resultado = (GenericCommandResult)handler.Handle(command);

            if (resultado.Sucesso)
            {
                var token = GerarJSONWebToken((Usuario)resultado.Data);

                return new GenericCommandResult(resultado.Sucesso, resultado.Mensagem, new { token = token });
            }

            return new GenericCommandResult(false, resultado.Mensagem, resultado.Data);
        }

        // Criamos nosso método que vai gerar nosso Token
        private string GerarJSONWebToken(Usuario userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ChaveSecretaCodeTur"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Definimos nossas Claims (dados da sessão) para poderem ser capturadas
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.FamilyName, userInfo.Nome),
                new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
                new Claim(ClaimTypes.Role, userInfo.TipoUsuario.ToString()),
                new Claim("role", userInfo.TipoUsuario.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, userInfo.Id.ToString())
            };

            var token = new JwtSecurityToken
                (
                    "codetur",
                    "codetur",
                    claims,
                    expires: DateTime.Now.AddMinutes(120),
                    signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
