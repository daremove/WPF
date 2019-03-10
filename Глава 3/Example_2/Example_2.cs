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
            Title = "Display Some Text";
            Content = "Content can be simple text!";
        }
    }
}
