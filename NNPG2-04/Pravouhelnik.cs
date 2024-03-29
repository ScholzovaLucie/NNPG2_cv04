using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNPG2_04
{
    internal class Pravouhelnik
    {
        public Rectangle rectangle;
        public TvarData data;

        public Pravouhelnik(Rectangle rectangle, TvarData data)
        {
            this.rectangle = rectangle;
            this.data = data;
        }
    }
}
