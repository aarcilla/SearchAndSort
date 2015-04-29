using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAndSort
{
    public class IntArrayDescendingComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            int num1 = (int)x;
            int num2 = (int)y;

            if (num1 > num2)
                return -1;
            else if (num1 < num2)
                return 1;
            else
                return 0;
        }
    }
}
