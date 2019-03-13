using System;
using System.Collections.Generic;
using System.IO;
 
namespace graph
{
    public struct Coords
    {
        public double x;
        public double y;
        public double vx;
        public double vy;
 
        public Coords(double x, double y, double vx, double vy)
        {
            this.x = x;
            this.y = y;
            this.vx = vx;
            this.vy = vy;
        }
    }
     public class Application
    {
        public double G { get; } = 9.8;
        public double DT { get; } = 0.01;

        public List<Coords> GetCoords(double v0, int angle, double k, double m)
        {
            List<Coords> arrayOfCoords = new List<Coords>();
            double x_prev, y_prev, vx_prev, vy_prev;
            double x_next, y_next, vx_next, vy_next;

            x_prev = y_prev = 0;
            vx_prev = v0 * Math.Cos(angle * Math.PI / 180);
            vy_prev = v0 * Math.Sin(angle * Math.PI / 180);

            y_next = 0;
            while (y_next >= 0)
            {
                x_next = x_prev + vx_prev * DT;
                y_next = y_prev + vy_prev * DT;
                vx_next = vx_prev * (1 - k / m * DT);
                vy_next = vy_prev - DT * (G + k / m * vy_prev);
                Coords item = new Coords(x_next, y_next, vx_next, vy_next);
                arrayOfCoords.Add(item);
                x_prev = x_next;
                y_prev = y_next;
                vx_prev = vx_next;
                vy_prev = vy_next;
            };
 
            return arrayOfCoords;
        }
        public void ReadFromFile(string input, string output)
        {
            List<Coords> arrayOfCoords;
 
            using (StreamReader sr = new StreamReader(input, System.Text.Encoding.Default))
            {
                string line;
                double speed = 0;
                int angle = 0;
                double k = 0;
                double m = 0;
 
                while ((line = sr.ReadLine()) != null)
                {
                    string[] words = line.Split(new char[] { ':' });
 
                    if (words[0] == "speed")
                        speed = Convert.ToDouble(words[1]);
                    if (words[0] == "angle") 
                        angle = Convert.ToInt32(words[1]);
                    if (words[0] == "k")
                        k = Convert.ToDouble(words[1]);
                    if (words[0] == "m")
                        m = Convert.ToDouble(words[1]);
                }
 
               arrayOfCoords = this.GetCoords(speed, angle, k, m);
            }
 
            using (StreamWriter sw = new StreamWriter(output, false, System.Text.Encoding.Default))
            {
                foreach (var elem in arrayOfCoords)
                {
                    sw.Write($"{elem.x};{elem.y}\n");
                }
            }
        }
 
        public static void Main()
        {
            Application app = new Application();

            app.ReadFromFile("../../input.txt", "../../output.txt");
        }
    }
}