using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AffinTransformation
{

    public class WarnockAlgorithm
    {
        public bool isNotInitIterate = false;
        public bool isIterate = false;
        private List<PolyFigure> _baseFigure;
        private const double TOLERANCE = 1e-5;
        private Bitmap currentMap;
        private struct Params
        {
            public List<Polygon> _activePolygons;
            public Rectangle rect;

            public Params(List<Polygon> activePolygons, int X, int Y, int width, int height)
            {
                _activePolygons = activePolygons;
                rect = new Rectangle(X, Y, width, height);

            }

        }

        private Stack<Params> _paramsStack = new Stack<Params>();
        private double x0, y0, z0;

        private List<Polygon> FiguresToPolygons(List<PolyFigure> figures)
        {
            var p = new List<Polygon>();
            foreach (var f in figures)
            {
                foreach (var triangle in f.GetPolygon())
                {
                    var pol = new Polygon();
                    pol.a = f.GetDot(triangle.aIndex);
                    pol.b = f.GetDot(triangle.bIndex);
                    pol.c = f.GetDot(triangle.cIndex);
                    pol.color = f.Color;
                    float x, y, width, hight;
                    x = Math.Min(Math.Min(pol.a.x, pol.b.x), pol.c.x);
                    y = Math.Min(Math.Min(pol.a.y, pol.b.y), pol.c.y);
                    width = Math.Max(Math.Max(pol.a.x, pol.b.x), pol.c.x) - x;
                    hight = Math.Max(Math.Max(pol.a.y, pol.b.y), pol.c.y) - y;
                    pol.rect = new RectangleF(x, y, width, hight);
                    pol.normal = triangle.normal;
                    p.Add(pol);
                }
            }

            return p;
        }
        struct Polygon
        {
            public Dot a, b, c;
            public Dot normal;
            public RectangleF rect;
            public Color color;
        }

        float VectorProd(Dot a1, Dot b1, Dot a2, Dot b2)
        {
            return VectorProd(b1.x - a1.x, b1.y - a1.y, b2.x - a2.x, b2.y - a2.y);

        }

        Dot Vector(Dot a, Dot b)
        {
            return new Dot(b.x - a.x, b.y - a.y, b.z - a.z, 1);
        }

        float ScalarProd(Dot a, Dot b)
        {
            return (a.x * b.x + a.y * b.y + a.z * b.z);
        }
        float ScalarProd(Dot a1, Dot b1, Dot a2, Dot b2)
        {
            var a = Vector(a1, b1);
            var b = Vector(a2, b2);
            return (a.x * b.x + a.y * b.y + a.z * b.z);
        }
        float VectorProd(float x1, float y1, float x2, float y2)
        {
            return x1 * y2 - y1 * x2;
        }
        bool IsIn(int x, int y, Polygon polygon)
        {
            Dot pixel = new Dot(x, y, 0, 1);
            var prod1 = VectorProd(polygon.a, pixel, polygon.a, polygon.b);
            var prod2 = VectorProd(polygon.b, pixel, polygon.b, polygon.c);
            var prod3 = VectorProd(polygon.c, pixel, polygon.c, polygon.a);
            return (prod1 >= 0 && prod2 >= 0 && prod3 >= 0 || prod1 <= 0 && prod2 <= 0 && prod3 <= 0);
        }
        private void Iteration()
        {
            var par = _paramsStack.Pop();
            var activePolygons = new List<Polygon>();
            var rectf = (RectangleF)(par.rect);
            foreach (var polyg in par._activePolygons)
            {
                //check
                if (rectf.IntersectsWith(polyg.rect))
                    activePolygons.Add(polyg);
            }


            if (activePolygons.Count > 0)
            {
                var r = par.rect;
                int halfWidth = r.Width / 2;
                int halfHeight = r.Height / 2;

                if (r.Width == 1 && r.Height == 1)
                {
                    ////paint
                    float mxmDepth = float.MinValue;
                    Color color = Color.CadetBlue;
                    bool haveColor = false;
                    float delta = 0.5f;
                    foreach (var poly in activePolygons)
                    {
                        if (IsIn(r.X, r.Y, poly))
                        {
                            haveColor = true;
                            var depth = poly.normal.h + poly.normal.x * r.X + poly.normal.y * r.Y;
                            depth /= -poly.normal.z;

                            if (depth > mxmDepth)
                            {
                                mxmDepth = depth;
                                delta = Math.Abs(ScalarProd(new Dot(0, 0, 1, 1), poly.normal));

                                int R, G, B;
                                R = (int)(poly.color.R * delta);
                                G = (int)(poly.color.G * delta);
                                B = (int)(poly.color.B * delta);

                                color = Color.FromArgb(R, G, B);
                            }
                        }

                    }
                    if (haveColor)
                        currentMap.SetPixel(r.X, r.Y, color);
                }
                else if (r.Width == 1)
                {
                    _paramsStack.Push(new Params(activePolygons, r.X, r.Y, r.Width, halfHeight));
                    _paramsStack.Push(new Params(activePolygons, r.X, r.Y + halfHeight, r.Width, r.Height - halfHeight));
                  
                }
                else if (r.Height == 1)
                {
                    _paramsStack.Push(new Params(activePolygons, r.X, r.Y, halfWidth, r.Height));
                    _paramsStack.Push(new Params(activePolygons, r.X + halfWidth, r.Y, r.Width - halfWidth, r.Height));
                }
                else
                {
                    _paramsStack.Push(new Params(activePolygons, r.X, r.Y, halfWidth, halfHeight));
                    _paramsStack.Push(new Params(activePolygons, r.X + halfWidth, r.Y, r.Width - halfWidth, halfHeight));
                    _paramsStack.Push(new Params(activePolygons, r.X, r.Y + halfHeight, halfWidth, r.Height - halfHeight));
                    _paramsStack.Push(new Params(activePolygons, r.X + halfWidth, r.Y + halfHeight, r.Width - halfWidth, r.Height - halfHeight));
                    if (isIterate)
                    {
                        for (int i = r.X; i < r.X + r.Width; i++)
                        {
                            currentMap.SetPixel(i, halfHeight + r.Y, Color.CornflowerBlue);
                        }
                        for (int i = r.Y; i < r.Y + r.Height; i++)
                        {
                            currentMap.SetPixel(halfWidth + r.X, i, Color.CornflowerBlue);
                        }
                    }
                }
            }
        }
        public Bitmap CreateBitmapOfAll(List<PolyFigure> figs, PaintEventArgs e)
        {
            var screen = e.ClipRectangle;
            currentMap = new Bitmap(screen.Width, screen.Height);
            
            x0 = AffinTransformation.x0;
            y0 = AffinTransformation.y0;
            z0 = AffinTransformation.z0;
            var psr = new Params(FiguresToPolygons(figs), screen.X + 2, screen.Y + 2, screen.Width - 3, screen.Height - 3);
            _paramsStack.Push(psr);
            while (_paramsStack.Count > 0)
            {
                Iteration();
            }
            return currentMap;
        }

        public Bitmap CreateBitmapOfIteration( PaintEventArgs e)
        {
            if (_paramsStack.Count == 0)
            {
                isIterate = false;
                return currentMap;

            }
            var a =_paramsStack.Peek();

            Iteration();
            return currentMap;
        }

        public void InitIterateDraw(List<PolyFigure> figs, PaintEventArgs e)
        {
            isNotInitIterate = false;
            var screen = e.ClipRectangle;
            currentMap = new Bitmap(screen.Width, screen.Height);
            x0 = AffinTransformation.x0;
            y0 = AffinTransformation.y0;
            z0 = AffinTransformation.z0;
            var psr = new Params(FiguresToPolygons(figs), screen.X + 2, screen.Y + 2, screen.Width - 3, screen.Height - 3);
            _paramsStack.Push(psr);
        }

        public void StartIterateDraw()
        {
            isNotInitIterate = true;
            isIterate = true;
        }
        public bool IsIterateDrawing()
        {
            return isIterate ;
        }
    }
}