using CodeTur.Comum.Commands;
using CodeTur.Comum.Handlers.Contracts;
using CodeTur.Dominio.Commands.Pacote;
using CodeTur.Dominio.Entidades;
using CodeTur.Dominio.Repositorios;
using System;

namespace CodeTur.Dominio.Handlers.Pacotes
{
    public class AlterarPacoteCommandHandle : IHandlerCommand<CadastroPacoteCommand>
    {
        private readonly IPacoteRepositorio _pacoteRepositorio;

        public AlterarPacoteCommandHandle(IPacoteRepositorio pacoteRepositorio)
        {
            _pacoteRepositorio = pacoteRepositorio;
        }

        public ICommandResult Handle(CadastroPacoteCommand command)
        {
            //Validação dos dados
            command.Validar();

            if (command.Invalid)
                return new GenericCommandResult(true, "Dados inválidos", command.Notifications);

            //Verifica a existência do pacote com o mesmo titulo
            var pacoteexiste = _pacoteRepositorio.BuscarPorTitulo(command.Titulo);

            if (pacoteexiste != null)
                return new GenericCommandResult(true, "Titulo do pacote já cadastrado", null);

            
            var pacote = new Pacote(command.Titulo, command.Descricao, command.Imagem, command.Ativo);

            if (pacote.Invalid)
                return new GenericCommandResult(true, "Dados inválidos", pacote.Notifications);

            //Adicionar pacote
            _pacoteRepositorio.Adicionar(pacote);

            //Retorno de sucesso
            return new GenericCommandResult(true, "Pacote criado", pacote);

        }
    }
}