using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Example_1
{
    public class DisplaySomeText : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new DisplaySomeText());
        }
        public DisplaySomeText()
        {
            //Задаем шрифт
            FontFamily = new FontFamily("Times New Roman");
            //Задаем размер шрифта, начертание и толщину
            FontSize = 32;
            FontStyle = FontStyles.Italic;
            FontWeight = FontWeights.Bold;

            Title = "Display Some Text";
            //Пример того, как свойству Content можно задать текстовую строку
            Content = "Content can be simple text!";

            //Задаем цвет фона и текста
            Background = new SolidColorBrush(Colors.Red);
            Foreground = new SolidColorBrush(Colors.White);

            //Позволяем окну автоматически подстраиваться под размеры содержимого
            SizeToContent = SizeToContent.WidthAndHeight;
            //Запрещаем менять размеры окны
            ResizeMode = ResizeMode.NoResize;

            //Задаем цвет рамки и толщину
            BorderBrush = Brushes.SaddleBrown;
            BorderThickness = new Thickness(25, 50, 75, 100);
        }
    }
}
