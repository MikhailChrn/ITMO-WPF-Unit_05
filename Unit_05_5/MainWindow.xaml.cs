using System;
using System.IO;
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
using Microsoft.Win32;

namespace Unit_05_5
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

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                textBox.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, textBox.Text);
            }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MenuItem_Click_Close(object sender, RoutedEventArgs e)
        {
            textBox.Clear();
        }




        //Тип шрифта
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string fontName = ((sender as ComboBox).SelectedItem as TextBlock).Text;
            if (textBox != null)
            {
                textBox.FontFamily = new FontFamily(fontName);
            }
        }
        //Размер шрифта
        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            string fontSize = ((sender as ComboBox).SelectedItem as TextBlock).Text;
            if (textBox != null)
            {
                textBox.FontSize = Convert.ToDouble(fontSize);
            }
        }

        //Тумблеры типа Button для переключение параметров шрифта
        bool isBolt = false;
        bool isItalic = false;
        bool isUnder = false;

        private void Bolt_Click(object sender, RoutedEventArgs e)
        {
            if (isBolt == false)
            {
                textBox.FontWeight = FontWeights.Bold;
                isBolt = true;
            }
            else
            {
                textBox.FontWeight = FontWeights.Regular;
                isBolt = false;
            }
        }
        private void Italic_Click(object sender, RoutedEventArgs e)
        {
            if (isItalic == false)
            {
                textBox.FontStyle = FontStyles.Italic;
                isItalic = true;
            }
            else
            {
                textBox.FontStyle = FontStyles.Normal;
                isItalic = false;
            }
        }
        private void Under_Click(object sender, RoutedEventArgs e)
        {
            if (isUnder == false)
            {
                textBox.TextDecorations = TextDecorations.Underline;
                isUnder = true;
            }
            else
            {
                textBox.TextDecorations = null;
                isUnder = false;
            }
        }
        //Переключение цвета шрифта типа RadioButton
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
            {
                textBox.Foreground = Brushes.Black;
            }
        }
        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
            {
                textBox.Foreground = Brushes.Red;
            }
        }

    }
}
