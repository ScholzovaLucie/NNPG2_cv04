using NNPG2_04.Tvary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace NNPG2_04
{
    internal class Elipsa : Tvar
    {
        public Point startPoint;
        public Point center;
        public int width;
        public int height;


        public Elipsa(Point startPoint, Point center, int width, int height)
        {
            this.startPoint = startPoint;
            this.center = center;
            this.width = width;
            this.height = height;
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
            
            double xRadius = width / 2;
            double yRadius = height / 2;
            double centerX = center.X + xRadius;
            double centerY = center.Y + yRadius;

            double distance = Math.Pow((point.X - centerX) / xRadius, 2) + Math.Pow((point.Y - centerY) / yRadius, 2);

            return distance <= 1;
   
        }
        public override double vzdalenostOdBodu(Point point)
        {

            double centerX = this.center.X;
            double centerY = this.center.Y;
            double xRadius = this.width / 2;
            double yRadius = this.height / 2;
            double angle = Math.Atan2(point.Y - centerY, point.X - centerX);
            double closestX = centerX + xRadius * Math.Cos(angle);
            double closestY = centerY + yRadius * Math.Sin(angle);
            return Math.Sqrt(Math.Pow(point.X - closestX, 2) + Math.Pow(point.Y - closestY, 2));

        }



        public override void Draw(Graphics g, bool vypln, bool srafovani, bool okraj)
        {
            if (vypln)
            {
                SolidBrush blueBrush = new SolidBrush((Color)this.vypln);
                g.FillEllipse(
                         blueBrush,
                         this.startPoint.X,
                         this.startPoint.Y,
                         this.width,
                         this.height
                     );
                if (okraj)
                {
                    Pen pen = new Pen((Color)this.okraj, this.tloustkaOkraje);
                    g.DrawEllipse(
                        pen,
                        this.startPoint.X,
                        this.startPoint.Y,
                        this.width,
                        this.height
                     );
                }
            }
            if (srafovani)
            {
                HatchBrush blueBrush = new HatchBrush(
                    (HatchStyle)this.vybraneSrafovani,
                    (Color)this.vypln,
                    Color.White
                    );
                g.FillEllipse(
                        blueBrush,
                        this.startPoint.X,
                        this.startPoint.Y,
                        this.width,
                        this.height
                    );
                if (okraj)
                {
                    Pen pen = new Pen((Color)this.okraj, this.tloustkaOkraje);
                    g.DrawEllipse(
                        pen,
                        this.startPoint.X,
                        this.startPoint.Y,
                        this.width,
                        this.height
                     );
                }
            }
            if (okraj || !vypln && !srafovani)
            {
                Pen pen = new Pen((Color)this.okraj, this.tloustkaOkraje);
                g.DrawEllipse(
                   pen,
                   this.startPoint.X,
                   this.startPoint.Y,
                   this.width,
                   this.height
               );
            }
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
                hash = hash * 23 + (center != null && width != null && height != null ? center.GetHashCode() + width.GetHashCode() + height.GetHashCode()  : 0);
                return hash;
            }
        }
    }
}
