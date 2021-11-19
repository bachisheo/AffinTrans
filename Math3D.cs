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
            Dot n = new Dot(0, 0, 0, 0);
            n.x = (dot2.y - dot1.y) * (dot3.z - dot1.z) - (dot3.y - dot1.y) * (dot2.z - dot1.z);
            n.y = (dot2.x - dot1.x) * (dot3.z - dot1.z) - (dot3.x - dot1.x) * (dot2.z - dot1.z);
            n.z = (dot2.x - dot1.x) * (dot3.y - dot1.y) - (dot3.x - dot1.x) * (dot2.y - dot1.y);
            float mod = (float)Math.Sqrt(n.x * n.x + n.y * n.y + n.z * n.z);
            n.x /= mod;
            n.y /= -mod;
            n.z /= mod;
            n.h = n.x * dot1.x + n.y * dot1.y + n.z * dot1.z;
            n.h *= -1f;
            return n;
        }
        
    
  

    }
}
