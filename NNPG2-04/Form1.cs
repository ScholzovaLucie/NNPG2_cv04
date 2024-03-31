using NNPG2_04.Tvary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace NNPG2_04
{
    public partial class Form1 : Form
    {
        private LinkedList<Tvar> listTvaru = new LinkedList<Tvar>();

        private Color vybranaBarvaOkraj = Color.Black;
        private HatchStyle vybraneSrafovani = HatchStyle.Horizontal;
        private HatchStyle vybranyOkraj;
        private Color vybranaBarvaPozadi = Color.Blue;
        private Point startPoint;
        private Point endPoint;
        private Tvar aktualniTvar = null;
        private Point posledniPozice;

        private bool kresliLine = false;
        private bool kresliPravouhelnik = false;
        private bool kresliOval = false;
        private bool drawingLine = false;
        private bool drawingRectangle = false;
        private bool drawingElipse = false;
        private bool mazani = false;
        private bool editace = false;
        private bool editovani = false;
        private bool transformovani = false;
        private bool posun = false;

        private int tloustkaOkraje = 0;
        private int tolerance = 20;

        public Form1()
        {
            InitializeComponent();
            comboBoxSrafovani_Init();
            okrajStyl_Init();
            cteatepanel();

            this.DoubleBuffered = true;

            this.PanelKresba.MouseDown += Form1_MouseDown;
            this.PanelKresba.MouseUp += Form1_MouseUp;
            this.PanelKresba.MouseMove += Form1_MouseMove;
            this.PanelKresba.Paint += PaintPanel_Paint;
            this.PanelKresba.MouseClick += Form1_MouseClick;
            comboBoxPosun.SelectedIndexChanged += ComboBox_SelectedIndexChanged;

            tloustkaOkraje = (int)tloustkaOkrajeSetting.Value;
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxPosun.SelectedIndex)
            {
                case 0:
                    listTvaru = this.aktualniTvar.doPopredi(listTvaru);
                    break;
                case 1:
                    listTvaru = this.aktualniTvar.doPozadi(listTvaru);
                    break;

            }

            comboBoxPosun.Visible = false;
            aktualniTvar = null;
            InvalidateAll();
        }

        private void cteatepanel()
        {
            comboBoxPosun.Items.Add("Posunout do popředí");
            comboBoxPosun.Items.Add("Posunout do pozadí");
            comboBoxPosun.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (mazani)
                {
                    Tvar closestShape = ClickedOnObject(e.Location);
                    if (closestShape != null)
                    {
                        listTvaru.Remove(closestShape);
                    }
                }
                if (editace)
                {
                    posledniPozice = e.Location;

                    Tvar clickedOnObject = ClickedOnObject(e.Location);
                    if (clickedOnObject != null)
                    {
                        if (aktualniTvar != null)
                        {
                            resetAktualniTvar();
                        }
                        else
                        {
                            clickedOnObject.CreateManipulator();
                            aktualniTvar = clickedOnObject;
                            editovani = true;
                        }

                    }


                }
            }

            if (e.Button == MouseButtons.Right)
            {
                Tvar clickedOnObject = ClickedOnObject(e.Location);
                if (clickedOnObject != null)
                {
                    comboBoxPosun.Location = e.Location;
                    comboBoxPosun.Visible = true;
                    comboBoxPosun.Focus();
                    aktualniTvar = clickedOnObject;
                }
            }

            InvalidateAll();
        }

        private Tvar ClickedOnObject(Point clickPoint)
        {
            double closestDistance = 0;
            Tvar closestShape = null;

            foreach (var shape in listTvaru.Reverse())
            {
                if (shape.vypln == null && shape.vybraneSrafovani == null)
                {
                    double distanceToShape = DistanceToClosestEdge(clickPoint, shape);
                    if (closestDistance == 0)
                    {
                        closestShape = shape;
                        closestDistance = distanceToShape;
                    }
                    else if (distanceToShape < closestDistance)
                    {
                        closestShape = shape;
                        closestDistance = distanceToShape;
                    }
                }
                else
                {
                    if (shape.ContainsPoint(clickPoint)) { return shape; }
                }
            }

            if (closestDistance < tolerance)
                return closestShape;

            return null;
        }

        private double DistanceToClosestEdge(Point point, Tvar shape)
        {
            if (shape is Usecka)
            {
                return ((Usecka)shape).vzdalenostOdBodu(point);
            }
            else if (shape is Elipsa)
            {
                return ((Elipsa)shape).vzdalenostOdBodu(point);
            }
            else if (shape is Pravouhelnik)
            {
                return ((Pravouhelnik)shape).vzdalenostOdBodu(point);
            }
            else
            {
                return double.MaxValue;
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (kresliLine)
                {
                    startPoint = e.Location;
                    endPoint = e.Location;
                    drawingLine = true;
                }
                else if (kresliOval)
                {
                    startPoint = e.Location;
                    endPoint = e.Location;
                    drawingElipse = true;
                }
                else if (kresliPravouhelnik)
                {
                    startPoint = e.Location;
                    endPoint = e.Location;
                    drawingRectangle = true;
                }
                else if (editovani)
                {
                    if (aktualniTvar.ManipulatorContains(e.Location))
                    {
                        transformovani = true;
                    }
                    else if (aktualniTvar.ContainsPoint(e.Location))
                    {
                        aktualniTvar.setOfset(e.Location);
                        posun = true;
                    }
                }
                this.InvalidateAll();
            }

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawingElipse || drawingLine || drawingRectangle)
            {
                endPoint = e.Location;
                InvalidateAll();
            }
            else if (transformovani)
            {
                aktualniTvar.UpdateSize(e.Location);
                InvalidateAll();
            }
            else if (posun)
            {
                aktualniTvar.UpdatePosition(e.Location);
                InvalidateAll();
            }

        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (drawingLine)
                {
                    endPoint = e.Location;
                    drawingLine = false;

                    Point[] pair =
                        {
                        new Point(startPoint.X, startPoint.Y),
                        new Point(endPoint.X, endPoint.Y)
                    };

                    Usecka usecka = new Usecka(pair);
                    usecka.pridejData(vybranaBarvaOkraj, null, null, tloustkaOkraje);
                    usecka.nastavZIndex(listTvaru.Count);
                    if (listTvaru.Count == 0)
                        listTvaru.AddFirst(usecka);
                    else
                        listTvaru.AddAfter(listTvaru.Last, usecka);
                }
                else if (drawingElipse)
                {
                    endPoint = e.Location;
                    drawingElipse = false;

                    int width = endPoint.X - startPoint.X;
                    int height = endPoint.Y - startPoint.Y;

                    Elipsa elipsa = new Elipsa(
                        startPoint,
                        endPoint,
                        width,
                        height
                     );

                    Color? okraj = null;
                    if (PouzitOkraj.Checked) okraj = vybranaBarvaOkraj;

                    if (jednolitaBarve.Checked)
                        elipsa.pridejData(okraj, vybranaBarvaPozadi, null, tloustkaOkraje);

                    else if (srafovani.Checked)
                        elipsa.pridejData(okraj, vybranaBarvaPozadi, vybraneSrafovani, tloustkaOkraje);

                    else
                        elipsa.pridejData(vybranaBarvaOkraj, null, null, tloustkaOkraje);

                    elipsa.nastavZIndex(listTvaru.Count);
                    if (listTvaru.Count == 0)
                        listTvaru.AddFirst(elipsa);
                    else
                        listTvaru.AddAfter(listTvaru.Last, elipsa);
                }
                else if (drawingRectangle)
                {
                    endPoint = e.Location;
                    drawingRectangle = false;

                    int width = endPoint.X - startPoint.X;
                    int height = endPoint.Y - startPoint.Y;


                    Pravouhelnik pravouhelnik = new Pravouhelnik(
                        new Rectangle(startPoint.X, startPoint.Y, width, height)
                        );

                    Color? okraj = null;
                    if (PouzitOkraj.Checked) okraj = vybranaBarvaOkraj;

                    if (jednolitaBarve.Checked)
                        pravouhelnik.pridejData(okraj, vybranaBarvaPozadi, null, tloustkaOkraje);

                    else if (srafovani.Checked)
                        pravouhelnik.pridejData(okraj, vybranaBarvaPozadi, vybraneSrafovani, tloustkaOkraje);

                    else
                        pravouhelnik.pridejData(vybranaBarvaOkraj, null, null, tloustkaOkraje);

                    pravouhelnik.nastavZIndex(listTvaru.Count);
                    if (listTvaru.Count == 0)
                        listTvaru.AddFirst(pravouhelnik);
                    else
                        listTvaru.AddAfter(listTvaru.Last, pravouhelnik);
                }
                else if (transformovani)
                {
                    resetAktualniTvar();
                    InvalidateAll();
                }
                else if (posun)
                {
                    resetAktualniTvar();
                    InvalidateAll();
                }

                posun = false;
                transformovani = false;
                drawingRectangle = false;
                drawingLine = false;
                drawingElipse = false;

            }

        }

        private void PaintPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.Clear(Color.White);

            foreach (var tvar in listTvaru)
            {
                tvar.Draw(g, tvar.vypln != null, tvar.vybraneSrafovani != null, tvar.okraj != null);
            }

            if (drawingRectangle)
            {
                int width = endPoint.X - startPoint.X;
                int height = endPoint.Y - startPoint.Y;

                Rectangle rect2 = new Rectangle(startPoint.X, startPoint.Y, width, height);
                Pravouhelnik pravouhelnik = new Pravouhelnik(rect2);
                pravouhelnik.pridejData(vybranaBarvaOkraj, vybranaBarvaPozadi, vybraneSrafovani, tloustkaOkraje);
                pravouhelnik.nastavZIndex(listTvaru.Count);
                pravouhelnik.Draw(g, jednolitaBarve.Checked, srafovani.Checked, PouzitOkraj.Checked);
            }

            if (drawingElipse)
            {
                int width = endPoint.X - startPoint.X;
                int height = endPoint.Y - startPoint.Y;
                Elipsa elipsa = new Elipsa(
                     startPoint,
                     endPoint,
                     width,
                     height
                  );
                elipsa.pridejData(vybranaBarvaOkraj, vybranaBarvaPozadi, vybraneSrafovani, tloustkaOkraje);
                elipsa.nastavZIndex(listTvaru.Count);
                elipsa.Draw(g, jednolitaBarve.Checked, srafovani.Checked, PouzitOkraj.Checked);
            }

            if (drawingLine)
            {
                Point[] pair =
                    {
                        new Point(startPoint.X, startPoint.Y),
                        new Point(endPoint.X, endPoint.Y)
                    };
                Usecka usecka = new Usecka(pair);
                usecka.pridejData(vybranaBarvaOkraj, vybranaBarvaPozadi, vybraneSrafovani, tloustkaOkraje);
                usecka.nastavZIndex(listTvaru.Count);
                usecka.Draw(g, jednolitaBarve.Checked, srafovani.Checked, PouzitOkraj.Checked);
            }

            if (editovani || posun)
            {
                var okrapred = aktualniTvar.okraj;
                aktualniTvar.okraj = Color.Red;
                aktualniTvar.Draw(g, false, false, true);
                aktualniTvar.okraj = okrapred;
            }
        }

        private void zrusButtns()
        {
            this.kresliLine = false;
            this.kresliOval = false;
            this.kresliPravouhelnik = false;
            this.mazani = false;
            this.editace = false;
            resetAktualniTvar();

            kresliPravouhelnikButton.Checked = false;
            KreslitUseckuButton.Checked = false;
            krasliElipsuButton.Checked = false;
            smazatButton.Checked = false;
            transformaceButoon.Checked = false;
        }

        private void KreslitUsecku_Click(object sender, EventArgs e)
        {
            bool value = this.kresliLine;
            zrusButtns();
            if (value == false)
            {
                this.kresliLine = true;
                KreslitUseckuButton.Checked = true;
            }

        }

        private void kresliPravouhelnik_Click(object sender, EventArgs e)
        {
            bool value = this.kresliPravouhelnik;
            zrusButtns();
            if (value == false)
            {
                this.kresliPravouhelnik = true;
                kresliPravouhelnikButton.Checked = true;
            }
        }

        private void krasliElipsu_Click(object sender, EventArgs e)
        {
            bool value = this.kresliOval;
            zrusButtns();
            if (value == false)
            {
                this.kresliOval = true;
                krasliElipsuButton.Checked = true;
            }
        }

        private void transformaceButoon_Click(object sender, EventArgs e)
        {
            bool value = this.editace;
            if (value)
            {
                if (aktualniTvar != null)
                    resetAktualniTvar();
            }
            zrusButtns();
            if (value == false)
            {
                editace = true;
                transformaceButoon.Checked = true;
            }
            InvalidateAll();
        }

        private void smazatButton_Click(object sender, EventArgs e)
        {
            bool value = this.mazani;
            zrusButtns();
            if (value == false)
            {
                mazani = true;
                smazatButton.Checked = true;
            }
        }

        private void barvaOkraj_Click_1(object sender, EventArgs e)
        {
            if (colorDialogOkraj.ShowDialog() == DialogResult.OK)
            {
                zmenaBarvy(colorDialogOkraj.Color, "okraj");
            }
            InvalidateAll();
        }

        private void barvaPozadi_Click(object sender, EventArgs e)
        {
            if (colorDialogPozadi.ShowDialog() == DialogResult.OK)
            {
                zmenaBarvy(colorDialogPozadi.Color, "pozadi");
            }
            InvalidateAll();
        }

        private void pictureBoxBarvaPozadi_Paint(object sender, PaintEventArgs e)
        {
            pictureBoxBarvaPozadi.BackColor = vybranaBarvaPozadi;
        }

        private void pictureBoxBarvaOkraj_Paint(object sender, PaintEventArgs e)
        {
            pictureBoxBarvaOkraj.BackColor = vybranaBarvaOkraj;
        }

        private void zmenaBarvy(Color novaBarva, string barvaBpx)
        {
            if (barvaBpx.Equals("pozadi"))
            {
                vybranaBarvaPozadi = novaBarva;
                pictureBoxBarvaPozadi.Invalidate();
            }
            else if (barvaBpx.Equals("okraj"))
            {
                vybranaBarvaOkraj = novaBarva;
                pictureBoxBarvaOkraj.Invalidate();
            }


        }

        private void InvalidateAll()
        {
            this.Invalidate();
            this.PanelKresba.Invalidate();
        }

        private void numericUokrajTloustkapDown1_ValueChanged(object sender, EventArgs e)
        {
            this.tloustkaOkraje = (int)tloustkaOkrajeSetting.Value;
        }

        private void BezVyplne_CheckedChanged(object sender, EventArgs e)
        {
            if (BezVyplne.Checked)
            {
                jednolitaBarve.Checked = false;
                srafovani.Checked = false;
            }

        }

        private void jednolitaBarve_CheckedChanged(object sender, EventArgs e)
        {
            if (jednolitaBarve.Checked)
            {
                BezVyplne.Checked = false;
                srafovani.Checked = false;
            }

        }

        private void srafovani_CheckedChanged(object sender, EventArgs e)
        {
            if (srafovani.Checked)
            {
                jednolitaBarve.Checked = false;
                BezVyplne.Checked = false;
            }

        }

        private void comboBoxSrafovaniSUkazkou_SelectedIndexChanged(object sender, EventArgs e)
        {
            vybraneSrafovani = (HatchStyle)comboBoxSrafovaniSUkazkou.SelectedItem;
            InvalidateAll();
        }

        private void comboBoxSrafovani_Init()
        {
            comboBoxSrafovaniSUkazkou.Items.Clear();
            for (int i = 0; i <= 52; i++)
            {

                comboBoxSrafovaniSUkazkou.Items.Add((HatchStyle)i);
            }
            comboBoxSrafovaniSUkazkou.SelectedIndex = 0;
        }


        private void okrajStyl_Init()
        {
            Type styleType = typeof(BorderStyle);
            foreach (string s in Enum.GetNames(styleType))
            {

                okrajStyl.Items.Add(s);
            }
            okrajStyl.SelectedIndex = 0;
        }

        private void resetAktualniTvar()
        {
            if (aktualniTvar != null)
                aktualniTvar.CreateManipulator();
            this.aktualniTvar = null;
            this.editovani = false;
            this.transformovani = false;
            this.posun = false;
        }

    }

}
