using CSProjeDemo2;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace System
{
    internal class Program
    {
        static Payslip payslip = new Payslip();
        static void Main(string[] args)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string path = Path.Combine(desktopPath, "Case\\Case\\Console2\\personnel.txt");

            List<Personnel> list = ReadFile.JsonReadFile(path);

            foreach (var person in list)
            {
                if(person.Title is "Manager") Console.WriteLine($"Manager: {person.FullName}, {person.Title}");
                else Console.WriteLine($"Officer: {person.FullName}, {person.Title}");
            }

            List<Personnel> listWithInfo = new List<Personnel>();
            List<Personnel> listPersonnelWithLessThan10Hours = new List<Personnel>();

            foreach (var item in list)
            {
                if (item.Title == "Manager")
                {
                    Console.WriteLine($"Manager: {item.FullName}, Please enter hourlywage:");
                    item.HourlyWage = Convert.ToDecimal(Console.ReadLine());
                    Console.WriteLine($"Manager: {item.FullName}, Hourly wage: {item.HourlyWage}, Please enter total hours:");
                    item.TotalHours = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine($"Manager: {item.FullName}, Hourly wage: {item.HourlyWage}, Total Hours: {item.TotalHours}, Please enter bonus:");
                    item.Bonus = Convert.ToInt32(Console.ReadLine());
                    if (item.TotalHours < 10)
                    {
                        listPersonnelWithLessThan10Hours.Add(item);
                    }
                    listWithInfo.Add(item);
                }
                else
                {
                    Console.WriteLine($"Officer: {item.FullName}, Please enter hourlywage:");
                    item.HourlyWage = Convert.ToDecimal(Console.ReadLine());
                    Console.WriteLine($"Officer: {item.FullName}, Hourly wage: {item.HourlyWage}, Please enter total hours:");
                    item.TotalHours = Convert.ToInt32(Console.ReadLine());
                    if (item.TotalHours < 10)
                    {
                        listPersonnelWithLessThan10Hours.Add(item);
                    }
                    listWithInfo.Add(item);
                }
            }

            foreach (var person in listWithInfo)
            {
                if (person.Title is "Manager") Console.WriteLine($"Manager: {person.FullName}, {person.Title}, HourlyWage: {person.HourlyWage}, Total Hours: {person.TotalHours}, Bonus: {person.Bonus}");
                else Console.WriteLine($"Officer: {person.FullName}, {person.Title}, HourlyWage: {person.HourlyWage}, Total Hours: {person.TotalHours}");
            }

            Console.ReadLine();

            List<Payslip> payslips = payslip.PrintPayslip(list);

            foreach (var item in payslips)
            {
                Console.WriteLine($"Personel Name: {item.PersonelName}, Hours of Work: {item.HoursOfWork}, Main Pay: {item.MainPay}, Overtime: {item.OvertimeOrBonus}, Total Salary: {item.TotalSalary}");
            }

            // Burada artık bordroları yazdırmaya başlıyorum.

            DateTime date = DateTime.Now;
            string filePath = Path.Combine(desktopPath,$"Case\\Case\\Console2\\payslip_{date.ToString("MMMM yyyy").ToUpper()}.txt");

            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }

            using (StreamWriter writer = new StreamWriter(filePath, false, new UTF8Encoding(true)))
            {
                writer.WriteLine($"Payslips, {date.ToString("MMMM yyyy").ToUpper()}\n");

                foreach (var item in payslips)
                {
                    var json = Text.Json.JsonSerializer.Serialize(new
                    {
                        Personnel_Name = item.PersonelName,
                        Hours_of_Work = item.HoursOfWork,
                        Main_Pay = $"₺{item.MainPay:N2}",
                        Overtime_or_Bonus = $"₺{item.OvertimeOrBonus:N2}",
                        Total_Pay = $"₺{item.TotalSalary:N2}"
                    }, new JsonSerializerOptions
                    { 
                        WriteIndented = true,
                        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                    });
                    writer.WriteLine(json + "\n");
                }

                writer.WriteLine($"Personnel with less than 10 hours of work:\n");

                foreach (var item in listPersonnelWithLessThan10Hours)
                {
                    var json = Text.Json.JsonSerializer.Serialize(new
                    {
                        Personnel_Name = item.FullName,
                        Hours_of_Work = item.TotalHours,
                        Hourly_Wage = $"₺{item.HourlyWage:N2}"
                    }, new JsonSerializerOptions 
                    {
                        WriteIndented = true,
                        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                    });
                    writer.WriteLine(json + "\n");
                }
            }
            Console.WriteLine("Maaş bordrosu başarıyla oluşturuldu: " + filePath);
        }
    }
}
