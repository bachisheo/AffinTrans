using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AffinTransformation
{
    public class Painter
    {
        static int x0, y0, z0;
        List<Figure> figures;
        List<Figure> baseFigures;
        public Painter(int X0, int Y0, int Z0)
        {
            figures = new List<Figure>();
            baseFigures = new List<Figure>();
            x0 = X0;
            y0 = Y0;
            z0 = Z0;
        }

        public void PaintAll(Pen pen, PaintEventArgs e)
        {
            for(int i = 0; i < figures.Count(); i++) {
                figures[i] = baseFigures[i].Reflection(false, true, false);
                figures[i] = figures[i].Translation(x0, y0, z0);
                Paint(figures[i], pen, e);
            }
        }
        public void Paint(Figure fig, Pen pen, PaintEventArgs e)
        {
            foreach (Line line in fig.GetLines())
            {
                Dot a = fig.GetDot(line.aNum);
                Dot b = fig.GetDot(line.bNum);
                e.Graphics.DrawLine(pen, a.x, a.y, b.x, b.y);
            }
        }
        public void AddFigure(Figure fig)
        {
            figures.Add(fig);
            baseFigures.Add(fig);
        }
    }
}
