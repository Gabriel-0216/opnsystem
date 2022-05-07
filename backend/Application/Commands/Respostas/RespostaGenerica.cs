namespace Application.Commands.Respostas;

public class RespostaGenerica
{
    public int Id { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime DataAtualizacao { get; set; }
    public List<Erro> Erros { get; private set; } = new List<Erro>();

    public void AdicionarErro(string mensagem) => Erros.Add(new Erro(mensagem));
    public void AdicionarErros(IEnumerable<string> mensagens) => Erros.AddRange(mensagens.Select(item => new Erro(item)));
    public bool SucessoOperacao() => Erros.Count == 0;
    public record Erro(string MensagemErro);
}