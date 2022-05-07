using Flunt.Notifications;
namespace Dominio.Entidades
{
    public class BaseEntidade : Notifiable<Notification>
    {
        public int Id { get; private set; } = 0;
        public DateTime Data_Criacao { get; private set; } = DateTime.UtcNow;
        public DateTime Data_Atualizacao { get; private set; } = DateTime.UtcNow;

        public IList<string> RetornarNotificacoesString()
        {
            return Notifications.Select(p => new string($"{p.Key}, {p.Message}")).ToList();
        }
    }
}
