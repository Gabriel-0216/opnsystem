using Dominio.Entidades.ObjetosDeValor;

namespace Dominio.Entidades
{
    public class Departamento : BaseEntidade
    {
        public Nome? NomeDepartamento { get; private set; }
        public IList<Sugestao> Sugestoes { get; private set; } = new List<Sugestao>();
        protected Departamento()
        {
        }
        public Departamento(string nomeDepartamento)
        {
            Validacoes(nomeDepartamento);
            if (IsValid) NomeDepartamento = new Nome(nomeDepartamento);
        }

        public void EditarNome(string nomeDepartamento)
        {
            Validacoes(nomeDepartamento);
            if (IsValid) NomeDepartamento = new Nome(nomeDepartamento);
        }
        private void Validacoes(string nomeDepartamento)
        {
            var nome = new Nome(nomeDepartamento);
            if (!nome.IsValid) AddNotifications(nome.Notifications);
        }
        public void AdicionarSugestao(Sugestao sugestao)
        {
            if(sugestao.IsValid) Sugestoes.Add(sugestao);
        }
    }
}
