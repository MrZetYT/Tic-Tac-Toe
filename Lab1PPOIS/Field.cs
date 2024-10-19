using System;
using System.Linq.Expressions;
using Lab1PPOIS;

public class Field(byte N) : IField
{
    private protected byte[,] field = new byte[N, N];
    private protected byte fieldSize = N;

    public byte GetSize()
    {
        return fieldSize;
    }
    public bool CheckCellIsEmpty(int row, int column) => field[row, column] == 0;
    private int CheckColumns(byte x, byte y)
    {
        byte fieldValue = 0;
        if (x + 1 != field.GetLength(0) && x + 2 != field.GetLength(0))
        {
            if (field[x + 1, y] == field[x, y] && field[x + 1, y] == field[x + 2, y])
            {
                fieldValue = field[x, y];
            }
        }
        if (x + 1 != field.GetLength(0) && x - 1 >= 0)
        {
            if (field[x, y] == field[x + 1, y] && field[x + 1, y] == field[x - 1, y])
            {
                fieldValue = field[x, y];
            }
        }
        if (x - 1 >= 0 && x - 2 >= 0)
        {
            if (field[x, y] == field[x - 1, y] && field[x - 1, y] == field[x - 2, y])
            {
                fieldValue = field[x, y];
            }
        }
        return fieldValue;
    }
    private int CheckRows(byte x, byte y)
    {
        byte fieldValue = 0;
        if (y + 1 != field.GetLength(1) && y + 2 != field.GetLength(1))
        {
            if (field[x, y + 1] == field[x, y] && field[x, y + 1] == field[x, y + 2])
            {
                fieldValue = field[x, y];
            }
        }
        if (y + 1 != field.GetLength(1) && y - 1 >= 0)
        {
            if (field[x, y] == field[x, y + 1] && field[x, y + 1] == field[x, y - 1])
            {
                fieldValue = field[x, y];
            }
        }
        if (y - 1 >= 0 && y - 2 >= 0)
        {
            if (field[x, y] == field[x, y - 1] && field[x, y - 1] == field[x, y - 2])
            {
                fieldValue = field[x, y];
            }
        }
        return fieldValue;
    }
    private int CheckMainDiagonal(byte x, byte y)
    {
        byte fieldValue = 0;
        if ((x + 1 != field.GetLength(0) && x + 2 != field.GetLength(0)) && (y + 1 != field.GetLength(1) && y + 2 != field.GetLength(1)))
        {
            if (field[x + 1, y + 1] == field[x, y] && field[x + 1, y + 1] == field[x + 2, y + 2])
            {
                fieldValue = field[x, y];
            }
        }
        if ((x + 1 != field.GetLength(0) && x - 1 >= 0) && (y + 1 != field.GetLength(0) && y - 1 >= 0))
        {
            if (field[x, y] == field[x + 1, y + 1] && field[x + 1, y + 1] == field[x - 1, y - 1])
            {
                fieldValue = field[x, y];
            }
        }
        if ((x - 1 >= 0 && x - 2 >= 0) && (y - 1 >= 0 && y - 2 >= 0))
        {
            if (field[x, y] == field[x - 1, y - 1] && field[x - 1, y - 1] == field[x - 2, y - 2])
            {
                fieldValue = field[x, y];
            }
        }
        return fieldValue;
    }
    private int CheckSecondaryDiagonal(byte x, byte y)
    {
        byte fieldValue = 0;
        if ((x + 1 != field.GetLength(0) && x + 2 != field.GetLength(0)) && (y - 1 >= 0 && y - 2 >= 0))
        {
            if (field[x + 1, y - 1] == field[x, y] && field[x + 1, y - 1] == field[x + 2, y - 2])
            {
                fieldValue = field[x, y];
            }
        }
        if ((x + 1 != field.GetLength(0) && x - 1 >= 0) && (y - 1 >= 0 && y + 1 != field.GetLength(1)))
        {
            if (field[x, y] == field[x + 1, y - 1] && field[x + 1, y - 1] == field[x - 1, y + 1])
            {
                fieldValue = field[x, y];
            }
        }
        if ((x - 1 >= 0 && x - 2 >= 0) && (y + 1 != field.GetLength(1) && y + 2 != field.GetLength(1)))
        {
            if (field[x, y] == field[x - 1, y + 1] && field[x - 1, y + 1] == field[x - 2, y + 2])
            {
                fieldValue = field[x, y];
            }
        }
        return fieldValue;
    }
    public int CheckWinner(byte x, byte y)
    {
        int winner;
        winner = CheckColumns(x, y);
        if (winner == 0)
            winner = CheckRows(x, y);
        if (winner == 0)
            winner = CheckMainDiagonal(x, y);
        if (winner == 0)
            winner = CheckSecondaryDiagonal(x, y);
        return winner;
    }
    public byte this[byte x, byte y]
    {
        get => field[x, y];

        set => field[x, y] = value;
    }
}