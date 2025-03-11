using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo1
{
    public class HistoryBook : Book
    {
        public override void DecreaseStock()
        {
            if (InStock >= 1)
            {
                InStock--;
            }
            else throw new Exception("Book is not available");
        }

        public override void IncreaseStock()
        {
            InStock++;
        }
    }
}
