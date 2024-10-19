using System;
using System.Linq.Expressions;
using Lab1PPOIS;

public enum Symbols : byte { Cross = 1, Circle = 2 };

public class Player : IPlayer
{
    private Symbols symbol;
    public Symbols Symbol
    {
        get => symbol;
        set
        {
            byte numberSymbol = (byte)value;
            if (numberSymbol == 1)
                symbol = Symbols.Cross;
            else if (numberSymbol == 2)
                symbol = Symbols.Circle;
        }
    }
    public int MakeMove(byte x, byte y, Field field)
    {
        int isMoveMade = -1;
        if (field.CheckCellIsEmpty(x, y))
        {
            field[x, y] = (byte)Symbol;
            isMoveMade = field.CheckWinner(x, y);
        }
        return isMoveMade;
    }
}