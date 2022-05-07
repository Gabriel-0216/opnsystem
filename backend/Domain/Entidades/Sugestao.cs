using Dominio.Entidades.ObjetosDeValor;

namespace Dominio.Entidades
{
    public class Sugestao : BaseEntidade
    {
        public Nome? NomeColaborador { get; private set; }
        public Departamento? Departamento { get;  private set; }
        public string Descricao { get; private init; } = string.Empty;
        public string Justificativa { get; private init; } = string.Empty;


        protected Sugestao()
        {

        }
        public Sugestao(string nomeColaborador, Departamento departamento, string justificativa, string descricao)
        {
            Validacoes(nomeColaborador, departamento, justificativa, descricao);
            if (!IsValid) return;
            NomeColaborador = new Nome(nomeColaborador);
            Departamento = departamento;
            Justificativa = justificativa;
            Descricao = descricao;
        }
        private void Validacoes(string nomeColaborador, Departamento departamento, string justificativa, string descricao)
        {
            var nome = new Nome(nomeColaborador);
            if (!nome.IsValid) AddNotifications(nome.Notifications);
            if (!departamento.IsValid) AddNotifications(departamento.Notifications);
            if (string.IsNullOrEmpty(justificativa)) AddNotification(nameof(Justificativa), "Não pode ser vazia ou nula.");
            if (string.IsNullOrEmpty(descricao)) AddNotification(nameof(Descricao), "Não pode ser vazia ou nula.");
        }
    }
}
