namespace ServisDB.Forme
{
  partial class FormUgovor
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
            this.dgvPrijave = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnKupacClear = new System.Windows.Forms.Button();
            this.tbKupacSifra = new System.Windows.Forms.TextBox();
            this.lblBrojRacuna = new System.Windows.Forms.Label();
            this.tbBrojRacuna = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblAdresa = new System.Windows.Forms.Label();
            this.tbAdresa = new System.Windows.Forms.TextBox();
            this.btnPartneri = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblRadnik = new System.Windows.Forms.Label();
            this.lblnapomena = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbRadnik = new System.Windows.Forms.TextBox();
            this.tbNapomena = new System.Windows.Forms.TextBox();
            this.tbKupacaTelefon = new System.Windows.Forms.TextBox();
            this.tbKupac = new System.Windows.Forms.TextBox();
            this.dtpDatum = new System.Windows.Forms.DateTimePicker();
            this.tbRedniBroj = new System.Windows.Forms.TextBox();
            this.btnBrisanje = new System.Windows.Forms.Button();
            this.btnStampa = new System.Windows.Forms.Button();
            this.tmrDelay = new System.Windows.Forms.Timer(this.components);
            this.lblKupacBrojLk = new System.Windows.Forms.Label();
            this.tbKupacBrojLk = new System.Windows.Forms.TextBox();
            this.lblKupacMaticniBroj = new System.Windows.Forms.Label();
            this.tbKupacMaticniBroj = new System.Windows.Forms.TextBox();
            this.lbIIznosSaPdv = new System.Windows.Forms.Label();
            this.tbIznosSaPDV = new System.Windows.Forms.TextBox();
            this.tbSumaUplata = new System.Windows.Forms.TextBox();
            this.lblSumaUplata = new System.Windows.Forms.Label();
            this.tbInicijalnoUplaceno = new System.Windows.Forms.TextBox();
            this.lblInicijalnoUplaceno = new System.Windows.Forms.Label();
            this.tbBrojRata = new System.Windows.Forms.TextBox();
            this.lblBrojRata = new System.Windows.Forms.Label();
            this.tbPreostaloZaUplatu = new System.Windows.Forms.TextBox();
            this.lblPreostaloZaUplatu = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.tbStatus = new System.Windows.Forms.TextBox();
            this.dgvRate = new System.Windows.Forms.DataGridView();
            this.tbUplaceno = new System.Windows.Forms.TextBox();
            this.lblUplaceno = new System.Windows.Forms.Label();
            this.tbIznosRate = new System.Windows.Forms.TextBox();
            this.lblIznosRate = new System.Windows.Forms.Label();
            this.lblRokPlacanja = new System.Windows.Forms.Label();
            this.dtpRokPlacanja = new System.Windows.Forms.DateTimePicker();
            this.lblDatumUplate = new System.Windows.Forms.Label();
            this.dtpDatumUplate = new System.Windows.Forms.DateTimePicker();
            this.lblUgovorRataNapomena = new System.Windows.Forms.Label();
            this.tbUgovorRataNapomena = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnZakljuciUgovor = new System.Windows.Forms.Button();
            this.tbBrojRate = new System.Windows.Forms.TextBox();
            this.lblBrojRate = new System.Windows.Forms.Label();
            this.btnPreuzmiIznos = new System.Windows.Forms.Button();
            this.gbRate = new System.Windows.Forms.GroupBox();
            this.rbSviUgovori = new System.Windows.Forms.RadioButton();
            this.rbRealizovani = new System.Windows.Forms.RadioButton();
            this.rbNerealizovani = new System.Windows.Forms.RadioButton();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrijave)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRate)).BeginInit();
            this.gbRate.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.MinimumSize = new System.Drawing.Size(1073, 659);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1073, 659);
            this.tabControl1.TabIndex = 26;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            this.tabControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tabControl1_KeyDown);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.rbNerealizovani);
            this.tabPage1.Controls.Add(this.rbRealizovani);
            this.tabPage1.Controls.Add(this.rbSviUgovori);
            this.tabPage1.Controls.Add(this.btnReload);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.textBox2);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.dgvPrijave);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1065, 630);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Pregled";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnReload
            // 
            this.btnReload.Image = global::ServisDB.Properties.Resources.reload__1_;
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
            // dgvPrijave
            // 
            this.dgvPrijave.AllowUserToAddRows = false;
            this.dgvPrijave.AllowUserToDeleteRows = false;
            this.dgvPrijave.AllowUserToOrderColumns = true;
            this.dgvPrijave.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPrijave.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrijave.Location = new System.Drawing.Point(3, 29);
            this.dgvPrijave.Name = "dgvPrijave";
            this.dgvPrijave.ReadOnly = true;
            this.dgvPrijave.RowHeadersVisible = false;
            this.dgvPrijave.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPrijave.Size = new System.Drawing.Size(1059, 598);
            this.dgvPrijave.TabIndex = 0;
            this.dgvPrijave.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dgvPrijave.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataGridView1_RowPrePaint);
            this.dgvPrijave.SelectionChanged += new System.EventHandler(this.dgvPrijave_SelectionChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gbRate);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.dgvRate);
            this.tabPage2.Controls.Add(this.tbStatus);
            this.tabPage2.Controls.Add(this.lblStatus);
            this.tabPage2.Controls.Add(this.tbPreostaloZaUplatu);
            this.tabPage2.Controls.Add(this.lblPreostaloZaUplatu);
            this.tabPage2.Controls.Add(this.tbBrojRata);
            this.tabPage2.Controls.Add(this.lblBrojRata);
            this.tabPage2.Controls.Add(this.tbInicijalnoUplaceno);
            this.tabPage2.Controls.Add(this.lblInicijalnoUplaceno);
            this.tabPage2.Controls.Add(this.tbSumaUplata);
            this.tabPage2.Controls.Add(this.lblSumaUplata);
            this.tabPage2.Controls.Add(this.tbIznosSaPDV);
            this.tabPage2.Controls.Add(this.lbIIznosSaPdv);
            this.tabPage2.Controls.Add(this.lblKupacMaticniBroj);
            this.tabPage2.Controls.Add(this.tbKupacMaticniBroj);
            this.tabPage2.Controls.Add(this.lblKupacBrojLk);
            this.tabPage2.Controls.Add(this.tbKupacBrojLk);
            this.tabPage2.Controls.Add(this.btnKupacClear);
            this.tabPage2.Controls.Add(this.tbKupacSifra);
            this.tabPage2.Controls.Add(this.lblBrojRacuna);
            this.tabPage2.Controls.Add(this.tbBrojRacuna);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Controls.Add(this.lblAdresa);
            this.tabPage2.Controls.Add(this.tbAdresa);
            this.tabPage2.Controls.Add(this.btnPartneri);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.lblRadnik);
            this.tabPage2.Controls.Add(this.lblnapomena);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.tbRadnik);
            this.tabPage2.Controls.Add(this.tbNapomena);
            this.tabPage2.Controls.Add(this.tbKupacaTelefon);
            this.tabPage2.Controls.Add(this.tbKupac);
            this.tabPage2.Controls.Add(this.dtpDatum);
            this.tabPage2.Controls.Add(this.tbRedniBroj);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1065, 630);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Unos [F2]";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // btnKupacClear
            // 
            this.btnKupacClear.Location = new System.Drawing.Point(478, 57);
            this.btnKupacClear.Name = "btnKupacClear";
            this.btnKupacClear.Size = new System.Drawing.Size(22, 23);
            this.btnKupacClear.TabIndex = 83;
            this.btnKupacClear.Text = "x";
            this.btnKupacClear.UseVisualStyleBackColor = true;
            this.btnKupacClear.Click += new System.EventHandler(this.btnKupacClear_Click);
            // 
            // tbKupacSifra
            // 
            this.tbKupacSifra.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbKupacSifra.Location = new System.Drawing.Point(125, 58);
            this.tbKupacSifra.Name = "tbKupacSifra";
            this.tbKupacSifra.ReadOnly = true;
            this.tbKupacSifra.Size = new System.Drawing.Size(52, 22);
            this.tbKupacSifra.TabIndex = 82;
            // 
            // lblBrojRacuna
            // 
            this.lblBrojRacuna.AutoSize = true;
            this.lblBrojRacuna.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrojRacuna.Location = new System.Drawing.Point(521, 11);
            this.lblBrojRacuna.Name = "lblBrojRacuna";
            this.lblBrojRacuna.Size = new System.Drawing.Size(71, 16);
            this.lblBrojRacuna.TabIndex = 74;
            this.lblBrojRacuna.Text = "Br. računa:";
            // 
            // tbBrojRacuna
            // 
            this.tbBrojRacuna.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBrojRacuna.Location = new System.Drawing.Point(653, 8);
            this.tbBrojRacuna.Name = "tbBrojRacuna";
            this.tbBrojRacuna.Size = new System.Drawing.Size(100, 22);
            this.tbBrojRacuna.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel2.Location = new System.Drawing.Point(13, 275);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1026, 1);
            this.panel2.TabIndex = 61;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Location = new System.Drawing.Point(8, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1028, 1);
            this.panel1.TabIndex = 60;
            // 
            // lblAdresa
            // 
            this.lblAdresa.AutoSize = true;
            this.lblAdresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdresa.Location = new System.Drawing.Point(8, 91);
            this.lblAdresa.Name = "lblAdresa";
            this.lblAdresa.Size = new System.Drawing.Size(55, 16);
            this.lblAdresa.TabIndex = 58;
            this.lblAdresa.Text = "Adresa:";
            // 
            // tbAdresa
            // 
            this.tbAdresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAdresa.Location = new System.Drawing.Point(126, 93);
            this.tbAdresa.Multiline = true;
            this.tbAdresa.Name = "tbAdresa";
            this.tbAdresa.Size = new System.Drawing.Size(374, 52);
            this.tbAdresa.TabIndex = 2;
            // 
            // btnPartneri
            // 
            this.btnPartneri.Location = new System.Drawing.Point(435, 57);
            this.btnPartneri.Name = "btnPartneri";
            this.btnPartneri.Size = new System.Drawing.Size(37, 23);
            this.btnPartneri.TabIndex = 53;
            this.btnPartneri.Text = "...";
            this.btnPartneri.UseVisualStyleBackColor = true;
            this.btnPartneri.Click += new System.EventHandler(this.btnPartneri_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(516, 584);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(135, 36);
            this.button2.TabIndex = 51;
            this.button2.Text = "Odustani [ESC]";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(366, 584);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 36);
            this.button1.TabIndex = 50;
            this.button1.Text = "Sačuvaj [F1]";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblRadnik
            // 
            this.lblRadnik.AutoSize = true;
            this.lblRadnik.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRadnik.Location = new System.Drawing.Point(522, 231);
            this.lblRadnik.Name = "lblRadnik";
            this.lblRadnik.Size = new System.Drawing.Size(54, 16);
            this.lblRadnik.TabIndex = 48;
            this.lblRadnik.Text = "Radnik:";
            // 
            // lblnapomena
            // 
            this.lblnapomena.AutoSize = true;
            this.lblnapomena.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnapomena.Location = new System.Drawing.Point(521, 166);
            this.lblnapomena.Name = "lblnapomena";
            this.lblnapomena.Size = new System.Drawing.Size(79, 16);
            this.lblnapomena.TabIndex = 47;
            this.lblnapomena.Text = "Napomena:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(297, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 16);
            this.label8.TabIndex = 45;
            this.label8.Text = "Datum:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 16);
            this.label4.TabIndex = 41;
            this.label4.Text = "Kontakt telefon:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 16);
            this.label3.TabIndex = 40;
            this.label3.Text = "Kupac:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 16);
            this.label1.TabIndex = 38;
            this.label1.Text = "Redni broj:";
            // 
            // tbRadnik
            // 
            this.tbRadnik.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRadnik.Location = new System.Drawing.Point(653, 228);
            this.tbRadnik.Name = "tbRadnik";
            this.tbRadnik.Size = new System.Drawing.Size(225, 22);
            this.tbRadnik.TabIndex = 14;
            // 
            // tbNapomena
            // 
            this.tbNapomena.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNapomena.Location = new System.Drawing.Point(653, 163);
            this.tbNapomena.Multiline = true;
            this.tbNapomena.Name = "tbNapomena";
            this.tbNapomena.Size = new System.Drawing.Size(367, 52);
            this.tbNapomena.TabIndex = 13;
            // 
            // tbKupacaTelefon
            // 
            this.tbKupacaTelefon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbKupacaTelefon.Location = new System.Drawing.Point(125, 158);
            this.tbKupacaTelefon.Name = "tbKupacaTelefon";
            this.tbKupacaTelefon.Size = new System.Drawing.Size(266, 22);
            this.tbKupacaTelefon.TabIndex = 3;
            // 
            // tbKupac
            // 
            this.tbKupac.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbKupac.Location = new System.Drawing.Point(183, 58);
            this.tbKupac.Name = "tbKupac";
            this.tbKupac.Size = new System.Drawing.Size(246, 22);
            this.tbKupac.TabIndex = 1;
            // 
            // dtpDatum
            // 
            this.dtpDatum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDatum.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDatum.Location = new System.Drawing.Point(363, 9);
            this.dtpDatum.Name = "dtpDatum";
            this.dtpDatum.Size = new System.Drawing.Size(137, 22);
            this.dtpDatum.TabIndex = 0;
            // 
            // tbRedniBroj
            // 
            this.tbRedniBroj.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRedniBroj.Location = new System.Drawing.Point(125, 8);
            this.tbRedniBroj.Name = "tbRedniBroj";
            this.tbRedniBroj.ReadOnly = true;
            this.tbRedniBroj.Size = new System.Drawing.Size(100, 22);
            this.tbRedniBroj.TabIndex = 26;
            this.tbRedniBroj.Text = "AUTO";
            // 
            // btnBrisanje
            // 
            this.btnBrisanje.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrisanje.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrisanje.Location = new System.Drawing.Point(1079, 69);
            this.btnBrisanje.Name = "btnBrisanje";
            this.btnBrisanje.Size = new System.Drawing.Size(101, 36);
            this.btnBrisanje.TabIndex = 28;
            this.btnBrisanje.Text = "Brisanje [F5]";
            this.btnBrisanje.UseVisualStyleBackColor = true;
            this.btnBrisanje.Click += new System.EventHandler(this.btnBrisanje_Click);
            // 
            // btnStampa
            // 
            this.btnStampa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStampa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStampa.Location = new System.Drawing.Point(1079, 26);
            this.btnStampa.Name = "btnStampa";
            this.btnStampa.Size = new System.Drawing.Size(101, 37);
            this.btnStampa.TabIndex = 27;
            this.btnStampa.Text = "Štampa [F4]";
            this.btnStampa.UseVisualStyleBackColor = true;
            this.btnStampa.Click += new System.EventHandler(this.btnStampa_Click);
            // 
            // lblKupacBrojLk
            // 
            this.lblKupacBrojLk.AutoSize = true;
            this.lblKupacBrojLk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKupacBrojLk.Location = new System.Drawing.Point(8, 196);
            this.lblKupacBrojLk.Name = "lblKupacBrojLk";
            this.lblKupacBrojLk.Size = new System.Drawing.Size(53, 16);
            this.lblKupacBrojLk.TabIndex = 89;
            this.lblKupacBrojLk.Text = "Broj LK:";
            // 
            // tbKupacBrojLk
            // 
            this.tbKupacBrojLk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbKupacBrojLk.Location = new System.Drawing.Point(126, 193);
            this.tbKupacBrojLk.Name = "tbKupacBrojLk";
            this.tbKupacBrojLk.Size = new System.Drawing.Size(167, 22);
            this.tbKupacBrojLk.TabIndex = 87;
            // 
            // lblKupacMaticniBroj
            // 
            this.lblKupacMaticniBroj.AutoSize = true;
            this.lblKupacMaticniBroj.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKupacMaticniBroj.Location = new System.Drawing.Point(8, 231);
            this.lblKupacMaticniBroj.Name = "lblKupacMaticniBroj";
            this.lblKupacMaticniBroj.Size = new System.Drawing.Size(48, 16);
            this.lblKupacMaticniBroj.TabIndex = 91;
            this.lblKupacMaticniBroj.Text = "JMBG:";
            // 
            // tbKupacMaticniBroj
            // 
            this.tbKupacMaticniBroj.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbKupacMaticniBroj.Location = new System.Drawing.Point(127, 228);
            this.tbKupacMaticniBroj.Name = "tbKupacMaticniBroj";
            this.tbKupacMaticniBroj.Size = new System.Drawing.Size(166, 22);
            this.tbKupacMaticniBroj.TabIndex = 90;
            // 
            // lbIIznosSaPdv
            // 
            this.lbIIznosSaPdv.AutoSize = true;
            this.lbIIznosSaPdv.Location = new System.Drawing.Point(522, 60);
            this.lbIIznosSaPdv.Name = "lbIIznosSaPdv";
            this.lbIIznosSaPdv.Size = new System.Drawing.Size(95, 16);
            this.lbIIznosSaPdv.TabIndex = 92;
            this.lbIIznosSaPdv.Text = "Iznos ugovora:";
            // 
            // tbIznosSaPDV
            // 
            this.tbIznosSaPDV.Location = new System.Drawing.Point(653, 58);
            this.tbIznosSaPDV.Name = "tbIznosSaPDV";
            this.tbIznosSaPDV.Size = new System.Drawing.Size(100, 22);
            this.tbIznosSaPDV.TabIndex = 93;
            this.tbIznosSaPDV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbIznosSaPDV.TextChanged += new System.EventHandler(this.tbIznosSaPDV_TextChanged);
            // 
            // tbSumaUplata
            // 
            this.tbSumaUplata.Location = new System.Drawing.Point(653, 93);
            this.tbSumaUplata.Name = "tbSumaUplata";
            this.tbSumaUplata.ReadOnly = true;
            this.tbSumaUplata.Size = new System.Drawing.Size(100, 22);
            this.tbSumaUplata.TabIndex = 95;
            this.tbSumaUplata.Text = "0";
            this.tbSumaUplata.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSumaUplata
            // 
            this.lblSumaUplata.AutoSize = true;
            this.lblSumaUplata.Location = new System.Drawing.Point(522, 96);
            this.lblSumaUplata.Name = "lblSumaUplata";
            this.lblSumaUplata.Size = new System.Drawing.Size(86, 16);
            this.lblSumaUplata.TabIndex = 94;
            this.lblSumaUplata.Text = "Suma uplata:";
            // 
            // tbInicijalnoUplaceno
            // 
            this.tbInicijalnoUplaceno.Location = new System.Drawing.Point(920, 88);
            this.tbInicijalnoUplaceno.Name = "tbInicijalnoUplaceno";
            this.tbInicijalnoUplaceno.Size = new System.Drawing.Size(100, 22);
            this.tbInicijalnoUplaceno.TabIndex = 97;
            this.tbInicijalnoUplaceno.Text = "0";
            this.tbInicijalnoUplaceno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblInicijalnoUplaceno
            // 
            this.lblInicijalnoUplaceno.AutoSize = true;
            this.lblInicijalnoUplaceno.Location = new System.Drawing.Point(776, 91);
            this.lblInicijalnoUplaceno.Name = "lblInicijalnoUplaceno";
            this.lblInicijalnoUplaceno.Size = new System.Drawing.Size(122, 16);
            this.lblInicijalnoUplaceno.TabIndex = 96;
            this.lblInicijalnoUplaceno.Text = "Inicijalno uplaćeno:";
            // 
            // tbBrojRata
            // 
            this.tbBrojRata.Location = new System.Drawing.Point(920, 54);
            this.tbBrojRata.Name = "tbBrojRata";
            this.tbBrojRata.Size = new System.Drawing.Size(100, 22);
            this.tbBrojRata.TabIndex = 99;
            this.tbBrojRata.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbBrojRata.TextChanged += new System.EventHandler(this.tbBrojRata_TextChanged);
            // 
            // lblBrojRata
            // 
            this.lblBrojRata.AutoSize = true;
            this.lblBrojRata.Location = new System.Drawing.Point(776, 57);
            this.lblBrojRata.Name = "lblBrojRata";
            this.lblBrojRata.Size = new System.Drawing.Size(61, 16);
            this.lblBrojRata.TabIndex = 98;
            this.lblBrojRata.Text = "Broj rata:";
            // 
            // tbPreostaloZaUplatu
            // 
            this.tbPreostaloZaUplatu.Location = new System.Drawing.Point(653, 128);
            this.tbPreostaloZaUplatu.Name = "tbPreostaloZaUplatu";
            this.tbPreostaloZaUplatu.ReadOnly = true;
            this.tbPreostaloZaUplatu.Size = new System.Drawing.Size(100, 22);
            this.tbPreostaloZaUplatu.TabIndex = 101;
            this.tbPreostaloZaUplatu.Text = "0";
            this.tbPreostaloZaUplatu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPreostaloZaUplatu
            // 
            this.lblPreostaloZaUplatu.AutoSize = true;
            this.lblPreostaloZaUplatu.Location = new System.Drawing.Point(521, 131);
            this.lblPreostaloZaUplatu.Name = "lblPreostaloZaUplatu";
            this.lblPreostaloZaUplatu.Size = new System.Drawing.Size(125, 16);
            this.lblPreostaloZaUplatu.TabIndex = 100;
            this.lblPreostaloZaUplatu.Text = "Preostalo za uplatu:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(776, 14);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(48, 16);
            this.lblStatus.TabIndex = 102;
            this.lblStatus.Text = "Status:";
            // 
            // tbStatus
            // 
            this.tbStatus.Location = new System.Drawing.Point(920, 8);
            this.tbStatus.Name = "tbStatus";
            this.tbStatus.ReadOnly = true;
            this.tbStatus.Size = new System.Drawing.Size(22, 22);
            this.tbStatus.TabIndex = 103;
            this.tbStatus.Text = "E";
            // 
            // dgvRate
            // 
            this.dgvRate.AllowUserToAddRows = false;
            this.dgvRate.AllowUserToDeleteRows = false;
            this.dgvRate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRate.Location = new System.Drawing.Point(12, 315);
            this.dgvRate.MultiSelect = false;
            this.dgvRate.Name = "dgvRate";
            this.dgvRate.ReadOnly = true;
            this.dgvRate.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRate.Size = new System.Drawing.Size(488, 240);
            this.dgvRate.TabIndex = 104;
            this.dgvRate.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvRate_RowPrePaint);
            this.dgvRate.SelectionChanged += new System.EventHandler(this.dgvRate_SelectionChanged);
            // 
            // tbUplaceno
            // 
            this.tbUplaceno.Location = new System.Drawing.Point(137, 81);
            this.tbUplaceno.Name = "tbUplaceno";
            this.tbUplaceno.ReadOnly = true;
            this.tbUplaceno.Size = new System.Drawing.Size(100, 22);
            this.tbUplaceno.TabIndex = 108;
            this.tbUplaceno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblUplaceno
            // 
            this.lblUplaceno.AutoSize = true;
            this.lblUplaceno.Location = new System.Drawing.Point(6, 84);
            this.lblUplaceno.Name = "lblUplaceno";
            this.lblUplaceno.Size = new System.Drawing.Size(70, 16);
            this.lblUplaceno.TabIndex = 107;
            this.lblUplaceno.Text = "Uplaćeno:";
            // 
            // tbIznosRate
            // 
            this.tbIznosRate.Location = new System.Drawing.Point(137, 50);
            this.tbIznosRate.Name = "tbIznosRate";
            this.tbIznosRate.ReadOnly = true;
            this.tbIznosRate.Size = new System.Drawing.Size(100, 22);
            this.tbIznosRate.TabIndex = 106;
            this.tbIznosRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblIznosRate
            // 
            this.lblIznosRate.AutoSize = true;
            this.lblIznosRate.Location = new System.Drawing.Point(6, 52);
            this.lblIznosRate.Name = "lblIznosRate";
            this.lblIznosRate.Size = new System.Drawing.Size(68, 16);
            this.lblIznosRate.TabIndex = 105;
            this.lblIznosRate.Text = "Iznos rate:";
            // 
            // lblRokPlacanja
            // 
            this.lblRokPlacanja.AutoSize = true;
            this.lblRokPlacanja.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRokPlacanja.Location = new System.Drawing.Point(260, 52);
            this.lblRokPlacanja.Name = "lblRokPlacanja";
            this.lblRokPlacanja.Size = new System.Drawing.Size(91, 16);
            this.lblRokPlacanja.TabIndex = 110;
            this.lblRokPlacanja.Text = "Rok plaćanja:";
            // 
            // dtpRokPlacanja
            // 
            this.dtpRokPlacanja.Enabled = false;
            this.dtpRokPlacanja.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpRokPlacanja.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpRokPlacanja.Location = new System.Drawing.Point(388, 48);
            this.dtpRokPlacanja.Name = "dtpRokPlacanja";
            this.dtpRokPlacanja.Size = new System.Drawing.Size(115, 22);
            this.dtpRokPlacanja.TabIndex = 109;
            // 
            // lblDatumUplate
            // 
            this.lblDatumUplate.AutoSize = true;
            this.lblDatumUplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatumUplate.Location = new System.Drawing.Point(260, 84);
            this.lblDatumUplate.Name = "lblDatumUplate";
            this.lblDatumUplate.Size = new System.Drawing.Size(90, 16);
            this.lblDatumUplate.TabIndex = 112;
            this.lblDatumUplate.Text = "Datum uplate:";
            // 
            // dtpDatumUplate
            // 
            this.dtpDatumUplate.Enabled = false;
            this.dtpDatumUplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDatumUplate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDatumUplate.Location = new System.Drawing.Point(386, 79);
            this.dtpDatumUplate.Name = "dtpDatumUplate";
            this.dtpDatumUplate.ShowCheckBox = true;
            this.dtpDatumUplate.Size = new System.Drawing.Size(116, 22);
            this.dtpDatumUplate.TabIndex = 111;
            this.dtpDatumUplate.ValueChanged += new System.EventHandler(this.dtpDatumUplate_ValueChanged);
            // 
            // lblUgovorRataNapomena
            // 
            this.lblUgovorRataNapomena.AutoSize = true;
            this.lblUgovorRataNapomena.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUgovorRataNapomena.Location = new System.Drawing.Point(6, 127);
            this.lblUgovorRataNapomena.Name = "lblUgovorRataNapomena";
            this.lblUgovorRataNapomena.Size = new System.Drawing.Size(79, 16);
            this.lblUgovorRataNapomena.TabIndex = 114;
            this.lblUgovorRataNapomena.Text = "Napomena:";
            // 
            // tbUgovorRataNapomena
            // 
            this.tbUgovorRataNapomena.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUgovorRataNapomena.Location = new System.Drawing.Point(137, 124);
            this.tbUgovorRataNapomena.Multiline = true;
            this.tbUgovorRataNapomena.Name = "tbUgovorRataNapomena";
            this.tbUgovorRataNapomena.ReadOnly = true;
            this.tbUgovorRataNapomena.Size = new System.Drawing.Size(367, 48);
            this.tbUgovorRataNapomena.TabIndex = 113;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 294);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 18);
            this.label2.TabIndex = 116;
            this.label2.Text = "Rate:";
            // 
            // btnZakljuciUgovor
            // 
            this.btnZakljuciUgovor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnZakljuciUgovor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZakljuciUgovor.Location = new System.Drawing.Point(1079, 116);
            this.btnZakljuciUgovor.Name = "btnZakljuciUgovor";
            this.btnZakljuciUgovor.Size = new System.Drawing.Size(101, 52);
            this.btnZakljuciUgovor.TabIndex = 29;
            this.btnZakljuciUgovor.Text = "Zaključenje [F6]";
            this.btnZakljuciUgovor.UseVisualStyleBackColor = true;
            this.btnZakljuciUgovor.Click += new System.EventHandler(this.btnZakljuciUgovor_Click);
            // 
            // tbBrojRate
            // 
            this.tbBrojRate.Location = new System.Drawing.Point(137, 19);
            this.tbBrojRate.Name = "tbBrojRate";
            this.tbBrojRate.ReadOnly = true;
            this.tbBrojRate.Size = new System.Drawing.Size(100, 22);
            this.tbBrojRate.TabIndex = 117;
            this.tbBrojRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBrojRate
            // 
            this.lblBrojRate.AutoSize = true;
            this.lblBrojRate.Location = new System.Drawing.Point(6, 22);
            this.lblBrojRate.Name = "lblBrojRate";
            this.lblBrojRate.Size = new System.Drawing.Size(61, 16);
            this.lblBrojRate.TabIndex = 118;
            this.lblBrojRate.Text = "Broj rate:";
            // 
            // btnPreuzmiIznos
            // 
            this.btnPreuzmiIznos.Location = new System.Drawing.Point(97, 81);
            this.btnPreuzmiIznos.Name = "btnPreuzmiIznos";
            this.btnPreuzmiIznos.Size = new System.Drawing.Size(34, 23);
            this.btnPreuzmiIznos.TabIndex = 119;
            this.btnPreuzmiIznos.Text = "=>";
            this.btnPreuzmiIznos.UseVisualStyleBackColor = true;
            this.btnPreuzmiIznos.Visible = false;
            this.btnPreuzmiIznos.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // gbRate
            // 
            this.gbRate.Controls.Add(this.lblBrojRate);
            this.gbRate.Controls.Add(this.btnPreuzmiIznos);
            this.gbRate.Controls.Add(this.lblIznosRate);
            this.gbRate.Controls.Add(this.tbIznosRate);
            this.gbRate.Controls.Add(this.tbBrojRate);
            this.gbRate.Controls.Add(this.lblUplaceno);
            this.gbRate.Controls.Add(this.tbUplaceno);
            this.gbRate.Controls.Add(this.lblUgovorRataNapomena);
            this.gbRate.Controls.Add(this.dtpRokPlacanja);
            this.gbRate.Controls.Add(this.tbUgovorRataNapomena);
            this.gbRate.Controls.Add(this.lblRokPlacanja);
            this.gbRate.Controls.Add(this.lblDatumUplate);
            this.gbRate.Controls.Add(this.dtpDatumUplate);
            this.gbRate.Location = new System.Drawing.Point(516, 305);
            this.gbRate.Name = "gbRate";
            this.gbRate.Size = new System.Drawing.Size(522, 250);
            this.gbRate.TabIndex = 120;
            this.gbRate.TabStop = false;
            // 
            // rbSviUgovori
            // 
            this.rbSviUgovori.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbSviUgovori.AutoSize = true;
            this.rbSviUgovori.Checked = true;
            this.rbSviUgovori.Location = new System.Drawing.Point(914, 6);
            this.rbSviUgovori.Name = "rbSviUgovori";
            this.rbSviUgovori.Size = new System.Drawing.Size(93, 20);
            this.rbSviUgovori.TabIndex = 5;
            this.rbSviUgovori.TabStop = true;
            this.rbSviUgovori.Text = "Svi ugovori";
            this.rbSviUgovori.UseVisualStyleBackColor = true;
            this.rbSviUgovori.Click += new System.EventHandler(this.rbSviUgovori_Click);
            // 
            // rbRealizovani
            // 
            this.rbRealizovani.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbRealizovani.AutoSize = true;
            this.rbRealizovani.Location = new System.Drawing.Point(696, 4);
            this.rbRealizovani.Name = "rbRealizovani";
            this.rbRealizovani.Size = new System.Drawing.Size(97, 20);
            this.rbRealizovani.TabIndex = 6;
            this.rbRealizovani.Text = "Realizovani";
            this.rbRealizovani.UseVisualStyleBackColor = true;
            this.rbRealizovani.Click += new System.EventHandler(this.rbRealizovani_Click);
            // 
            // rbNerealizovani
            // 
            this.rbNerealizovani.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbNerealizovani.AutoSize = true;
            this.rbNerealizovani.Location = new System.Drawing.Point(799, 5);
            this.rbNerealizovani.Name = "rbNerealizovani";
            this.rbNerealizovani.Size = new System.Drawing.Size(109, 20);
            this.rbNerealizovani.TabIndex = 7;
            this.rbNerealizovani.Text = "Nerealizovani";
            this.rbNerealizovani.UseVisualStyleBackColor = true;
            this.rbNerealizovani.Click += new System.EventHandler(this.rbNerealizovani_Click);
            // 
            // FormUgovor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1185, 659);
            this.Controls.Add(this.btnZakljuciUgovor);
            this.Controls.Add(this.btnBrisanje);
            this.Controls.Add(this.btnStampa);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormUgovor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ugovori o odloženom plaćanju";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrijave)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRate)).EndInit();
            this.gbRate.ResumeLayout(false);
            this.gbRate.PerformLayout();
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Label lblRadnik;
    private System.Windows.Forms.Label lblnapomena;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox tbRadnik;
    private System.Windows.Forms.TextBox tbNapomena;
    private System.Windows.Forms.TextBox tbKupacaTelefon;
    private System.Windows.Forms.TextBox tbKupac;
    private System.Windows.Forms.DateTimePicker dtpDatum;
    private System.Windows.Forms.TextBox tbRedniBroj;
    private System.Windows.Forms.DataGridView dgvPrijave;
    private System.Windows.Forms.Button btnBrisanje;
    private System.Windows.Forms.Button btnStampa;
    private System.Windows.Forms.TextBox textBox2;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.Timer tmrDelay;
    private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button btnPartneri;
        private System.Windows.Forms.Label lblAdresa;
        private System.Windows.Forms.TextBox tbAdresa;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblBrojRacuna;
        private System.Windows.Forms.TextBox tbBrojRacuna;
        private System.Windows.Forms.TextBox tbKupacSifra;
        private System.Windows.Forms.Button btnKupacClear;
        private System.Windows.Forms.Label lblKupacMaticniBroj;
        private System.Windows.Forms.TextBox tbKupacMaticniBroj;
        private System.Windows.Forms.Label lblKupacBrojLk;
        private System.Windows.Forms.TextBox tbKupacBrojLk;
        private System.Windows.Forms.TextBox tbPreostaloZaUplatu;
        private System.Windows.Forms.Label lblPreostaloZaUplatu;
        private System.Windows.Forms.TextBox tbBrojRata;
        private System.Windows.Forms.Label lblBrojRata;
        private System.Windows.Forms.TextBox tbInicijalnoUplaceno;
        private System.Windows.Forms.Label lblInicijalnoUplaceno;
        private System.Windows.Forms.TextBox tbSumaUplata;
        private System.Windows.Forms.Label lblSumaUplata;
        private System.Windows.Forms.TextBox tbIznosSaPDV;
        private System.Windows.Forms.Label lbIIznosSaPdv;
        private System.Windows.Forms.TextBox tbStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblDatumUplate;
        private System.Windows.Forms.DateTimePicker dtpDatumUplate;
        private System.Windows.Forms.Label lblRokPlacanja;
        private System.Windows.Forms.DateTimePicker dtpRokPlacanja;
        private System.Windows.Forms.TextBox tbUplaceno;
        private System.Windows.Forms.Label lblUplaceno;
        private System.Windows.Forms.TextBox tbIznosRate;
        private System.Windows.Forms.Label lblIznosRate;
        private System.Windows.Forms.DataGridView dgvRate;
        private System.Windows.Forms.Label lblUgovorRataNapomena;
        private System.Windows.Forms.TextBox tbUgovorRataNapomena;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnZakljuciUgovor;
        private System.Windows.Forms.TextBox tbBrojRate;
        private System.Windows.Forms.Label lblBrojRate;
        private System.Windows.Forms.Button btnPreuzmiIznos;
        private System.Windows.Forms.GroupBox gbRate;
        private System.Windows.Forms.RadioButton rbNerealizovani;
        private System.Windows.Forms.RadioButton rbRealizovani;
        private System.Windows.Forms.RadioButton rbSviUgovori;
    }
}

