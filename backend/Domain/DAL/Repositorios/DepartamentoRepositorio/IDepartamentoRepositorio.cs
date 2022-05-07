using Dominio.Entidades;

namespace Dominio.DAL.Repositorios.DepartamentoRepositorio;

public interface IDepartamentoRepositorio : IRepositorio<Departamento>
{
    Task<Departamento?> GetById(int id, bool asNoTracking = false, bool incluirSugestoes = false);
    Task<IEnumerable<Departamento>> GetAll(bool incluirSugestoes = false);
}