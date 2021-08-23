using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GridGamesLibrary;

namespace GridGamesTests
{
    [TestClass]
    public class GamesLibraryTest
    {
        [TestMethod]
        public void IsGridCellEmptyTrue()
        {
            // Arrange
            NoughtsAndCrossesGame game = new NoughtsAndCrossesGame();
            bool expected = true;

            // Act
            bool actual = game.IsGridCellEmpty(1);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsGridCellEmptyFalse()
        {
            // Arrange
            NoughtsAndCrossesGame game = new NoughtsAndCrossesGame();
            game.PlayMove(1);
            bool expected = false;

            // Act
            bool actual = game.IsGridCellEmpty(1);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsGridCellValidTrue()
        {
            // Arrange
            NoughtsAndCrossesGame game = new NoughtsAndCrossesGame();
            bool expected = true;

            // Act
            bool actual = game.IsGridCellValid(1);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(0, false)]
        [DataRow(10, false)]
        public void IsGridCellValidFalse(int cell, bool expected)
        {
            // Arrange
            NoughtsAndCrossesGame game = new NoughtsAndCrossesGame();

            // Act
            bool actual = game.IsGridCellValid(cell);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HasPlayerWonFalse()
        {
            // Arrange
            NoughtsAndCrossesGame game = new NoughtsAndCrossesGame();
            bool expected = false;

            // Act
            bool actual = game.HasPlayerWon();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetRowValuesBlank()
        {
            // Arrange
            NoughtsAndCrossesGame game = new NoughtsAndCrossesGame();
            char[] expected = new char[] { '-', '-', '-' };

            // Act
            char[] actual = game.GetRowValues(1);

            // Assert
            Assert.AreEqual(expected[0], actual[0]);
            Assert.AreEqual(expected[1], actual[1]);
            Assert.AreEqual(expected[2], actual[2]);
        }

        [TestMethod]
        public void IsGameOverFalse()
        {
            // Arrange
            NoughtsAndCrossesGame game = new NoughtsAndCrossesGame();
            bool expected = false;

            // Act
            bool actual = game.IsGameOver;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsCurrentPlayer1True()
        {
            // Arrange
            NoughtsAndCrossesGame game = new NoughtsAndCrossesGame();
            int expected = 1;

            // Act
            int actual = game.CurrentPlayer;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsPlayMoveValidCellTrue()
        {
            // Arrange
            NoughtsAndCrossesGame game = new NoughtsAndCrossesGame();
            bool expected = true;
            string expectedMessage = "";

            // Act
            bool actual = game.PlayMove(1);
            string actualMessage = game.ErrorMessage;

            // Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod]
        public void IsPlayMoveInvalidCellFalse()
        {
            // Arrange
            NoughtsAndCrossesGame game = new NoughtsAndCrossesGame();
            bool expected = false;
            string expectedMessage = "Selected cell must be between 1 and 9";

            // Act
            bool actual = game.PlayMove(10);
            string actualMessage = game.ErrorMessage;

            // Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedMessage, actualMessage);
        }
    }
}
