using NNPG2_04.Tvary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NNPG2_04
{
    internal class Pravouhelnik : Tvar
    {
        public Rectangle rectangle;
        private Rectangle RightBottomManipulator;
        private bool manipulace = false;
        private Point offset;

        public Pravouhelnik(Rectangle rectangle)
        {
            this.rectangle = rectangle;
        }

        public void pridejData(Color? okraj, Color? vypln, HatchStyle? vybraneSrafovani, int tloustkaOkraje)
        {
            this.okraj = okraj;
            this.vypln = vypln;
            this.vybraneSrafovani = vybraneSrafovani;
            this.tloustkaOkraje = tloustkaOkraje;
        }

        public override bool ContainsPoint(Point point)
        {
            if (this.vypln != null || this.vybraneSrafovani != null)
            {
                return point.X >= rectangle.X && point.X <= rectangle.X + rectangle.Width && point.Y >= rectangle.Y && point.Y <= rectangle.Y + rectangle.Height;
            }
            else
            {
                double expandDistance = 20;
                return point.X >= rectangle.X - expandDistance && point.X <= rectangle.X + rectangle.Width + expandDistance &&
                       point.Y >= rectangle.Y - expandDistance && point.Y <= rectangle.Y + rectangle.Height + expandDistance;
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

        public override void Draw(Graphics g, bool vypln, bool srafovani, bool okraj)
        {
            if (vypln)
            {
                SolidBrush blueBrush = new SolidBrush((Color)this.vypln);
                g.FillRectangle(blueBrush, this.rectangle);
                if (okraj)
                {
                    Pen pen = new Pen((Color)this.okraj, this.tloustkaOkraje);
                    g.DrawRectangle(pen, this.rectangle);
                }
            }

            if (srafovani)
            {
                HatchBrush blueBrush = new HatchBrush(
                    (HatchStyle)this.vybraneSrafovani,
                    (Color)this.vypln,
                    Color.White
                    );
                g.FillRectangle(blueBrush, this.rectangle);
                if (okraj)
                {
                    Pen pen = new Pen((Color)this.okraj, this.tloustkaOkraje);
                    g.DrawRectangle(pen, this.rectangle);
                }
            }

            if (okraj || !vypln && !srafovani)
            {
                Pen pen = new Pen((Color)this.okraj, this.tloustkaOkraje);
                g.DrawRectangle(pen, this.rectangle);
            }

            if (manipulace)
            {
                g.DrawRectangle(Pens.Red, rectangle);
                int x = rectangle.X + rectangle.Width - 10;
                int y = rectangle.Y + rectangle.Height - 10;
                RightBottomManipulator = new Rectangle(x, y , 10, 10);
                g.FillRectangle(Brushes.Red, RightBottomManipulator);
            }
        }

        public override void UpdatePosition(Point point)
        {
            rectangle.Location = new Point(point.X -offset.X, point.Y - offset.Y);
        }

        public override void setOfset(Point point)
        {
            offset = new Point(point.X - rectangle.X, point.Y - rectangle.Y);
        }

        public override void UpdateSize(Point point)
        {
            double newX = Math.Min(rectangle.X, point.X);
            double newY = Math.Min(rectangle.Y, point.Y);

            double newWidth = Math.Abs(point.X - rectangle.X);
            double newHeight = Math.Abs(point.Y - rectangle.Y);

            rectangle.X = (int)newX;
            rectangle.Y = (int)newY;
            rectangle.Width = (int)newWidth;
            rectangle.Height = (int)newHeight;

        }

        public override void nastavZIndex(int index)
        {
            this.zIndex = index;
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

        public override double vzdalenostOdBodu(Point point)
        {
            Point[] startPoints = new Point[]
            {
                    new Point(this.rectangle.X, this.rectangle.Y),
                    new Point(this.rectangle.X + this.rectangle.Width, this.rectangle.Y),
                    new Point(this.rectangle.X + this.rectangle.Width, this.rectangle.Y + this.rectangle.Height),
                    new Point(this.rectangle.X, this.rectangle.Y + this.rectangle.Height)
            };

            Point[] endPoints = new Point[]
            {
                    new Point(this.rectangle.X + this.rectangle.Width, this.rectangle.Y),
                    new Point(this.rectangle.X + this.rectangle.Width, this.rectangle.Y + this.rectangle.Height),
                    new Point(this.rectangle.X, this.rectangle.Y + this.rectangle.Height),
                    new Point(this.rectangle.X, this.rectangle.Y)
            };

            double nejlratsiVzdalenost = new TvarRozsireni().DistancePointToLine(point, startPoints[0], endPoints[0]);

            for (int i = 0; i < 4; i++)
            {
                double vzdalenost = new TvarRozsireni().DistancePointToLine(point, startPoints[i], endPoints[i]);
                if (nejlratsiVzdalenost > vzdalenost) nejlratsiVzdalenost = vzdalenost;
            }

            return nejlratsiVzdalenost;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + (rectangle != null ? rectangle.GetHashCode() : 0);
                return hash;
            }
        }
    }
}
