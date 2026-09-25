namespace пара_11._09_bank;

internal class BankAccount
{
    static private int s_accountNumberSeed = 1000000000;
    public string Number { get;}
    public string Owner { get; private set; }
    public decimal Balance 
    {
        get
        {
            decimal balance = 0;
            foreach(var item in _allTransactions)
            {
                balance += item.Amount;
            }
            return balance;
        }
    }

    private List<Transaction> _allTransactions = new List<Transaction>();

    public BankAccount(string name, decimal initialBalance)
    {
        
        Owner = name; // this.Owner = name
        MakeDeposide(initialBalance, DateTime.UtcNow, "Initial balance");
        Number = s_accountNumberSeed.ToString();
        s_accountNumberSeed++;
    }

    public void MakeDeposide(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount),"Amount of deposite must be positive"); 
        }
        var deposide = new Transaction(amount, date, note);
        _allTransactions.Add(deposide);
    }

    public void MakeWithdrawal(decimal amount, DateTime date, string note)
    {
        
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            if (Balance < amount)
            {
                throw new InvalidOperationException("Not sufficien rubls for this withdawaL");
            }
        
            var withdrawal = new Transaction(-amount, date, note);
        _allTransactions.Add(withdrawal);
    }
}
