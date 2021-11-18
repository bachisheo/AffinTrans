using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace AffinTransformation
{
    public class Face
    {
        private Dot _normal;
        private List<Line> _lines;
        public Face(Dot normal)
        {
            _normal = normal;
            _lines = new List<Line>();
        }
 
    }
}
