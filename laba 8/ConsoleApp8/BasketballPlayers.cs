using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp8
{
    class BasketballPlayers
    {
        BasketballPlayer[] data;
        public BasketballPlayers()
        {
            data = new BasketballPlayer[2];
        }
        public BasketballPlayer this[int index]
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
