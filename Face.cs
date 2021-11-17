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
        public Face(Line line1, Line line2)
        {
            var a1 = line1.getADot();
            var b1 = line2.getBDot();
            var a2 = line2.getADot();
            var b2 = line2.getBDot();
            if (a2 == a1 || a2 == b1)
                _normal = Math3D.GetNormalOfSurface(a1, b1, b2);
            else if(b2 == a1 || b2 == b1)
                _normal = Math3D.GetNormalOfSurface(a1, b1, a2);
            else
                throw new ArgumentException("The lines have no common points");
            _lines = new List<Line>();
            _lines.Add(line1);
            _lines.Add(line2);
        }

        public void AddLine(Line line)
        {
            if (Math3D.IsOnSurface(line, _normal))
                _lines.Add(line);
        }
    }
}
