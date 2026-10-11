using System.Text;
using System.Threading.Channels;

namespace пара_11._09_bank;
// Bank account - потом object => можно переопределить виртуальные методы, находящиеся в object
/// <summary>
/// класс BankAccount 
/// </summary>
public class BankAccount
{
    /// <summary>
    /// показывает реальный минимальный баланс
    /// </summary>
    private readonly decimal _minimalBalancs;
    /// <summary>
    /// начальный номер счета банковских аккаунтов
    /// </summary>
    static private int s_accountNumberSeed = 1000000000;
    public string Number { get;}
    public string Owner { get; private set; }
    /// <summary>
    /// изменение баланса банковского счета
    /// </summary>
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

    public BankAccount(string name, decimal initialBalance) : this(name, initialBalance, 0) { }
    public BankAccount(string name, decimal initialBalance, decimal minimumBalancs)
    {
        
        Owner = name; // this.Owner = name
        _minimalBalancs = minimumBalancs;
        if (initialBalance < 0)
        {
            MakeDeposide(initialBalance, DateTime.UtcNow, "Initial balance");
        }
        Number = s_accountNumberSeed.ToString();
        s_accountNumberSeed++;
    }
    /// <summary>
    /// метод описывающий пополнение банковскго счета на указанную сумму
    /// </summary>
    /// <param name="amount">Сумма пополениея</param>
    /// <param name="date">Дата транзакции</param>
    /// <param name="note">Коментарий к операции</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Бросается, если <paramref name="amount"/> меньше или равен нулю
    /// </exception>
    public void MakeDeposide(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount),"Amount of deposite must be positive"); 
        }
        var deposide = new Transaction(amount, date, note);
        _allTransactions.Add(deposide);
    }
    /// <summary>
    /// метод описывающий списывание средств с банковского счета
    /// </summary>
    /// <param name="amount">Сумма снятия. Должна быть положительной</param>
    /// <param name="date">Дата операции</param>
    /// <param name="note">Комментарий к операции</param>
    public void MakeWithdrawal(decimal amount, DateTime date, string note)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount);
        Transaction? overdraftTransaction = CheckWithdrawalLimit(Balance - amount < _minimalBalancs);
        Transaction? withdrawal = new(-amount, date, note);
        _allTransactions.Add(withdrawal);
        if(overdraftTransaction is not null)
        {
            _allTransactions.Add(overdraftTransaction);
        }
      
    //        if (amount <= 0)
    //        {
    //            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
    //        }
    //        if (Balance < amount)
    //        {
    //            throw new InvalidOperationException("Not sufficien rubls for this withdawaL");
    //        }
        
    //        var withdrawal = new Transaction(-amount, date, note);
    //    _allTransactions.Add(withdrawal);
    }
    /// <summary>
    /// Метод для того, проверки что баланс не исключительный
    /// </summary>
    /// <param name="v">входной параметр что досточно средств для списывания</param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException">
    /// Бросается в случае не хватки средств для списания
    /// </exception>
    protected virtual Transaction? CheckWithdrawalLimit(bool v)
    {
        if (v)
        {
            throw new InvalidOperationException("Not sufficient rubls from this withdrewal ");
        }
        return default;
        
    }
    /// <summary>
    /// метод взозвращающий историю транзакций
    /// </summary>
    /// <returns></returns>
    public string GetAccountHistory()
    {
        var report = new StringBuilder();

        decimal balance = 0;
        report.AppendLine("Data\t\tAmount\tBalance\tNote");
        foreach (var item in _allTransactions)
        {
            balance += item.Amount;
            report.AppendLine($"" +
                $"{item.Date.ToShortDateString()}\t" +
                $"{item.Amount}\t{balance}\t{item.Note}");
        }
        return report.ToString();
    }   
    //ключевое слово virtual позволяет в дочернем классе
    // предоставить другую версию реализации метода
    //PerformMorthAndTransaction
    public virtual void PerformMorthAndTransaction()
    {
       
    }
    // переопределяем метод, который насследовали от object
    // этот метод должен возвращать строку с состоянием объекта
    //public override string ToString()
    //{
    //return "Type: {GetType().Name}\t Owner: {Owner}\t Number of account: {Number}";

    //}

    public override string ToString()
    => $"Type: {GetType().Name} \tOwner: {Owner} \tNumber of account: {Number}";
    
    
}
