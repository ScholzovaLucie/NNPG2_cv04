using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNPG2_04
{
    internal class Elipsa
    {
        public Point startPoint;
        public int width;
        public int height;
        public TvarData data;

        public Elipsa(Point startPoint, int width, int height, TvarData data)
        {
            this.startPoint = startPoint;
            this.width = width;
            this.height = height;
            this.data = data;
        }
    }
}
