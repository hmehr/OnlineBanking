using System.Net.Mail;

namespace INSE6260.OnlineBanking.Infrastructure.Email
{
    public class SMTPService : IEmailService
    {
        public void SendMail(string from, string to, string subject, string body)
        {
            var message = new MailMessage {Subject = subject, Body = body};
            var smtp = new SmtpClient();
            smtp.Send(message);
        }
    }

}
