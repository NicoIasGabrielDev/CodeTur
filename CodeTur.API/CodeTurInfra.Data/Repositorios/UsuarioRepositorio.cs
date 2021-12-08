using CodeTur.Dominio.Entidades;
using CodeTur.Dominio.Repositorios;
using CodeTurInfra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeTur.Infra.Data.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly CodeTurContext _context;

        public UsuarioRepositorio(CodeTurContext context)
        {
            _context = context;
        }

        public void Adicionar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public void Alterar(Usuario usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
            _context.SaveChanges();
        }


        public Usuario BuscarPorEmail(string email)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Email.ToLower() == email.ToLower());
        }

        public Usuario BuscarPorId(Guid id)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        public ICollection<Usuario> Listar(bool? Ativo = null)
        {
            return _context
                         .Usuarios
                         .AsNoTracking()
                         .Include(x => x.Comentarios)
                         .OrderBy(x => x.DataCriacao)
                         .ToList();
        }
    }
}
