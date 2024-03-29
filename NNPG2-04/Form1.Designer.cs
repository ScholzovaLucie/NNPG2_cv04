namespace NNPG2_04
{
    partial class Form1
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.colorDialogOkraj = new System.Windows.Forms.ColorDialog();
            this.colorDialogPozadi = new System.Windows.Forms.ColorDialog();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.KreslitUseckuButton = new System.Windows.Forms.ToolStripButton();
            this.kresliPravouhelnikButton = new System.Windows.Forms.ToolStripButton();
            this.krasliElipsuButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.transformaceButoon = new System.Windows.Forms.ToolStripButton();
            this.smazatButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.PanelKresba = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBoxBarvaPozadi = new System.Windows.Forms.PictureBox();
            this.pictureBoxBarvaOkraj = new System.Windows.Forms.PictureBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxSrafovaniSUkazkou = new System.Windows.Forms.ComboBox();
            this.srafovani = new System.Windows.Forms.CheckBox();
            this.jednolitaBarve = new System.Windows.Forms.CheckBox();
            this.BezVyplne = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tloustkaOkrajeSetting = new System.Windows.Forms.NumericUpDown();
            this.okrajStyl = new System.Windows.Forms.ComboBox();
            this.PouzitOkraj = new System.Windows.Forms.CheckBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.colorDialog2 = new System.Windows.Forms.ColorDialog();
            this.toolStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBarvaPozadi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBarvaOkraj)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tloustkaOkrajeSetting)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator2,
            this.KreslitUseckuButton,
            this.kresliPravouhelnikButton,
            this.krasliElipsuButton,
            this.toolStripSeparator1,
            this.transformaceButoon,
            this.smazatButton,
            this.toolStripSeparator3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // KreslitUseckuButton
            // 
            this.KreslitUseckuButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.KreslitUseckuButton.Image = ((System.Drawing.Image)(resources.GetObject("KreslitUseckuButton.Image")));
            this.KreslitUseckuButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.KreslitUseckuButton.Name = "KreslitUseckuButton";
            this.KreslitUseckuButton.Size = new System.Drawing.Size(48, 22);
            this.KreslitUseckuButton.Text = "Úsečka";
            this.KreslitUseckuButton.Click += new System.EventHandler(this.KreslitUsecku_Click);
            // 
            // kresliPravouhelnikButton
            // 
            this.kresliPravouhelnikButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.kresliPravouhelnikButton.Image = ((System.Drawing.Image)(resources.GetObject("kresliPravouhelnikButton.Image")));
            this.kresliPravouhelnikButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.kresliPravouhelnikButton.Name = "kresliPravouhelnikButton";
            this.kresliPravouhelnikButton.Size = new System.Drawing.Size(80, 22);
            this.kresliPravouhelnikButton.Text = "Pravouhelník";
            this.kresliPravouhelnikButton.Click += new System.EventHandler(this.kresliPravouhelnik_Click);
            // 
            // krasliElipsuButton
            // 
            this.krasliElipsuButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.krasliElipsuButton.Image = ((System.Drawing.Image)(resources.GetObject("krasliElipsuButton.Image")));
            this.krasliElipsuButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.krasliElipsuButton.Name = "krasliElipsuButton";
            this.krasliElipsuButton.Size = new System.Drawing.Size(41, 22);
            this.krasliElipsuButton.Text = "Elipsa";
            this.krasliElipsuButton.Click += new System.EventHandler(this.krasliElipsu_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // transformaceButoon
            // 
            this.transformaceButoon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.transformaceButoon.Image = ((System.Drawing.Image)(resources.GetObject("transformaceButoon.Image")));
            this.transformaceButoon.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.transformaceButoon.Name = "transformaceButoon";
            this.transformaceButoon.Size = new System.Drawing.Size(82, 22);
            this.transformaceButoon.Text = "Transformace";
            this.transformaceButoon.Click += new System.EventHandler(this.transformaceButoon_Click);
            // 
            // smazatButton
            // 
            this.smazatButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.smazatButton.Image = ((System.Drawing.Image)(resources.GetObject("smazatButton.Image")));
            this.smazatButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.smazatButton.Name = "smazatButton";
            this.smazatButton.Size = new System.Drawing.Size(49, 22);
            this.smazatButton.Text = "Smazat";
            this.smazatButton.Click += new System.EventHandler(this.smazatButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // PanelKresba
            // 
            this.PanelKresba.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelKresba.Location = new System.Drawing.Point(0, 25);
            this.PanelKresba.Name = "PanelKresba";
            this.PanelKresba.Size = new System.Drawing.Size(800, 425);
            this.PanelKresba.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBoxBarvaPozadi);
            this.panel2.Controls.Add(this.pictureBoxBarvaOkraj);
            this.panel2.Controls.Add(this.splitter1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.comboBoxSrafovaniSUkazkou);
            this.panel2.Controls.Add(this.srafovani);
            this.panel2.Controls.Add(this.jednolitaBarve);
            this.panel2.Controls.Add(this.BezVyplne);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.tloustkaOkrajeSetting);
            this.panel2.Controls.Add(this.okrajStyl);
            this.panel2.Controls.Add(this.PouzitOkraj);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 350);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 100);
            this.panel2.TabIndex = 2;
            // 
            // pictureBoxBarvaPozadi
            // 
            this.pictureBoxBarvaPozadi.BackColor = System.Drawing.SystemColors.HotTrack;
            this.pictureBoxBarvaPozadi.Location = new System.Drawing.Point(465, 50);
            this.pictureBoxBarvaPozadi.Name = "pictureBoxBarvaPozadi";
            this.pictureBoxBarvaPozadi.Size = new System.Drawing.Size(23, 21);
            this.pictureBoxBarvaPozadi.TabIndex = 2;
            this.pictureBoxBarvaPozadi.TabStop = false;
            this.pictureBoxBarvaPozadi.Click += new System.EventHandler(this.barvaPozadi_Click);
            // 
            // pictureBoxBarvaOkraj
            // 
            this.pictureBoxBarvaOkraj.BackColor = System.Drawing.SystemColors.HotTrack;
            this.pictureBoxBarvaOkraj.Location = new System.Drawing.Point(25, 50);
            this.pictureBoxBarvaOkraj.Name = "pictureBoxBarvaOkraj";
            this.pictureBoxBarvaOkraj.Size = new System.Drawing.Size(23, 21);
            this.pictureBoxBarvaOkraj.TabIndex = 3;
            this.pictureBoxBarvaOkraj.TabStop = false;
            this.pictureBoxBarvaOkraj.Click += new System.EventHandler(this.barvaOkraj_Click_1);
            this.pictureBoxBarvaOkraj.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxBarvaOkraj_Paint);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 100);
            this.splitter1.TabIndex = 10;
            this.splitter1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(585, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Barva pozadí";
            // 
            // comboBoxSrafovaniSUkazkou
            // 
            this.comboBoxSrafovaniSUkazkou.FormattingEnabled = true;
            this.comboBoxSrafovaniSUkazkou.Location = new System.Drawing.Point(662, 67);
            this.comboBoxSrafovaniSUkazkou.Name = "comboBoxSrafovaniSUkazkou";
            this.comboBoxSrafovaniSUkazkou.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSrafovaniSUkazkou.TabIndex = 8;
            this.comboBoxSrafovaniSUkazkou.SelectedIndexChanged += new System.EventHandler(this.comboBoxSrafovaniSUkazkou_SelectedIndexChanged);
            // 
            // srafovani
            // 
            this.srafovani.AutoSize = true;
            this.srafovani.Location = new System.Drawing.Point(708, 26);
            this.srafovani.Name = "srafovani";
            this.srafovani.Size = new System.Drawing.Size(73, 17);
            this.srafovani.TabIndex = 7;
            this.srafovani.Text = "Šrafování";
            this.srafovani.UseVisualStyleBackColor = true;
            this.srafovani.CheckedChanged += new System.EventHandler(this.srafovani_CheckedChanged);
            // 
            // jednolitaBarve
            // 
            this.jednolitaBarve.AutoSize = true;
            this.jednolitaBarve.Location = new System.Drawing.Point(590, 26);
            this.jednolitaBarve.Name = "jednolitaBarve";
            this.jednolitaBarve.Size = new System.Drawing.Size(98, 17);
            this.jednolitaBarve.TabIndex = 6;
            this.jednolitaBarve.Text = "Jednolitá barva";
            this.jednolitaBarve.UseVisualStyleBackColor = true;
            this.jednolitaBarve.CheckedChanged += new System.EventHandler(this.jednolitaBarve_CheckedChanged);
            // 
            // BezVyplne
            // 
            this.BezVyplne.AutoSize = true;
            this.BezVyplne.Checked = true;
            this.BezVyplne.CheckState = System.Windows.Forms.CheckState.Checked;
            this.BezVyplne.Location = new System.Drawing.Point(465, 26);
            this.BezVyplne.Name = "BezVyplne";
            this.BezVyplne.Size = new System.Drawing.Size(78, 17);
            this.BezVyplne.TabIndex = 5;
            this.BezVyplne.Text = "Bez výplně";
            this.BezVyplne.UseVisualStyleBackColor = true;
            this.BezVyplne.CheckedChanged += new System.EventHandler(this.BezVyplne_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(462, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Výplň";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Okraj";
            // 
            // tloustkaOkrajeSetting
            // 
            this.tloustkaOkrajeSetting.AccessibleName = "tloustkaOkraje";
            this.tloustkaOkrajeSetting.Location = new System.Drawing.Point(270, 68);
            this.tloustkaOkrajeSetting.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tloustkaOkrajeSetting.Name = "tloustkaOkrajeSetting";
            this.tloustkaOkrajeSetting.Size = new System.Drawing.Size(120, 20);
            this.tloustkaOkrajeSetting.TabIndex = 2;
            this.tloustkaOkrajeSetting.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tloustkaOkrajeSetting.ValueChanged += new System.EventHandler(this.numericUokrajTloustkapDown1_ValueChanged);
            // 
            // okrajStyl
            // 
            this.okrajStyl.FormattingEnabled = true;
            this.okrajStyl.Location = new System.Drawing.Point(143, 67);
            this.okrajStyl.Name = "okrajStyl";
            this.okrajStyl.Size = new System.Drawing.Size(121, 21);
            this.okrajStyl.TabIndex = 1;
            // 
            // PouzitOkraj
            // 
            this.PouzitOkraj.AutoSize = true;
            this.PouzitOkraj.Location = new System.Drawing.Point(25, 26);
            this.PouzitOkraj.Name = "PouzitOkraj";
            this.PouzitOkraj.Size = new System.Drawing.Size(57, 17);
            this.PouzitOkraj.TabIndex = 0;
            this.PouzitOkraj.Text = "Použít";
            this.PouzitOkraj.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.PanelKresba);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBarvaPozadi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBarvaOkraj)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tloustkaOkrajeSetting)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ColorDialog colorDialogOkraj;
        private System.Windows.Forms.ColorDialog colorDialogPozadi;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Panel PanelKresba;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown tloustkaOkrajeSetting;
        private System.Windows.Forms.ComboBox okrajStyl;
        private System.Windows.Forms.CheckBox PouzitOkraj;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxSrafovaniSUkazkou;
        private System.Windows.Forms.CheckBox srafovani;
        private System.Windows.Forms.CheckBox jednolitaBarve;
        private System.Windows.Forms.CheckBox BezVyplne;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColorDialog colorDialog2;
        private System.Windows.Forms.ToolStripButton KreslitUseckuButton;
        private System.Windows.Forms.ToolStripButton kresliPravouhelnikButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton krasliElipsuButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton transformaceButoon;
        private System.Windows.Forms.ToolStripButton smazatButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.PictureBox pictureBoxBarvaPozadi;
        private System.Windows.Forms.PictureBox pictureBoxBarvaOkraj;
    }
}

