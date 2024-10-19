using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1PPOIS
{
    internal interface IPlayer
    {
        public Symbols Symbol { get; set; }
        public int MakeMove(byte x, byte y, Field field);
    }
}
