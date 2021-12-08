using System;

namespace CodeTur.Comum.Queries
{
    public class GenericQueryResult : IQueryResult
    {
        public GenericQueryResult(bool sucesso, string mensagem, object data)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
            Data = data;
        }

        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public Object Data { get; set; }
    }
}
