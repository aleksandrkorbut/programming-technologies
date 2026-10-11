using System;
using System.Collections.Generic;
using System.Text;

namespace пара_11._09_bank
{
    public class InterestEarningAccount : BankAccount
    {
        public InterestEarningAccount(string name, decimal initialBalance) : base(name, initialBalance)
        { }
        // override данный метод помогает дочернем классе определить новую реализацию
        //метода PerformMorthAndTransaction

        /// <summary>
        /// Метод для проверки изменения баланса
        /// </summary>
        public override void PerformMorthAndTransaction()
        {
            if (Balance > 500m)
            {
                decimal interest = Balance * 0.02m;
                MakeDeposide(interest, DateTime.UtcNow, "Apply month interest");

            }
        }
    }
}
