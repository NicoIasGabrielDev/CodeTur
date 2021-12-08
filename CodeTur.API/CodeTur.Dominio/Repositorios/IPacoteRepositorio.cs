using CodeTur.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Dominio.Repositorios
{
    public interface IPacoteRepositorio
    {
        /// <summary>
        /// Cadastrar um pacote
        /// </summary>
        /// <param name="pacote">Dados do Pacote</param>
        void Adicionar(Pacote pacote);
        /// <summary>
        /// Alterar dados do Pacote
        /// </summary>
        /// <param name="pacote">Alterar dados</param>
        void Alterar(Pacote pacote);
        IEnumerable<Pacote> Listar(bool? ativo = null);
        Pacote BuscarPorTitulo(string titulo);
        Pacote BuscarPorId(Guid id);
    }
}