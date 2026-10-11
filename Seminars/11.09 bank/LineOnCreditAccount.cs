using System;
using System.Collections.Generic;
using System.Text;

namespace пара_11._09_bank
{
    internal class LineOnCreditAccount : BankAccount
    {
        public LineOnCreditAccount ( string name, decimal initialBalance, decimal creditLimit ) : 
            base( name, initialBalance, -creditLimit) { }
       /// <summary>
       /// метод описывающий взымаемые ежемесечные проценты
       /// </summary>
        public override void PerformMorthAndTransaction()
        {
            if (Balance < 0)
            {
                decimal interest = -Balance * 0.07m;
                MakeWithdrawal(interest, DateTime.UtcNow, "Charge monthly interesr");
            }
        }
        /// <summary>
        /// Метод реализующий проверку вывод средств
        /// </summary>
        /// <param name="isOverdrawn"></param>
        /// <returns></returns>
        protected override Transaction? CheckWithdrawalLimit(bool isOverdrawn) => isOverdrawn ? new Transaction(-20, DateTime.UtcNow, "apply overdraft") : default;


    }
}
