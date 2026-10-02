namespace ИДЗ_1
{
    internal class Program
    {
        // метода дающий информмацию из списков проверить на null
        // добавить метода в main
        static void Main(string[] args)
        {
            Console.WriteLine("Выберете какой загрузить репозиторий " +
                "1 - из памяти 2 - из cvs.файла");
            string? variat1 = Console.ReadLine();
            if (variat1 == null) {
                throw new Exception("Введено не коректное значение");
            }
            int variat = int.Parse(variat1);

            List <Account> accounts = null;
            List <Branch> branches = null;
            List <Client> clients = null;

            switch (variat)
            {
                case 1:
                    { /* загрузка из InMemoryRepository */

                        try
                        {
                            var repo = new InMemoryRepository();
                            accounts = repo.GetAccounts();
                            branches =repo.GetBranchs();
                            clients = repo.GetClients();



                            Console.WriteLine("Задание 1 Введите счет (пример 0000000)");

                            string? number = Console.ReadLine();
                            if (number == null)
                            {
                                throw new Exception("Введено не коректное значение");
                            }
                            FindClientAccount(accounts, number, clients);
                            Console.WriteLine("Задание 2 Ведиет номер счета (пример 0000000)");
                            string? number1 = Console.ReadLine();
                            if (number1 == null)
                            {
                                throw new Exception("Введено не коректное значение");
                            }
                            FindBranch(number1, accounts, branches);
                            Console.WriteLine("Задание 3 вывод общего баланса");
                            decimal ban = GetTotalBalance(accounts);
                            Console.WriteLine(ban + " Всего средств ");
                            Console.WriteLine("Задание 4 Клиенты с более чем одним счетом. Списко клиентов по id");
                            Number_Of_Clients(accounts,clients);
                            Console.WriteLine("Задание 5 Вывод всех счетов");
                            PrintAllAccount(accounts, branches, clients);
                        }
                        catch
                        {
                            Console.WriteLine("Возникло исключение значение NUll или данного счета не существует");
                            
                        }
                        break;
                        
                    }
                case 2:
                    {/* загрузка из CsvRepository("ИДЗ 1") */
                        try
                        {
                            string? BasePath1 = "C:\\Users\\Пользователь\\Desktop\\C#\\3 сем\\ИДЗ 1\\ИДЗ 1\\";
                            CsvRepository cvs = new CsvRepository(BasePath1);
                            accounts = cvs.GetAccounts();
                            branches = cvs.GetBranchs();
                            clients = cvs.GetClients();
                            if (cvs == null)
                            {
                                throw new Exception("Данные не найдены");
                            }

                            Console.WriteLine("Задание 1 Введите счет (пример 0000000)");

                            string? number = Console.ReadLine();
                            if (number == null)
                            {
                                throw new Exception("Введено не коректное значение");
                            }

                            FindClientAccount(accounts, number, clients);



                            Console.WriteLine("Задание 2 Ведиет номер счета (пример 0000000)");
                            string? number1 = Console.ReadLine();
                            if (number1 == null)
                            {
                                throw new Exception("Введено не коректное значение");
                            }
                            FindBranch(number1, accounts, branches);
                            Console.WriteLine("Задание 3 вывод общего баланса");
                            decimal ban = GetTotalBalance(accounts);
                            Console.WriteLine(ban + " Всего средств ");
                            Console.WriteLine("Задание 4 Клиенты с более чем одним счетом. Списко клиентов по id");
                            Number_Of_Clients(accounts,clients);
                            Console.WriteLine("Задание 5 Вывод всех счетов");
                            PrintAllAccount(accounts, branches, clients);
                            break;
                        }
                        catch
                        {
                            Console.WriteLine("Возникло исключение значение NUll или данного счета не существует");
                            
                        }
                        break;

                    }
                default:
                    {
                        Console.WriteLine("Введено не верное значение");
                        break;
                    }


            }




        }
        /// <summary>
        /// Поиск аккаунта клиента по номеру счета 
        /// </summary>
        /// <param name="accounts"></param>
        /// <param name="number"></param>
        /// <param name="clients"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>

        static Client FindClientAccount(List<Account> accounts, string number, List<Client> clients)
        {
            Account FindAccount=null;
            foreach (var account in accounts)
            {
                if (account.Number == number)
                {
                    FindAccount = account;
                    break;
                }
            }
            
            if (FindAccount == null )
            {
                throw new Exception("Ошибка Счет с номером '{0}' не найден.");

            }

            Console.WriteLine("Найден счет: Number='{0}', ClientID={1}", FindAccount.Number, FindAccount.ClientID);

            foreach (var client in clients)
            {
                if (client.Id == FindAccount.ClientID)
                {
                    Console.WriteLine("Связанный клиент найден: Id={0}", client.Id);
                    return client;
                }
            }

            Console.WriteLine("Связанный клиент не найден для AccountID={0}", FindAccount.ClientID);
            return null;
        }



        /// <summary>
        /// Находит отделение банка по введенному счету и выводит на консоль
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <param name="accounts"></param>
        /// <param name="branches"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        static Branch FindBranch(string accountNumber, List<Account> accounts, List<Branch> branches)
        {
            Account Findaccount = null;
            foreach (var account in accounts)
            {
                if (account.Number == accountNumber)
                {
                    Findaccount = account; break;
                }
            }
            int error = Convert.ToInt32(accountNumber);
            if (Findaccount == null || error <= 0)
            {
                throw new Exception("Ошибка Счет с номером '{0}' не найден.");
            }

            Console.WriteLine("Найден счет: Number='{0}', BranchID={1}", Findaccount.Number, Findaccount.BranchID);

            foreach (var branch in branches)
            {
                if (branch.Id == Findaccount.BranchID)
                {
                    Console.WriteLine("Связанный филиал найден: Id={0}", branch.Id);
                    return branch;
                }
            }

            Console.WriteLine("Связанный филиал не найден для BranchID={0}", Findaccount.BranchID);
            return null;
        }

        /// <summary>
        /// Вывод общего баланса всез аккаутов 
        /// </summary>
        /// <param name="accounts"></param>
        /// <returns></returns>
        static decimal GetTotalBalance(List<Account> accounts)
        {
            
            if (accounts == null || accounts.Count == 0) return 0;
            decimal total = 0;
            foreach (var account in accounts)
            {
                total += account.Balance;
            }
            return total;
        }

        /// <summary>
        /// Метод находит все счета клиентов и череез foreach надит тех у кого более одного счета
        /// </summary>
        /// <param name="accounts"></param>
        /// <param name="clients"></param>
        /// <returns></returns>
        static List<Client> Number_Of_Clients(List<Account> accounts,List<Client>clients)
        {
            var accountCounts = new Dictionary<int, int>();

            // Подсчет количества счетов для каждого клиента
            foreach (var account in accounts)
            {
                if (accountCounts.ContainsKey(account.ClientID))
                    accountCounts[account.ClientID]++;
                else
                    accountCounts[account.ClientID] = 1;
            }



            var result = new List<Client>();
            foreach (var client in clients)
            {
                if (accountCounts.TryGetValue(client.Id, out int count) && count > 1)
                {
                    result.Add(client);
                }
            }



            for (int i = 0; i < result.Count - 1; i++)
            {
                for (int j = i + 1; j < result.Count; j++)
                {
                    if (result[i].Id > result[j].Id)
                    {
                        var tmp = result[i];
                        result[i] = result[j];
                        result[j] = tmp;
                    }
                }
            }

            Console.WriteLine("Клиенты после сортировки по Id:");
            foreach (var c in result)
                Console.WriteLine("Client Id: {0}", c.Id);

            return result;
        }

        /// <summary>
        /// переберает аккаунты и находит связанные с ними отделения банка и выводит всю информацию на консоль
        /// </summary>
        /// <param name="accounts"></param>
        /// <param name="branches"></param>
        /// <param name="clients"></param>
        static void PrintAllAccount(List<Account> accounts, List<Branch> branches, List<Client> clients)
        {
            foreach (var account in accounts)
            {
                string? clientInfo = "Не найдено";
                string? branchInfo = "-";

                foreach (var client in clients)
                {
                    if (client.Id == account.ClientID)
                    {
                        clientInfo = client.FullName;
                        break;
                    }
                }

                foreach (var branch in branches)
                {
                    if (branch.Id == account.BranchID)
                    {
                        branchInfo = branch.Name;
                        break;
                    }
                }
                Console.WriteLine($"{account.GetInfo()} - клиент {clientInfo}, отделение {branchInfo}");
            }
        }
    }
}
