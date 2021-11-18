using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffinTransformation
{
    public static class Math3D
    {
        public static double TOLERANCE = 1e-10;
        public static Dot GetNormalOfSurface(Dot dot1, Dot dot2, Dot dot3)
        {
            Dot normal = new Dot(0, 0, 0, 0);
            normal.x = (dot2.y - dot1.y) * (dot3.z - dot1.z) - (dot3.y - dot1.y) * (dot2.z - dot1.z);
            normal.y = (dot2.x - dot1.x) * (dot3.z - dot1.z) - (dot3.x - dot1.x) * (dot2.z - dot1.z);
            normal.z = (dot2.x - dot1.x) * (dot3.y - dot1.y) - (dot3.x - dot1.x) * (dot2.y - dot1.y);
            normal.h = normal.x * dot1.x + normal.y * dot1.y + normal.z * dot1.z;
            return normal;
        }
    
  

    }
}
