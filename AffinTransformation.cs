using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AffinTransformation.Properties;

namespace AffinTransformation
{
    
    public static class AffinTransformation
    {

        public static int x0 = 200, y0 = 400, z0 = 400;
        public static Dot axes = new Dot(x0, y0, z0, 1);
        static public Figure Rotation(Figure fig, char axes, float angle)
        {
            switch (axes)
            {
                case 'X': case 'x': return RotationX(fig, angle);
                case 'Y': case 'y': return RotationY(fig, angle);
                case 'Z': case 'z': return RotationZ(fig, angle);
                default: return fig;
            }
        }
        static Figure RotationY(Figure fig, float angle)
        {
            float[,] matrix = new float[4, 4];
            matrix[1, 1] = 1;
            matrix[0, 0] = (float)Math.Cos((angle * Math.PI) / 180.0);
            matrix[2, 0] = (float)Math.Sin((angle * Math.PI) / 180.0);
            matrix[0, 2] = -(float)Math.Sin((angle * Math.PI) / 180.0);
            matrix[2, 2] = (float)Math.Cos((angle * Math.PI) / 180.0);
            matrix[3, 3] = 1;
            return fig.Product(matrix);
        }
        static Figure RotationX(Figure fig, float angle)
        {
            float[,] matrix = new float[4, 4];
            matrix[0, 0] = 1;
            matrix[1, 1] = (float)Math.Cos((angle * Math.PI) / 180.0);
            matrix[1, 2] = (float)Math.Sin((angle * Math.PI) / 180.0);
            matrix[2, 1] = -(float)Math.Sin((angle * Math.PI) / 180.0);
            matrix[2, 2] = (float)Math.Cos((angle * Math.PI) / 180.0);
            matrix[3, 3] = 1;
            return fig.Product(matrix);
        }
        static Figure RotationZ(Figure fig, float angle)
        {
            float[,] matrix = new float[4, 4];
            matrix[0, 0] = (float)Math.Cos((angle * Math.PI) / 180.0);
            matrix[0, 1] = (float)Math.Sin((angle * Math.PI) / 180.0);
            matrix[1, 0] = -(float)Math.Sin((angle * Math.PI) / 180.0);
            matrix[1, 1] = (float)Math.Cos((angle * Math.PI) / 180.0);
            matrix[2, 2] = 1;
            matrix[3, 3] = 1;
            return fig.Product(matrix);
        }
        //Масштабирование
        public static Figure Dilatation(Figure fig, float ax, float ay, float az)
        {
            float[,] matrix = new float[4, 4];
            matrix[0, 0] = ax;
            matrix[1, 1] = ay;
            matrix[2, 2] = az;
            matrix[3, 3] = 1;
            return fig.Product(matrix);
        }
        public static Figure Reflection(Figure fig, bool rx, bool ry, bool rz)
        {
            float[,] matrix = new float[4, 4];
            matrix[0, 0] = rx ? -1 : 1;
            matrix[1, 1] = ry ? -1 : 1;
            matrix[2, 2] = rz ? -1 : 1;
            matrix[3, 3] = 1;
            return fig.Product(matrix);
        }
        //Проекция (косоугольная)
        static Figure Project(Figure fig, bool isCabinet = true)
        {
            double f = isCabinet ? -0.5 : -1.0;
            float[,] matrix = new float[4, 4];
            matrix[0, 0] = 1; matrix[1, 1] = 1;
            matrix[2, 0] = (float)(f * Math.Cos((45 * Math.PI) / 180.0));
            matrix[2, 1] = (float)(f * Math.Sin((45 * Math.PI) / 180.0));
            matrix[3, 3] = 1;
            return fig.Product(matrix);
        }
        static public void Paint(List<Figure> figs, Pen pen, PaintEventArgs e)
        {
            foreach(Figure f in figs)
                Paint(f, pen, e);
        }
        static public void Paint(Figure fig, Pen pen, PaintEventArgs e)
        {
            Figure _2d = Project(fig);
            _2d = Reflection(_2d, false, true, false);
            _2d = Translation(_2d, x0, y0, z0);
            foreach (Line line in _2d.GetLines())
            {
                Dot a = _2d.GetDot(line.aNum);
                Dot b = _2d.GetDot(line.bNum);
                e.Graphics.DrawLine(pen, a.x, a.y, b.x, b.y);
            }
        }
        public static Figure Translation(Figure fig, Dot delta)
        {
            return Translation(fig, delta.x, delta.y, delta.z);
        }
        public static Figure Translation(Figure fig, float dx, float dy, float dz)
        {
            float[,] matrix = new float[4, 4];
            for (int i = 0; i < 4; i++)
                matrix[i, i] = 1;
            matrix[3, 0] = dx;
            matrix[3, 1] = dy;
            matrix[3, 2] = dz;
            return fig.Product(matrix);
        }
    }
}
