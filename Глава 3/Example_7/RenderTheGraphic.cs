using System;
using System.Windows;

namespace Example_7
{
    class RenderTheGraphic : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new RenderTheGraphic());
        }
        public RenderTheGraphic()
        {
            Title = "Render The Graphic";
            SimpleEllipse elips = new SimpleEllipse();
            Content = elips;
        }
    }
}