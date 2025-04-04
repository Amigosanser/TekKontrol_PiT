using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExamEvaluationApp;
using System;

namespace ExamEvaluationTests
{
    [TestClass]
    public class ExamEvaluationTests
    {
        [TestMethod]
        public void CalculateGrade_ValidScores_ReturnsCorrectGrade()
        {
            // Arrange
            int module1Score = 15; // Модуль 1: Разработка БД (макс 22)
            int module2Score = 25; // Модуль 2: Разработка ПО (макс 38)
            int module3Score = 16; // Модуль 3: Обслуживание ПО (макс 20)
            int expectedTotal = 56;
            string expectedGrade = "5 (отлично)";

            // Act
            var result = MainWindow.CalculateGrade(module1Score + module2Score + module3Score);

            // Assert
            Assert.AreEqual(expectedGrade, result);
        }

        [TestMethod]
        public void CalculateGrade_BorderlineScore_ReturnsCorrectGrade()
        {
            // Arrange
            int module1Score = 10;
            int module2Score = 15;
            int module3Score = 7;
            string expectedGrade = "4 (хорошо)";

            // Act
            var result = MainWindow.CalculateGrade(module1Score + module2Score + module3Score);

            // Assert
            Assert.AreEqual(expectedGrade, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CalculateGrade_InvalidScore_ThrowsException()
        {
            // Arrange
            int invalidTotalScore = 81; // Максимально возможный балл - 80

            // Act
            MainWindow.CalculateGrade(invalidTotalScore);

            // Assert - ожидаемое исключение указано в атрибуте
        }

        [TestMethod]
        public void GetValidatedScore_ValidInput_ReturnsScore()
        {
            // Arrange
            var mainWindow = new MainWindow();
            string input = "15";
            int maxScore = 22;
            string moduleName = "Модуль 1";
            int expectedScore = 15;

            // Act
            int result = mainWindow.GetValidatedScore(input, maxScore, moduleName);

            // Assert
            Assert.AreEqual(expectedScore, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetValidatedScore_InvalidInput_ThrowsException()
        {
            // Arrange
            var mainWindow = new MainWindow();
            string invalidInput = "abc";
            int maxScore = 22;
            string moduleName = "Модуль 1";

            // Act
            mainWindow.GetValidatedScore(invalidInput, maxScore, moduleName);

            // Assert - ожидаемое исключение указано в атрибуте
        }
    }
}