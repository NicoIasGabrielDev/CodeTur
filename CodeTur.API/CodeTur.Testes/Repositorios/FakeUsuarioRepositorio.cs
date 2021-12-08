using CodeTur.Dominio.Entidades;
using CodeTur.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeTur.Testes.Repositorios
{
    public class FakeUsuarioRepositorio : IUsuarioRepositorio
    {
        List<Usuario> _usuarios = new List<Usuario>()
            {
                new Usuario("Nicolas", "email@email.com", "1234567", Comum.Enum.EnTipoUsuario.comum),
                new Usuario("Daiana", "email12@email.com", "1234567", Comum.Enum.EnTipoUsuario.comum)
            };

        public void Adicionar(Usuario usuario)
        {
            _usuarios.Add(usuario);
        }

        public void Alterar(Usuario usuario)
        {

        }

        public void AlterarSenha(Usuario usuario)
        {

        }

        public Usuario BuscarPorEmail(string email)
        {
            return _usuarios.FirstOrDefault(x => x.Email == email);

        }

        public Usuario BuscarPorId(Guid id)
        {
            return _usuarios.FirstOrDefault(x => x.Id == id);
        }

        public ICollection<Usuario> Listar(bool? Ativo = null)
        {
            return _usuarios;
        }
    }
}