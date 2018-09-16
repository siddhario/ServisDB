namespace ServisDB.Forme
{
  partial class frmServisnaPrijava
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
            this.label13 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dgvPrijave = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.tbServiserPrimio = new System.Windows.Forms.TextBox();
            this.btnKupacClear = new System.Windows.Forms.Button();
            this.tbKupacSifra = new System.Windows.Forms.TextBox();
            this.lblBrojRacuna = new System.Windows.Forms.Label();
            this.tbBrojRacuna = new System.Windows.Forms.TextBox();
            this.lblPredmet = new System.Windows.Forms.Label();
            this.tbPredmet = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblAdresa = new System.Windows.Forms.Label();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.tbAdresa = new System.Windows.Forms.TextBox();
            this.btnPartneri = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblServiser = new System.Windows.Forms.Label();
            this.lblnapomenaServisera = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbServiser = new System.Windows.Forms.TextBox();
            this.tbNapomenaServisera = new System.Windows.Forms.TextBox();
            this.tbDodatnaOprema = new System.Windows.Forms.TextBox();
            this.tbSerijskiBroj = new System.Windows.Forms.TextBox();
            this.tbModel = new System.Windows.Forms.TextBox();
            this.tbKupacaTelefon = new System.Windows.Forms.TextBox();
            this.tbKupac = new System.Windows.Forms.TextBox();
            this.dtpDatum = new System.Windows.Forms.DateTimePicker();
            this.tbRedniBroj = new System.Windows.Forms.TextBox();
            this.btnBrisanje = new System.Windows.Forms.Button();
            this.btnStampa = new System.Windows.Forms.Button();
            this.tmrDelay = new System.Windows.Forms.Timer(this.components);
            this.btnReload = new System.Windows.Forms.Button();
            this.dtpZavrseno = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.tbDobavljac = new System.Windows.Forms.TextBox();
            this.lblDobavljac = new System.Windows.Forms.Label();
            this.btnDobavljaci = new System.Windows.Forms.Button();
            this.tbDobavljacSifra = new System.Windows.Forms.TextBox();
            this.btnDobavljacClear = new System.Windows.Forms.Button();
            this.dtpDatumVracanja = new System.Windows.Forms.DateTimePicker();
            this.lblDatumVracanja = new System.Windows.Forms.Label();
            this.dtpPoslatMejlDobavljacu = new System.Windows.Forms.DateTimePicker();
            this.lblPoslatMejlDobavljacu = new System.Windows.Forms.Label();
            this.btnDpDatumVracanja = new System.Windows.Forms.Button();
            this.btnDpPoslatMejlDobavljacu = new System.Windows.Forms.Button();
            this.tbBrojNaloga = new System.Windows.Forms.TextBox();
            this.lblBrojNaloga = new System.Windows.Forms.Label();
            this.tbBrojGarantnogLista = new System.Windows.Forms.TextBox();
            this.lblBrojGarantnogLista = new System.Windows.Forms.Label();
            this.tbGarantniRok = new System.Windows.Forms.TextBox();
            this.lblGarantniRok = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrijave)).BeginInit();
            this.tabPage2.SuspendLayout();
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
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1073, 741);
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
            this.tabPage1.Controls.Add(this.dgvPrijave);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1065, 712);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Pregled";
            this.tabPage1.UseVisualStyleBackColor = true;
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
            this.dgvPrijave.Size = new System.Drawing.Size(1059, 680);
            this.dgvPrijave.TabIndex = 0;
            this.dgvPrijave.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dgvPrijave.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataGridView1_RowPrePaint);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button4);
            this.tabPage2.Controls.Add(this.btnDpPoslatMejlDobavljacu);
            this.tabPage2.Controls.Add(this.btnDpDatumVracanja);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.tbServiserPrimio);
            this.tabPage2.Controls.Add(this.btnDobavljacClear);
            this.tabPage2.Controls.Add(this.btnKupacClear);
            this.tabPage2.Controls.Add(this.tbKupacSifra);
            this.tabPage2.Controls.Add(this.tbDobavljacSifra);
            this.tabPage2.Controls.Add(this.lblBrojNaloga);
            this.tabPage2.Controls.Add(this.tbBrojNaloga);
            this.tabPage2.Controls.Add(this.lblGarantniRok);
            this.tabPage2.Controls.Add(this.tbGarantniRok);
            this.tabPage2.Controls.Add(this.lblPoslatMejlDobavljacu);
            this.tabPage2.Controls.Add(this.dtpPoslatMejlDobavljacu);
            this.tabPage2.Controls.Add(this.lblBrojRacuna);
            this.tabPage2.Controls.Add(this.tbBrojRacuna);
            this.tabPage2.Controls.Add(this.btnDobavljaci);
            this.tabPage2.Controls.Add(this.lblDobavljac);
            this.tabPage2.Controls.Add(this.tbDobavljac);
            this.tabPage2.Controls.Add(this.lblPredmet);
            this.tabPage2.Controls.Add(this.tbPredmet);
            this.tabPage2.Controls.Add(this.lblDatumVracanja);
            this.tabPage2.Controls.Add(this.dtpDatumVracanja);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Controls.Add(this.lblEmail);
            this.tabPage2.Controls.Add(this.lblAdresa);
            this.tabPage2.Controls.Add(this.tbEmail);
            this.tabPage2.Controls.Add(this.tbAdresa);
            this.tabPage2.Controls.Add(this.btnPartneri);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.lblServiser);
            this.tabPage2.Controls.Add(this.lblnapomenaServisera);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.lblBrojGarantnogLista);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.dtpZavrseno);
            this.tabPage2.Controls.Add(this.tbServiser);
            this.tabPage2.Controls.Add(this.tbNapomenaServisera);
            this.tabPage2.Controls.Add(this.tbDodatnaOprema);
            this.tabPage2.Controls.Add(this.tbSerijskiBroj);
            this.tabPage2.Controls.Add(this.tbModel);
            this.tabPage2.Controls.Add(this.tbKupacaTelefon);
            this.tabPage2.Controls.Add(this.tbKupac);
            this.tabPage2.Controls.Add(this.tbBrojGarantnogLista);
            this.tabPage2.Controls.Add(this.dtpDatum);
            this.tabPage2.Controls.Add(this.tbRedniBroj);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1065, 712);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Unos [F2]";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(8, 441);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 16);
            this.label9.TabIndex = 86;
            this.label9.Text = "Opremuo primio:";
            // 
            // tbServiserPrimio
            // 
            this.tbServiserPrimio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbServiserPrimio.Location = new System.Drawing.Point(126, 438);
            this.tbServiserPrimio.Name = "tbServiserPrimio";
            this.tbServiserPrimio.Size = new System.Drawing.Size(225, 22);
            this.tbServiserPrimio.TabIndex = 85;
            // 
            // btnKupacClear
            // 
            this.btnKupacClear.Location = new System.Drawing.Point(435, 57);
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
            this.lblBrojRacuna.Location = new System.Drawing.Point(513, 91);
            this.lblBrojRacuna.Name = "lblBrojRacuna";
            this.lblBrojRacuna.Size = new System.Drawing.Size(71, 16);
            this.lblBrojRacuna.TabIndex = 74;
            this.lblBrojRacuna.Text = "Br. računa:";
            // 
            // tbBrojRacuna
            // 
            this.tbBrojRacuna.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBrojRacuna.Location = new System.Drawing.Point(658, 91);
            this.tbBrojRacuna.Name = "tbBrojRacuna";
            this.tbBrojRacuna.Size = new System.Drawing.Size(152, 22);
            this.tbBrojRacuna.TabIndex = 9;
            // 
            // lblPredmet
            // 
            this.lblPredmet.AutoSize = true;
            this.lblPredmet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPredmet.Location = new System.Drawing.Point(8, 241);
            this.lblPredmet.Name = "lblPredmet";
            this.lblPredmet.Size = new System.Drawing.Size(62, 16);
            this.lblPredmet.TabIndex = 67;
            this.lblPredmet.Text = "Predmet:";
            // 
            // tbPredmet
            // 
            this.tbPredmet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPredmet.Location = new System.Drawing.Point(126, 238);
            this.tbPredmet.Multiline = true;
            this.tbPredmet.Name = "tbPredmet";
            this.tbPredmet.Size = new System.Drawing.Size(328, 77);
            this.tbPredmet.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel2.Location = new System.Drawing.Point(8, 220);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(982, 1);
            this.panel2.TabIndex = 61;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Location = new System.Drawing.Point(12, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(983, 1);
            this.panel1.TabIndex = 60;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(8, 190);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(45, 16);
            this.lblEmail.TabIndex = 59;
            this.lblEmail.Text = "Email:";
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
            // tbEmail
            // 
            this.tbEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbEmail.Location = new System.Drawing.Point(125, 187);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(225, 22);
            this.tbEmail.TabIndex = 4;
            // 
            // tbAdresa
            // 
            this.tbAdresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAdresa.Location = new System.Drawing.Point(126, 91);
            this.tbAdresa.Multiline = true;
            this.tbAdresa.Name = "tbAdresa";
            this.tbAdresa.Size = new System.Drawing.Size(327, 52);
            this.tbAdresa.TabIndex = 2;
            // 
            // btnPartneri
            // 
            this.btnPartneri.Location = new System.Drawing.Point(397, 57);
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
            this.button2.Location = new System.Drawing.Point(484, 532);
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
            this.button1.Location = new System.Drawing.Point(343, 532);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 36);
            this.button1.TabIndex = 50;
            this.button1.Text = "Sačuvaj [F1]";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblServiser
            // 
            this.lblServiser.AutoSize = true;
            this.lblServiser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServiser.Location = new System.Drawing.Point(513, 270);
            this.lblServiser.Name = "lblServiser";
            this.lblServiser.Size = new System.Drawing.Size(61, 16);
            this.lblServiser.TabIndex = 48;
            this.lblServiser.Text = "Serviser:";
            // 
            // lblnapomenaServisera
            // 
            this.lblnapomenaServisera.AutoSize = true;
            this.lblnapomenaServisera.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnapomenaServisera.Location = new System.Drawing.Point(513, 311);
            this.lblnapomenaServisera.Name = "lblnapomenaServisera";
            this.lblnapomenaServisera.Size = new System.Drawing.Size(138, 16);
            this.lblnapomenaServisera.TabIndex = 47;
            this.lblnapomenaServisera.Text = "Napomena servisera:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(259, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 16);
            this.label8.TabIndex = 45;
            this.label8.Text = "Datum:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(8, 384);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 16);
            this.label7.TabIndex = 44;
            this.label7.Text = "Dodatna oprema:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 352);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 16);
            this.label6.TabIndex = 43;
            this.label6.Text = "Ser. broj:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 324);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 16);
            this.label5.TabIndex = 42;
            this.label5.Text = "Model:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 155);
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
            // tbServiser
            // 
            this.tbServiser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbServiser.Location = new System.Drawing.Point(658, 270);
            this.tbServiser.Name = "tbServiser";
            this.tbServiser.Size = new System.Drawing.Size(225, 22);
            this.tbServiser.TabIndex = 14;
            // 
            // tbNapomenaServisera
            // 
            this.tbNapomenaServisera.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNapomenaServisera.Location = new System.Drawing.Point(658, 308);
            this.tbNapomenaServisera.Multiline = true;
            this.tbNapomenaServisera.Name = "tbNapomenaServisera";
            this.tbNapomenaServisera.Size = new System.Drawing.Size(337, 74);
            this.tbNapomenaServisera.TabIndex = 13;
            // 
            // tbDodatnaOprema
            // 
            this.tbDodatnaOprema.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDodatnaOprema.Location = new System.Drawing.Point(127, 381);
            this.tbDodatnaOprema.Multiline = true;
            this.tbDodatnaOprema.Name = "tbDodatnaOprema";
            this.tbDodatnaOprema.Size = new System.Drawing.Size(225, 43);
            this.tbDodatnaOprema.TabIndex = 8;
            // 
            // tbSerijskiBroj
            // 
            this.tbSerijskiBroj.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSerijskiBroj.Location = new System.Drawing.Point(127, 349);
            this.tbSerijskiBroj.Name = "tbSerijskiBroj";
            this.tbSerijskiBroj.Size = new System.Drawing.Size(225, 22);
            this.tbSerijskiBroj.TabIndex = 7;
            // 
            // tbModel
            // 
            this.tbModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbModel.Location = new System.Drawing.Point(127, 321);
            this.tbModel.Name = "tbModel";
            this.tbModel.Size = new System.Drawing.Size(225, 22);
            this.tbModel.TabIndex = 6;
            // 
            // tbKupacaTelefon
            // 
            this.tbKupacaTelefon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbKupacaTelefon.Location = new System.Drawing.Point(125, 152);
            this.tbKupacaTelefon.Name = "tbKupacaTelefon";
            this.tbKupacaTelefon.Size = new System.Drawing.Size(225, 22);
            this.tbKupacaTelefon.TabIndex = 3;
            // 
            // tbKupac
            // 
            this.tbKupac.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbKupac.Location = new System.Drawing.Point(183, 58);
            this.tbKupac.Name = "tbKupac";
            this.tbKupac.Size = new System.Drawing.Size(208, 22);
            this.tbKupac.TabIndex = 1;
            // 
            // dtpDatum
            // 
            this.dtpDatum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDatum.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDatum.Location = new System.Drawing.Point(316, 8);
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
            this.btnBrisanje.Location = new System.Drawing.Point(1075, 71);
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
            this.btnStampa.Location = new System.Drawing.Point(1075, 28);
            this.btnStampa.Name = "btnStampa";
            this.btnStampa.Size = new System.Drawing.Size(101, 37);
            this.btnStampa.TabIndex = 27;
            this.btnStampa.Text = "Štampa [F4]";
            this.btnStampa.UseVisualStyleBackColor = true;
            this.btnStampa.Click += new System.EventHandler(this.btnStampa_Click);
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
            // dtpZavrseno
            // 
            this.dtpZavrseno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpZavrseno.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpZavrseno.Location = new System.Drawing.Point(658, 8);
            this.dtpZavrseno.Name = "dtpZavrseno";
            this.dtpZavrseno.Size = new System.Drawing.Size(118, 22);
            this.dtpZavrseno.TabIndex = 37;
            this.dtpZavrseno.ValueChanged += new System.EventHandler(this.dtpZavrseno_ValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(513, 11);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 16);
            this.label12.TabIndex = 49;
            this.label12.Text = "Završeno:";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(782, 8);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(27, 23);
            this.button4.TabIndex = 89;
            this.button4.Text = "x";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // tbDobavljac
            // 
            this.tbDobavljac.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDobavljac.Location = new System.Drawing.Point(716, 60);
            this.tbDobavljac.Name = "tbDobavljac";
            this.tbDobavljac.ReadOnly = true;
            this.tbDobavljac.Size = new System.Drawing.Size(207, 22);
            this.tbDobavljac.TabIndex = 70;
            // 
            // lblDobavljac
            // 
            this.lblDobavljac.AutoSize = true;
            this.lblDobavljac.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDobavljac.Location = new System.Drawing.Point(513, 61);
            this.lblDobavljac.Name = "lblDobavljac";
            this.lblDobavljac.Size = new System.Drawing.Size(73, 16);
            this.lblDobavljac.TabIndex = 71;
            this.lblDobavljac.Text = "Dobavljač:";
            // 
            // btnDobavljaci
            // 
            this.btnDobavljaci.Location = new System.Drawing.Point(929, 60);
            this.btnDobavljaci.Name = "btnDobavljaci";
            this.btnDobavljaci.Size = new System.Drawing.Size(37, 23);
            this.btnDobavljaci.TabIndex = 72;
            this.btnDobavljaci.Text = "...";
            this.btnDobavljaci.UseVisualStyleBackColor = true;
            this.btnDobavljaci.Click += new System.EventHandler(this.btnDobavljaci_Click);
            // 
            // tbDobavljacSifra
            // 
            this.tbDobavljacSifra.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDobavljacSifra.Location = new System.Drawing.Point(658, 60);
            this.tbDobavljacSifra.Name = "tbDobavljacSifra";
            this.tbDobavljacSifra.ReadOnly = true;
            this.tbDobavljacSifra.Size = new System.Drawing.Size(52, 22);
            this.tbDobavljacSifra.TabIndex = 81;
            this.tbDobavljacSifra.TextChanged += new System.EventHandler(this.tbDobavljacSifra_TextChanged);
            // 
            // btnDobavljacClear
            // 
            this.btnDobavljacClear.Location = new System.Drawing.Point(967, 60);
            this.btnDobavljacClear.Name = "btnDobavljacClear";
            this.btnDobavljacClear.Size = new System.Drawing.Size(22, 23);
            this.btnDobavljacClear.TabIndex = 84;
            this.btnDobavljacClear.Text = "x";
            this.btnDobavljacClear.UseVisualStyleBackColor = true;
            this.btnDobavljacClear.Click += new System.EventHandler(this.btnDobavljacClear_Click);
            // 
            // dtpDatumVracanja
            // 
            this.dtpDatumVracanja.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDatumVracanja.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDatumVracanja.Location = new System.Drawing.Point(658, 157);
            this.dtpDatumVracanja.Name = "dtpDatumVracanja";
            this.dtpDatumVracanja.Size = new System.Drawing.Size(118, 22);
            this.dtpDatumVracanja.TabIndex = 12;
            this.dtpDatumVracanja.Visible = false;
            this.dtpDatumVracanja.ValueChanged += new System.EventHandler(this.dtpDatumVracanja_ValueChanged);
            // 
            // lblDatumVracanja
            // 
            this.lblDatumVracanja.AutoSize = true;
            this.lblDatumVracanja.Location = new System.Drawing.Point(513, 159);
            this.lblDatumVracanja.Name = "lblDatumVracanja";
            this.lblDatumVracanja.Size = new System.Drawing.Size(105, 16);
            this.lblDatumVracanja.TabIndex = 63;
            this.lblDatumVracanja.Text = "Datum vraćanja:";
            this.lblDatumVracanja.Visible = false;
            // 
            // dtpPoslatMejlDobavljacu
            // 
            this.dtpPoslatMejlDobavljacu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPoslatMejlDobavljacu.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPoslatMejlDobavljacu.Location = new System.Drawing.Point(659, 127);
            this.dtpPoslatMejlDobavljacu.Name = "dtpPoslatMejlDobavljacu";
            this.dtpPoslatMejlDobavljacu.Size = new System.Drawing.Size(117, 22);
            this.dtpPoslatMejlDobavljacu.TabIndex = 11;
            this.dtpPoslatMejlDobavljacu.Visible = false;
            this.dtpPoslatMejlDobavljacu.ValueChanged += new System.EventHandler(this.dtpPoslatMejlDobavljacu_ValueChanged);
            // 
            // lblPoslatMejlDobavljacu
            // 
            this.lblPoslatMejlDobavljacu.AutoSize = true;
            this.lblPoslatMejlDobavljacu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoslatMejlDobavljacu.Location = new System.Drawing.Point(513, 127);
            this.lblPoslatMejlDobavljacu.Name = "lblPoslatMejlDobavljacu";
            this.lblPoslatMejlDobavljacu.Size = new System.Drawing.Size(106, 16);
            this.lblPoslatMejlDobavljacu.TabIndex = 76;
            this.lblPoslatMejlDobavljacu.Text = "Mejl dobavljaču:";
            this.lblPoslatMejlDobavljacu.Visible = false;
            // 
            // btnDpDatumVracanja
            // 
            this.btnDpDatumVracanja.Location = new System.Drawing.Point(782, 156);
            this.btnDpDatumVracanja.Name = "btnDpDatumVracanja";
            this.btnDpDatumVracanja.Size = new System.Drawing.Size(27, 23);
            this.btnDpDatumVracanja.TabIndex = 87;
            this.btnDpDatumVracanja.Text = "x";
            this.btnDpDatumVracanja.UseVisualStyleBackColor = true;
            this.btnDpDatumVracanja.Visible = false;
            this.btnDpDatumVracanja.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnDpPoslatMejlDobavljacu
            // 
            this.btnDpPoslatMejlDobavljacu.Location = new System.Drawing.Point(782, 127);
            this.btnDpPoslatMejlDobavljacu.Name = "btnDpPoslatMejlDobavljacu";
            this.btnDpPoslatMejlDobavljacu.Size = new System.Drawing.Size(27, 23);
            this.btnDpPoslatMejlDobavljacu.TabIndex = 88;
            this.btnDpPoslatMejlDobavljacu.Text = "x";
            this.btnDpPoslatMejlDobavljacu.UseVisualStyleBackColor = true;
            this.btnDpPoslatMejlDobavljacu.Visible = false;
            this.btnDpPoslatMejlDobavljacu.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // tbBrojNaloga
            // 
            this.tbBrojNaloga.Location = new System.Drawing.Point(658, 238);
            this.tbBrojNaloga.Name = "tbBrojNaloga";
            this.tbBrojNaloga.ReadOnly = true;
            this.tbBrojNaloga.Size = new System.Drawing.Size(100, 22);
            this.tbBrojNaloga.TabIndex = 16;
            this.tbBrojNaloga.Text = "AUTO";
            // 
            // lblBrojNaloga
            // 
            this.lblBrojNaloga.AutoSize = true;
            this.lblBrojNaloga.Location = new System.Drawing.Point(513, 241);
            this.lblBrojNaloga.Name = "lblBrojNaloga";
            this.lblBrojNaloga.Size = new System.Drawing.Size(72, 16);
            this.lblBrojNaloga.TabIndex = 80;
            this.lblBrojNaloga.Text = "Br. naloga:";
            // 
            // tbBrojGarantnogLista
            // 
            this.tbBrojGarantnogLista.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBrojGarantnogLista.Location = new System.Drawing.Point(658, 402);
            this.tbBrojGarantnogLista.Name = "tbBrojGarantnogLista";
            this.tbBrojGarantnogLista.Size = new System.Drawing.Size(152, 22);
            this.tbBrojGarantnogLista.TabIndex = 10;
            // 
            // lblBrojGarantnogLista
            // 
            this.lblBrojGarantnogLista.AutoSize = true;
            this.lblBrojGarantnogLista.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrojGarantnogLista.Location = new System.Drawing.Point(513, 408);
            this.lblBrojGarantnogLista.Name = "lblBrojGarantnogLista";
            this.lblBrojGarantnogLista.Size = new System.Drawing.Size(118, 16);
            this.lblBrojGarantnogLista.TabIndex = 39;
            this.lblBrojGarantnogLista.Text = "Br. garantnog lista:";
            // 
            // tbGarantniRok
            // 
            this.tbGarantniRok.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbGarantniRok.Location = new System.Drawing.Point(658, 438);
            this.tbGarantniRok.Name = "tbGarantniRok";
            this.tbGarantniRok.Size = new System.Drawing.Size(97, 22);
            this.tbGarantniRok.TabIndex = 15;
            // 
            // lblGarantniRok
            // 
            this.lblGarantniRok.AutoSize = true;
            this.lblGarantniRok.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGarantniRok.Location = new System.Drawing.Point(513, 441);
            this.lblGarantniRok.Name = "lblGarantniRok";
            this.lblGarantniRok.Size = new System.Drawing.Size(83, 16);
            this.lblGarantniRok.TabIndex = 78;
            this.lblGarantniRok.Text = "Garantni rok:";
            // 
            // frmServisnaPrijava
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1185, 741);
            this.Controls.Add(this.btnBrisanje);
            this.Controls.Add(this.btnStampa);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmServisnaPrijava";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Servisne prijave";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrijave)).EndInit();
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
    private System.Windows.Forms.Label lblServiser;
    private System.Windows.Forms.Label lblnapomenaServisera;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox tbServiser;
    private System.Windows.Forms.TextBox tbNapomenaServisera;
    private System.Windows.Forms.TextBox tbDodatnaOprema;
    private System.Windows.Forms.TextBox tbSerijskiBroj;
    private System.Windows.Forms.TextBox tbModel;
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
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblAdresa;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.TextBox tbAdresa;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblPredmet;
        private System.Windows.Forms.TextBox tbPredmet;
        private System.Windows.Forms.Label lblBrojRacuna;
        private System.Windows.Forms.TextBox tbBrojRacuna;
        private System.Windows.Forms.TextBox tbKupacSifra;
        private System.Windows.Forms.Button btnKupacClear;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbServiserPrimio;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnDpPoslatMejlDobavljacu;
        private System.Windows.Forms.Button btnDpDatumVracanja;
        private System.Windows.Forms.Button btnDobavljacClear;
        private System.Windows.Forms.TextBox tbDobavljacSifra;
        private System.Windows.Forms.Label lblBrojNaloga;
        private System.Windows.Forms.TextBox tbBrojNaloga;
        private System.Windows.Forms.Label lblGarantniRok;
        private System.Windows.Forms.TextBox tbGarantniRok;
        private System.Windows.Forms.Label lblPoslatMejlDobavljacu;
        private System.Windows.Forms.DateTimePicker dtpPoslatMejlDobavljacu;
        private System.Windows.Forms.Button btnDobavljaci;
        private System.Windows.Forms.Label lblDobavljac;
        private System.Windows.Forms.TextBox tbDobavljac;
        private System.Windows.Forms.Label lblDatumVracanja;
        private System.Windows.Forms.DateTimePicker dtpDatumVracanja;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblBrojGarantnogLista;
        private System.Windows.Forms.DateTimePicker dtpZavrseno;
        private System.Windows.Forms.TextBox tbBrojGarantnogLista;
    }
}

