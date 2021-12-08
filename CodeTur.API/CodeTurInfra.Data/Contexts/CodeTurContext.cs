using CodeTur.Dominio.Entidades;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTurInfra.Data.Contexts
{
    public class CodeTurContext : DbContext

    {
        public CodeTurContext(DbContextOptions<CodeTurContext> options):
            base(options)
        {}

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pacote> Pacotes { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();

            #region Mapeamento Tabela Usuarios
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
            modelBuilder.Entity<Usuario>().Property(x => x.Id);
            //Nome
            modelBuilder.Entity<Usuario>().Property(x => x.Nome).HasMaxLength(40);
            modelBuilder.Entity<Usuario>().Property(x => x.Nome).HasColumnType("varchar(40)");
            modelBuilder.Entity<Usuario>().Property(x => x.Nome).IsRequired();
            //Email
            modelBuilder.Entity<Usuario>().Property(x => x.Email).HasMaxLength(60);
            modelBuilder.Entity<Usuario>().Property(x => x.Email).HasColumnType("varchar(60)");
            modelBuilder.Entity<Usuario>().Property(x => x.Email).IsRequired();
            //Senha
            modelBuilder.Entity<Usuario>().Property(x => x.Senha).HasMaxLength(60);
            modelBuilder.Entity<Usuario>().Property(x => x.Senha).HasColumnType("varchar(60)");
            modelBuilder.Entity<Usuario>().Property(x => x.Senha).IsRequired();
            //Telefone
            modelBuilder.Entity<Usuario>().Property(x => x.Telefone).HasMaxLength(11);
            modelBuilder.Entity<Usuario>().Property(x => x.Telefone).HasColumnType("varchar(11)");

            //Relacionamento Um para Muitos - Usuário Comentários
            modelBuilder.Entity<Usuario>()
                                .HasMany(c => c.Comentarios)
                                .WithOne(u => u.Usuario)
                                .HasForeignKey(fk => fk.IdUsuario);

            //Datas
            modelBuilder.Entity<Usuario>().Property(x => x.DataCriacao).HasColumnType("DateTime");
            modelBuilder.Entity<Usuario>().Property(x => x.DataAlteracao).HasColumnType("DateTime");
            #endregion

            #region Mapeamento Pacote
            modelBuilder.Entity<Pacote>().ToTable("Pacotes");
            //Defini como chave primaria
            modelBuilder.Entity<Pacote>().Property(x => x.Id);
            //Titulo
            modelBuilder.Entity<Pacote>().Property(x => x.Titulo).HasMaxLength(120);
            modelBuilder.Entity<Pacote>().Property(x => x.Titulo).HasColumnType("varchar(120)");
            modelBuilder.Entity<Pacote>().Property(x => x.Titulo).IsRequired();
            //Descrição
            modelBuilder.Entity<Pacote>().Property(x => x.Descricao).HasColumnType("Text");
            modelBuilder.Entity<Pacote>().Property(x => x.Descricao).IsRequired();
            //Imagem
            modelBuilder.Entity<Pacote>().Property(x => x.Imagem).HasMaxLength(250);
            modelBuilder.Entity<Pacote>().Property(x => x.Imagem).HasColumnType("varchar(350)");
            modelBuilder.Entity<Pacote>().Property(x => x.Imagem).IsRequired();
            //Ativo
            modelBuilder.Entity<Pacote>().Property(x => x.Ativo).HasColumnType("bit");
            //Relacionamento
            modelBuilder.Entity<Pacote>().HasMany(c => c.Comentarios).WithOne(e => e.Pacote).HasForeignKey(x => x.IdPacote);
            //DataCriacao
            modelBuilder.Entity<Usuario>().Property(t => t.DataCriacao).HasColumnType("DateTime");
            modelBuilder.Entity<Usuario>().Property(t => t.DataCriacao).HasDefaultValueSql("GetDate()");
            //DataAlteracao
            modelBuilder.Entity<Usuario>().Property(t => t.DataAlteracao).HasColumnType("DateTime");
            modelBuilder.Entity<Usuario>().Property(t => t.DataAlteracao).HasDefaultValueSql("GetDate()");
            #endregion

            #region Mapeamento Comentario
            modelBuilder.Entity<Comentario>().ToTable("Comentarios");
            //Defini como chave primaria
            modelBuilder.Entity<Comentario>().Property(x => x.Id);
            //Texto
            modelBuilder.Entity<Comentario>().Property(x => x.Texto).HasMaxLength(500);
            modelBuilder.Entity<Comentario>().Property(x => x.Texto).HasColumnType("varchar(500)");
            modelBuilder.Entity<Comentario>().Property(x => x.Texto).IsRequired();
            //Sentimento
            modelBuilder.Entity<Comentario>().Property(x => x.Sentimento).HasMaxLength(40);
            modelBuilder.Entity<Comentario>().Property(x => x.Sentimento).HasColumnType("varchar(100)");
            modelBuilder.Entity<Comentario>().Property(x => x.Sentimento).IsRequired();
            //Status
            modelBuilder.Entity<Comentario>().Property(x => x.Status).HasColumnType("int");

            //DataCriacao
            modelBuilder.Entity<Usuario>().Property(t => t.DataCriacao).HasColumnType("DateTime");
            modelBuilder.Entity<Usuario>().Property(t => t.DataCriacao).HasDefaultValueSql("GetDate()");
            //DataAlteracao
            modelBuilder.Entity<Usuario>().Property(t => t.DataAlteracao).HasColumnType("DateTime");
            modelBuilder.Entity<Usuario>().Property(t => t.DataAlteracao).HasDefaultValueSql("GetDate()");
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
