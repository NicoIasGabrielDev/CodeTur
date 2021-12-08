using CodeTur.Comum.Entidades;
using Flunt.Validations;
using System.Collections.Generic;
using System.Linq;

namespace CodeTur.Dominio.Entidades
{
    public class Pacote : Entidade
    {
        private readonly List<Comentario> _comentarios;
        public Pacote(string titulo, string descricao, string imagem, bool ativo)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(titulo, "Titulo", "Informe o título do pacote")
                .IsNotNullOrEmpty(descricao, "Descricao", "Informe a do descrição do pacote")
                .IsNotNullOrEmpty(imagem, "Imagem", "Informe o link da imagem do pacote")
            );

            if (Valid)
            {
                Titulo = titulo;
                Descricao = descricao;
                Imagem = imagem;
                Ativo = ativo;
                _comentarios = new List<Comentario>();
            }
        }

        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public string Imagem { get; private set; }
        public bool Ativo { get; private set; }
        public IReadOnlyCollection<Comentario> Comentarios { get { return _comentarios.ToArray(); } }

        public void AdicionarComentario(Comentario comentario)
        {

            if (_comentarios.Any(x => x.IdUsuario == comentario.IdUsuario))
                AddNotification("Comentários", "Usuário já possui um comentário neste pacote");

            if (Valid)
                _comentarios.Add(comentario);
        }

        public void AtivarPacote()
        {
            Ativo = true;
        }

        public void DesativarPacote()
        {
            Ativo = false;
        }

        public void AtualizaPacote(string titulo, string descricao)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(titulo, "Titulo", "Informe o título do pacote")
                .IsNotNullOrEmpty(descricao, "Descricao", "Informe a descrição do pacote")
            );

            if (Valid)
            {
                Titulo = titulo;
                Descricao = descricao;
            }
        }

        public void AtualizaImagem(string imagem)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(imagem, "Imagem", "Informe a imagem do pacote")
            );

            if (Valid)
                Imagem = imagem;
        }
    }
}
