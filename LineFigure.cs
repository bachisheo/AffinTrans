using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace AffinTransformation
{
    public class LineFigure : PolyFigure
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

        public LineFigure()
        {
            lines = new List<Line>();
            Color = Color.Aquamarine;
        }
        public void Input(in TextReader tr)
        {
            int ind;
            var text = base.Input(tr, out ind);
            baseItemCount = int.Parse(text[ind++]);
            lines = new List<Line>(baseItemCount);
            for (int i = 0; i < baseItemCount; i++)
            {
                int a = int.Parse(text[ind++]);
                int b = int.Parse(text[ind++]);
                Color color = Color.DarkSlateBlue;
                lines.Add(new Line(a - 1, b - 1));
            }
        }
        List<Line> lines;
        public new LineFigure Product(float[,] matrix)
        {
            var prod = new LineFigure();
            prod.baseItemCount = baseItemCount;
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
        public void AddLine(int a, int b) => lines.Add(new Line(a, b));
        public List<Line> GetLines() => lines;
    }
}