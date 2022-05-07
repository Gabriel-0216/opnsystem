using Dominio.DAL.Contexto;
using Dominio.Entidades;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Dominio.DAL.Repositorios.DepartamentoRepositorio;

public class DepartamentoRepositorio : IDepartamentoRepositorio
{
    private readonly AppDbContext _context;

    public DepartamentoRepositorio(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Add(Departamento entity)
    {
        await _context.AddAsync(entity);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Update(Departamento entity)
    {
        _context.Update(entity);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Delete(Departamento entity)
    {
        try
        {
            _context.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }
        catch (SqlException)
        {
            return false;
        }
    }

    public async Task<Departamento?> GetById(int id, bool asNoTracking = false, bool incluirSugestoes = false)
    {
        IQueryable<Departamento> query = _context.Departamentos;
        if (asNoTracking) query = query.AsNoTracking();
        if (incluirSugestoes) query = query.Include(p => p.Sugestoes);

        return await query.Where(p => p.Id == id).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Departamento>> GetAll(bool incluirSugestoes = false)
    {
        IQueryable<Departamento> query = _context.Departamentos;
        if (incluirSugestoes) query = query.Include(p => p.Sugestoes);

        return await query.ToListAsync();
    }
}