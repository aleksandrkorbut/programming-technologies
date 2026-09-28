using System;
using System.Collections.Generic;
using System.Text;

namespace ИДЗ_1
{
    internal class CsvRepository
    { 
        private string _basePatch;
        /// <summary>
        /// Конструктор класса CsvRepository
        /// </summary>
        /// <param name="basePatch"></param>
        public CsvRepository(string basePatch) { _basePatch = basePatch; }

        /// <summary>
        /// Принимает информацию из файла Branch.csv и выдает ее 
        /// </summary>
        /// <returns></returns>
        public List<Branch> GetBranchs()
        {
           
            List<Branch> result = new List<Branch>();
            string[] lines = File.ReadAllLines(Path.Combine(_basePatch, "Branch.csv"));
            if (lines.Length < 2) return result;
            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(',');
                if (parts.Length < 3) continue;
                Branch b = new Branch();
                b.Id = int.Parse(parts[0]);
                b.Name = parts[1];
                b.Adress = parts[2];
                result.Add(b);
            }
            return result;
        }
        /// <summary>
        /// Принимает информацию из Account.csv и выдает ее 
        /// </summary>
        /// <returns></returns>
        public List <Account> GetAccounts()
        {
            
            List <Account > result1 = new List<Account>();
            string[] lines = File.ReadAllLines(Path.Combine(_basePatch, "Account.csv"));
            if (lines.Length < 2) return result1;
            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(',');
                if (parts.Length < 6) continue;
                Account a = new Account();
                a.Id = int.Parse(parts[0]);
                a.Number = (parts[1]);
                a.BranchID = int.Parse(parts[2]);
                a.ClientID = int.Parse(parts[3]);
                a.Balance = int.Parse(parts[4]);
                a.Type = (parts[5]);
                result1.Add(a);
            }
            return result1;
        }
        /// <summary>
        /// принимает информацию из файла Client.csv и передает ее
        /// </summary>
        /// <returns></returns>
        public List<Client> GetClients()
        {
            
            List<Client> result3 = new List<Client>();
            string[] lines = File.ReadAllLines(Path.Combine(_basePatch, "Client.csv"));
            if (lines.Length < 2) return result3;
            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(',');
                if (parts.Length < 4) continue;
                Client c = new Client();
                c.Id = int.Parse(parts[0]);
                c.FullName = parts[1];
                c.Passport = parts[2];
                c.Pfone = parts[3];
                result3.Add(c);
            }
            return result3;
        }
    }
}
