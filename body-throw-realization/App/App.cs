using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Input;
using System.Windows.Data;
using System.Collections.Generic;
using System.Windows.Shapes;

namespace App
{
    public class App : Window
    {
        TextBox speed, angle;
        Canvas canvas;
        double offset;

        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new App());
        }
        public App()
        {
            Title = "Бросок тела";

            Grid grid = new Grid();
            grid.ShowGridLines = true;
            Content = grid;

            for (int i = 0; i < 3; i++)
            {
                RowDefinition rowdef = new RowDefinition();
                rowdef.Height = GridLength.Auto;
                grid.RowDefinitions.Add(rowdef);
            }

            for (int j = 0; j < 3; j++)
            {
                ColumnDefinition coldef = new ColumnDefinition();
                coldef.Width = new GridLength(150, GridUnitType.Pixel);
                grid.ColumnDefinitions.Add(coldef);
            }

            string[] strLabels = { "_Speed:", "_Angle:" };
            for (int i = 0; i < strLabels.Length; i++)
            {
                Label lbl = new Label();
                lbl.Content = strLabels[i];
                lbl.Margin = new Thickness(5);
                grid.Children.Add(lbl);
                Grid.SetRow(lbl, i);
                Grid.SetColumn(lbl, 0);

                TextBox txtbox = new TextBox();
                txtbox.Width = 100;
                txtbox.Margin = new Thickness(5);

                if (i == 0)
                    speed = txtbox;
                else
                    angle = txtbox;

                grid.Children.Add(txtbox);
                Grid.SetRow(txtbox, i);
                Grid.SetColumn(txtbox, 1);
            }

            Button btn = new Button();
            btn.Content = "_Посчитать";
            btn.VerticalAlignment = VerticalAlignment.Center;
            btn.Margin = new Thickness(5);
            Binding binding = new Binding();
            btn.Click += Calculate;
            grid.Children.Add(btn);
            Grid.SetRow(btn, 0);
            Grid.SetColumn(btn, 2);
            Grid.SetRowSpan(btn, 2);

            canvas = new Canvas();
            
            ScaleTransform scaleTransform = new ScaleTransform(1, -1, 0, 0);
            //TranslateTransform translate = new TranslateTransform(0, offset);
            //TransformGroup group = new TransformGroup();
            //group.Children.Add(scaleTransform);
            //group.Children.Add(translate);

            canvas.RenderTransform = scaleTransform;
            
   
            canvas.HorizontalAlignment = HorizontalAlignment.Stretch;
            canvas.VerticalAlignment = VerticalAlignment.Stretch;
            canvas.Width = 1000;
            canvas.Height = 400;
            offset = canvas.Height;
            Brush brush = new SolidColorBrush(Colors.Red);
            brush.Opacity = 0.1;
            canvas.Background = brush;
            grid.Children.Add(canvas);
            Grid.SetRow(canvas, 2);
            Grid.SetColumn(canvas, 0);
            Grid.SetColumnSpan(canvas, 3);
        }
        void Calculate(object sender, RoutedEventArgs e)
        {
            canvas.Children.Clear();
            Program prg = new Program();
            List<Coords> result = prg.GetCoords(Convert.ToDouble(speed.Text), Convert.ToInt32(angle.Text), 2.0, 100.0);
            Polyline pol = new Polyline();
            pol.StrokeThickness = 1;
            pol.Stroke = Brushes.Red;
            PointCollection coords = new PointCollection();

            foreach (Coords elem in result)
            {
                Console.WriteLine(elem.y);
                Point point = new Point(elem.x, elem.y);
                coords.Add(point);
            }

            pol.Points = coords;
            canvas.Children.Add(pol);
            Canvas.SetTop(pol, 0);
            Canvas.SetLeft(pol, 0);
        } 
    }
}