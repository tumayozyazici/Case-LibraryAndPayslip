using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo2
{
    public class Payslip
    {
        public string PersonelName { get; set; }
        public int HoursOfWork { get; set; }
        public decimal MainPay { get; set; }
        public decimal OvertimeOrBonus { get; set; }
        public decimal TotalSalary { get; set; }

        public List<Payslip> PrintPayslip(List<Personnel> personnelList)
        {
            List<Payslip> payslips = new List<Payslip>();

            foreach (var item in personnelList)
            {
                decimal mainPay = item.CalculateSalary().Item1;
                decimal? extra = item.CalculateSalary().Item2;

                payslips.Add(new Payslip
                {
                    PersonelName = item.FullName,
                    HoursOfWork = item.TotalHours,
                    MainPay = mainPay,
                    OvertimeOrBonus = extra ?? 0,
                    TotalSalary = mainPay + (extra ?? 0)
                });
            }
            return payslips;
        }
    }
}
