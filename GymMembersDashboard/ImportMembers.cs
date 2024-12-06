using GymMembersDashboard.Core;
using OfficeOpenXml;
using System.IO;
using System.Reflection;

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
                    var members = new List<MemberTrack>();
                    var columnMapping = new Dictionary<int, PropertyInfo>();
                    for (int col = dataTable.Address.Start.Column; col <= dataTable.Address.End.Column; col++)
                    {
                        var header = dataWorksheets.Cells[dataTable.Address.Start.Row, col].Text;
                        foreach (var prop in typeof (MemberTrack).GetProperties())
                        {
                            var attr = prop.GetCustomAttribute<ExcelColumnAttribute>();
                            if (attr != null && attr.ColumnName == header)
                            {
                                columnMapping[col] = prop; 
                                break;
                            }
                        }
                    }
                    for (int row = dataTable.Address.Start.Row + 1; row <= dataTable.Address.End.Row; row++)
                    {
                        var instance = new MemberTrack();
                        foreach (var map in columnMapping)
                        {
                            var cellValue = dataWorksheets.Cells[row, map.Key].Text;
                            var value = Convert.ChangeType(cellValue, map.Value.PropertyType);
                            map.Value.SetValue(instance, value);
                        }
                        members.Add(instance);
                    }
                    return members;
                }
            }
        }
    }
}
