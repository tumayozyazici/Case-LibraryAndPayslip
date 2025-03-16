using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo2
{
    public class Manager : Personnel
    {
        public override (decimal, decimal?) CalculateSalary()
        {
            TotalSalary = TotalHours * HourlyWage + Bonus;
            return (TotalSalary, Bonus);
        }
    }
}
