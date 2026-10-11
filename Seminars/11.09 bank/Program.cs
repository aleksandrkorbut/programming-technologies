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
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            InterestEarningAccount InterestEarning = new("Axel", 1000m);
            InterestEarning.MakeDeposide(100m, DateTime.UtcNow, " ;)");
            InterestEarning.MakeWithdrawal(10M, DateTime.UtcNow, ";( ");
            InterestEarning.PerformMorthAndTransaction();

            Console.WriteLine(InterestEarning.ToString());
            // /Console.WriteLine(InterestEarning); эквивалента верхней
            Console.WriteLine(InterestEarning.GetAccountHistory());

            GiftCartAccount giftCart = new("Axel", 1000m, 5000);
            giftCart.MakeDeposide(100m, DateTime.UtcNow, " ;)");
            giftCart.MakeWithdrawal(10M, DateTime.UtcNow, ";( ");
            giftCart.PerformMorthAndTransaction();

            Console.WriteLine(giftCart);
            Console.WriteLine(giftCart.GetAccountHistory());

            LineOnCreditAccount LineOnCredit = new LineOnCreditAccount("Aleks", 0, 1000m);
            LineOnCredit.MakeWithdrawal(500m, DateTime.UtcNow, "credit");
            GiftCartAccount GiftCart = new GiftCartAccount("Aleks", 1000m, 5000m);
            List<BankAccount> accounts = new List<BankAccount>();
            accounts.Add(account1);
            accounts.Add(giftCart);
            accounts.Add(LineOnCredit);
            accounts.Add(InterestEarning);
            
            foreach(BankAccount account in accounts)
            {
                Console.WriteLine(account); // == Console.WriteLine(account.ToString)
                account.PerformMorthAndTransaction();
                Console.WriteLine(account.GetAccountHistory());
            }
        }
    }
}
