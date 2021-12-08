using CodeTur.Comum.Commands;
using CodeTur.Dominio.Commands.Usuario;
using CodeTur.Dominio.Handlers.Usuarios;
using CodeTur.Testes.Repositorios;
using Xunit;

namespace CodeTur.Testes.Handlers.Usuarios
{
    public class CriarUsuarioHandleTestes
    {
        [Fact]
        public void DeveRetornarErroCasoOsDadosDoHandleSejamInvalidos()
        {
            // criar um command
            var command = new CadastroUsuarioCommand();
            // criar um handle
            var handle = new CadastroUsuarioHandle(new FakeUsuarioRepositorio());
            //Pega o resultado
            var resultado = (GenericCommandResult)handle.Handle(command);
            //Validar Condicao
            Assert.False(resultado.Sucesso, "Usuario válido");
        }

        [Fact]
        public void DeveRetornarSucessoCasoOsDadosDoHandleSejamValidos()
        {
            // criar um command
            var command = new CadastroUsuarioCommand("Nicolas", "email8@email.com", "1234567", "", Comum.Enum.EnTipoUsuario.comum);
            // criar um handle
            var handle = new CadastroUsuarioHandle(new FakeUsuarioRepositorio()); 
            //Pega o resultado
            var resultado = (GenericCommandResult)handle.Handle(command);
            //Validar Condicao
            Assert.True(resultado.Sucesso, "Usuario inválido");
        }
    }
}
