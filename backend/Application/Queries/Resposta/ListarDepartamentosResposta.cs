namespace Application.Queries.Resposta;

public class ListarDepartamentosResposta
{
    public ListarDepartamentosResposta(int id,
        DateTime dataCriacao, DateTime dataAtualizacao, string nome,
        List<Sugestao> sugestoes)
    {
        Id = id;
        DataCriacao = dataCriacao;
        DataAtualizacao = dataAtualizacao;
        Nome = nome;
        Sugestoes = sugestoes;
    }
    public ListarDepartamentosResposta(int id,
        DateTime dataCriacao, DateTime dataAtualizacao, string nome)
    {
        Id = id;
        DataCriacao = dataCriacao;
        DataAtualizacao = dataAtualizacao;
        Nome = nome;
    }
    
    public int Id { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime DataAtualizacao { get; set; }
    public string Nome { get; set; }

    public IEnumerable<Sugestao?> Sugestoes { get; private set; } = new List<Sugestao?>();
    
    public record Sugestao(int Id, DateTime Data_Criacao, DateTime Data_Atualizacao, int DepartamentoId,
        string NomeColaborador, string Justificativa, string Descricao);
}