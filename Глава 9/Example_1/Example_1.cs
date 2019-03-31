using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace Example_1
{
    public class ExamineRoutedEvents : Application
    {
        //объявляем статическое свойство только для чтения, содержащая шрифт
        static readonly FontFamily fontfam = new FontFamily("Lucida Console");
        //объявляем строковый формат
        const string strFormat = "{0, -30} {1, -15} {2, -15} {3, -15}";
        //создаем экземпляры StackPanel и DateTime
        StackPanel stackOutput;
        DateTime dtLast;

        [STAThread]
        public static void Main()
        {
            ExamineRoutedEvents app = new ExamineRoutedEvents();
            app.Run();
        }
        //переопределяем метод OnStartup, 
        //который происходит при вызове метода Run() объекта Application.
        protected override void OnStartup(StartupEventArgs e)
        {
            //вызываем контсруктор базового класса
            base.OnStartup(e);

            //создаем окно и задаем заголовок
            Window win = new Window();
            win.Title = "Examine Routed Events";

            //создаем сетку
            Grid grid = new Grid();
            win.Content = grid;

            //создаем 3 строки на сетке, 2 из которых ужимаются под контент,
            //а последняя занимает 100 процентов доступного пространства
            RowDefinition rowdef = new RowDefinition();
            rowdef.Height = GridLength.Auto;
            grid.RowDefinitions.Add(rowdef);

            rowdef = new RowDefinition();
            rowdef.Height = GridLength.Auto;
            grid.RowDefinitions.Add(rowdef);

            rowdef = new RowDefinition();
            rowdef.Height = new GridLength(100, GridUnitType.Star);
            grid.RowDefinitions.Add(rowdef);


            //создаем кнопку и добавляем на сетку
            Button btn = new Button();
            btn.HorizontalAlignment = HorizontalAlignment.Center;
            btn.Margin = new Thickness(24);
            btn.Padding = new Thickness(24);
            grid.Children.Add(btn);

            //создаем текстовый блок и добавляем на кнопку
            TextBlock text = new TextBlock();
            text.FontSize = 24;
            text.Text = win.Title;
            btn.Content = text;

            //создаем строку заголовка с заданным форматированием
            //и добавляем на 2 строку сетки
            TextBlock textHeadings = new TextBlock();
            textHeadings.FontFamily = fontfam;
            textHeadings.Inlines.Add(new Underline(new Run(
                String.Format(strFormat, "Routed Event", "sender", "Source", "OriginalSource"))));
            grid.Children.Add(textHeadings);
            Grid.SetRow(textHeadings, 1);

            //создаем скролл и добавляем на последнюю строку сетки
            ScrollViewer scroll = new ScrollViewer();
            grid.Children.Add(scroll);
            Grid.SetRow(scroll, 2);

            //добавляем StackPanel
            stackOutput = new StackPanel();
            scroll.Content = stackOutput;

            //создаем массив WPF элементов
            UIElement[] els = { win, grid, btn, text };
            //и на каждый элемент вешаем обработчик
            foreach (UIElement el in els)
            {
                el.PreviewKeyDown += AllPurposeEventHandler;
                el.PreviewKeyUp += AllPurposeEventHandler;
                el.PreviewTextInput += AllPurposeEventHandler;
                el.KeyDown += AllPurposeEventHandler;
                el.KeyUp += AllPurposeEventHandler;
                el.TextInput += AllPurposeEventHandler;

                el.MouseDown += AllPurposeEventHandler;
                el.MouseUp += AllPurposeEventHandler;
                el.PreviewMouseDown += AllPurposeEventHandler;
                el.PreviewMouseUp += AllPurposeEventHandler;

                el.StylusDown += AllPurposeEventHandler;
                el.StylusUp += AllPurposeEventHandler;
                el.PreviewStylusDown += AllPurposeEventHandler;
                el.PreviewStylusUp += AllPurposeEventHandler;

                //обрабатываем клик
                el.AddHandler(Button.ClickEvent, new RoutedEventHandler(AllPurposeEventHandler));
            }

            //открываем окно
            win.Show();
        }
        void AllPurposeEventHandler(object sender, RoutedEventArgs e)
        {
            //добавляем пустую строку для удобочитаемости,
            //если временной промежуток превышает 100 мс
            DateTime dtNow = DateTime.Now;
            if (dtNow - dtLast > TimeSpan.FromMilliseconds(100))
                stackOutput.Children.Add(new TextBlock(new Run(" ")));
            dtLast = dtNow;

            //выводим информацию о событии в текстовый блок и добавляем на сетку
            //затем скролим вниз
            TextBlock text = new TextBlock();
            text.FontFamily = fontfam;
            text.Text = String.Format(strFormat, e.RoutedEvent.Name, TypeWithoutNamespace(sender),
                TypeWithoutNamespace(e.Source), TypeWithoutNamespace(e.OriginalSource));
            stackOutput.Children.Add(text);
            (stackOutput.Parent as ScrollViewer).ScrollToBottom();
        }
        //промежуточная функция для вывода без пространства имен
        string TypeWithoutNamespace(object obj)
        {
            string[] astr = obj.GetType().ToString().Split('.');
            return astr[astr.Length - 1];
        }
    }
}