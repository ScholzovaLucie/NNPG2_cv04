using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNPG2_04
{
    internal class TvarData
    {
        public Color? okraj;
        public Color? vypln;
        public HatchStyle? vybraneSrafovani;
        public int tloustkaOkraje;
        public int zIndex;

        public TvarData(Color? okraj, Color? vypln, HatchStyle? vybraneSrafovani,  int tloustkaOkraje)
        {
            this.okraj = okraj;
            this.vypln = vypln;
            this.vybraneSrafovani = vybraneSrafovani;
            this.tloustkaOkraje = tloustkaOkraje;
        }

        public TvarData() { }
    }
}
