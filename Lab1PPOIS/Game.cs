using System;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using Lab1PPOIS;

public class Game
{
    public static Action Clear = () => Console.Clear();
    protected static int SetPlayerChoice()
    {
        bool isWrongPlayerChoice = true;
        int playerChoice = 0;
        while (isWrongPlayerChoice)
        {
            try
            {
                playerChoice = Int32.Parse(Console.ReadLine());
                if (playerChoice == 1 || playerChoice == 2)
                {
                    isWrongPlayerChoice = false;
                }
                else
                    Console.WriteLine("Неправильное число");
            }
            catch
            {
                Console.WriteLine("Что-то пошло не так. Попробуйте ещё раз.");
            }
        }
        return playerChoice;
    }
    protected static void MainMenu()
    {
        Field field = new(0);
        Player firstPlayer = new();
        Player secondPlayer = new();
        int winner;
        Console.WriteLine("Главное меню\n1. Начать игру.\n" + "2. Выход.");
        int playerChoice = SetPlayerChoice();
        switch (playerChoice)
        {
            case 1:
                {
                    StartGame(ref field, ref firstPlayer, ref secondPlayer);
                    Clear();
                    winner = PlayGame(ref field, ref firstPlayer, ref secondPlayer);
                    if (winner == 1)
                        Console.WriteLine("Победили Крестики");
                    if (winner == 2)
                        Console.WriteLine("Победили Нолики");
                    if (winner == 0)
                        Console.WriteLine("Нет победителя");
                    Console.ReadLine();
                    Clear();
                    return;
                }
            case 2:
                {
                    Console.WriteLine("Завершение работы");
                    return;
                }
        }
    }
    protected static int SetFieldSize()
    {
        bool isWrongFieldSize = true;
        int fieldSize = 0;
        while (isWrongFieldSize)
        {
            try
            {
                fieldSize = Int32.Parse(Console.ReadLine());
                if (fieldSize >= 3 && fieldSize <= 50)
                {
                    isWrongFieldSize = false;
                }
                else
                    Console.WriteLine("Неправильный размер поля");
            }
            catch
            {
                Console.WriteLine("Что-то пошло не так. Попробуйте ещё раз.");
            }
        }
        return fieldSize;
    }
    protected static int SetPlayerSymbol()
    {
        bool isWrongPlayerSymbol = true;
        int playerSymbol = 0;
        while (isWrongPlayerSymbol)
        {
            try
            {
                playerSymbol = Int32.Parse(Console.ReadLine());
                if (playerSymbol == 1 || playerSymbol == 2)
                {
                    isWrongPlayerSymbol = false;
                }
                else
                    Console.WriteLine("Неправильный символ");
            }
            catch
            {
                Console.WriteLine("Что-то пошло не так. Попробуйте ещё раз.");
            }
        }
        return playerSymbol;
    }
    protected static void StartGame(ref Field field, ref Player firstPlayer, ref Player secondPlayer)
    {
        Console.Write("Введите размер поля NxN (от 3 до 50): ");
        int fieldSize = SetFieldSize();
        field = new Field((byte)fieldSize);
        Console.WriteLine("Первый игрок с символом: \n1. Крестик \n2. Нолик");
        int firstPlayerSymbol = SetPlayerSymbol();
        firstPlayer.Symbol = (Symbols)firstPlayerSymbol;
        int secondPlayerSymbol = 0; 
        if (firstPlayerSymbol == 1)
        {
            secondPlayerSymbol = 2;
            Console.WriteLine("Второй игрок с символом: Нолик");
        }
        else if(firstPlayerSymbol == 2)
        {
            secondPlayerSymbol = 1;
            Console.WriteLine("Второй игрок с символом: Крестик");
        }
        secondPlayer.Symbol = (Symbols)secondPlayerSymbol;
    }
    protected static void ShowLine(ref Field field)
    {
        for (int i = 0; i < field.GetSize(); i++)
        {
            Console.Write("----");
        }
        Console.Write("-\n");
    }
    protected static void ShowScale(ref Field field)
    {
        Console.Write("  ");
        for (int i  = 0; i < field.GetSize(); i++)
        {
            Console.Write("  {0} ",i);
        }
    }
    protected static void ShowField(ref Field field)
    {
        ShowScale(ref field);
        Console.Write("\n  ");
        ShowLine(ref field);
        for (byte i = 0; i < field.GetSize(); i++)
        {
            Console.Write("{0} |",i);
            for (byte j = 0; j < field.GetSize();j++)
            {
                if (field[i, j] == 0)
                {
                    Console.Write("   |");
                }
                if (field[i, j] == 1)
                {
                    Console.Write(" X |");
                }
                if (field[i, j] == 2)
                {
                    Console.Write(" O |");
                }
            }
            Console.Write("\n  ");
            ShowLine(ref field);
        }
    }
    protected static byte[] SetPlayerMove(Field field)
    {
        bool isWrongValidMove = true;
        Regex reg = new(@"\d \d");
        string choice = "";
        byte[] moveOfPlayer = new byte[2];
        while (isWrongValidMove)
        {
            try
            {
                choice = Console.ReadLine();
                moveOfPlayer[0] = Convert.ToByte(choice[0] - '0');
                moveOfPlayer[1] = Convert.ToByte(choice[2] - '0');
                if (reg.IsMatch(choice) && (moveOfPlayer[0] >=0 && moveOfPlayer[0]<=field.GetSize()-1)
                    && moveOfPlayer[1]>=0 && moveOfPlayer[1]<=field.GetSize()-1)
                {
                    isWrongValidMove = false;
                }
                else
                    Console.WriteLine("Неправильный ход");
            }
            catch
            {
                Console.WriteLine("Что-то пошло не так. Попробуйте ещё раз.");
            }
        }
        return moveOfPlayer;
    }
    protected static int PlayGame(ref Field field, ref Player firstPlayer, ref Player secondPlayer)
    {
        int numberOfMoves = 1;
        int winner = 0;
        byte[] moveOfPlayer = new byte[2];
        while (numberOfMoves <= field.GetSize() * field.GetSize() && winner == 0)
        {
            ShowField(ref field);
            if (numberOfMoves % 2 == 0)
            {
                Console.Write("Второй игрок делает ход: ");
                moveOfPlayer = SetPlayerMove(field);
                secondPlayer.MakeMove(moveOfPlayer[0], moveOfPlayer[1], field);
            } 
            else
            {
                Console.Write("Первый игрок делает ход: ");
                moveOfPlayer = SetPlayerMove(field);
                firstPlayer.MakeMove(moveOfPlayer[0], moveOfPlayer[1], field);
            }
            winner = field.CheckWinner(moveOfPlayer[0], moveOfPlayer[1]);
            numberOfMoves++;
            if (winner == 0)
            {
                Clear();

            }
            else
            {
                Clear();
                ShowField(ref field);
            }
        }
        return winner;
    }
    protected static void Main()
    {
        MainMenu();
    }
}