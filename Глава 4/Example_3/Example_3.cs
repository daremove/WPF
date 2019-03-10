using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Example_3
{
    public class ImageTheButton : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new ImageTheButton());
        }
        public ImageTheButton()
        {
            Title = "Image the Button";
            Uri uri = new Uri("pack://application:,,,/catbread.jpg");
            BitmapImage bitmap = new BitmapImage(uri);
            Image img = new Image();
            img.Source = bitmap;
            img.Stretch = Stretch.None;

            Button btn = new Button();
            btn.Content = img;
            btn.HorizontalAlignment = HorizontalAlignment.Center;
            btn.VerticalAlignment = VerticalAlignment.Center;

            Content = btn;
        }
    }
    
}