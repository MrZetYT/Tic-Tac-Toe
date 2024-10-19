using Lab1PPOIS;
using System.ComponentModel;
using NUnit;

namespace Lab1PPOIS.Tests
{
    public class FieldTests
    {
        [Test]
        public void GetSize_TryGetSizeOfField_1()
        {
            Field field = new(5);
            int expectedSize = 5;
            Assert.That(field.GetSize(), Is.EqualTo(expectedSize));
        }
        [Test]
        public void GetSize_TryGetSizeOfField_2()
        {
            Field field = new(17);
            int expectedSize = 5;
            Assert.That(field.GetSize(), Is.Not.EqualTo(expectedSize));
        }
        [Test]
        public void GetSize_TryGetSizeOfField_3()
        {
            Field field = new(0);
            int expectedSize = 5;
            Assert.That(field.GetSize(), Is.Not.EqualTo(expectedSize));
        }
        [Test]
        public void CheckCellIsEmpty_CheckingCellOfFieldIsEmpty_1()
        {
            Field field = new(3);
            field[1, 1] = 1;
            bool expectedEmptyCell = false;
            Assert.That(field.CheckCellIsEmpty(1,1), Is.EqualTo(expectedEmptyCell));
        }
        [Test]
        public void CheckCellIsEmpty_CheckingCellOfFieldIsEmpty_2()
        {
            Field field = new(3);
            field[2, 1] = 1;
            bool expectedEmptyCell = true;
            Assert.That(field.CheckCellIsEmpty(1,1), Is.EqualTo(expectedEmptyCell));
        }
        [Test]
        public void CheckCellIsEmpty_CheckingCellOfFieldIsEmpty_3()
        {
            Field field = new(3);
            field[0, 0] = 2;
            bool expectedEmptyCell = true;
            Assert.That(field.CheckCellIsEmpty(0, 0), Is.Not.EqualTo(expectedEmptyCell));
        }
        [Test]
        public void CheckWinner_CheckColumns_1()
        {
            Field field = new(3);
            field[0, 0] = 1;
            field[1, 0] = 1;
            field[2, 0] = 1;
            int expectedWinner = 1;
            Assert.That(field.CheckWinner(0, 0), Is.EqualTo(expectedWinner));
        }
        [Test]
        public void CheckWinner_CheckColumns_2()
        {
            Field field = new(4);
            field[0, 0] = 2;
            field[1, 0] = 2;
            field[2, 0] = 1;
            int expectedWinner = 2;
            Assert.That(field.CheckWinner(2, 0), Is.Not.EqualTo(expectedWinner));
        }
        [Test]
        public void CheckWinner_CheckColumns_3()
        {
            Field field = new(5);
            field[0, 0] = 2;
            field[1, 0] = 2;
            field[2, 0] = 2;
            int expectedWinner = 2;
            Assert.That(field.CheckWinner(1, 0), Is.EqualTo(expectedWinner));
        }
        [Test]
        public void CheckWinner_CheckColumns_4()
        {
            Field field = new(5);
            field[0, 0] = 2;
            field[1, 0] = 2;
            field[2, 0] = 2;
            int expectedWinner = 2;
            Assert.That(field.CheckWinner(2, 0), Is.EqualTo(expectedWinner));
        }
        [Test]
        public void CheckWinner_CheckRows_1()
        {
            Field field = new(5);
            field[0, 1] = 2;
            field[0, 2] = 2;
            field[0, 3] = 2;
            int expectedWinner = 2;
            Assert.That(field.CheckWinner(0, 1), Is.EqualTo(expectedWinner));
        }
        [Test]
        public void CheckWinner_CheckRows_2()
        {
            Field field = new(5);
            field[0, 1] = 1;
            field[0, 2] = 1;
            field[0, 4] = 1;
            int expectedWinner = 1;
            Assert.That(field.CheckWinner(0, 2), Is.Not.EqualTo(expectedWinner));
        }
        [Test]
        public void CheckWinner_CheckRows_3()
        {
            Field field = new(5);
            field[0, 1] = 1;
            field[0, 2] = 1;
            field[0, 3] = 1;
            int expectedWinner = 1;
            Assert.That(field.CheckWinner(0, 2), Is.EqualTo(expectedWinner));
        }
        [Test]
        public void CheckWinner_CheckRows_4()
        {
            Field field = new(5);
            field[0, 1] = 1;
            field[0, 2] = 1;
            field[0, 3] = 1;
            int expectedWinner = 1;
            Assert.That(field.CheckWinner(0, 3), Is.EqualTo(expectedWinner));
        }
        [Test]
        public void CheckWinner_CheckMainDiagonal_1()
        {
            Field field = new(5);
            field[0, 0] = 1;
            field[1, 1] = 1;
            field[2, 2] = 1;
            int expectedWinner = 1;
            Assert.That(field.CheckWinner(0, 0), Is.EqualTo(expectedWinner));
        }
        [Test]
        public void CheckWinner_CheckMainDiagonal_2()
        {
            Field field = new(5);
            field[1, 2] = 1;
            field[2, 3] = 1;
            field[3, 4] = 1;
            int expectedWinner = 1;
            Assert.That(field.CheckWinner(2, 3), Is.EqualTo(expectedWinner));
        }
        [Test]
        public void CheckWinner_CheckMainDiagonal_3()
        {
            Field field = new(5);
            field[3, 2] = 1;
            field[4, 3] = 1;
            field[2, 1] = 1;
            int expectedWinner = 1;
            Assert.That(field.CheckWinner(4, 3), Is.EqualTo(expectedWinner));
        }
        [Test]
        public void CheckWinner_CheckSecondaryDiagonal_1()
        {
            Field field = new(5);
            field[0, 4] = 2;
            field[1, 3] = 2;
            field[2, 2] = 2;
            int expectedWinner = 2;
            Assert.That(field.CheckWinner(2, 2), Is.EqualTo(expectedWinner));
        }
        [Test]
        public void CheckWinner_CheckSecondaryDiagonal_2()
        {
            Field field = new(5);
            field[2, 3] = 2;
            field[3, 2] = 2;
            field[4, 1] = 2;
            int expectedWinner = 2;
            Assert.That(field.CheckWinner(3, 2), Is.EqualTo(expectedWinner));
        }
        [Test]
        public void CheckWinner_CheckSecondaryDiagonal_3()
        {
            Field field = new(5);
            field[0, 2] = 2;
            field[1, 1] = 2;
            field[3, 0] = 2;
            int expectedWinner = 2;
            Assert.That(field.CheckWinner(0, 2), Is.Not.EqualTo(expectedWinner));
        }
        [Test]
        public void CheckWinner_CheckSecondaryDiagonal_4()
        {
            Field field = new(5);
            field[2, 3] = 2;
            field[3, 2] = 2;
            field[4, 1] = 2;
            int expectedWinner = 2;
            Assert.That(field.CheckWinner(2, 3), Is.EqualTo(expectedWinner));
        }
        [Test]
        public void this_IndexatorOfField_1()
        {
            Field field = new(3);
            field[0, 0] = 2;
            byte expectedSymbol = 2;
            Assert.That(field[0,0], Is.EqualTo(expectedSymbol));
        }
        [Test]
        public void this_IndexatorOfField_2()
        {
            Field field = new(3);
            field[1, 1] = 2;
            byte expectedSymbol = 1;
            Assert.That(field[1, 1], Is.Not.EqualTo(expectedSymbol));
        }
        [Test]
        public void this_IndexatorOfField_3()
        {
            Field field = new(3);
            field[2, 0] = 2;
            byte expectedSymbol = 2;
            Assert.That(field[2, 0], Is.EqualTo(expectedSymbol));
        }
    }
}