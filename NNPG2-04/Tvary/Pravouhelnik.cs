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
    internal class Pravouhelnik : Tvar
    {
        public Rectangle rectangle;

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

    public override bool Contains(int x, int y)
    {
        throw new NotImplementedException();
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

            else
            {
                Pen pen = new Pen((Color)this.okraj, this.tloustkaOkraje);
                g.DrawRectangle(pen, this.rectangle);
            }
        }

    public override void UpdatePosition(int x, int y)
    {
            rectangle.X = x;
            rectangle.Y = y;
        }

        public override void nastavZIndex(int index)
        {
            this.zIndex = index;
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
