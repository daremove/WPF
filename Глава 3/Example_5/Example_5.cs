using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Documents;

namespace Example_5
{
   class FormatTheText : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new FormatTheText());
        }
        public FormatTheText()
        {
            Title = "Format the Text";
            TextBlock txt = new TextBlock();
            txt.FontSize = 32;
            txt.Inlines.Add("This is some");
            txt.Inlines.Add(new Italic(new Run("italic")));
            txt.Inlines.Add(" text, and this is some");
            txt.Inlines.Add(new Bold(new Italic(new Run(" bold italic"))));
            txt.Inlines.Add(" text.");
            txt.TextWrapping = TextWrapping.Wrap;

            Content = txt;
        }
    }
}
