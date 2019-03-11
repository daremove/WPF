using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Example_7
{
    class UriDialog : Window
    {
        TextBox txtbox;

        public UriDialog()
        {
            Title = "Enter a URI";
            ShowInTaskbar = false;
            SizeToContent = SizeToContent.WidthAndHeight;
            WindowStyle = WindowStyle.ToolWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;

            txtbox = new TextBox();
            txtbox.Margin = new Thickness(48);
            Content = txtbox;

            txtbox.Focus();
        }
        public string Text
        {
            set
            {
                txtbox.Text = value;
                txtbox.SelectionStart = txtbox.Text.Length;
            }
            get
            {
                return txtbox.Text;
            }
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.Key == Key.Enter)
                Close();
        }
    }
}