using NNPG2_04.Tvary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNPG2_04
{
    internal class Usecka : Tvar
    {
        public Point[] points;

        public Usecka(Point[] points)
        {
            this.points = points;
        }

        public void pridejData(Color? okraj, Color? vypln, HatchStyle? vybraneSrafovani, int tloustkaOkraje)
        {
            this.okraj = okraj;
            this.vypln = vypln;
            this.vybraneSrafovani = vybraneSrafovani;
            this.tloustkaOkraje = tloustkaOkraje;

        }

        public override void nastavZIndex(int index)
        {
            this.zIndex = index;
        }

        public override bool Contains(int x, int y)
        {
            throw new NotImplementedException();
        }

        public override void Draw(Graphics g, bool vypln, bool srafovani, bool okraj)
        {
            Pen pen = new Pen((Color)this.okraj, this.tloustkaOkraje);
            g.DrawLine(pen, this.points[0], this.points[1]);
        }

        public override void UpdatePosition(int x, int y)
        {
            throw new NotImplementedException();
        }


        public override LinkedList<Tvar> doPopredi(LinkedList<Tvar> list)
        {
            this.zIndex++;
            list.Find(this).Previous.Value.zIndex--;

            list = new TvarRozsireni().SortLinkedListByZIndex(list);

            return list;
        }

        public override LinkedList<Tvar> doPozadi(LinkedList<Tvar> list)
        {
            this.zIndex--;

            list.Find(this).Next.Value.zIndex++;
            list.Find(this).Value.zIndex--;

            list = new TvarRozsireni().SortLinkedListByZIndex(list);

            return list;
        }
    }
}
