using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiShare.Domain.Extentions
{
    public static class UserExtentions
    {
        /// <summary>
        /// Возвращает стандартизированное ФИО [например: Шазамов Шазам Шазамович] или "ФИ" [например: Шазамова Шазама], если отчество получено пустым или не получено вовсе.
        /// Если получены пустые данные, вернется пустая строка.
        /// </summary>
        /// <param name="firstname">Имя</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="patronymicname">Отчество</param>
        /// <returns>ФИО полностью.</returns>
        public static string GetFullNameOrDefault(string firstname, string surname, string? patronymicname = null)
        {
            var fullname = new StringBuilder();

            if (!string.IsNullOrEmpty(surname) && !string.IsNullOrWhiteSpace(surname))
                fullname.Append(surname);

            if (!string.IsNullOrEmpty(firstname) && !string.IsNullOrWhiteSpace(firstname))
                fullname.Append(' ' + firstname);

            if (!string.IsNullOrEmpty(patronymicname) && !string.IsNullOrWhiteSpace(patronymicname))
                fullname.Append(' ' + patronymicname);

            var res = fullname.ToString();
            return res;
        }
    }
}
