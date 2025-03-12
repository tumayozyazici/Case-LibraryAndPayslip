using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo1
{
    public class FictionalBook : Book
    {
        public override void DecreaseStock()
        {
            if (InStock > 1)
            {
                InStock--;
            }
            else if (InStock == 1)
            {
                InStock--;
                Status = Status.NotAvailable;
            }
            else throw new Exception("Book is not available");
        }

        public override void IncreaseStock()
        {
            if (InStock==0)
            {
                Status = Status.Borrowable;
            }
            InStock++;
        }
    }
}
