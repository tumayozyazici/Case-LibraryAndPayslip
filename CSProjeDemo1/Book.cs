using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo1
{
    public abstract class Book
    {
        private int inStock;

        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int InStock
        {
            get { return inStock; }
            set 
            {
                if(value > 0)
                {
                    inStock = value;
                    Status = Status.Borrowable;
                }
                else
                {
                    inStock = 0;
                    Status = Status.NotAvailable;
                }
            }
        }

        public DateTime PublishDate { get; set; }
        public Status Status { get; set; }

        public abstract void DecreaseStock();
        public abstract void IncreaseStock();
    }
}
