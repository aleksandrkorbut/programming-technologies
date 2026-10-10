using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    /// <summary>
    /// Класс клиент
    /// </summary>
    internal class Client
    {
        /// <summary>
        /// Id клиента
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// полное имя клиента
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// данные паспорта клиента
        /// </summary>
        public string Passport { get; set; }
        /// <summary>
        /// номер телефона клиента
        /// </summary>
        public string Pfone { get; set; }
        /// <summary>
        /// Выдает информацию класса Клиент
        /// </summary>
        /// <returns></returns>
        public string GetInfo()
        {
            return $"{FullName} ( паспорт ){Passport}";
        }

    }
}
