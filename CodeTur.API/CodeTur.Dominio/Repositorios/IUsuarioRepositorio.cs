using CodeTur.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Dominio.Repositorios
{
    public interface IUsuarioRepositorio
    {
        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        /// <param name="usuario">Dados do usuário</param>
        void Adicionar(Usuario usuario);

        /// <summary>
        /// altera os dados do usuário
        /// </summary>
        /// <param name="usuario">Dados do usuário</param>
        void Alterar(Usuario usuario);

        Usuario BuscarPorEmail(string email);
        Usuario BuscarPorId(Guid id);
        ICollection<Usuario> Listar(bool? Ativo = null);
    }
}

