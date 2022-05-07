using Dominio.DAL.Contexto;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Dominio.DAL.Repositorios.SugestoesRepositorio
{
    public class SugestaoRepositorio : ISugestaoRepositorio
    {
        private readonly AppDbContext _context;

        public SugestaoRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(Sugestao entity)
        {
            await _context.AddAsync(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(Sugestao entity)
        {
            _context.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Update(Sugestao entity)
        {
            _context.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<IEnumerable<Sugestao>> GetAll(bool incluirDepartamento = false)
        {
            IQueryable<Sugestao> query = _context.Sugestoes;
            if (incluirDepartamento) query = query.Include(p => p.Departamento);

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Sugestao>> GetByDepartamento(int departamentoId)
        {
            return await _context
                .Sugestoes
                .Where(p => p.Departamento.Id == departamentoId).ToListAsync();
        }

        public async Task<Sugestao?> GetById(int id, bool asNoTracking = false, bool incluirDepartamento = false)
        {
            IQueryable<Sugestao> query = _context.Sugestoes;

            if (asNoTracking) query = query.AsNoTracking();
            if (incluirDepartamento) query = query.Include(p => p.Departamento);

            return await query.Where(p => p.Id == id).FirstOrDefaultAsync();

        }

    }
}
