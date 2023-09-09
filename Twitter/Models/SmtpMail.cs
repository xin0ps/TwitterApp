using System;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Threading.Tasks;


namespace Twitter.Models
{

    static internal class sendEmail
    {
        static public void send(string tomail, string subject, string _message)
        {
            string fromMail = "pass";
            string fromPassword = "pass";

            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);

            message.Subject = subject;
            message.To.Add(new MailAddress(tomail));

            message.Body = $"<html><body>{_message}</body></html>";
            message.IsBodyHtml = true;

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail, fromPassword),
                EnableSsl = true
            };

            smtpClient.Send(message);
            Console.WriteLine("\nMail gönderildi.");
        }

    }
}


