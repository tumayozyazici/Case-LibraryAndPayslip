using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CSProjeDemo2
{
    [JsonConverter(typeof(PersonnelConverter))]
    public abstract class Personnel
    {
        private decimal hourlyWage;

        public string FullName { get; set; }
        public string Title { get; set; }
        public decimal? OverTime { get; set; }
        public decimal Bonus { get; set; }
        public decimal HourlyWage
        {
            get { return hourlyWage; }
            set
            {
                if (Title == "Manager" & value < 500) throw new Exception("Manager's hourly wage cannot be less than 500.");
                else hourlyWage = value;
            }
        }
        public int TotalHours { get; set; }
        public decimal TotalSalary { get; set; }

        public abstract (decimal, decimal?) CalculateSalary();
    }
}