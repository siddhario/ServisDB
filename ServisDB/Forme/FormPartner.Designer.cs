namespace ServisDB.Forme
{
  partial class FormPartner
    {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnReload = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblBrojLK = new System.Windows.Forms.Label();
            this.tbBrojLK = new System.Windows.Forms.TextBox();
            this.cbDobavljac = new System.Windows.Forms.CheckBox();
            this.cbKupac = new System.Windows.Forms.CheckBox();
            this.rbPravnoLice = new System.Windows.Forms.RadioButton();
            this.rbFizickoLice = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblAdresa = new System.Windows.Forms.Label();
            this.lblMaticniBroj = new System.Windows.Forms.Label();
            this.lblTelefon = new System.Windows.Forms.Label();
            this.lblNaziv = new System.Windows.Forms.Label();
            this.lblSifra = new System.Windows.Forms.Label();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.tbAdresa = new System.Windows.Forms.TextBox();
            this.tbMaticniBroj = new System.Windows.Forms.TextBox();
            this.tbTelefon = new System.Windows.Forms.TextBox();
            this.tbNaziv = new System.Windows.Forms.TextBox();
            this.tbSifra = new System.Windows.Forms.TextBox();
            this.btnBrisanje = new System.Windows.Forms.Button();
            this.btnStampa = new System.Windows.Forms.Button();
            this.tmrDelay = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1213, 741);
            this.tabControl1.TabIndex = 26;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            this.tabControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tabControl1_KeyDown);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnReload);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.textBox2);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.dgvMain);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1205, 712);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Pregled";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnReload
            // 
            this.btnReload.Image = global::Delos.Properties.Resources.reload__1_;
            this.btnReload.Location = new System.Drawing.Point(371, 3);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(46, 22);
            this.btnReload.TabIndex = 4;
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label13.Location = new System.Drawing.Point(89, 6);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(93, 16);
            this.label13.TabIndex = 3;
            this.label13.Text = "Pretraga - [F3]";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(184, 3);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(181, 22);
            this.textBox2.TabIndex = 2;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(4, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(82, 22);
            this.textBox1.TabIndex = 1;
            this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.AllowUserToDeleteRows = false;
            this.dgvMain.AllowUserToOrderColumns = true;
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Location = new System.Drawing.Point(3, 29);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.ReadOnly = true;
            this.dgvMain.RowHeadersVisible = false;
            this.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMain.Size = new System.Drawing.Size(1196, 680);
            this.dgvMain.TabIndex = 0;
            this.dgvMain.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dgvMain.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataGridView1_RowPrePaint);
            this.dgvMain.SelectionChanged += new System.EventHandler(this.dgvMain_SelectionChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lblBrojLK);
            this.tabPage2.Controls.Add(this.tbBrojLK);
            this.tabPage2.Controls.Add(this.cbDobavljac);
            this.tabPage2.Controls.Add(this.cbKupac);
            this.tabPage2.Controls.Add(this.rbPravnoLice);
            this.tabPage2.Controls.Add(this.rbFizickoLice);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.lblEmail);
            this.tabPage2.Controls.Add(this.lblAdresa);
            this.tabPage2.Controls.Add(this.lblMaticniBroj);
            this.tabPage2.Controls.Add(this.lblTelefon);
            this.tabPage2.Controls.Add(this.lblNaziv);
            this.tabPage2.Controls.Add(this.lblSifra);
            this.tabPage2.Controls.Add(this.tbEmail);
            this.tabPage2.Controls.Add(this.tbAdresa);
            this.tabPage2.Controls.Add(this.tbMaticniBroj);
            this.tabPage2.Controls.Add(this.tbTelefon);
            this.tabPage2.Controls.Add(this.tbNaziv);
            this.tabPage2.Controls.Add(this.tbSifra);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1205, 712);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Unos [F2]";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblBrojLK
            // 
            this.lblBrojLK.AutoSize = true;
            this.lblBrojLK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrojLK.Location = new System.Drawing.Point(311, 117);
            this.lblBrojLK.Name = "lblBrojLK";
            this.lblBrojLK.Size = new System.Drawing.Size(53, 16);
            this.lblBrojLK.TabIndex = 50;
            this.lblBrojLK.Text = "Broj LK:";
            // 
            // tbBrojLK
            // 
            this.tbBrojLK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBrojLK.Location = new System.Drawing.Point(396, 116);
            this.tbBrojLK.Name = "tbBrojLK";
            this.tbBrojLK.Size = new System.Drawing.Size(90, 22);
            this.tbBrojLK.TabIndex = 49;
            // 
            // cbDobavljac
            // 
            this.cbDobavljac.AutoSize = true;
            this.cbDobavljac.Location = new System.Drawing.Point(222, 266);
            this.cbDobavljac.Name = "cbDobavljac";
            this.cbDobavljac.Size = new System.Drawing.Size(89, 20);
            this.cbDobavljac.TabIndex = 9;
            this.cbDobavljac.Text = "Dobavljač";
            this.cbDobavljac.UseVisualStyleBackColor = true;
            // 
            // cbKupac
            // 
            this.cbKupac.AutoSize = true;
            this.cbKupac.Location = new System.Drawing.Point(125, 266);
            this.cbKupac.Name = "cbKupac";
            this.cbKupac.Size = new System.Drawing.Size(65, 20);
            this.cbKupac.TabIndex = 8;
            this.cbKupac.Text = "Kupac";
            this.cbKupac.UseVisualStyleBackColor = true;
            // 
            // rbPravnoLice
            // 
            this.rbPravnoLice.AutoSize = true;
            this.rbPravnoLice.Location = new System.Drawing.Point(222, 36);
            this.rbPravnoLice.Name = "rbPravnoLice";
            this.rbPravnoLice.Size = new System.Drawing.Size(93, 20);
            this.rbPravnoLice.TabIndex = 2;
            this.rbPravnoLice.TabStop = true;
            this.rbPravnoLice.Text = "Pravno lice";
            this.rbPravnoLice.UseVisualStyleBackColor = true;
            // 
            // rbFizickoLice
            // 
            this.rbFizickoLice.AutoSize = true;
            this.rbFizickoLice.Location = new System.Drawing.Point(125, 37);
            this.rbFizickoLice.Name = "rbFizickoLice";
            this.rbFizickoLice.Size = new System.Drawing.Size(92, 20);
            this.rbFizickoLice.TabIndex = 1;
            this.rbFizickoLice.TabStop = true;
            this.rbFizickoLice.Text = "Fizičko lice";
            this.rbFizickoLice.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(421, 349);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(135, 36);
            this.button2.TabIndex = 11;
            this.button2.Text = "Odustani [ESC]";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(280, 349);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 36);
            this.button1.TabIndex = 10;
            this.button1.Text = "Sačuvaj [F1]";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(8, 225);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(45, 16);
            this.lblEmail.TabIndex = 48;
            this.lblEmail.Text = "Email:";
            // 
            // lblAdresa
            // 
            this.lblAdresa.AutoSize = true;
            this.lblAdresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdresa.Location = new System.Drawing.Point(8, 146);
            this.lblAdresa.Name = "lblAdresa";
            this.lblAdresa.Size = new System.Drawing.Size(55, 16);
            this.lblAdresa.TabIndex = 44;
            this.lblAdresa.Text = "Adresa:";
            // 
            // lblMaticniBroj
            // 
            this.lblMaticniBroj.AutoSize = true;
            this.lblMaticniBroj.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaticniBroj.Location = new System.Drawing.Point(8, 117);
            this.lblMaticniBroj.Name = "lblMaticniBroj";
            this.lblMaticniBroj.Size = new System.Drawing.Size(79, 16);
            this.lblMaticniBroj.TabIndex = 42;
            this.lblMaticniBroj.Text = "Matični broj:";
            // 
            // lblTelefon
            // 
            this.lblTelefon.AutoSize = true;
            this.lblTelefon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelefon.Location = new System.Drawing.Point(8, 196);
            this.lblTelefon.Name = "lblTelefon";
            this.lblTelefon.Size = new System.Drawing.Size(57, 16);
            this.lblTelefon.TabIndex = 41;
            this.lblTelefon.Text = "Telefon:";
            // 
            // lblNaziv
            // 
            this.lblNaziv.AutoSize = true;
            this.lblNaziv.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNaziv.Location = new System.Drawing.Point(8, 67);
            this.lblNaziv.Name = "lblNaziv";
            this.lblNaziv.Size = new System.Drawing.Size(45, 16);
            this.lblNaziv.TabIndex = 40;
            this.lblNaziv.Text = "Naziv:";
            // 
            // lblSifra
            // 
            this.lblSifra.AutoSize = true;
            this.lblSifra.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSifra.Location = new System.Drawing.Point(8, 8);
            this.lblSifra.Name = "lblSifra";
            this.lblSifra.Size = new System.Drawing.Size(38, 16);
            this.lblSifra.TabIndex = 38;
            this.lblSifra.Text = "Šifra:";
            // 
            // tbEmail
            // 
            this.tbEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbEmail.Location = new System.Drawing.Point(125, 225);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(225, 22);
            this.tbEmail.TabIndex = 7;
            // 
            // tbAdresa
            // 
            this.tbAdresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAdresa.Location = new System.Drawing.Point(125, 146);
            this.tbAdresa.Multiline = true;
            this.tbAdresa.Name = "tbAdresa";
            this.tbAdresa.Size = new System.Drawing.Size(361, 43);
            this.tbAdresa.TabIndex = 5;
            // 
            // tbMaticniBroj
            // 
            this.tbMaticniBroj.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMaticniBroj.Location = new System.Drawing.Point(125, 117);
            this.tbMaticniBroj.Name = "tbMaticniBroj";
            this.tbMaticniBroj.Size = new System.Drawing.Size(138, 22);
            this.tbMaticniBroj.TabIndex = 4;
            // 
            // tbTelefon
            // 
            this.tbTelefon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTelefon.Location = new System.Drawing.Point(125, 196);
            this.tbTelefon.Name = "tbTelefon";
            this.tbTelefon.Size = new System.Drawing.Size(361, 22);
            this.tbTelefon.TabIndex = 6;
            this.tbTelefon.Text = "11111111111111111111111111111111111111111111111111";
            // 
            // tbNaziv
            // 
            this.tbNaziv.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNaziv.Location = new System.Drawing.Point(125, 64);
            this.tbNaziv.Multiline = true;
            this.tbNaziv.Name = "tbNaziv";
            this.tbNaziv.Size = new System.Drawing.Size(361, 46);
            this.tbNaziv.TabIndex = 3;
            // 
            // tbSifra
            // 
            this.tbSifra.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSifra.Location = new System.Drawing.Point(125, 8);
            this.tbSifra.Name = "tbSifra";
            this.tbSifra.ReadOnly = true;
            this.tbSifra.Size = new System.Drawing.Size(100, 22);
            this.tbSifra.TabIndex = 0;
            this.tbSifra.Text = "AUTO";
            // 
            // btnBrisanje
            // 
            this.btnBrisanje.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrisanje.Location = new System.Drawing.Point(1219, 71);
            this.btnBrisanje.Name = "btnBrisanje";
            this.btnBrisanje.Size = new System.Drawing.Size(101, 36);
            this.btnBrisanje.TabIndex = 1;
            this.btnBrisanje.Text = "Brisanje [F5]";
            this.btnBrisanje.UseVisualStyleBackColor = true;
            this.btnBrisanje.Click += new System.EventHandler(this.btnBrisanje_Click);
            // 
            // btnStampa
            // 
            this.btnStampa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStampa.Location = new System.Drawing.Point(1219, 28);
            this.btnStampa.Name = "btnStampa";
            this.btnStampa.Size = new System.Drawing.Size(101, 37);
            this.btnStampa.TabIndex = 0;
            this.btnStampa.Text = "Štampa [F4]";
            this.btnStampa.UseVisualStyleBackColor = true;
            this.btnStampa.Click += new System.EventHandler(this.btnStampa_Click);
            // 
            // FormPartner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1332, 741);
            this.Controls.Add(this.btnBrisanje);
            this.Controls.Add(this.btnStampa);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormPartner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Katalog partnera";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Label lblTelefon;
    private System.Windows.Forms.Label lblNaziv;
    private System.Windows.Forms.Label lblSifra;
    private System.Windows.Forms.TextBox tbTelefon;
    private System.Windows.Forms.TextBox tbNaziv;
    private System.Windows.Forms.TextBox tbSifra;
    private System.Windows.Forms.DataGridView dgvMain;
    private System.Windows.Forms.Button btnBrisanje;
    private System.Windows.Forms.Button btnStampa;
    private System.Windows.Forms.TextBox textBox2;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.Timer tmrDelay;
    private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblAdresa;
        private System.Windows.Forms.Label lblMaticniBroj;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.TextBox tbAdresa;
        private System.Windows.Forms.TextBox tbMaticniBroj;
        private System.Windows.Forms.RadioButton rbPravnoLice;
        private System.Windows.Forms.RadioButton rbFizickoLice;
        private System.Windows.Forms.CheckBox cbDobavljac;
        private System.Windows.Forms.CheckBox cbKupac;
        private System.Windows.Forms.Label lblBrojLK;
        private System.Windows.Forms.TextBox tbBrojLK;
    }
}

