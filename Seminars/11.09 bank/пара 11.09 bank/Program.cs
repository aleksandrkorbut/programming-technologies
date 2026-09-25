namespace пара_11._09_bank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount account1 = new BankAccount("Aleks", 100000);
            BankAccount account2 = new BankAccount("Axel", 10);
            Console.WriteLine($"account {account1.Balance} №{account1.Number} {account1.Owner}");
            Console.WriteLine($"account {account2.Balance} №{account2.Number} {account2.Owner}");

            account1.MakeDeposide(2000000, DateTime.UtcNow, ":)");
            Console.WriteLine(account1.Balance);
            account1.MakeWithdrawal(1234, DateTime.UtcNow, ":(");
            Console.WriteLine(account1.Balance);

            try
            {
                account2.MakeWithdrawal(10000, DateTime.UtcNow, " ");
            }
            catch(InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
