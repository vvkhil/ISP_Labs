using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp8
{
    class Footballers
    {
        Footballer[] data;
        public Footballers()
        {
            data = new Footballer[2];
        }
        public Footballer this[int index]
        {
            get
            {
                return data[index];
            }
            set
            {
                data[index] = value;
            }
        }
    }

}
