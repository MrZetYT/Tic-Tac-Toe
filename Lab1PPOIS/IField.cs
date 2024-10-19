using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1PPOIS
{
    internal interface IField
    {
        public byte GetSize();
        public bool CheckCellIsEmpty(int row, int column);
        public int CheckWinner(byte x, byte y);
        public byte this[byte x, byte y] { get; set; }
    }
}
