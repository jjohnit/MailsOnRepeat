using Microsoft.Extensions.Configuration;

namespace MailsOnRepeat
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // Get credentials from the appSettings file
            var config = new ConfigurationBuilder()
                .AddJsonFile($"AppSettings.json").Build();

            while (true)
            {
                Console.WriteLine("Enter recipient mails : ");
                var recipients = Console.ReadLine()?.Split(',').ToList();
                recipients?.ForEach(x => x.Trim());
                //var recipients = new List<String>() { "RepeatMailTest1@yopmail.com", "RepeatMailTest2@yopmail.com" };
                if (recipients is null || recipients.Count <= 0)
                {
                    Console.WriteLine("Provide valid recipients");
                    continue;
                }
                Console.WriteLine("Enter the number of mails to send : ");
                short count = Convert.ToInt16(Console.ReadLine());

                MailDetails mailDetails = new MailDetails()
                {
                    FromName = config["Credentials:Name"],
                    FromAddress = config["Credentials:Username"],
                    Password = config["Credentials:Password"],
                    Recipients = recipients,
                    MailCount = count,
                    Subject = config["Credentials:Subject"],
                    Body = config["Credentials:Body"]
                };

                bool status = await Task.Run(() => SendMail.Send(mailDetails));
                Console.WriteLine($"Mails sent : {status}\nDo you want to continue (y/n) : ");
                if (Console.ReadLine()?.ToLower() == "n")
                    break;
            }
        }
    }
}