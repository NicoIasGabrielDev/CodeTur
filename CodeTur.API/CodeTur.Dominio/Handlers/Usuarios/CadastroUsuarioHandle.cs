using CodeTur.Comum.Commands;
using CodeTur.Comum.Handlers.Contracts;
using CodeTur.Comum.Util;
using CodeTur.Dominio.Commands.Usuario;
using CodeTur.Dominio.Entidades;
using CodeTur.Dominio.Repositorios;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Dominio.Handlers.Usuarios
{
    public class CadastroUsuarioHandle : Notifiable, IHandlerCommand<CadastroUsuarioCommand>
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public CadastroUsuarioHandle(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public ICommandResult Handle(CadastroUsuarioCommand command)
        {
        
            command.Validar();

            if (command.Invalid)
                return new GenericCommandResult(false, "Dados inválidos", command.Notifications);

            var usuarioExiste = _usuarioRepositorio.BuscarPorEmail(command.Email);

            if (usuarioExiste != null)
                return new GenericCommandResult(false, "E-mail já cadastrado, informe outro e-mail", null);

            // Criptografar Senha
            command.Senha = Senha.Criptografar(command.Senha);

            // Salvar no Banco
            var usuario = new Usuario(command.Nome, command.Email, command.Senha, command.TipoUsuario);
            if (!string.IsNullOrEmpty(command.Telefone))
                usuario.AdicionarTelefone(command.Telefone);

            if (usuario.Invalid)
                return new GenericCommandResult(false, "Dados inválidos", usuario.Notifications);

            _usuarioRepositorio.Adicionar(usuario);

            // Enviar Email de boas Vindas para o meu usuário
            

            return new GenericCommandResult(true, "Usuário Criado", null);
        }
    }
}
