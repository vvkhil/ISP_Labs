using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp6
{
    class FootballerComparer : IComparer<Footballer>
    {
        public int Compare(Footballer p1, Footballer p2)
        {
            if (p1.Name.Length > p2.Name.Length)
                return 1;
            else if (p1.Name.Length < p2.Name.Length)
                return -1;
            else
                return 0;
        }
    }
}
