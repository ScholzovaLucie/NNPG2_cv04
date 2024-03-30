using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNPG2_04.Tvary
{
    internal abstract class Tvar
    {

        public Color? okraj;
        public Color? vypln;
        public HatchStyle? vybraneSrafovani;
        public int tloustkaOkraje;
        public int zIndex;

        public bool jeVybrany = false;

        public abstract void nastavZIndex(int index);

        public abstract void Draw(Graphics g, bool vypln, bool srafovani, bool okraj);
        public abstract void UpdatePosition(int x, int y);
        public abstract bool ContainsPoint(Point point);
             public abstract double vzdalenostOdBodu(Point point);

        public abstract LinkedList<Tvar> doPopredi(LinkedList<Tvar> list);
        public abstract LinkedList<Tvar> doPozadi(LinkedList<Tvar> list);

    }
}
