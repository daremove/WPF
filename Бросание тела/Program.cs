using System;
using System.Collections.Generic;
using System.IO;

namespace graph
{
    public struct Coords
    {
        public double x;
        public double y;

        public Coords(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }
    public class Application
    {
        public double G { get; } = 9.8;
        public List<Coords> GetCoords(double v0, double angle)
        {
            List<Coords> arrayOfCoords = new List<Coords>();
            double flightTime = 2 * v0 * Math.Sin(angle) / G;

            for (double i = 0; i < flightTime; i += 0.1)
            {
                double x = Math.Round(v0 * i * Math.Cos(angle), 2),
                       y = Math.Round(v0 * i * Math.Sin(angle) - G * Math.Pow(i, 2) / 2, 2);

                Coords item = new Coords(x, y);

                arrayOfCoords.Add(item);
            }

            double lastX = Math.Round(v0 * flightTime * Math.Cos(angle), 2),
                   lastY = Math.Round(v0 * flightTime * Math.Sin(angle) - G * Math.Pow(flightTime, 2) / 2, 2);

            Coords lastItem = new Coords(lastX, lastY);

            arrayOfCoords.Add(lastItem);

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

                while ((line = sr.ReadLine()) != null)
                {
                    string[] words = line.Split(new char[] { ':' });

                    if (words[0] == "speed")
                        speed = Convert.ToDouble(words[1]);
                    if (words[0] == "angle")
                        angle = Convert.ToInt32(words[1]);
                }

                arrayOfCoords = this.GetCoords(speed, angle);
            }

            using (StreamWriter sw = new StreamWriter(output, false, System.Text.Encoding.Default))
            {
                foreach (var elem in arrayOfCoords)
                {
                    sw.Write($"x: {elem.x}, y: {elem.y}\n");
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