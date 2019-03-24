using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Example_4
{
    public class DesignAButton : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new DesignAButton());
        }
        public DesignAButton()
        {
            Title = "Design a Button";
            Button btn = new Button();
            btn.HorizontalAlignment = HorizontalAlignment.Center;
            btn.VerticalAlignment = VerticalAlignment.Center;
            btn.Click += ButtonOnClick;
            Content = btn;

            StackPanel stack = new StackPanel();
            btn.Content = stack;

            stack.Children.Add(ZigZag(10));

            Label lbl = new Label();
            lbl.Content = "_Read books!";
            lbl.HorizontalContentAlignment = HorizontalAlignment.Center;

            stack.Children.Add(lbl);

            stack.Children.Add(ZigZag(0));
        }
        Polyline ZigZag(int offset)
        {
            Polyline poly = new Polyline();
            poly.Stroke = SystemColors.ControlTextBrush;
            poly.Points = new PointCollection();
            for (int x = 0; x <= 100; x += 10)
                poly.Points.Add(new Point(x, (x + offset) % 20));

            return poly;
        }
        void ButtonOnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("The button has been clicked", Title);
        }
    }
}