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
        public Point startPoint;
        public Point endPoint;
        private Rectangle RightBottomManipulator;
        private bool manipulace = false;
        private Point offset;
        TvarRozsireni rozsireni = new TvarRozsireni();

        public Usecka(Point[] points)
        {
            this.startPoint = points[0];
            this.endPoint = points[1];
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
            double minX = Math.Min(startPoint.X, endPoint.X) - expandDistance;
            double minY = Math.Min(startPoint.Y, endPoint.Y) - expandDistance;
            double maxX = Math.Max(startPoint.X, endPoint.X) + expandDistance;
            double maxY = Math.Max(startPoint.Y, endPoint.Y) + expandDistance;
            return point.X >= minX && point.X <= maxX && point.Y >= minY && point.Y <= maxY;
        }

        public override double vzdalenostOdBodu(Point point)
        {

            return rozsireni.DistancePointToLine(point, this.startPoint, this.endPoint);

        }

        public override void Draw(Graphics g, bool vypln, bool srafovani, bool okraj)
        {
            if (!manipulace)
            {
                Pen pen = new Pen((Color)this.okraj, this.tloustkaOkraje);
                g.DrawLine(pen, this.startPoint, this.endPoint);
            }
            else if (manipulace)
            {
                
                Pen pen = new Pen(Color.Red, this.tloustkaOkraje);
                g.DrawLine(pen, this.startPoint, this.endPoint);
                RightBottomManipulator = new Rectangle(endPoint.X, endPoint.Y, 10, 10);
                g.FillRectangle(Brushes.Red, RightBottomManipulator);
                
            }
        }

        public override void UpdatePosition(Point point)
        {
            double newStartX = point.X - offset.X;
            double newStartY = point.Y - offset.Y;

            double offsetX = newStartX - startPoint.X;
            double offsetY = newStartY - startPoint.Y;

            startPoint.X = (int)newStartX;
            startPoint.Y = (int)newStartY;
            endPoint.X += (int)offsetX;
            endPoint.Y += (int)offsetY;
        }

        public override void setOfset(Point point)
        {
            offset = new Point(point.X - startPoint.X, point.Y - startPoint.Y);
        }


        public override void UpdateSize(Point point)
        {
            endPoint = point;
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

            list = rozsireni.SortLinkedListByZIndex(list);

            return list;
        }

        public override LinkedList<Tvar> doPozadi(LinkedList<Tvar> list)
        {
            list.Find(this).Previous.Value.zIndex++;
            list.Find(this).Value.zIndex--;

            list = rozsireni.SortLinkedListByZIndex(list);

            return list;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + (startPoint != null && endPoint != null ? startPoint.GetHashCode() + endPoint.GetHashCode() : 0);
                return hash;
            }
        }

        public override bool ManipulatorContains(Point point)
        {
            return point.X >= RightBottomManipulator.X &&
                    point.X <= RightBottomManipulator.X + RightBottomManipulator.Width &&
                    point.Y >= RightBottomManipulator.Y &&
                    point.Y <= RightBottomManipulator.Y + RightBottomManipulator.Height;
        }

        public override void CreateManipulator()
        {
            if (!manipulace)
                manipulace = true;
            else if (manipulace)
            {
                manipulace = false;
            }

        }

    }
}
