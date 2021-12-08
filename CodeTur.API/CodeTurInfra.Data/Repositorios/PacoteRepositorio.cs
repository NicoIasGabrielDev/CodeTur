using CodeTur.Dominio.Entidades;
using CodeTur.Dominio.Repositorios;
using CodeTurInfra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeTur.Infra.Data.Repositorios
{
    public class PacoteRepositorio : IPacoteRepositorio
    {
        private readonly CodeTurContext _context;
        public PacoteRepositorio(CodeTurContext context)
        {
            _context = context;
        }

        public void Adicionar(Pacote pacote)
        {
            _context.Pacotes.Add(pacote);
            _context.SaveChanges();
        }

        public void Alterar(Pacote pacote)
        {
            _context.Entry(pacote).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Pacote BuscarPorId(Guid id)
        {
            return _context.Pacotes.FirstOrDefault(p => p.Id == id);
        }

        public Pacote BuscarPorTitulo(string titulo)
        {
            return _context.Pacotes.FirstOrDefault(p => p.Titulo.ToLower() == titulo.ToLower());
        }

        public IEnumerable<Pacote> Listar(bool? ativo = null)
        {
            if (ativo == null)
                return _context
                            .Pacotes
                            .AsNoTracking()
                            .Include(p => p.Comentarios)
                            .OrderBy(p => p.DataCriacao);
            else
                return _context
                            .Pacotes
                            .AsNoTracking()
                            .Include(p => p.Comentarios)
                            .Where(p => p.Ativo == ativo)
                            .OrderBy(p => p.DataCriacao);
        }
    }
}