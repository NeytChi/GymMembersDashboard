using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMembersDashboard
{
    internal class ImportMembers
    {
        public ImportMembers() { }
        public ICollection<MemberTrack> GetMembers()
        {
            //  Шлях до файл з даними
            var path = "D:\\VS Projects\\NET Analytics\\GymMembersDashboard\\Gym members.xlsx";
            
            // Підключення до бібліотеки імпорту Excel безкоштовну ліцензію
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            // Створюємо пакет з файлу Excel 
            using (var package = new ExcelPackage(new FileInfo(path)))
            {
                // Визначаємо робочий книгу з пакету
                using (var workbook = package.Workbook)
                {
                    // визначаємо робочий зошит з таблицею даних
                    var dataWorksheets = workbook.Worksheets.Where(n => n.Name == "Gym members exercise tracking").First();
                    // визначаємо робочу таблицю з даними
                    var dataTable = dataWorksheets.Tables.Where(t => t.Name == "gmet").First();
                    
                    // конвертування даних з таблиці до колекції з даними 
                    var members = dataTable.ToCollection<MemberTrack>();

                    return members;
                }
            }
        }
    }
}
