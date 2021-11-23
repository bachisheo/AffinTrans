using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
namespace AffinTransformation
{ 
    public class PolyFigure : Figure
    {
        public class Triangle
        {
            public int aIndex { get; }
            public int bIndex { get; }
            public int cIndex { get; }
            public Color color { get; }
            public Dot normal { get; set; }

            public Triangle(int a, int b, int c, Color col)
            {
                aIndex = a;
                bIndex = b;
                cIndex = c;
                color = col;
                normal = new Dot(0, 0, 0, 1);
            }
        }
        public PolyFigure()
        {
            triangles = new List<Triangle>();
            Color = Color.BlueViolet;
        }
      

        public void Input(in TextReader tr)
        {
            int ind;
            var text = base.Input(tr, out ind);
            baseItemCount = int.Parse(text[ind++]);
            triangles = new List<Triangle>(baseItemCount);
            for (int i = 0; i < baseItemCount; i++)
            {
                int a = int.Parse(text[ind++]);
                int b = int.Parse(text[ind++]);
                int c = int.Parse(text[ind++]);
                Color color = Color.Aqua;
                triangles.Add(new Triangle(a - 1, b - 1, c - 1, color));
            }
        }
        public void AddPolygon(int a, int b, int c, Color col) => triangles.Add(new Triangle(a, b, c,col ));
        public List<Triangle> GetPolygon() => triangles;



        public new PolyFigure Product(float[,] matrix)
        {
            PolyFigure prod = new PolyFigure();
            prod.Color = Color;
            prod.baseItemCount = baseItemCount;
            prod.dotCount = dotCount;
            prod.baseDots = baseDots;
            prod.triangles = new List<Triangle>(triangles);
            prod.dots = new List<Dot>(dotCount);
            foreach (Dot dot in dots)
            {
                prod.dots.Add(dot * matrix);
            }
            return prod;
        }

        public void CalculateNormals()
        {
            for(int i = 0; i < triangles.Count; i++)
            {
                var tr = triangles[i];
                triangles[i].normal = Math3D.GetNormalOfSurface(GetDot(tr.aIndex), GetDot(tr.bIndex), GetDot(tr.cIndex));
            }
        }
        List<Triangle> triangles;

    }
}
