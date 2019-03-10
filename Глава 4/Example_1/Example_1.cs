using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Example_1
{
    public class ClickTheButton : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new ClickTheButton());
        }
        public ClickTheButton()
        {
            Title = "Click the Button";
            //Создаем экземпляр класса Кнопка
            Button btn = new Button();
            //Задаем текст кнопки, с возможностью подчеркивания первой буквы, при нажатии на alt
            btn.Content = "_Click me, please!";
            //Задаем внешние отступы для кнопки
            btn.Margin = new Thickness(96);
            //Задаем внутренние отступы для кнопки
            btn.Padding = new Thickness(96);
            //Задаем настройки шрифта для кнопки
            btn.FontSize = 48;
            btn.FontFamily = new FontFamily("Times New Roman");
            //Задаем цвет фона для кнопки
            btn.Background = Brushes.Red;
            //Задаем цвет текста для кнопки
            btn.Foreground = Brushes.DarkSalmon;
            //Задаем цвет бордера для кнопки
            btn.BorderBrush = Brushes.Magenta;
            //Задаем настройки выравнивания для текста внутри кнопки
            btn.HorizontalContentAlignment = HorizontalAlignment.Left;
            btn.VerticalContentAlignment = VerticalAlignment.Bottom;
            //Выравниваем кнопку по центру экрана
            btn.HorizontalAlignment = HorizontalAlignment.Center;
            btn.VerticalAlignment = VerticalAlignment.Center;
            //Привязываем обработчик событий по клику
            btn.Click += ButtonOnClick;
            //Выводим кнопку на экран
            Content = btn;
        }
        void ButtonOnClick(object sender, RoutedEventArgs e)
        {
            //При клике на кнопку выводим модальное окно
            MessageBox.Show("The button has been clicked and all is well.", Title);
        }
    }
}