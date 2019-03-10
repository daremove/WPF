using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace Example_5
{
    public class ToggleTheButton : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new ToggleTheButton());
        }
        public ToggleTheButton()
        {
            Title = "Toggle the Button";
            CheckBox btn = new CheckBox();
            btn.Content = "Can _Resize";
            btn.HorizontalAlignment = HorizontalAlignment.Center;
            btn.VerticalAlignment = VerticalAlignment.Center;
            btn.IsChecked = (ResizeMode == ResizeMode.CanResize);
            btn.Checked += ButtonOnChecked;
            btn.Unchecked += ButtonOnChecked;
            Content = btn;
        }
        void ButtonOnChecked(object sender, RoutedEventArgs e)
        {
            ToggleButton btn = sender as ToggleButton;
            ResizeMode = (bool)btn.IsChecked ? ResizeMode.CanResize : ResizeMode.NoResize;
        }
    }
}