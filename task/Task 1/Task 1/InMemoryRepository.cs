using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Task1
{
    internal class InMemoryRepository
    {
        /// <summary>
        /// Класс выдает информацию из репозитории
        /// </summary>
        private List<Branch> _branch;
        private List<Client> _client;
        private List<Account> _accounts;
        /// <summary>
        /// Конструктор класса InMemoryRepository
        /// </summary>
        public InMemoryRepository()
        {
            _branch = new List<Branch> {

                new Branch{ Id = 1, Name = "Центральное", Adress = "Коммиунистичекий прю 17" },
                new Branch { Id = 2, Name = "Восточное", Adress = "Ул. Строителей 17" },
                new Branch { Id = 3, Name = "Западное", Adress = "Ул. Шахтеров 23" }
            };
            _client = new List<Client>
            {

                new Client { Id = 1, FullName = "Михеев И.Б.", Passport = "5407 097398", Pfone = "89330998722" },
                new Client { Id = 2, FullName = "Молотов И.А.", Passport = "5489 080910", Pfone = "89330891323" },
                new Client { Id = 3, FullName = "Тон И.И.", Passport = "5509 090203", Pfone = "89137778177" },
                new Client { Id = 4, FullName = "Грон А.Л.", Passport = "5690 020103", Pfone = "89530988913" },
                new Client { Id = 5, FullName = "Нон И.К.", Passport = "5409 080102", Pfone = "89134789900" }
            };
            _accounts = new List<Account> {

                new Account { Id = 1, Number = "0000001", BranchID = 1, ClientID = 1, Balance = 3000, Type = "Дебютовый" },
                new Account { Id = 2, Number = "0000002", BranchID = 1, ClientID = 2, Balance = 33000, Type = "Дебютовый" },
                new Account { Id = 3, Number = "0000003", BranchID = 2, ClientID = 2, Balance = 100000, Type = "Кредитный" },
                new Account { Id = 4, Number = "0000004", BranchID = 2, ClientID = 3, Balance = 1000, Type = "Дебютовый" },
                new Account { Id = 5, Number = "0000005", BranchID = 1, ClientID = 4, Balance = 230000, Type = "Кредитный" },
                new Account { Id = 6, Number = "0000006", BranchID = 1, ClientID = 5, Balance = 100000, Type = "Кредитный" },
                new Account { Id = 7, Number = "0000007", BranchID = 3, ClientID = 5, Balance = 12341, Type = "Дебютовый" },
                new Account { Id = 8, Number = "0000008", BranchID = 3, ClientID = 4, Balance = 343223, Type = "Дебютовый" }
            };
        }
        /// <summary>
        /// Выдает информацию из об отделениях
        /// </summary>
        /// <returns></returns>
        public List<Branch> GetBranchs() { return _branch; }
        /// <summary>
        /// Выдает информацию об аккаунтах
        /// </summary>
        /// <returns></returns>
        public List<Client> GetClients() { return _client; }
        /// <summary>
        /// Выдает информацию о клиентах
        /// </summary>
        /// <returns></returns>
        public List<Account> GetAccounts() { return _accounts; }
    }
}
