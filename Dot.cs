using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffinTransformation
{
    public class Dot
    {
        public float x, y, z, h;
        public Dot(float x, float y, float z, float h)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.h = h;
        }
        public Dot(Dot b)
        {
            this.x = b.x;
            this.y = b.y;
            this.z = b.z;
            this.h = b.h;
        }
        public static Dot operator +(Dot a, Dot b) =>
            new Dot(a.x + b.x, a.y + b.y, a.z + b.z, 1);
        public static Dot operator *(float b, Dot a) =>
            new Dot(a.x * b, a.y * b, a.z * b, 1);
        public static Dot operator +(Dot a, float b) =>
            new Dot(a.x + b, a.y + b, a.z + b, 1);
        public static Dot operator -(Dot a, float b) => a + -1.0f * b;
        public static Dot operator -(Dot a, Dot b) => a + -1.0f * b;
        public float max() => Math.Max(x, Math.Max(y, z));
        public float min() => Math.Min(x, Math.Min(y, z));
        public static Dot operator *(Dot a, float[,] matrix)
        {
            float[] coord = { 0, 0, 0, 0 };
            float[] old = { a.x, a.y, a.z, a.h };
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
}
