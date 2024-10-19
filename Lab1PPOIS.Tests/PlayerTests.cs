using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1PPOIS.Tests
{
    public class PlayerTests
    {
        [Test]
        public void Symbol_GetSetSymbolOfPlayer_1()
        {
            Player player = new();
            player.Symbol = global::Symbols.Cross;
            Symbols expectedSymbol = Symbols.Cross;
            Assert.That(player.Symbol, Is.EqualTo(expectedSymbol));
        }
        [Test]
        public void Symbol_GetSetSymbolOfPlayer_2()
        {
            Player player = new();
            player.Symbol = global::Symbols.Circle;
            Symbols expectedSymbol = Symbols.Cross;
            Assert.That(player.Symbol, Is.Not.EqualTo(expectedSymbol));
        }
        [Test]
        public void Symbol_GetSetSymbolOfPlayer_3()
        {
            Player player = new();
            Symbols expectedSymbol = 0;
            Assert.That(player.Symbol, Is.EqualTo(expectedSymbol));
        }
        [Test]
        public void MakeMove_MakeMoveOnField_1()
        {
            Player player = new();
            Field field = new(3);
            player.Symbol = Symbols.Cross;
            player.MakeMove(0, 0, field);
            Assert.That(field[0,0], Is.EqualTo((byte)player.Symbol));
        }
        [Test]
        public void MakeMove_MakeMoveOnField_2()
        {
            Player player = new();
            Field field = new(4);
            player.Symbol = Symbols.Circle;
            player.MakeMove(1, 0, field);
            Assert.That(field[1, 0], Is.EqualTo((byte)player.Symbol));
        }
        [Test]
        public void MakeMove_MakeMoveOnField_3()
        {
            Player player = new();
            Field field = new(4);
            player.Symbol = Symbols.Circle;
            player.MakeMove(2, 0, field);
            Assert.That(field[1, 0], Is.Not.EqualTo((byte)player.Symbol));
        }
    }
}
