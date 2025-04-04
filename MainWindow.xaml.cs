using System;
using System.Windows;
using System.Windows.Controls;

namespace ExamEvaluationApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void CalculateGrade_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int module1 = GetValidatedScore(Module1Score.Text, 22, "Модуль 1");
                int module2 = GetValidatedScore(Module2Score.Text, 38, "Модуль 2");
                int module3 = GetValidatedScore(Module3Score.Text, 20, "Модуль 3");

                int totalScore = module1 + module2 + module3;

                string grade = CalculateGrade(totalScore);

                MessageBox.Show($"Общая сумма баллов: {totalScore}\nОценка: {grade}",
                                "Результат экзамена",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public int GetValidatedScore(string input, int maxScore, string moduleName)
        {
            if (!int.TryParse(input, out int score))
            {
                throw new ArgumentException($"Некорректное значение баллов для {moduleName}");
            }

            if (score < 0 || score > maxScore)
            {
                throw new ArgumentException($"Баллы для {moduleName} должны быть от 0 до {maxScore}");
            }

            return score;
        }

        public static string CalculateGrade(int totalScore)
        {
            if (totalScore >= 56 && totalScore <= 80) return "5 (отлично)";
            if (totalScore >= 32 && totalScore <= 55) return "4 (хорошо)";
            if (totalScore >= 16 && totalScore <= 31) return "3 (удовлетворительно)";
            if (totalScore >= 0 && totalScore <= 15) return "2 (неудовлетворительно)";

            throw new ArgumentException("Некорректная сумма баллов");
        }
    }
}