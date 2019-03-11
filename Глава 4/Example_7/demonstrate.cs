﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Example_7
{
    public class NavigateTheWeb : Window
    {
        Frame frm;

        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new NavigateTheWeb());
        }
        public NavigateTheWeb()
        {
            Title = "Navigate the Web";

            frm = new Frame();
            Content = frm;

            Loaded += OnWindowLoaded;
        }
        void OnWindowLoaded(object sender, RoutedEventArgs e)
        {
            UriDialog dlg = new UriDialog();
            dlg.Owner = this;
            dlg.Text = "http://";
            dlg.ShowDialog();

            try
            {
                frm.Source = new Uri(dlg.Text);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, Title);
            }
        }
    }
}