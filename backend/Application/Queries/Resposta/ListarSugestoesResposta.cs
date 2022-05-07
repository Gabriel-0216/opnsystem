namespace Application.Queries.Resposta;

public class ListarSugestoesResposta
{
    public ListarSugestoesResposta(int id, DateTime dataCriacao, DateTime dataAtualizacao, int departamentoId,
        DepartamentoDto? departamento, string nomeColaborador, string justificativa, string descricao )
    {
        Id = id;
        Data_Criacao = dataCriacao;
        Data_Atualizacao = dataAtualizacao;
        DepartamentoId = departamentoId;
        Departamento = departamento;
        NomeColaborador = nomeColaborador;
        Justificativa = justificativa;
        Descricao = descricao;
    }
    public int Id { get; set; }
    public DateTime Data_Criacao { get; set; }
    public DateTime Data_Atualizacao { get; set; }
    public int DepartamentoId { get; set; }
    public DepartamentoDto? Departamento { get; set; }
    public string NomeColaborador { get; set; }
    public string Justificativa { get; set; }
    public string Descricao { get; set; }
    
    public record DepartamentoDto(int Id, DateTime DataCriacao, DateTime DataAtualizacao, string Nome);
}