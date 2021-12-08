using CodeTur.Comum.Commands;
using CodeTur.Comum.Enum;
using CodeTur.Comum.Queries;
using CodeTur.Dominio.Commands.Pacote;
using CodeTur.Dominio.Handlers.Pacotes;
using CodeTur.Dominio.Queries.Pacote;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace CodeTur.Api.Controllers
{
    [Route("v1/pacotes")]
    [ApiController]
    public class PacoteController : ControllerBase
    {
        [HttpPost]
        [Authorize(Roles = "admin")]
        public GenericCommandResult Create(CadastroPacoteCommand command,[FromServices] AlterarPacoteCommandHandle handle)
        {
            return (GenericCommandResult)handle.Handle(command);
        }


        [HttpGet]
        [Authorize]
        public GenericQueryResult GetAll([FromServices] ListarPacoteQueryHandle handle)
        {
            ListarPacotesQuery query = new ListarPacotesQuery();

            var tipoUsuario = HttpContext.User.Claims.FirstOrDefault(t => t.Type == ClaimTypes.Role);

            if (tipoUsuario.Value.ToString() == EnTipoUsuario.comum.ToString())
                query.Ativo = true;

            return (GenericQueryResult)handle.Handle(query);
        }

        [HttpPut]
        [Authorize]
        public GenericCommandResult Edit(AlterarPacoteCommand command ,[FromServices] AlterarPacoteCommandHandle handle)
        {
            AlterarPacoteCommand query = new AlterarPacoteCommand();

            var tipoUsuario = HttpContext.User.Claims.FirstOrDefault(t => t.Type == ClaimTypes.Role);

            if (tipoUsuario.Value.ToString() == EnTipoUsuario.comum.ToString())
                query.Ativo = true;

            return (GenericQueryResult)handle.Handle(command);
        }

    }
}
