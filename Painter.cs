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
        Figure figure;
        Figure baseFigure;
        static int x0, y0, z0;
        public Painter(int X0, int Y0, int Z0, Figure fig)
        {
            figure = fig;
            baseFigure = fig;
            x0 = X0;
            y0 = Y0;
            z0 = Z0;
        }

        //Проекция (косоугольная)
        Figure Project(Figure fig, bool isCabinet = true)
        {
            double f = isCabinet ? -0.5 : 1.0;
            float[,] matrix = new float[4, 4];
            matrix[0, 0] = 1; matrix[1, 1] = 1;
            matrix[2, 0] = (float)(f * Math.Cos((45 * Math.PI) / 180.0));
            matrix[2, 1] = (float)(f * Math.Sin((45 * Math.PI) / 180.0));
            matrix[3, 3] = 1;
            return fig.Product(matrix);
        }
        public void Paint(Pen pen, PaintEventArgs e)
        {
            Paint(figure, pen, e);
        }
        void Paint(Figure fig, Pen pen, PaintEventArgs e)
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

        ///Перенос
        public void Translation(float dx, float dy, float dz)
        {
            figure = Translation(figure, dx, dy, dz);
        }
        //Перемещение
        public Figure Translation(Figure fig, float dx, float dy, float dz)
        {
            float[,] matrix = new float[4, 4];
            for (int i = 0; i < 4; i++)
                matrix[i, i] = 1;
            matrix[3, 0] = dx;
            matrix[3, 1] = dy;
            matrix[3, 2] = dz;
            return fig.Product(matrix);
        }
        /// <summary>
        /// Отражение
        /// </summary>
        /// <param name="rx"></param>
        /// <param name="ry"></param>
        /// <param name="rz"></param>
        /// <returns></returns>
        public void Reflection(bool rx, bool ry, bool rz)
        {
            figure = Reflection(figure, rx, ry, rz);
        }
        //Отражение
        public Figure Reflection(Figure fig, bool rx, bool ry, bool rz)
        {
            float[,] matrix = new float[4, 4];
            matrix[0, 0] = rx ? -1 : 1;
            matrix[1, 1] = ry ? -1 : 1;
            matrix[2, 2] = rz ? -1 : 1;
            matrix[3, 3] = 1;
            return fig.Product(matrix);

        }
        public void ResetTransformation()
        {
            figure = baseFigure;
        }
        //Масштабирование
        public void Dilatation(float ax, float ay, float az)
        {
            figure = Dilatation(figure, ax, ay, az);
        }
        //Масштабирование
        Figure Dilatation(Figure fig, float ax, float ay, float az)
        {
            float[,] matrix = new float[4, 4];
            matrix[0, 0] = ax;
            matrix[1, 1] = ay;
            matrix[2, 2] = az;
            matrix[3, 3] = 1;
            return fig.Product(matrix);
        }

        public void RotationZ(float angle)
        {
            figure = RotationZ(figure, angle);
        }
        Figure RotationZ(Figure fig, float angle)
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
        public void RotationX(float angle)
        {
            figure = RotationX(figure, angle);
        }
        Figure RotationX(Figure fig, float angle)
        {
            float[,] matrix = new float[4, 4];
            matrix[0,0] = 1;
            matrix[1, 1] = (float)Math.Cos((angle * Math.PI) / 180.0);
            matrix[1, 2] = (float)Math.Sin((angle * Math.PI) / 180.0);
            matrix[2,1 ] = -(float)Math.Sin((angle * Math.PI) / 180.0);
            matrix[2, 2] = (float)Math.Cos((angle * Math.PI) / 180.0);
            matrix[3, 3] = 1;
            return fig.Product(matrix);
        }
        public void RotationY(float angle)
        {
            figure = RotationY(figure, angle);
        }
        //Поворот по оси ОУ
        Figure RotationY(Figure fig, float angle)
        {
            float[,] matrix = new float[4, 4];
            matrix[1,1] = 1;
            matrix[0,0] = (float)Math.Cos((angle * Math.PI) / 180.0);
            matrix[2, 0] = (float)Math.Sin((angle * Math.PI) / 180.0);
            matrix[0, 2] = -(float)Math.Sin((angle * Math.PI) / 180.0);
            matrix[2, 2] = (float)Math.Cos((angle * Math.PI) / 180.0);
            matrix[3, 3] = 1;
            return fig.Product(matrix);
        }
    }
}
