using CodeTur.Comum.Enum;
using CodeTur.Dominio.Entidades;
using Xunit;

namespace CodeTur.Testes.Entidades
{
    public class UsuarioTestes
    {
        [Fact]
        public void RetornarErroseUsuarioInvalido()
        {
            var usuario = new Usuario("", "nicolas@email.com", "123456", EnTipoUsuario.comum );
            Assert.True(usuario.Invalid, "O usuário é inválido");
        }

        [Fact]
        public void RetornarSucessoeUsuarioInvalido()
        {
            var usuario = new Usuario("Nicolas", "nicolas@email.com", "123456", EnTipoUsuario.comum);
            Assert.True(usuario.Valid, "O usuário é válido");
        }

        [Fact]
        public void RetornarErroseEmailInvalido()
        {
            var usuario = new Usuario("Nicolas", "nicolasemail.com", "123456", EnTipoUsuario.comum);
            Assert.True(usuario.Invalid, "O usuário é válido");
        }
    }
}
