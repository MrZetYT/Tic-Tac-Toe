using NUnit.Framework;
using System;
using System.IO;

namespace Lab1PPOIS.Tests
{
    public class GameTests : Game
    {
        [SetUp]
        public void Setup()
        {
            Clear = () => { };
        }
        [TearDown]
        public void TearDown()
        {
            Clear = () => Console.Clear(); 
        }
        [Test]
        public void MainMenu_ShouldDisplayMainMenu()
        {
            var output = new StringWriter();
            Console.SetOut(output);

            var input = new StringReader("2\n");
            Console.SetIn(input);

            Game.MainMenu();

            var consoleOutput = output.ToString();
            Assert.IsTrue(consoleOutput.Contains("Главное меню"));
        }

        [Test]
        public void MainMenu_ShouldStartGameAndDisplayWinner_1()
        {
            var output = new StringWriter();
            Console.SetOut(output);
            var input = new StringReader("1\n5\n1\n0 0\n1 0\n1 1\n2 1\n2 2\n\n");
            Console.SetIn(input);

            Game.MainMenu();

            var consoleOutput = output.ToString();
            Assert.IsTrue(consoleOutput.Contains("Победили Крестики")); 
        }
        [Test]
        public void MainMenu_ShouldStartGameAndDisplayWinner_2()
        {
            var output = new StringWriter();
            Console.SetOut(output);
            var input = new StringReader("1\n5\n2\n0 0\n1 0\n1 1\n2 1\n2 2\n\n");
            Console.SetIn(input);

            Game.MainMenu();

            var consoleOutput = output.ToString();
            Assert.IsTrue(consoleOutput.Contains("Победили Нолики"));
        }
        [Test]
        public void MainMenu_ShouldStartGameAndDisplayWinner_3()
        {
            var output = new StringWriter();
            Console.SetOut(output);
            var input = new StringReader("1\n3\n1\n0 0\n1 1\n1 0\n2 0\n0 2\n0 1\n2 1\n1 2\n2 2\n\n");
            Console.SetIn(input);

            Game.MainMenu();

            var consoleOutput = output.ToString();
            Assert.IsTrue(consoleOutput.Contains("Нет победителя"));
        }
        [Test]
        public void MainMenu_ShouldDisplayWrongFieldSize_1()
        {
            var output = new StringWriter();
            Console.SetOut(output);
            var input = new StringReader("1\n2\n3\n1\n0 0\n1 1\n1 0\n2 0\n0 2\n0 1\n2 1\n1 2\n2 2\n\n");
            Console.SetIn(input);

            Game.MainMenu();

            var consoleOutput = output.ToString();
            Assert.IsTrue(consoleOutput.Contains("Неправильный размер поля"));
        }
        [Test]
        public void MainMenu_ShouldDisplayWrongFieldSize_2()
        {
            var output = new StringWriter();
            Console.SetOut(output);
            var input = new StringReader("1\n52\n3\n1\n0 0\n1 1\n1 0\n2 0\n0 2\n0 1\n2 1\n1 2\n2 2\n\n");
            Console.SetIn(input);

            Game.MainMenu();

            var consoleOutput = output.ToString();
            Assert.IsTrue(consoleOutput.Contains("Неправильный размер поля"));
        }
        [Test]
        public void MainMenu_ShouldDisplayWrongFieldSize_3()
        {
            var output = new StringWriter();
            Console.SetOut(output);
            var input = new StringReader("1\nmama\n3\n1\n0 0\n1 1\n1 0\n2 0\n0 2\n0 1\n2 1\n1 2\n2 2\n\n");
            Console.SetIn(input);

            Game.MainMenu();

            var consoleOutput = output.ToString();
            Assert.IsTrue(consoleOutput.Contains("Что-то пошло не так. Попробуйте ещё раз."));
        }

        [Test]
        public void MainMenu_ShouldExitFromProgram()
        {
            var output = new StringWriter();
            Console.SetOut(output);
            var input = new StringReader("2\n");
            Console.SetIn(input);

            Game.MainMenu();

            var consoleOutput = output.ToString();
            Assert.IsTrue(consoleOutput.Contains("Завершение работы"));
        }

        [Test]
        public void MainMenu_ShouldHandleInvalidOption_1()
        {
            var output = new StringWriter();
            Console.SetOut(output);
            var input = new StringReader("3\n2\n");
            Console.SetIn(input);

            Game.MainMenu();

            var consoleOutput = output.ToString();
            Assert.IsTrue(consoleOutput.Contains("Неправильное число"));
        }
        [Test]
        public void MainMenu_ShouldHandleInvalidOption_2()
        {
            var output = new StringWriter();
            Console.SetOut(output);
            var input = new StringReader("mama\n2\n");
            Console.SetIn(input);

            Game.MainMenu();

            var consoleOutput = output.ToString();
            Assert.IsTrue(consoleOutput.Contains("Что-то пошло не так. Попробуйте ещё раз."));
        }
        [Test]
        public void MainMenu_ShoulDisplayWrongPlayerSymbol_1()
        {
            var output = new StringWriter();
            Console.SetOut(output);
            var input = new StringReader("1\n5\n3\n2\n0 0\n1 0\n1 1\n2 1\n2 2\n\n");
            Console.SetIn(input);

            Game.MainMenu();

            var consoleOutput = output.ToString();
            Assert.IsTrue(consoleOutput.Contains("Неправильный символ"));
        }
        [Test]
        public void MainMenu_ShoulDisplayWrongPlayerSymbol_2()
        {
            var output = new StringWriter();
            Console.SetOut(output);
            var input = new StringReader("1\n5\nmama\n2\n0 0\n1 0\n1 1\n2 1\n2 2\n\n");
            Console.SetIn(input);

            Game.MainMenu();

            var consoleOutput = output.ToString();
            Assert.IsTrue(consoleOutput.Contains("Что-то пошло не так. Попробуйте ещё раз."));
        }
        [Test]
        public void MainMenu_ShoulDisplayWrongPlayerMove_1()
        {
            var output = new StringWriter();
            Console.SetOut(output);
            var input = new StringReader("1\n3\n2\n4 0\n0 0\n1 0\n1 1\n2 1\n2 2\n\n");
            Console.SetIn(input);

            Game.MainMenu();

            var consoleOutput = output.ToString();
            Assert.IsTrue(consoleOutput.Contains("Неправильный ход"));
        }
        [Test]
        public void MainMenu_ShoulDisplayWrongPlayerMove_2()
        {
            var output = new StringWriter();
            Console.SetOut(output);
            var input = new StringReader("1\n3\n2\n40 0\n0 0\n1 0\n1 1\n2 1\n2 2\n\n");
            Console.SetIn(input);

            Game.MainMenu();

            var consoleOutput = output.ToString();
            Assert.IsTrue(consoleOutput.Contains("Что-то пошло не так. Попробуйте ещё раз."));
        }
        [Test]
        public void Main_ShouldStartGameAndDisplayWinner_1()
        {
            var output = new StringWriter();
            Console.SetOut(output);
            var input = new StringReader("1\n5\n1\n0 0\n1 0\n1 1\n2 1\n2 2\n\n");
            Console.SetIn(input);

            Main();

            var consoleOutput = output.ToString();
            Assert.IsTrue(consoleOutput.Contains("Победили Крестики"));
        }
    }
}
