using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
        float VectorProd(float x1, float y1, float x2, float y2)
        {
            return x1 * y2 - y1 * x2;
        }
        Dot Vector(Dot a, Dot b)
        {
            return new Dot(b.x - a.x, b.y - a.y, b.z - a.z, 1);
        }

        bool IsIntersect(Dot a1, Dot b1, Dot a2, Dot b2)
        {
            var res1 = VectorProd(a1, b1, a1, a2);
            var res2 = VectorProd(a1, b1, a1, b2);
            return res1 * res2 < 0;
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

        bool IsIn(int x, int y, Polygon polygon)
        {
            Dot pixel = new Dot(x, y, 0, 1);
            var prod1 = VectorProd(polygon.a, pixel, polygon.a, polygon.b);
            var prod2 = VectorProd(polygon.b, pixel, polygon.b, polygon.c);
            var prod3 = VectorProd(polygon.c, pixel, polygon.c, polygon.a);
            return (prod1 >= 0 && prod2 >= 0 && prod3 >= 0 || prod1 <= 0 && prod2 <= 0 && prod3 <= 0);
        }

        bool isIntersect(Dot a1, Dot b1, Dot a2, Dot b2)
        {
            var prod11 = VectorProd(a1, b1, a1, a2);
            var prod12 = VectorProd(a1, b1, a1, b2);
            var prod21 = VectorProd(a2, b2, a2, b1);
            var prod22 = VectorProd(a2, b2, a2, a1);
            return prod11 * prod12 < 0 && prod21 * prod22 < 0;
        }

        bool isRondedTriangle(Rectangle r, Polygon pol)
        {
            bool a = IsIn(r.X, r.Y, pol),
                b = IsIn(r.X + r.Width, r.Y, pol),
                c = IsIn(r.X, r.Y + r.Height, pol),
                d = IsIn(r.X + r.Width, r.Y + r.Height, pol);
            return a && b && c && d;
        }

        bool IsIn(RectangleF large, RectangleF small)
        {
            if (large.X <= small.X && large.Y <= small.Y)
            {
                if (large.X + large.Width >= small.X + small.Width
                    && large.Y + large.Height >= small.Y + small.Height)
                    return true;
            }

            return false;
        }

        bool isIntersect(Dot a, Dot b, Polygon pol)
        {
            return (isIntersect(a, b, pol.a, pol.b) ||
                    isIntersect(a, b, pol.b, pol.c) ||
                    isIntersect(a, b, pol.c, pol.a));
        }

        float getZ(Polygon poly, float X, float Y)
        {
            var depth = poly.normal.h + poly.normal.x * X + poly.normal.y * Y;
            return depth / -poly.normal.z;
        }

        bool isIntersect(Rectangle rect, Polygon pol)
        {
            Dot a = new Dot(rect.X, rect.Y, 0, 1);
            Dot b = new Dot(rect.X, rect.Y + rect.Height, 0, 1);
            Dot d = new Dot(rect.X + rect.Width, rect.Y, 0, 1);
            Dot c = new Dot(rect.X + rect.Width, rect.Y + rect.Height, 0, 1);
            return isIntersect(a, b, pol) || isIntersect(b, c, pol) ||
                   isIntersect(c, d, pol) || isIntersect(d, a, pol);
        }
        private void Iteration()
        {
            var par = _paramsStack.Pop();
            var activePolygons = new List<Polygon>();
            var roundedPol = new List<Polygon>();
            var rectf = (RectangleF)(par.rect);
            var r = par.rect;
            int halfWidth = r.Width / 2;
            int halfHeight = r.Height / 2;
            foreach (var polyg in par._activePolygons)
            {
                //если пересекаются области
                if (rectf.IntersectsWith(polyg.rect))
                {
                    //если область внутри треугольника
                    if (isRondedTriangle(r, polyg))
                    {
                        roundedPol.Add(polyg);
                        activePolygons.Add(polyg);
                    }
                    else
                    {
                        //если треугольник целиком внутри области
                        if (IsIn(rectf, polyg.rect))
                        {
                            activePolygons.Add(polyg);
                        }
                        else
                        {
                            if (isIntersect(r, polyg))
                            {
                                activePolygons.Add(polyg);
                            }
                        }
                    }
                }
            }

            if (roundedPol.Count > 0)
            {
                //check on overloap
                Polygon maxPol = roundedPol[0];
                bool isRounded = false;
                float maxza = float.MinValue, maxzb = float.MinValue, maxzc = float.MinValue, maxzd = float.MinValue;

                foreach (var poly in activePolygons)
                {
                    maxza = Math.Max(getZ(poly, r.X, r.Y), maxza);
                    maxzb = Math.Max(getZ(poly, r.X + r.Width, r.Y), maxzb);
                    maxzc = Math.Max(getZ(poly, r.X + r.Width, r.Y + r.Height), maxzc);
                    maxzd = Math.Max(getZ(poly, r.X, r.Y + r.Height), maxzd);
                }

                double delt = 0.0005;
                foreach (var poly in roundedPol)
                {
                    if (maxza - getZ(poly, r.X, r.Y) < delt &&
                        maxzb - getZ(poly, r.X + r.Width, r.Y) < delt &&
                        maxzc - getZ(poly, r.X + r.Width, r.Y + r.Height) < delt &&
                        maxzd - getZ(poly, r.X, r.Y + r.Height) < delt)
                    {
                        maxPol = poly;
                        isRounded = true;
                        continue;
                    }
                }
                if(isRounded)
                {
                    var delta = Math.Abs(ScalarProd(new Dot(0, 0, 1, 1), maxPol.normal));

                    int R, G, B;
                    R = (int)(maxPol.color.R * delta);
                    G = (int)(maxPol.color.G * delta);
                    B = (int)(maxPol.color.B * delta);

                    var color = Color.FromArgb(R, G, B);
                    for (int i = par.rect.X; i < par.rect.X + par.rect.Width; i++)
                        for (int j = par.rect.Y; j < par.rect.Y + par.rect.Height; j++)
                        {
                            currentMap.SetPixel(i, j, color);
                        }

                    return;
                }

            }

            //pixel
            if (activePolygons.Count > 0)
            {
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

        public Bitmap CreateBitmapOfIteration(PaintEventArgs e)
        {
            if (_paramsStack.Count == 0)
            {
                isIterate = false;
                return currentMap;
            }

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
            return isIterate;
        }
    }
}