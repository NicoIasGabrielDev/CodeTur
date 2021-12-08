using CodeTur.Dominio.Commands.Usuario;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CodeTur.Testes.Commands
{
    public class CadastroUsuarioCommandTestes
    {
        [Fact]

        public void DeveRetornarErrosdeDados()
        {
            var command = new CadastroUsuarioCommand();
            command.Validar();
            Assert.True(command.Invalid, "As informações foram devidamentes preenchidas");
        }
    }
}
