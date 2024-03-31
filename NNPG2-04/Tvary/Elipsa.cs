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
        private Rectangle rectangle;
        public Point startPoint;
        public Point center;
        public int width;
        public int height;
        private Point offset;
        private bool manipulace = false;
        private Rectangle RightBottomManipulator;


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
            if (this.vypln != null || this.vybraneSrafovani != null)
            {
                return point.X >= startPoint.X && point.X <= startPoint.X + width && point.Y >= startPoint.Y && point.Y <= startPoint.Y + height;
            }
            else
            {
                double expandDistance = 20;
                return point.X >= startPoint.X - expandDistance && point.X <= startPoint.X + width + expandDistance &&
                       point.Y >= startPoint.Y - expandDistance && point.Y <= startPoint.Y + height + expandDistance;
            }

        }
        public override double vzdalenostOdBodu(Point point)
        {
            Point[] startPoints = new Point[]
           {
                    new Point(this.startPoint.X, this.startPoint.Y),
                    new Point(this.startPoint.X + this.width, this.startPoint.Y),
                    new Point(this.startPoint.X + this.width, this.startPoint.Y + this.height),
                    new Point(this.startPoint.X, this.startPoint.Y + this.height)
           };

            Point[] endPoints = new Point[]
            {
                    new Point(this.startPoint.X + this.width, this.startPoint.Y),
                    new Point(this.startPoint.X + this.width, this.startPoint.Y + this.height),
                    new Point(this.startPoint.X, this.startPoint.Y + this.height),
                    new Point(this.startPoint.X, this.startPoint.Y)
            };

            double nejlratsiVzdalenost = new TvarRozsireni().DistancePointToLine(point, startPoints[0], endPoints[0]);

            for (int i = 0; i < 4; i++)
            {
                double vzdalenost = new TvarRozsireni().DistancePointToLine(point, startPoints[i], endPoints[i]);
                if (nejlratsiVzdalenost > vzdalenost) nejlratsiVzdalenost = vzdalenost;
            }

            return nejlratsiVzdalenost;
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

            if(manipulace)
            {
                rectangle = new Rectangle(startPoint.X, startPoint.Y, width, height);
                g.DrawRectangle(Pens.Red, rectangle);
                int x = rectangle.X + rectangle.Width - 10;
                int y = rectangle.Y + rectangle.Height - 10;
                RightBottomManipulator = new Rectangle(x, y, 10, 10);
                g.FillRectangle(Brushes.Red, RightBottomManipulator);
            }
        }

        public override void UpdatePosition(Point point)
        {
            double newStartX = point.X - offset.X;
            double newStartY = point.Y - offset.Y;

            startPoint.X = (int)newStartX;
            startPoint.Y = (int)newStartY;
            center = new Point(point.X - offset.X, point.Y - offset.Y);
        }

        public override void setOfset(Point point)
        {
            offset = new Point(point.X - startPoint.X, point.Y - startPoint.Y);
        }

        public override void UpdateSize(Point point)
        {
            double newX = Math.Min(startPoint.X, point.X);
            double newY = Math.Min(startPoint.Y, point.Y);

            double newWidth = Math.Abs(point.X - startPoint.X);
            double newHeight = Math.Abs(point.Y - startPoint.Y);

            startPoint.X = (int)newX;
            startPoint.Y = (int)newY;
            width = (int)newWidth;
            height = (int)newHeight;

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
