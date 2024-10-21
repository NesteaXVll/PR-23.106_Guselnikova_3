using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PR_23._106_Guselnikova_3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string input = InputTextBox.Text;
                if (string.IsNullOrWhiteSpace(input))
                {
                    MessageBox.Show("Пустая строка!", "Некорректный ввод", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                if (!EnglishWord(input))
                {
                    MessageBox.Show("Должны быть только английские буквы!\nЗнаки препинания можно", "Некорректный ввод", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                int vowel = VowelLetters(input);
                string longWord = LongWord(input);

                VowelsCountTextBox.Text = vowel.ToString();
                LongestWordTextBox.Text = longWord;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private int VowelLetters(string input)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'y', 'A', 'E', 'I', 'O', 'U', 'Y' };
            return input.Count(c => vowels.Contains(c));
        }

        private string LongWord(string input)
        {
            string[] words = input.Split(new[] { ' ', '.', ',', ';', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            return words.OrderByDescending(w => w.Length).FirstOrDefault();
        }
        private bool EnglishWord(string input)
        {
            return input.All(c => char.IsLetter(c) && c <= 'z' && c >= 'A' || char.IsWhiteSpace(c) || char.IsPunctuation(c));
        }
    }
}
