using System;
using System.Collections.Generic;
using System.Drawing;

namespace AffinTransformation
{
    public abstract class Figure
    {
        protected int dotCount;
        protected int baseItemCount;
        protected List<Dot> dots;
        protected List<Dot> baseDots;
        public Color Color { get; set; }
        public void AddDot(float x, float y, float z)
        {
            dots.Add(new Dot(x, y, z, 1));
            baseDots.Add(new Dot(x, y, z, 1));
        }

        public Figure()
        {
            baseDots = new List<Dot>();
            dots = new List<Dot>();
            Color = Color.Green;
        }
        public Dot GetDot(int index) => dots[index];
        public Dot GetBaseDot(int index) => baseDots[index];
        public void Reset() => dots = new List<Dot>(baseDots);
        public string[] Input(in System.IO.TextReader tr, out int index)
        {
            char[] separator = { ' ', '\n', '\r' };
            string[] text = tr.ReadToEnd().Split(separator, StringSplitOptions.RemoveEmptyEntries);
            index = 0;
            dotCount = int.Parse(text[index++]);
            
            dots = new List<Dot>(dotCount);
            baseDots = new List<Dot>(dotCount);
          
            for (int i = 0; i < dotCount; i++)
            {
                float x, y, z;
                x = float.Parse(text[index++]);
                y = float.Parse(text[index++]);
                z = float.Parse(text[index++]);
                AddDot(x, y, z);
            }
            return text;
            }

        public Figure Product(float[,] matrix)
        {
            if (this.GetType().Name == typeof(LineFigure).Name)
            {
                return((LineFigure)this).Product(matrix);
            }
            return ((PolyFigure)this).Product(matrix);
        }
    }
}