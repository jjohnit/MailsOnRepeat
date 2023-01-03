using Microsoft.Extensions.Configuration;

namespace MailsOnRepeat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Get credentials from the appSettings file
            var config = new ConfigurationBuilder()
                .AddJsonFile($"AppSettings.json").Build();

            while (true)
            {
                //Console.WriteLine("Enter recipient mails : ");
                //var recipients = Console.ReadLine()?.Split(',').ToList();
                var recipients = new List<String>() { "RepeatMailTest1@yopmail.com", "RepeatMailTest2@yopmail.com" };
                //if (recipients is null || recipients.Count <= 0)
                //{
                //    Console.WriteLine("Provide valid recipients");
                //    continue;
                //}
                //Console.WriteLine("Enter the number of mails to send : ");
                //short count = Convert.ToInt16(Console.ReadLine());

                MailDetails mailDetails = new MailDetails()
                {
                    FromName = config["Credentials:Name"],
                    FromAddress = config["Credentials:Username"],
                    Password = config["Credentials:Password"],
                    Recipients = recipients,
                    Subject = "PLEASE STOP MAILING ME",
                    Body = "<p>Hi,<br/></p><p>As I have informed before, I have moved to the US and I'm not considering jobs in india anymore. So,</p>" +
                    "<H3>PLEASE STOP MAILING ME</H3><br/><br/><p>Regards,</p><p>Johnit Jasan</p>"
                };

                Console.WriteLine(SendMail.Send(mailDetails));
                break;
            }
        }
    }
}