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

namespace Unit_05_6
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

        private void MenuItem_Save(object sender, RoutedEventArgs e)
        //Заимствовано с сайта https://stackoverflow.com !!!!
        //Как работает практически не понятно !!!
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.FileName = "savedimage"; // Default file name
            dlg.DefaultExt = ".jpg"; // Default file extension
            dlg.Filter = "Image (.jpg)|*.jpg"; // Filter files by extension

            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                string filename = dlg.FileName;
                //get the dimensions of the ink control
                int margin = (int)this.incCanvas.Margin.Left;
                int width = (int)this.incCanvas.ActualWidth - margin;
                int height = (int)this.incCanvas.ActualHeight - margin;
                //render ink to bitmap
                RenderTargetBitmap rtb =
                new RenderTargetBitmap(width, height, 96d, 96d, PixelFormats.Default);
                rtb.Render(incCanvas);

                using (FileStream fs = new FileStream(filename, FileMode.Create))
                {
                    BmpBitmapEncoder encoder = new BmpBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(rtb));
                    encoder.Save(fs);
                }
            }
        }

        private void MenuItem_Clear(object sender, RoutedEventArgs e)
        //Очистка рабочего экрана
        {
            incCanvas.Strokes.Clear();
        }

        private void MenuItem_Close(object sender, RoutedEventArgs e)
        //Закрытие приложения
        {
            Application.Current.Shutdown();
        }

        // Блок выбора цветов
        private void Color_Black(object sender, RoutedEventArgs e)
        {
            incCanvas.DefaultDrawingAttributes.Color = Colors.Black;
        }
        private void Color_White(object sender, RoutedEventArgs e)
        {
            incCanvas.DefaultDrawingAttributes.Color = Colors.White;
        }
        private void Color_Red(object sender, RoutedEventArgs e)
        {
            incCanvas.DefaultDrawingAttributes.Color = Colors.Red;
        }
        private void Color_Blue(object sender, RoutedEventArgs e)
        {
            incCanvas.DefaultDrawingAttributes.Color = Colors.Blue;
        }
        private void Color_Green(object sender, RoutedEventArgs e)
        {
            incCanvas.DefaultDrawingAttributes.Color = Colors.Green;
        }


    }
}
