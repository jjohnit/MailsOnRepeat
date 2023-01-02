namespace MailsOnRepeat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine("Enter recipient mails : ");
                var recipients = Console.ReadLine()?.Split(',').ToList();
                if (recipients is null || recipients.Count <= 0)
                {
                    Console.WriteLine("Provide valid recipients");
                    continue;
                }
                Console.WriteLine("Enter the number of mails to send : ");
                short count = Convert.ToInt16(Console.ReadLine());
            }
        }
    }
}