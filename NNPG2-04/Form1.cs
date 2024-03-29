using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace NNPG2_04
{
    public partial class Form1 : Form
    {
        private List<Pravouhelnik> listPravouhelniku = new List<Pravouhelnik>();
        private List<Usecka> listUsecek = new List<Usecka>();
        private List<Elipsa> listElips = new List<Elipsa>();

        private Color vybranaBarvaOkraj = Color.Black;
        private HatchStyle vybraneSrafovani = HatchStyle.Horizontal;
        private HatchStyle vybranyOkraj;
        private Color vybranaBarvaPozadi = Color.Blue;
        private string vybranyStylNaplne = "Barva";
        private bool kresliLine = false;
        private bool kresliPravouhelnik = false;
        private bool kresliOval = false;

        private bool drawingLine = false;
        private bool drawingRectangle = false;
        private bool drawingElipse = false;

        private Point startPoint;
        private Point endPoint;

        private int tloustkaOkraje = 0;



        public Form1()
        {
            
            InitializeComponent();
            comboBoxSrafovani_Init();
            okrajStyl_Init();
            this.DoubleBuffered = true;

            this.PanelKresba.MouseDown += Form1_MouseDown;
            this.PanelKresba.MouseUp += Form1_MouseUp;
            this.PanelKresba.MouseMove += Form1_MouseMove;
            this.PanelKresba.Paint += PaintPanel_Paint;

            tloustkaOkraje = (int)tloustkaOkrajeSetting.Value;
        }


        private void Form1_MouseDown(object sender, MouseEventArgs e)
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
            this.InvalidateAll();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawingElipse || drawingLine || drawingRectangle)
            {
                endPoint = e.Location;
                InvalidateAll();
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
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

                Color? okraj = vybranaBarvaOkraj;

                if (!PouzitOkraj.Checked) okraj = vybranaBarvaOkraj;


                TvarData data = new TvarData(okraj, null, null, tloustkaOkraje);

                Usecka usecka = new Usecka(
                    pair,
                    data
                    );
                listUsecek.Add(usecka);
            }
            else if (drawingElipse)
            {
                endPoint = e.Location;
                drawingElipse = false;

                int width = endPoint.X - startPoint.X;
                int height = endPoint.Y - startPoint.Y;
                TvarData data = new TvarData();

                Color? okraj = vybranaBarvaOkraj;

                //if (!PouzitOkraj.Checked) okraj = null;

                if (jednolitaBarve.Checked)
                    data = new TvarData(okraj, vybranaBarvaPozadi, null, tloustkaOkraje);

                else if (srafovani.Checked)
                    data = new TvarData(okraj, vybranaBarvaPozadi, vybraneSrafovani, tloustkaOkraje);

                else
                    data = new TvarData(okraj, null, null, tloustkaOkraje);

                Elipsa elipsa = new Elipsa(
                    startPoint,
                    width,
                    height,
                    data
                    );

                listElips.Add(elipsa);
            }
            else if (drawingRectangle)
            {
                endPoint = e.Location;
                drawingRectangle = false;

                int width = endPoint.X - startPoint.X;
                int height = endPoint.Y - startPoint.Y;

                TvarData data = new TvarData();

                Color? okraj = vybranaBarvaOkraj;

                // if (!PouzitOkraj.Checked) okraj = null;

                if (jednolitaBarve.Checked)
                    data = new TvarData(okraj, vybranaBarvaPozadi, null, tloustkaOkraje);

                else if (srafovani.Checked)
                    data = new TvarData(okraj, vybranaBarvaPozadi, vybraneSrafovani, tloustkaOkraje);

                else
                    data = new TvarData(okraj, null, null, tloustkaOkraje);

                Pravouhelnik pravouhelnik = new Pravouhelnik(
                    new Rectangle(startPoint.X, startPoint.Y, width, height),
                    data
                    );
                listPravouhelniku.Add(pravouhelnik);
            }

            drawingRectangle = false;
            drawingLine = false;
            drawingElipse = false;
        }

        private void PaintPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.Clear(Color.White);

            foreach (var pravouhelnik in listPravouhelniku)
            {
                if (pravouhelnik.data.vypln != null)
                {
                    SolidBrush blueBrush = new SolidBrush((Color)pravouhelnik.data.vypln);
                    g.FillRectangle(blueBrush, pravouhelnik.rectangle);
                    if (pravouhelnik.data.okraj != null)
                    {
                        Pen pen = new Pen((Color)pravouhelnik.data.okraj, pravouhelnik.data.tloustkaOkraje);
                        g.DrawRectangle(pen, pravouhelnik.rectangle);
                    }
                }

                if (pravouhelnik.data.vybraneSrafovani != null)
                {
                    HatchBrush blueBrush = new HatchBrush(
                        (HatchStyle)pravouhelnik.data.vybraneSrafovani,
                        (Color)pravouhelnik.data.vypln,
                        Color.White
                        );
                    g.FillRectangle(blueBrush, pravouhelnik.rectangle);
                    if (pravouhelnik.data.okraj != null)
                    {
                        Pen pen = new Pen((Color)pravouhelnik.data.okraj, pravouhelnik.data.tloustkaOkraje);
                        g.DrawRectangle(pen, pravouhelnik.rectangle);
                    }
                }

                else
                {
                    Pen pen = new Pen((Color)pravouhelnik.data.okraj, pravouhelnik.data.tloustkaOkraje);
                    g.DrawRectangle(pen, pravouhelnik.rectangle);
                }
            }

            foreach (var elipsa in listElips)
            {
                if (elipsa.data.vypln != null)
                {
                    SolidBrush blueBrush = new SolidBrush((Color)elipsa.data.vypln);
                    g.FillEllipse(
                             blueBrush,
                             elipsa.startPoint.X,
                             elipsa.startPoint.Y,
                             elipsa.width,
                             elipsa.height
                         );
                    if (elipsa.data.okraj != null)
                    {
                        Pen pen = new Pen((Color)elipsa.data.okraj, elipsa.data.tloustkaOkraje);
                        g.DrawEllipse(
                            pen,
                            elipsa.startPoint.X,
                            elipsa.startPoint.Y,
                            elipsa.width,
                            elipsa.height
                         );
                    }
                }
                if (elipsa.data.vybraneSrafovani != null)
                {
                    HatchBrush blueBrush = new HatchBrush(
                        (HatchStyle)elipsa.data.vybraneSrafovani,
                        (Color)elipsa.data.vypln,
                        Color.White
                        );
                    g.FillEllipse(
                            blueBrush,
                            elipsa.startPoint.X,
                            elipsa.startPoint.Y,
                            elipsa.width,
                            elipsa.height
                        );
                    if (elipsa.data.okraj != null)
                    {
                        Pen pen = new Pen((Color)elipsa.data.okraj, elipsa.data.tloustkaOkraje);
                        g.DrawEllipse(
                            pen,
                            elipsa.startPoint.X,
                            elipsa.startPoint.Y,
                            elipsa.width,
                            elipsa.height
                         );
                    }
                }

                else
                {
                    Pen pen = new Pen((Color)elipsa.data.okraj, elipsa.data.tloustkaOkraje);
                    g.DrawEllipse(
                       pen,
                       elipsa.startPoint.X,
                       elipsa.startPoint.Y,
                       elipsa.width,
                       elipsa.height
                   );
                }

            }

            foreach (var usecka in listUsecek)
            {
                Pen pen = new Pen((Color)usecka.data.okraj, usecka.data.tloustkaOkraje);
                g.DrawLine(pen, usecka.points[0], usecka.points[1]);
            }

            if (drawingLine)
            {
                Pen pen = new Pen(vybranaBarvaOkraj, tloustkaOkraje);
                g.DrawLine(pen, startPoint, endPoint);
            }

            if (drawingRectangle)
            {
                int width = endPoint.X - startPoint.X;
                int height = endPoint.Y - startPoint.Y;

                if (jednolitaBarve.Checked)
                {
                    SolidBrush blueBrush = new SolidBrush((Color)vybranaBarvaPozadi);
                    Rectangle rect2 = new Rectangle(startPoint.X, startPoint.Y, width, height);
                    g.FillRectangle(blueBrush, rect2);
                   // if (PouzitOkraj.Checked)
                    //{
                        Pen pen = new Pen(vybranaBarvaOkraj, tloustkaOkraje);
                        Rectangle rect = new Rectangle(startPoint.X, startPoint.Y, width, height);
                        g.DrawRectangle(pen, rect);
                    //}
                }

                if (srafovani.Checked)
                {
                    HatchBrush blueBrush = new HatchBrush(
                        (HatchStyle)vybraneSrafovani,
                        (Color)vybranaBarvaPozadi,
                        Color.White
                        );
                    Rectangle rect2 = new Rectangle(startPoint.X, startPoint.Y, width, height);
                    g.FillRectangle(blueBrush, rect2);
                   // if (PouzitOkraj.Checked)
                    //{
                        Pen pen = new Pen(vybranaBarvaOkraj, tloustkaOkraje);
                        Rectangle rect = new Rectangle(startPoint.X, startPoint.Y, width, height);
                        g.DrawRectangle(pen, rect);
                    //}
                }

                else
                {
                    Pen pen = new Pen(vybranaBarvaOkraj, tloustkaOkraje);
                    Rectangle rect2 = new Rectangle(startPoint.X, startPoint.Y, width, height);
                    g.DrawRectangle(pen, rect2);
                }

            }

            if (drawingElipse)
            {
                int width = endPoint.X - startPoint.X;
                int height = endPoint.Y - startPoint.Y;
                if (jednolitaBarve.Checked)
                {
                    SolidBrush blueBrush = new SolidBrush((Color)vybranaBarvaOkraj);
                    g.FillEllipse(
                             blueBrush,
                             startPoint.X,
                             startPoint.Y,
                             width,
                             height
                         );
                   // if (PouzitOkraj.Checked)
                   // {
                        Pen pen = new Pen(vybranaBarvaOkraj, tloustkaOkraje);
                        g.DrawEllipse(
                            pen,
                            startPoint.X,
                            startPoint.Y,
                            width,
                            height
                         );
                    //}
                }
                if (srafovani.Checked)
                {
                    HatchBrush blueBrush = new HatchBrush(
                        (HatchStyle)vybraneSrafovani,
                        (Color)vybranaBarvaPozadi,
                        Color.White
                        );
                    g.FillEllipse(
                            blueBrush,
                            startPoint.X,
                            startPoint.Y,
                            width,
                            height
                        );
                    //if (PouzitOkraj.Checked)
                    //{
                        Pen pen = new Pen(vybranaBarvaOkraj, tloustkaOkraje);
                        g.DrawEllipse(
                            pen,
                            startPoint.X,
                            startPoint.Y,
                            width,
                            height
                         );
                    //}
                }

                else
                {
                    Pen pen = new Pen(vybranaBarvaOkraj, tloustkaOkraje);
                    g.DrawEllipse(
                       pen,
                       startPoint.X,
                       startPoint.Y,
                       width,
                       height
                   );
                }
            }
        }

        private void KreslitUsecku_Click(object sender, EventArgs e)
        {
            this.kresliLine = true;
            this.kresliOval = false;
            this.kresliPravouhelnik = false;

            kresliPravouhelnikButton.Checked = false;
            KreslitUseckuButton.Checked = true;
            krasliElipsuButton.Checked = false;
        }

        private void kresliPravouhelnik_Click(object sender, EventArgs e)
        {
            this.kresliLine = false;
            this.kresliOval = false;
            this.kresliPravouhelnik = true;

            kresliPravouhelnikButton.Checked = true;
            KreslitUseckuButton.Checked = false;
            krasliElipsuButton.Checked = false;
        }

        private void krasliElipsu_Click(object sender, EventArgs e)
        {
            this.kresliLine = false;
            this.kresliOval = false;
            this.kresliPravouhelnik = false;

            kresliPravouhelnikButton.Checked = false;
            KreslitUseckuButton.Checked = false;
            krasliElipsuButton.Checked = true;
        }

        private void transformaceButoon_Click(object sender, EventArgs e)
        {

        }

        private void smazatButton_Click(object sender, EventArgs e)
        {

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
    }

}
