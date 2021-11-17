using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
namespace AffinTransformation
{


    public struct Line
    {
        public int aNum, bNum;
        public Line(int a, int b)
        {
            aNum = a;
            bNum = b;
        }
    }
    public class Figure
    {
        public Color Color { get; set; }
        public const int DEM = 4;
        public Figure()
        {
            baseDots = new List<Dot>();
            dots = new List<Dot>();
            lines = new List<Line>();
            Color = Color.BlueViolet;
        }
        public void Input(in TextReader tr)
        {
            char[] separator = { ' ', '\n', '\r' };
            string[] text = tr.ReadToEnd().Split(separator, StringSplitOptions.RemoveEmptyEntries);
            int ind = 0;
            dotCount = int.Parse(text[ind++]);
            lineCount = int.Parse(text[ind++]);
            dots = new List<Dot>(dotCount);
            baseDots = new List<Dot>(dotCount);
            lines = new List<Line>(lineCount);
            for (int i = 0; i < dotCount; i++)
            {
                float x, y, z;
                x = float.Parse(text[ind++]);
                y = float.Parse(text[ind++]);
                z = float.Parse(text[ind++]);
                AddDot(x, y, z);
            }

            for (int i = 0; i < lineCount; i++)
            {
                int a = int.Parse(text[ind++]);
                int b = int.Parse(text[ind++]);
                lines.Add(new Line(a - 1, b - 1));
            }

        }
        public void AddDot(float x, float y, float z)
        {
            dots.Add(new Dot(x, y, z, 1));
            baseDots.Add(new Dot(x, y, z, 1));
        }
        public void AddLine(int a, int b) => lines.Add(new Line(a, b));
        public List<Line> GetLines() => lines;
        public Dot GetDot(int index) => dots[index];
        public Dot GetBaseDot(int index) => baseDots[index];


        public Figure Product(float[,] matrix)
        {
            Figure prod = new Figure();
            prod.lineCount = lineCount;
            prod.dotCount = dotCount;
            prod.baseDots = baseDots;
            prod.lines = new List<Line>(lines);
            prod.dots = new List<Dot>(dotCount);
            foreach (Dot dot in dots)
            {
                prod.dots.Add(dot * matrix);
            }
            return prod;
        }
        public void Reset() => dots = new List<Dot>(baseDots);

        int dotCount;
        int lineCount;
        List<Dot> dots;
        List<Dot> baseDots;
        List<Line> lines;

    }
}
