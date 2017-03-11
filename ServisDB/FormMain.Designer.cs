namespace ServisDB
{
  partial class FormMain
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
      this.button2 = new System.Windows.Forms.Button();
      this.button1 = new System.Windows.Forms.Button();
      this.label12 = new System.Windows.Forms.Label();
      this.label11 = new System.Windows.Forms.Label();
      this.label10 = new System.Windows.Forms.Label();
      this.label9 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.dtpZavrseno = new System.Windows.Forms.DateTimePicker();
      this.tbServiser = new System.Windows.Forms.TextBox();
      this.tbNapomenaServisera = new System.Windows.Forms.TextBox();
      this.tbOpisKvara = new System.Windows.Forms.TextBox();
      this.tbDodatnaOprema = new System.Windows.Forms.TextBox();
      this.tbSerijskiBroj = new System.Windows.Forms.TextBox();
      this.tbModel = new System.Windows.Forms.TextBox();
      this.tbKupacaTelefon = new System.Windows.Forms.TextBox();
      this.tbKupac = new System.Windows.Forms.TextBox();
      this.tbBrojGarantnogLista = new System.Windows.Forms.TextBox();
      this.dtpDatum = new System.Windows.Forms.DateTimePicker();
      this.tbRedniBroj = new System.Windows.Forms.TextBox();
      this.btnBrisanje = new System.Windows.Forms.Button();
      this.btnStampa = new System.Windows.Forms.Button();
      this.tmrDelay = new System.Windows.Forms.Timer(this.components);
      this.tabControl1.SuspendLayout();
      this.tabPage1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvPrijave)).BeginInit();
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
      this.dgvPrijave.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvPrijave.Location = new System.Drawing.Point(3, 29);
      this.dgvPrijave.Name = "dgvPrijave";
      this.dgvPrijave.ReadOnly = true;
      this.dgvPrijave.RowHeadersVisible = false;
      this.dgvPrijave.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dgvPrijave.Size = new System.Drawing.Size(1059, 680);
      this.dgvPrijave.TabIndex = 0;
      this.dgvPrijave.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentDoubleClick);
      this.dgvPrijave.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
      this.dgvPrijave.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataGridView1_RowPrePaint);
      // 
      // tabPage2
      // 
      this.tabPage2.Controls.Add(this.button2);
      this.tabPage2.Controls.Add(this.button1);
      this.tabPage2.Controls.Add(this.label12);
      this.tabPage2.Controls.Add(this.label11);
      this.tabPage2.Controls.Add(this.label10);
      this.tabPage2.Controls.Add(this.label9);
      this.tabPage2.Controls.Add(this.label8);
      this.tabPage2.Controls.Add(this.label7);
      this.tabPage2.Controls.Add(this.label6);
      this.tabPage2.Controls.Add(this.label5);
      this.tabPage2.Controls.Add(this.label4);
      this.tabPage2.Controls.Add(this.label3);
      this.tabPage2.Controls.Add(this.label2);
      this.tabPage2.Controls.Add(this.label1);
      this.tabPage2.Controls.Add(this.dtpZavrseno);
      this.tabPage2.Controls.Add(this.tbServiser);
      this.tabPage2.Controls.Add(this.tbNapomenaServisera);
      this.tabPage2.Controls.Add(this.tbOpisKvara);
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
      this.tabPage2.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.tabPage2_PreviewKeyDown);
      // 
      // button2
      // 
      this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.button2.Location = new System.Drawing.Point(421, 349);
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
      this.button1.Location = new System.Drawing.Point(280, 349);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(135, 36);
      this.button1.TabIndex = 50;
      this.button1.Text = "Sačuvaj [F1]";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // label12
      // 
      this.label12.AutoSize = true;
      this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label12.Location = new System.Drawing.Point(6, 303);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(68, 16);
      this.label12.TabIndex = 49;
      this.label12.Text = "Završeno:";
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label11.Location = new System.Drawing.Point(437, 282);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(61, 16);
      this.label11.TabIndex = 48;
      this.label11.Text = "Serviser:";
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label10.Location = new System.Drawing.Point(436, 180);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(138, 16);
      this.label10.TabIndex = 47;
      this.label10.Text = "Napomena servisera:";
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label9.Location = new System.Drawing.Point(437, 55);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(38, 16);
      this.label9.TabIndex = 46;
      this.label9.Text = "Kvar:";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label8.Location = new System.Drawing.Point(437, 14);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(50, 16);
      this.label8.TabIndex = 45;
      this.label8.Text = "Datum:";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label7.Location = new System.Drawing.Point(6, 233);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(113, 16);
      this.label7.TabIndex = 44;
      this.label7.Text = "Dodatna oprema:";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label6.Location = new System.Drawing.Point(6, 193);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(61, 16);
      this.label6.TabIndex = 43;
      this.label6.Text = "Ser. broj:";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label5.Location = new System.Drawing.Point(6, 156);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(49, 16);
      this.label5.TabIndex = 42;
      this.label5.Text = "Model:";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.Location = new System.Drawing.Point(6, 120);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(98, 16);
      this.label4.TabIndex = 41;
      this.label4.Text = "Kontakt telefon:";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.Location = new System.Drawing.Point(6, 86);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(49, 16);
      this.label3.TabIndex = 40;
      this.label3.Text = "Kupac:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.Location = new System.Drawing.Point(6, 45);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(118, 16);
      this.label2.TabIndex = 39;
      this.label2.Text = "Br. garantnog lista:";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(6, 11);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(73, 16);
      this.label1.TabIndex = 38;
      this.label1.Text = "Redni broj:";
      // 
      // dtpZavrseno
      // 
      this.dtpZavrseno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.dtpZavrseno.Format = System.Windows.Forms.DateTimePickerFormat.Short;
      this.dtpZavrseno.Location = new System.Drawing.Point(125, 298);
      this.dtpZavrseno.Name = "dtpZavrseno";
      this.dtpZavrseno.Size = new System.Drawing.Size(152, 22);
      this.dtpZavrseno.TabIndex = 37;
      this.dtpZavrseno.ValueChanged += new System.EventHandler(this.dtpZavrseno_ValueChanged);
      // 
      // tbServiser
      // 
      this.tbServiser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tbServiser.Location = new System.Drawing.Point(440, 300);
      this.tbServiser.Name = "tbServiser";
      this.tbServiser.Size = new System.Drawing.Size(225, 22);
      this.tbServiser.TabIndex = 36;
      // 
      // tbNapomenaServisera
      // 
      this.tbNapomenaServisera.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tbNapomenaServisera.Location = new System.Drawing.Point(440, 199);
      this.tbNapomenaServisera.Multiline = true;
      this.tbNapomenaServisera.Name = "tbNapomenaServisera";
      this.tbNapomenaServisera.Size = new System.Drawing.Size(377, 74);
      this.tbNapomenaServisera.TabIndex = 35;
      // 
      // tbOpisKvara
      // 
      this.tbOpisKvara.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tbOpisKvara.Location = new System.Drawing.Point(440, 83);
      this.tbOpisKvara.Multiline = true;
      this.tbOpisKvara.Name = "tbOpisKvara";
      this.tbOpisKvara.Size = new System.Drawing.Size(377, 87);
      this.tbOpisKvara.TabIndex = 34;
      // 
      // tbDodatnaOprema
      // 
      this.tbDodatnaOprema.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tbDodatnaOprema.Location = new System.Drawing.Point(125, 230);
      this.tbDodatnaOprema.Multiline = true;
      this.tbDodatnaOprema.Name = "tbDodatnaOprema";
      this.tbDodatnaOprema.Size = new System.Drawing.Size(225, 43);
      this.tbDodatnaOprema.TabIndex = 33;
      // 
      // tbSerijskiBroj
      // 
      this.tbSerijskiBroj.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tbSerijskiBroj.Location = new System.Drawing.Point(125, 190);
      this.tbSerijskiBroj.Name = "tbSerijskiBroj";
      this.tbSerijskiBroj.Size = new System.Drawing.Size(225, 22);
      this.tbSerijskiBroj.TabIndex = 32;
      // 
      // tbModel
      // 
      this.tbModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tbModel.Location = new System.Drawing.Point(125, 153);
      this.tbModel.Name = "tbModel";
      this.tbModel.Size = new System.Drawing.Size(225, 22);
      this.tbModel.TabIndex = 31;
      // 
      // tbKupacaTelefon
      // 
      this.tbKupacaTelefon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tbKupacaTelefon.Location = new System.Drawing.Point(125, 117);
      this.tbKupacaTelefon.Name = "tbKupacaTelefon";
      this.tbKupacaTelefon.Size = new System.Drawing.Size(225, 22);
      this.tbKupacaTelefon.TabIndex = 30;
      // 
      // tbKupac
      // 
      this.tbKupac.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tbKupac.Location = new System.Drawing.Point(125, 83);
      this.tbKupac.Name = "tbKupac";
      this.tbKupac.Size = new System.Drawing.Size(225, 22);
      this.tbKupac.TabIndex = 29;
      // 
      // tbBrojGarantnogLista
      // 
      this.tbBrojGarantnogLista.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tbBrojGarantnogLista.Location = new System.Drawing.Point(125, 42);
      this.tbBrojGarantnogLista.Name = "tbBrojGarantnogLista";
      this.tbBrojGarantnogLista.Size = new System.Drawing.Size(152, 22);
      this.tbBrojGarantnogLista.TabIndex = 28;
      // 
      // dtpDatum
      // 
      this.dtpDatum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.dtpDatum.Format = System.Windows.Forms.DateTimePickerFormat.Short;
      this.dtpDatum.Location = new System.Drawing.Point(493, 9);
      this.dtpDatum.Name = "dtpDatum";
      this.dtpDatum.Size = new System.Drawing.Size(137, 22);
      this.dtpDatum.TabIndex = 27;
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
      this.btnStampa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnStampa.Location = new System.Drawing.Point(1075, 28);
      this.btnStampa.Name = "btnStampa";
      this.btnStampa.Size = new System.Drawing.Size(101, 37);
      this.btnStampa.TabIndex = 27;
      this.btnStampa.Text = "Štampa [F4]";
      this.btnStampa.UseVisualStyleBackColor = true;
      this.btnStampa.Click += new System.EventHandler(this.btnStampa_Click);
      // 
      // FormMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1185, 741);
      this.Controls.Add(this.btnBrisanje);
      this.Controls.Add(this.btnStampa);
      this.Controls.Add(this.tabControl1);
      this.Name = "FormMain";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Evidencija servisnih prijava";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
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
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.DateTimePicker dtpZavrseno;
    private System.Windows.Forms.TextBox tbServiser;
    private System.Windows.Forms.TextBox tbNapomenaServisera;
    private System.Windows.Forms.TextBox tbOpisKvara;
    private System.Windows.Forms.TextBox tbDodatnaOprema;
    private System.Windows.Forms.TextBox tbSerijskiBroj;
    private System.Windows.Forms.TextBox tbModel;
    private System.Windows.Forms.TextBox tbKupacaTelefon;
    private System.Windows.Forms.TextBox tbKupac;
    private System.Windows.Forms.TextBox tbBrojGarantnogLista;
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
  }
}

