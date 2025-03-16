using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo2
{
    public class Officer : Personnel
    {
        public override (decimal, decimal?) CalculateSalary()
        {
            if (TotalHours > 180)
            {
                TotalSalary = 180 * HourlyWage + (TotalHours - 180) * HourlyWage * 1.5m;
                OverTime = (TotalHours - 180) * HourlyWage * 1.5m;
                return (TotalSalary, OverTime);

            }
            else
            {
                TotalSalary = TotalHours * HourlyWage;
                OverTime = 0;
                return (TotalSalary, OverTime);
            }
        }
    }
}
