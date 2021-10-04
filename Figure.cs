using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
namespace AffinTransformation
{

    public struct Dot
    {
        public float x, y, z, h;
        public Dot(float x, float y, float z, float h)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.h = h;
        }
        public Dot Product(float[,] matrix)
        {
            float[] coord = { 0, 0, 0, 0 };
            float[] old = { x, y, z, h };
            for (int j = 0; j < 4; j++)
            {
                for (int k = 0; k < 4; k++)
                {
                    coord[j] += old[k] * matrix[k, j];
                }
            }
            return new Dot(coord[0], coord[1], coord[2], coord[3]);
        }
    }
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
        public const int DEM = 4;
        public Figure()
        {
            dots = new List<Dot>();
            lines = new List<Line>();
        }
        public void Input(in TextReader tr)
        {
            char[] separator = { ' ', '\n', '\r' };
            string[] text = tr.ReadToEnd().Split(separator, StringSplitOptions.RemoveEmptyEntries);
            int ind = 0;
            dotCount = int.Parse(text[ind++]);
            lineCount = int.Parse(text[ind++]);
            dots = new List<Dot>(dotCount);
            lines = new List<Line>(lineCount);
            for (int i = 0; i < dotCount; i++)
            {
                float x, y, z;
                x = float.Parse(text[ind++]);
                y = float.Parse(text[ind++]);
                z = float.Parse(text[ind++]);
                AddDot(x, y, x);
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
        }
        public void AddLine(int a, int b)
        {
            lines.Add(new Line(a, b));
        }
        public List<Line> GetLines()
        {
            return lines;
        }
        public Dot GetDot(int index)
        {
            return dots[index];
        }
        ///Перенос
        public Figure Translation(float dx, float dy, float dz)
        {
            float[,] matrix = new float[4, 4];
            for (int i = 0; i < 4; i++)
                matrix[i, i] = 1;
            matrix[3, 0] = dx;
            matrix[3, 1] = dy;
            matrix[3, 2] = dz;
            return Product(matrix);
        }
        public Figure Reflection(bool rx, bool ry, bool rz) {
            float[,] matrix = new float[4, 4];
            matrix[0,0] = rx ? -1 : 1;
            matrix[1,1] = ry ? -1 : 1;
            matrix[2,2] = rz ? -1 : 1;
            matrix[3,3] = 1;
            return Product(matrix);

        }

        /* public Figure Dilatation(float ax, float ay, float az) { }
         public Figure RotationX(float angle) { }
         public Figure RotationY(float angle) { }
         public Figure RotationZ(float angle) { }*/
        public Figure Product(float[,] matrix)
        {
            Figure prod = new Figure();
            prod.lineCount = lineCount;
            prod.dotCount = dotCount;
            prod.lines = new List<Line>(lines);
            prod.dots = new List<Dot>(dotCount);
            foreach (Dot dot in dots)
            {
                prod.dots.Add(dot.Product(matrix));
            }
            return prod;
        }
        int dotCount;
        int lineCount;
        List<Dot> dots;
        List<Line> lines;

    }
}
