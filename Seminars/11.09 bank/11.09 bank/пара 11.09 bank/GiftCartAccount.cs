using System;
using System.Collections.Generic;
using System.Text;

namespace пара_11._09_bank
{
    public class GiftCartAccount : BankAccount
    {
        /// <summary>
        /// _monthlyDeposit - параметр по умолчанию
        /// </summary>
        private readonly decimal _monthlyDeposit = 0m;
        // _monthlyDeposit - параметр по умолчанию
        // при создании GiftCartAccount("Axel",1000); => _monthlyDeposit = 0
        // new GiftCartAccount("Axel",1000,5000); => _monthlyDeposit = 5000

        public GiftCartAccount (string name, decimal initialBalance, decimal monthlyDeposit=0 ) : base(name,initialBalance)
        => _monthlyDeposit = monthlyDeposit;
        /// <summary>
        /// 
        /// </summary>
        public override void PerformMorthAndTransaction()
        {
            if(_monthlyDeposit != 0)
            {
                MakeDeposide(_monthlyDeposit, DateTime.UtcNow, "Add mothly deposit");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString() + $"monthly deposite: {_monthlyDeposit}";
        }
   
    }
}
