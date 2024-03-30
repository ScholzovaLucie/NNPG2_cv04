using NNPG2_04.Tvary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net;
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

        public override bool ContainsPoint(Point point)
        {
    
                double expandDistance = 5.0;
                double minX = Math.Min(points[0].X, points[1].X) - expandDistance;
                double minY = Math.Min(points[0].Y, points[1].Y) - expandDistance;
                double maxX = Math.Max(points[0].X, points[1].X) + expandDistance;
                double maxY = Math.Max(points[0].Y, points[1].Y) + expandDistance;
                return point.X >= minX && point.X <= maxX && point.Y >= minY && point.Y <= maxY;

           
        }

        public override double vzdalenostOdBodu(Point point)
        {

            return new TvarRozsireni().DistancePointToLine(point, this.points[0], this.points[1]);
            
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
            bool nalezen = false;

            foreach (var item in list)
            {
                if (item.Equals(this)) { list.Find(item).Value.zIndex++; nalezen = true; continue; }
                if (nalezen)
                {
                    list.Find(item).Value.zIndex--;
                    break;
                }
            }

            list = new TvarRozsireni().SortLinkedListByZIndex(list);

            return list;
        }

        public override LinkedList<Tvar> doPozadi(LinkedList<Tvar> list)
        {
            list.Find(this).Previous.Value.zIndex++;
            list.Find(this).Value.zIndex--;

            list = new TvarRozsireni().SortLinkedListByZIndex(list);

            return list;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + (points != null ? points[0].GetHashCode() + points[1].GetHashCode() : 0);
                return hash;
            }
        }
    }
}
