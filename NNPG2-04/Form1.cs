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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace NNPG2_04
{
    public partial class Form1 : Form
    {
        private List<Tvar> listTvaru = new List<Tvar>();

        private Color vybranaBarvaOkraj = Color.Black;
        private HatchStyle vybraneSrafovani = HatchStyle.Horizontal;
        private HatchStyle vybranyOkraj;
        private Color vybranaBarvaPozadi = Color.Blue;
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

                Usecka usecka = new Usecka(pair);
                usecka.pridejData(vybranaBarvaOkraj, null, null, tloustkaOkraje);
                usecka.nastavZIndex(listTvaru.Count);
                listTvaru.Add(usecka);
            }
            else if (drawingElipse)
            {
                endPoint = e.Location;
                drawingElipse = false;

                int width = endPoint.X - startPoint.X;
                int height = endPoint.Y - startPoint.Y;

                Elipsa elipsa = new Elipsa(
                    startPoint,
                    width,
                    height
                 );

                if (jednolitaBarve.Checked)
                    elipsa.pridejData(vybranaBarvaOkraj, vybranaBarvaPozadi, null, tloustkaOkraje);

                else if (srafovani.Checked)
                    elipsa.pridejData(vybranaBarvaOkraj, vybranaBarvaPozadi, vybraneSrafovani, tloustkaOkraje);

                else
                    elipsa.pridejData(vybranaBarvaOkraj, null, null, tloustkaOkraje);

                elipsa.nastavZIndex(listTvaru.Count);
                listTvaru.Add(elipsa);
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

                if (jednolitaBarve.Checked)
                    pravouhelnik.pridejData(vybranaBarvaOkraj, vybranaBarvaPozadi, null, tloustkaOkraje);

                else if (srafovani.Checked)
                    pravouhelnik.pridejData(vybranaBarvaOkraj, vybranaBarvaPozadi, vybraneSrafovani, tloustkaOkraje);

                else
                    pravouhelnik.pridejData(vybranaBarvaOkraj, null, null, tloustkaOkraje);

                pravouhelnik.nastavZIndex(listTvaru.Count);
                listTvaru.Add(pravouhelnik);
            }

            drawingRectangle = false;
            drawingLine = false;
            drawingElipse = false;
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
            this.kresliOval = true;
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
