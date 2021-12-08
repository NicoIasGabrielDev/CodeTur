using CodeTur.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace CodeTur.Dominio.Commands.Pacote
{
    public class AlterarPacoteCommand : Notifiable, ICommand

    {
        public AlterarPacoteCommand()
        {

        }
        public Guid Id { get; set; }
        public string Titulo { get;  set; }
        public string Descricao { get;  set; }
        public string Imagem { get;  set; }
        public bool Ativo { get;  set; }

        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(Titulo, "Titulo", "Informe o título do pacote")
                .IsNotNullOrEmpty(Descricao, "Descricao", "Informe a descrição do pacote")
                .IsNotNullOrEmpty(Imagem, "Imagem", "Informe o link da imagem do pacote")
            );
        }
    }
}
