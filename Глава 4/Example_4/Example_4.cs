﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Example_4
{
    public class CommandTheButton : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new CommandTheButton());
        }
        public CommandTheButton()
        {
            Title = "Command the Button";
            Button btn = new Button();
            btn.HorizontalAlignment = HorizontalAlignment.Center;
            btn.VerticalAlignment = VerticalAlignment.Center;
            btn.Command = ApplicationCommands.Paste;
            btn.Content = ApplicationCommands.Paste.Text;
            Content = btn;

            CommandBindings.Add(new CommandBinding(
                ApplicationCommands.Paste, PasteOnExecute, PasteCanExecute));
        }
        void PasteOnExecute(object sender, ExecutedRoutedEventArgs e)
        {
            Title = Clipboard.GetText();
        }
        void PasteCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = Clipboard.ContainsText();
        }
        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);
            Title = "Command the Button";
        }
    }
}