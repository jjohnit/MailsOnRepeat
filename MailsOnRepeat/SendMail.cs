using MimeKit;
using MailKit.Net.Smtp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailsOnRepeat
{
    internal static class SendMail
    {
        public static bool Send()
        {
            var mailMessage = new MimeMessage();
            mailMessage.From.Add(new MailboxAddress("from name", "from email"));
            mailMessage.To.Add(new MailboxAddress("to name", "to email"));
            mailMessage.Subject = "subject";
            mailMessage.Body = new TextPart("plain")
            {
                Text = "Hello"
            };

            using (var smtpClient = new SmtpClient())
            {
                smtpClient.Connect("smtp.gmail.com", 587, true);
                smtpClient.Authenticate("user", "password");
                smtpClient.Send(mailMessage);
                smtpClient.Disconnect(true);
            }

            return true;
        }
    }
}
