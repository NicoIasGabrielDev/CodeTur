using CodeTur.Comum.Queries;
using System;

namespace CodeTur.Dominio.Queries.Pacote
{
    public class ListarPacotesQuery : IQuery
    {
        public bool? Ativo { get; set; } = null;
        public void Validar()
        {

        }
    }

    public class ListarPacotesQueryResult
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public bool Ativo { get; set; }
        public int QuantidadeComentarios { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
