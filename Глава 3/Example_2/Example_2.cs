using System;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Example_2
{
    public class RecordKeyStrokes : Window
    {
        StringBuilder build = new StringBuilder("text");

        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new RecordKeyStrokes());
        }
        public RecordKeyStrokes()
        {
            Title = "Record Keystrokes";
            Content = build;
        }
        protected override void OnTextInput(TextCompositionEventArgs e)
        {
            base.OnTextInput(e);
            string str = Content as string;
            if (e.Text == "\b")
            {
                if (build.Length > 0)
                    build.Remove(build.Length - 1, 1);
            }
            else
            {
                build.Append(e.Text);
            }
            Content = null;
            Content = build;
        }
    }
}
