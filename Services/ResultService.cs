using System.Linq;
using System.Net.Mail;
using ModelEntities.ModelViews;

namespace Services
{
    public class ResultService
    {
        public void SendByMail(ResultViewModel result, string to)
        {
            var totalAnswers = result.Answers.Count;
            var totalCorrects = result.Answers.Where(q => q.IsCorrect).Count();

            MailMessage mail = new MailMessage("anthony@proxiad.com", to);
            mail.Subject = "Résultat du test technique";
            mail.Body = $"Vous avez obtenu un résultat de {totalCorrects}/{totalAnswers}";

            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "smtp.proxiad.com";
            client.Send(mail);
        }
    }
}
