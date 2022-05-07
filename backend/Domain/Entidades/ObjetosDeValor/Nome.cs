namespace Dominio.Entidades.ObjetosDeValor
{
    public class Nome : ObjetoDeValor
    {
        public string Descricao { get; set; } = string.Empty;

        protected Nome()
        {

        }
        public Nome(string descricaoNome)
        {
            Validacoes(descricaoNome);
            if (IsValid)
            {
                Descricao = descricaoNome;
            }
        }
        private void Validacoes(string descricao)
        {
            if (string.IsNullOrEmpty(descricao)) AddNotification(nameof(descricao), "não pode ser vazio ou nulo");
        }

    }
}
