using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Example_1
{
    class DockAroundTheBlock : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new DockAroundTheBlock());
        }
        public DockAroundTheBlock()
        {
            Title = "Dock Around the Block";

            //Создаем экземпляр класса DockPanel, который
            //определяет область, в которой можно упорядочивать 
            //дочерние элементы горизонтально либо вертикально относительно друг друга.
            DockPanel dock = new DockPanel();
            //Выводим в контентую область
            Content = dock;
            for (int i = 0; i < 17; i++)
            {
                Button btn = new Button();
                btn.Content = $"Button No. {i + 1}";
                //Добавляем в DockPanel кнопку
                dock.Children.Add(btn);
                //Последовательно присваиваем каждой кнопке значения из перечисления Dock:
                //Dock.Left Dock.Top Dock.Right Dock.Bottom
                btn.SetValue(DockPanel.DockProperty, (Dock)(i % 4));
            }
        }
    }
}