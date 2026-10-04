using System;
using System.Collections.Generic;
using System.Text;

namespace ИДЗ_1
{
    /// <summary>
    /// class аккаунт 
    /// </summary>
    internal class Account
    {
        /// <summary>
        /// Id аккаунта
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Номер отделения
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// Id отделения
        /// </summary>
        public int BranchID { get; set; }
        /// <summary>
        /// Id Клиента
        /// </summary>
        public int ClientID { get; set; }
        /// <summary>
        /// Баланс аккаунта
        /// </summary>
        public decimal Balance { get; set; }
       /// <summary>
       /// тип счета
       /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// проверка на тип счета 
        /// </summary>
        public bool IsVip => Balance > 1000000;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rate"></param>
        /// <returns></returns>
        public decimal GetBalanceIbUsd(double rate)
        {
            if (rate <= 0) return 0;
            return Balance / (decimal)rate;
        }
        /// <summary>
        /// Выдает информации аккаунта
        /// </summary>
        /// <returns></returns>
        public string GetInfo()
        {
            return $"{Number} ({Type}, {Balance} руб.)";
        }
        
        

    }

}

