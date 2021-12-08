using CodeTur.Comum.Commands;
using CodeTur.Comum.Handlers.Contracts;
using CodeTur.Comum.Util;
using CodeTur.Dominio.Commands.Usuario;
using CodeTur.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Dominio.Handlers.Usuarios
{
    public class LoginHandle : IHandlerCommand<LoginCommand>
    {
        private readonly IUsuarioRepositorio _repositorio;

        public LoginHandle(IUsuarioRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public ICommandResult Handle(LoginCommand command)
        {
            //Comand é valido
            command.Validar();

            if (command.Invalid)
                return new GenericCommandResult(false, "Dados inválidos", command.Notifications);

            //Buscar usuario pelo email
            var usuario = _repositorio.BuscarPorEmail(command.Email);

            //Usuario existe
            if (usuario == null)
                return new GenericCommandResult(false, "Email inválido", null);

            //Validar Senha
            if (!Senha.Validar(command.Senha, usuario.Senha))
                return new GenericCommandResult(false, "Senha inválida", null);

            //retorna true com os dados do usuário
            return new GenericCommandResult(true, "Usuário Logado", usuario);
        }
    }
}
