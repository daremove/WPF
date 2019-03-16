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
            //не отображаем на панели задача
            ShowInTaskbar = false;
            //ширина и высота по размеру содержимого
            SizeToContent = SizeToContent.WidthAndHeight;
            //не имеет кнопок сворачивания/разворачивания
            WindowStyle = WindowStyle.ToolWindow;
            //располагаем по центру владельца
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
                //размещаем курсор в конце текущего содержимого поля
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