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
                        Thread.Sleep(30000);    // Wait for 30 seconds
                    }
                    
                    smtpClient.Disconnect(true);
                    Console.WriteLine("Operation completed.");
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
