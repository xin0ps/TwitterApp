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
            string fromMail = "steptest226@gmail.com";
            string fromPassword = "hibihdeorcokmndd";

            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);

            message.Subject = subject;
            message.To.Add(new MailAddress(tomail));

            message.Body = $"<html><body><p style='font-size: 50px; color: black;'>Hello,<br/><br/>Verification Code: <span style='font-weight: bold;'>{_message}</span></p></body></html>";

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


