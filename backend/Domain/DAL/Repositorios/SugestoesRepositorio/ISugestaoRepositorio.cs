using Dominio.Entidades;

namespace Dominio.DAL.Repositorios.SugestoesRepositorio
{
    public interface ISugestaoRepositorio : IRepositorio<Sugestao>
    {
        Task<Sugestao?> GetById(int id, bool asNoTracking = false, bool incluirDepartamento = false);
        Task<IEnumerable<Sugestao>> GetAll(bool incluirDepartamento = false);
        Task<IEnumerable<Sugestao>> GetByDepartamento(int departamentoId);

    }
}
