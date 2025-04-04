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
            int module1Score = 15;
            int module2Score = 25;
            int module3Score = 16;
            int expectedTotal = 56;
            string expectedGrade = "5 (отлично)";

            var result = MainWindow.CalculateGrade(module1Score + module2Score + module3Score);

            Assert.AreEqual(expectedGrade, result);
        }

        [TestMethod]
        public void CalculateGrade_BorderlineScore_ReturnsCorrectGrade()
        {
            int module1Score = 10;
            int module2Score = 15;
            int module3Score = 7;
            string expectedGrade = "4 (хорошо)";

            var result = MainWindow.CalculateGrade(module1Score + module2Score + module3Score);

            Assert.AreEqual(expectedGrade, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CalculateGrade_InvalidScore_ThrowsException()
        {
            int invalidTotalScore = 81;

            MainWindow.CalculateGrade(invalidTotalScore);
        }

        [TestMethod]
        public void GetValidatedScore_ValidInput_ReturnsScore()
        {
            var mainWindow = new MainWindow();
            string input = "15";
            int maxScore = 22;
            string moduleName = "Модуль 1";
            int expectedScore = 15;

            int result = mainWindow.GetValidatedScore(input, maxScore, moduleName);

            Assert.AreEqual(expectedScore, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetValidatedScore_InvalidInput_ThrowsException()
        {
            var mainWindow = new MainWindow();
            string invalidInput = "abc";
            int maxScore = 22;
            string moduleName = "Модуль 1";

            mainWindow.GetValidatedScore(invalidInput, maxScore, moduleName);
        }
    }
}