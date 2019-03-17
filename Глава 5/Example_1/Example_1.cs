using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Example_1
{
    class StackTenButtons : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new StackTenButtons());
        }
        public StackTenButtons()
        {
            Title = "Stack Ten Buttons";
            //Указываем, как будет автоматически изменен размер окна 
            //в соответствии с размером его содержимого
            SizeToContent = SizeToContent.WidthAndHeight;
            //Окно может быть только свернуто и восстановлено
            ResizeMode = ResizeMode.CanMinimize;

            //Создаем экземпляр класса StackPanel, который
            //выравнивает дочерние элементы в одну линию, 
            //ориентированную горизонтально или вертикально.
            StackPanel stack = new StackPanel();
            //Задаем внешние отступы панели
            stack.Margin = new Thickness(5);
            //Выводим панель в контент окна
            Content = stack;

            //Создаем экземпляр класса Random, который
            //представляет генератор псевдослучайных чисел
            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                //Создаем кнопку
                Button btn = new Button();
                //Задаем кнопке внешние отступы
                btn.Margin = new Thickness(5);
                //Задаем имя кнопки
                btn.Name = ((char)('A' + i)).ToString();
                //Задаем случайный размер кнопки от 0 до 10
                btn.FontSize += rand.Next(10);
                //Задаем контент кнопки
                btn.Content = $"Button {btn.Name} says 'Click me'";
                //Вешаем обработчик на клик
                btn.Click += ButtonOnClick;
                //Добавляем кнопку в StackPanel
                stack.Children.Add(btn);
            }
        }
        void ButtonOnClick(object sender, RoutedEventArgs e)
        {
            //Получаем кнопку, по которой был произведен клик
            Button btn = e.Source as Button;
            //Выводим сообщение о клике
            MessageBox.Show($"Button {btn.Name} has been clicked", "Button Click");
        }
    }
}