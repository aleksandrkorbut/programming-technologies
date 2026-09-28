using System;
using System.Collections.Generic;
using System.Text;

namespace ИДЗ_1
{
    internal class Branch
    {
        /// <summary>
        /// Id отделения 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Наименование отделения
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Адресс отделения
        /// </summary>
        public string Adress { get; set; }
        /// <summary>
        /// Проверка на цнгтральное отделение
        /// </summary>
        public bool IsCentral => Name == "Цетральный";
        /// <summary>
        /// Выдает информацию класса Branch
        /// </summary>
        /// <returns>возвращаемое значение</returns> 
        public string GetInfo()
        {
            return $"{Name} ({Adress})";
        }
    }
}
