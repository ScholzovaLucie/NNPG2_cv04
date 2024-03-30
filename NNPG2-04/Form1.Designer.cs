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
            this.components = new System.ComponentModel.Container();
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
            this.comboBoxPosun = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.vyplnBox = new System.Windows.Forms.GroupBox();
            this.pictureBoxBarvaPozadi = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BezVyplne = new System.Windows.Forms.CheckBox();
            this.comboBoxSrafovaniSUkazkou = new System.Windows.Forms.ComboBox();
            this.jednolitaBarve = new System.Windows.Forms.CheckBox();
            this.srafovani = new System.Windows.Forms.CheckBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.okrajBox = new System.Windows.Forms.GroupBox();
            this.pictureBoxBarvaOkraj = new System.Windows.Forms.PictureBox();
            this.PouzitOkraj = new System.Windows.Forms.CheckBox();
            this.okrajStyl = new System.Windows.Forms.ComboBox();
            this.tloustkaOkrajeSetting = new System.Windows.Forms.NumericUpDown();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.colorDialog2 = new System.Windows.Forms.ColorDialog();
            this.toolStrip1.SuspendLayout();
            this.PanelKresba.SuspendLayout();
            this.panel2.SuspendLayout();
            this.vyplnBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBarvaPozadi)).BeginInit();
            this.okrajBox.SuspendLayout();
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
            this.PanelKresba.Controls.Add(this.comboBoxPosun);
            this.PanelKresba.Controls.Add(this.panel2);
            this.PanelKresba.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelKresba.Location = new System.Drawing.Point(0, 25);
            this.PanelKresba.Name = "PanelKresba";
            this.PanelKresba.Size = new System.Drawing.Size(800, 425);
            this.PanelKresba.TabIndex = 1;
            // 
            // comboBoxPosun
            // 
            this.comboBoxPosun.FormattingEnabled = true;
            this.comboBoxPosun.Location = new System.Drawing.Point(493, 123);
            this.comboBoxPosun.Name = "comboBoxPosun";
            this.comboBoxPosun.Size = new System.Drawing.Size(121, 21);
            this.comboBoxPosun.TabIndex = 3;
            this.comboBoxPosun.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.vyplnBox);
            this.panel2.Controls.Add(this.splitter1);
            this.panel2.Controls.Add(this.okrajBox);
            this.panel2.Location = new System.Drawing.Point(0, 286);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 139);
            this.panel2.TabIndex = 2;
            // 
            // vyplnBox
            // 
            this.vyplnBox.Controls.Add(this.pictureBoxBarvaPozadi);
            this.vyplnBox.Controls.Add(this.label3);
            this.vyplnBox.Controls.Add(this.BezVyplne);
            this.vyplnBox.Controls.Add(this.comboBoxSrafovaniSUkazkou);
            this.vyplnBox.Controls.Add(this.jednolitaBarve);
            this.vyplnBox.Controls.Add(this.srafovani);
            this.vyplnBox.Location = new System.Drawing.Point(401, 3);
            this.vyplnBox.Name = "vyplnBox";
            this.vyplnBox.Size = new System.Drawing.Size(396, 131);
            this.vyplnBox.TabIndex = 4;
            this.vyplnBox.TabStop = false;
            this.vyplnBox.Text = "Výplň";
            // 
            // pictureBoxBarvaPozadi
            // 
            this.pictureBoxBarvaPozadi.BackColor = System.Drawing.SystemColors.HotTrack;
            this.pictureBoxBarvaPozadi.Location = new System.Drawing.Point(6, 100);
            this.pictureBoxBarvaPozadi.Name = "pictureBoxBarvaPozadi";
            this.pictureBoxBarvaPozadi.Size = new System.Drawing.Size(23, 21);
            this.pictureBoxBarvaPozadi.TabIndex = 2;
            this.pictureBoxBarvaPozadi.TabStop = false;
            this.pictureBoxBarvaPozadi.Click += new System.EventHandler(this.barvaPozadi_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(192, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Styl pozadí";
            // 
            // BezVyplne
            // 
            this.BezVyplne.AutoSize = true;
            this.BezVyplne.Checked = true;
            this.BezVyplne.CheckState = System.Windows.Forms.CheckState.Checked;
            this.BezVyplne.Location = new System.Drawing.Point(6, 55);
            this.BezVyplne.Name = "BezVyplne";
            this.BezVyplne.Size = new System.Drawing.Size(78, 17);
            this.BezVyplne.TabIndex = 5;
            this.BezVyplne.Text = "Bez výplně";
            this.BezVyplne.UseVisualStyleBackColor = true;
            this.BezVyplne.CheckedChanged += new System.EventHandler(this.BezVyplne_CheckedChanged);
            // 
            // comboBoxSrafovaniSUkazkou
            // 
            this.comboBoxSrafovaniSUkazkou.FormattingEnabled = true;
            this.comboBoxSrafovaniSUkazkou.Location = new System.Drawing.Point(269, 100);
            this.comboBoxSrafovaniSUkazkou.Name = "comboBoxSrafovaniSUkazkou";
            this.comboBoxSrafovaniSUkazkou.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSrafovaniSUkazkou.TabIndex = 8;
            this.comboBoxSrafovaniSUkazkou.SelectedIndexChanged += new System.EventHandler(this.comboBoxSrafovaniSUkazkou_SelectedIndexChanged);
            // 
            // jednolitaBarve
            // 
            this.jednolitaBarve.AutoSize = true;
            this.jednolitaBarve.Location = new System.Drawing.Point(130, 55);
            this.jednolitaBarve.Name = "jednolitaBarve";
            this.jednolitaBarve.Size = new System.Drawing.Size(98, 17);
            this.jednolitaBarve.TabIndex = 6;
            this.jednolitaBarve.Text = "Jednolitá barva";
            this.jednolitaBarve.UseVisualStyleBackColor = true;
            this.jednolitaBarve.CheckedChanged += new System.EventHandler(this.jednolitaBarve_CheckedChanged);
            // 
            // srafovani
            // 
            this.srafovani.AutoSize = true;
            this.srafovani.Location = new System.Drawing.Point(298, 55);
            this.srafovani.Name = "srafovani";
            this.srafovani.Size = new System.Drawing.Size(73, 17);
            this.srafovani.TabIndex = 7;
            this.srafovani.Text = "Šrafování";
            this.srafovani.UseVisualStyleBackColor = true;
            this.srafovani.CheckedChanged += new System.EventHandler(this.srafovani_CheckedChanged);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 139);
            this.splitter1.TabIndex = 10;
            this.splitter1.TabStop = false;
            // 
            // okrajBox
            // 
            this.okrajBox.Controls.Add(this.pictureBoxBarvaOkraj);
            this.okrajBox.Controls.Add(this.PouzitOkraj);
            this.okrajBox.Controls.Add(this.okrajStyl);
            this.okrajBox.Controls.Add(this.tloustkaOkrajeSetting);
            this.okrajBox.Location = new System.Drawing.Point(3, 3);
            this.okrajBox.Name = "okrajBox";
            this.okrajBox.Size = new System.Drawing.Size(392, 131);
            this.okrajBox.TabIndex = 3;
            this.okrajBox.TabStop = false;
            this.okrajBox.Text = "Okraj";
            // 
            // pictureBoxBarvaOkraj
            // 
            this.pictureBoxBarvaOkraj.BackColor = System.Drawing.SystemColors.HotTrack;
            this.pictureBoxBarvaOkraj.Location = new System.Drawing.Point(12, 101);
            this.pictureBoxBarvaOkraj.Name = "pictureBoxBarvaOkraj";
            this.pictureBoxBarvaOkraj.Size = new System.Drawing.Size(23, 21);
            this.pictureBoxBarvaOkraj.TabIndex = 3;
            this.pictureBoxBarvaOkraj.TabStop = false;
            this.pictureBoxBarvaOkraj.Click += new System.EventHandler(this.barvaOkraj_Click_1);
            this.pictureBoxBarvaOkraj.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxBarvaOkraj_Paint);
            // 
            // PouzitOkraj
            // 
            this.PouzitOkraj.AutoSize = true;
            this.PouzitOkraj.Location = new System.Drawing.Point(12, 32);
            this.PouzitOkraj.Name = "PouzitOkraj";
            this.PouzitOkraj.Size = new System.Drawing.Size(57, 17);
            this.PouzitOkraj.TabIndex = 0;
            this.PouzitOkraj.Text = "Použít";
            this.PouzitOkraj.UseVisualStyleBackColor = true;
            // 
            // okrajStyl
            // 
            this.okrajStyl.FormattingEnabled = true;
            this.okrajStyl.Location = new System.Drawing.Point(120, 101);
            this.okrajStyl.Name = "okrajStyl";
            this.okrajStyl.Size = new System.Drawing.Size(121, 21);
            this.okrajStyl.TabIndex = 1;
            // 
            // tloustkaOkrajeSetting
            // 
            this.tloustkaOkrajeSetting.AccessibleName = "tloustkaOkraje";
            this.tloustkaOkrajeSetting.Location = new System.Drawing.Point(266, 101);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PanelKresba);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.PanelKresba.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.vyplnBox.ResumeLayout(false);
            this.vyplnBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBarvaPozadi)).EndInit();
            this.okrajBox.ResumeLayout(false);
            this.okrajBox.PerformLayout();
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
        private System.Windows.Forms.NumericUpDown tloustkaOkrajeSetting;
        private System.Windows.Forms.ComboBox okrajStyl;
        private System.Windows.Forms.CheckBox PouzitOkraj;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxSrafovaniSUkazkou;
        private System.Windows.Forms.CheckBox srafovani;
        private System.Windows.Forms.CheckBox jednolitaBarve;
        private System.Windows.Forms.CheckBox BezVyplne;
        private System.Windows.Forms.ColorDialog colorDialog2;
        private System.Windows.Forms.ToolStripButton KreslitUseckuButton;
        private System.Windows.Forms.ToolStripButton kresliPravouhelnikButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton krasliElipsuButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton transformaceButoon;
        private System.Windows.Forms.ToolStripButton smazatButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.PictureBox pictureBoxBarvaPozadi;
        private System.Windows.Forms.PictureBox pictureBoxBarvaOkraj;
        private System.Windows.Forms.GroupBox vyplnBox;
        private System.Windows.Forms.GroupBox okrajBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ComboBox comboBoxPosun;
    }
}

