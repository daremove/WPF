﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Input;

namespace Example_2
{
    public class FormatTheButton : Window
    {
        Run runButton;
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new FormatTheButton());
        }
        public FormatTheButton()
        {
            Title = "Format the Button";

            Button btn = new Button();
            btn.HorizontalAlignment = HorizontalAlignment.Center;
            btn.VerticalAlignment = VerticalAlignment.Center;
            btn.MouseEnter += ButtonOnMouseEnter;
            btn.MouseLeave += ButtonOnMouseLeave;
            Content = btn;

            TextBlock txtblk = new TextBlock();
            txtblk.FontSize = 24;
            txtblk.TextAlignment = TextAlignment.Center;
            btn.Content = txtblk;

            txtblk.Inlines.Add(new Italic(new Run("click")));
            txtblk.Inlines.Add(" the ");
            txtblk.Inlines.Add(runButton = new Run("button"));
            txtblk.Inlines.Add(new LineBreak());
            txtblk.Inlines.Add("to launch the ");
            txtblk.Inlines.Add(new Bold(new Run("rocket"))) ;
        }
        void ButtonOnMouseEnter(object sender, MouseEventArgs e)
        {
            runButton.Foreground = Brushes.Red;
        }
        void ButtonOnMouseLeave(object sender, MouseEventArgs e)
        {
            runButton.Foreground = SystemColors.ControlTextBrush;
        }
    }
}