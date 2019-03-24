using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Documents;

namespace Example_1
{
    public class SetFontSizeProperty : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new SetFontSizeProperty());
        }
        public SetFontSizeProperty()
        {
            Title = "Set FontSize Property";
            SizeToContent = SizeToContent.WidthAndHeight;
            ResizeMode = ResizeMode.CanMinimize;
            //Задаем размер окна по умолчанию
            FontSize = 16;
            //Объявляем и инициализируем массив размерами
            double[] fntsizes = { 8, 16, 32 };

            //Создаем экземпляр класса Grid и выводим его на экран
            Grid grid = new Grid();
            Content = grid;

            //Создаем строки с высотой, размер которой определяется свойствами размера объекта содержимого.
            for (int i = 0; i < 2; i++)
            {
                RowDefinition row = new RowDefinition();
                row.Height = GridLength.Auto;
                grid.RowDefinitions.Add(row);
            }

            //Создаем колонки с аналогичными свойствами
            for (int i = 0; i < fntsizes.Length; i++)
            {
                ColumnDefinition col = new ColumnDefinition();
                col.Width = GridLength.Auto;
                grid.ColumnDefinitions.Add(col);
            }

            //Создаем кнопки
            for (int i = 0; i < fntsizes.Length; i++)
            {
                Button btn = new Button();
                //Задаем текст кнопки
                btn.Content = new TextBlock(
                    new Run($"Set window FontSize to {fntsizes[i]}"));
                //Задаем значение кнопки
                btn.Tag = fntsizes[i];
                //И задаем выравнивание по центру
                btn.HorizontalAlignment = HorizontalAlignment.Center;
                btn.VerticalAlignment = VerticalAlignment.Center;
                //Вешаем обработчик по клику
                btn.Click += WindowFontSizeOnClick;
                //Добавляем на сетку и задаем соотвествующее положение на ней
                grid.Children.Add(btn);
                Grid.SetRow(btn, 0);
                Grid.SetColumn(btn, i);

                //Все аналогично, только меняем обработчик и расположение
                btn = new Button();
                btn.Content = new TextBlock(
                    new Run($"Set button FontSize to {fntsizes[i]}"));
                btn.Tag = fntsizes[i];
                btn.HorizontalAlignment = HorizontalAlignment.Center;
                btn.VerticalAlignment = VerticalAlignment.Center;
                btn.Click += ButtonFontSizeOnClick;
                grid.Children.Add(btn);
                Grid.SetRow(btn, 1);
                Grid.SetColumn(btn, i);
            }
        }
        //Обработчик событий, который меняет размер шрифта всего окна
        void WindowFontSizeOnClick(object sender, RoutedEventArgs e)
        {
            Button btn = e.Source as Button;
            FontSize = (double)btn.Tag;
        }
        //Обработчик событий, который меняет размер шрифта только нажатой кнопки
        void ButtonFontSizeOnClick(object sender, RoutedEventArgs e)
        {
            Button btn = e.Source as Button;
            btn.FontSize = (double)btn.Tag;
        } 
    }
}