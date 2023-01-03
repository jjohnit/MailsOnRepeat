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
        public static bool Send(MailDetails mailDetails)
        {
            var mailMessage = new MimeMessage();
            //mailMessage.From.Add(new MailboxAddress("from name", "from email"));
            //mailMessage.To.Add(new MailboxAddress("","to email"));
            mailMessage.Subject = mailDetails.Subject;
            mailMessage.Body = new TextPart("html")
            {
                Text = mailDetails.Body
            };

            try
            {
                using (var smtpClient = new SmtpClient())
                {
                    smtpClient.Connect("smtp.gmail.com", 465, true);
                    smtpClient.Authenticate(mailDetails.FromAddress, mailDetails.Password);
                    
                    for (int i = 0; i < mailDetails.MailCount; i++)
                    {
                        smtpClient.Send(mailMessage, new MailboxAddress(mailDetails.FromName, mailDetails.FromAddress),
                            mailDetails.Recipients.Select(x => MailboxAddress.Parse(x)));
                        Console.WriteLine($"Mail {i + 1} sent");
                    }
                    
                    smtpClient.Disconnect(true);
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
