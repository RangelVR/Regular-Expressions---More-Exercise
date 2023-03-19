using System.Text.RegularExpressions;

string[] ticketsList = Console.ReadLine()
    .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

string pattern = @"(\@{6,}|\${6,}|\^{6,}|\#{6,})";

foreach (string ticket in ticketsList)
{
    if (ticket.Length == 20)
    {
        Match left = Regex.Match(ticket.Substring(0, 10), pattern);
        Match right = Regex.Match(ticket.Substring(10), pattern);
        int minLength = Math.Min(left.Length, right.Length);

        if (left.Success && right.Success)
        {
            string winLeft = left.Value.Substring(0, minLength);
            string winRight = right.Value.Substring(0, minLength);

            if (winLeft.Length + winRight.Length == 20)
            {
                Console.WriteLine($"ticket \"{ticket}\" - {winLeft.Length}{winLeft[0]} Jackpot!");
            }
            else
            {
                Console.WriteLine($"ticket \"{ticket}\" - {winLeft.Length}{winLeft[0]}");
            }
        }
        else
        {
            Console.WriteLine($"ticket \"{ticket}\" - no match");
        }

    }
    else
    {
        Console.WriteLine("invalid ticket");
    }
}
