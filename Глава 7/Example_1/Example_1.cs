using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Example_1
{
    public class PaintTheButton : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new PaintTheButton());
        }
        public PaintTheButton()
        {
            Title = "Paint the Button";

            Button btn = new Button();
            btn.HorizontalAlignment = HorizontalAlignment.Center;
            btn.VerticalAlignment = VerticalAlignment.Center;
            Content = btn;

            //Создаем экземпляр объекта Canvas
            Canvas canv = new Canvas();
            //Задаем ширину и высоту
            canv.Width = 144;
            canv.Height = 144;
            //Выводим canvas как содержимое кнопки
            btn.Content = canv;

            //Создаем прямоугольник
            Rectangle rect = new Rectangle();
            //Задаем ширину и высоту как у canvas
            rect.Width = canv.Width;
            rect.Height = canv.Height;
            //Задаем border radius
            rect.RadiusX = 24;
            rect.RadiusY = 24;
            //Окрашиваем в синий цвет
            rect.Fill = Brushes.Blue;
            //И добавляем на canvas
            canv.Children.Add(rect);
            //С помощью статических методов располагаем прямоугольник в левом верхнем углу
            Canvas.SetLeft(rect, 0);
            Canvas.SetRight(rect, 0);

            //Создаем многоугольник
            Polygon poly = new Polygon();
            //Окрашиваем его в желтый цвет
            poly.Fill = Brushes.Yellow;
            //Определяем вершины как коллекцию точек
            poly.Points = new PointCollection();
            for (int i = 0; i < 5; i++)
            {
                //Задаем координаты вершинам и добавляем их
                double angle = i * 4 * Math.PI / 5;
                Point pt = new Point(48 * Math.Sin(angle), -48 * Math.Cos(angle));

                poly.Points.Add(pt);
            }
            //Добавляем многоугольник на canvas
            canv.Children.Add(poly);
            //Располагаем его по центру
            Canvas.SetLeft(poly, canv.Width / 2);
            Canvas.SetTop(poly, canv.Height / 2);
        }
    }
}