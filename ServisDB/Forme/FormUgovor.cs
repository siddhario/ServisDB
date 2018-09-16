using ClosedXML.Excel;
using Npgsql;
using ServisDB.Klase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServisDB.Forme
{
    public partial class FormUgovor : Form
    {
        public List<string> DynamicFilters { get; set; }
        public List<string> StaticFilters { get; set; }
        NpgsqlConnection con = new NpgsqlConnection("Host=localhost;Username=postgres;Password=postgres;Database=servisdb");

        public string conn_string = "Host=localhost;Username=postgres;Password=postgres;Database=servisdb";
        private int? dobavljacStari;

        public FormUgovor()
        {
            InitializeComponent();
          

        }


        private void ReadUgovor(string brojPrijave, string kupac)
        {
            StaticFilters = new List<string>();
            StaticFilters.Add("(broj like concat(@broj,'%') or @broj is null)");
            StaticFilters.Add("(lower(kupac_naziv) like concat(lower(@kupac_ime),'%') or @kupac_ime is null)");

            List<string> filters = new List<string>();
            filters = filters.Concat(StaticFilters).ToList();
            if (DynamicFilters != null)
                filters = filters.Concat(DynamicFilters).ToList();

            using (var conn = new NpgsqlConnection(conn_string))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    dgvPrijave.DataSource = null;
                    dgvPrijave.AutoGenerateColumns = false;

                    dgvPrijave.Columns.Clear();
                    dgvPrijave.Columns.Add(new DataGridViewTextBoxColumn() { Name = "R.broj", DataPropertyName = "broj", Width = 80 });
                    dgvPrijave.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Datum", DataPropertyName = "datum", Width = 100, DefaultCellStyle = new DataGridViewCellStyle() { Format = "dd.MM.yyyy." } });
                    dgvPrijave.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Šifra kupca", DataPropertyName = "kupac_sifra", Width = 50, Visible = false });
                    dgvPrijave.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Kupac", DataPropertyName = "kupac_naziv", Width = 180 });
                    dgvPrijave.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Adresa", DataPropertyName = "kupac_adresa", Width = 180 });
                    dgvPrijave.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Telefon", DataPropertyName = "kupac_telefon", Width = 130 });
                    dgvPrijave.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Br.računa", DataPropertyName = "broj_racuna", Width = 130 });
                    dgvPrijave.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Iznos ugovora (sa PDV)", DataPropertyName = "iznos_sa_pdv", Width = 130 });
                    dgvPrijave.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Suma uplata", DataPropertyName = "suma_uplata", Width = 130 });
                    dgvPrijave.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Preostalo za uplatu", DataPropertyName = "preostalo_za_uplatu", Width = 130 });

                    // Retrieve all rows
                    cmd.Parameters.Clear();
                    Npgsql.NpgsqlParameter p1 = new NpgsqlParameter("@kupac_ime", DbType.String);
                    cmd.Parameters.Add(p1);

                    Npgsql.NpgsqlParameter p2 = new NpgsqlParameter("@broj", DbType.String);
                    cmd.Parameters.Add(p2);

                    if (kupac == "")
                        p1.Value = DBNull.Value;
                    else
                        p1.Value = kupac;

                    if (brojPrijave == "")
                        p2.Value = DBNull.Value;
                    else
                        p2.Value = brojPrijave;
                    cmd.CommandText = @"SELECT broj, datum, kupac_sifra, kupac_maticni_broj, kupac_broj_lk, kupac_naziv, kupac_adresa, kupac_telefon, broj_racuna, radnik, inicijalno_placeno, iznos_bez_pdv, pdv, iznos_sa_pdv, broj_rata, suma_uplata, preostalo_za_uplatu, status, napomena
	FROM public.ugovor";
                    if (filters.Count > 0)
                    {
                        cmd.CommandText += " WHERE ";
                        foreach (string f in filters)
                            cmd.CommandText += f + " AND ";
                        cmd.CommandText = cmd.CommandText.Substring(0, cmd.CommandText.Length - 4);
                    }
                    cmd.CommandText += " order by datum desc";

                    using (var reader = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        dgvPrijave.DataSource = dt;
                        dgvPrijave.Refresh();
                    }


                }
            }

        }




        private void button1_Click(object sender, EventArgs e)
        {
            //DateTime? zavrseno = null;
            //if (dtpZavrseno.Format == DateTimePickerFormat.Custom)
            //{
            //    zavrseno = null;
            //}
            //else
            //{
            //    zavrseno = dtpZavrseno.Value;
            //}

            //DateTime? poslatMejlDobavljacu = null;
            //if (dtpPoslatMejlDobavljacu.Format == DateTimePickerFormat.Custom)
            //{
            //    poslatMejlDobavljacu = null;
            //}
            //else
            //{
            //    poslatMejlDobavljacu = dtpPoslatMejlDobavljacu.Value;
            //}

            //DateTime? datumVracanja = null;
            //if (dtpDatumVracanja.Format == DateTimePickerFormat.Custom)
            //{
            //    datumVracanja = null;
            //}
            //else
            //{
            //    datumVracanja = dtpDatumVracanja.Value;
            //}
          
            int? kupacSifra;
            if (tbKupacSifra.Text == "")
            {
                PersistanceManager.InsertPartner(tbKupac.Text, "F", "", tbAdresa.Text, tbKupacaTelefon.Text,null, true, false, out kupacSifra);
                tbKupacSifra.Text = kupacSifra.ToString();
            }
            else
                PersistanceManager.UpdatePartner(int.Parse(tbKupacSifra.Text), tbAdresa.Text, tbKupacaTelefon.Text);

            if (tbRedniBroj.Text == "AUTO")
                PersistanceManager.InsertUgovor(dtpDatum.Value,  int.Parse(tbKupacSifra.Text) , tbKupac.Text, tbAdresa.Text, tbKupacaTelefon.Text, tbKupacBrojLk.Text,tbKupacMaticniBroj.Text
                   ,decimal.Parse(tbIznosSaPDV.Text),decimal.Parse(tbInicijalnoUplaceno.Text),decimal.Parse(tbSumaUplata.Text),decimal.Parse(tbPreostaloZaUplatu.Text),tbNapomena.Text,tbRadnik.Text,tbStatus.Text,int.Parse(tbBrojRata.Text),tbBrojRacuna.Text);
            else
                PersistanceManager.UpdateUgovor(tbRedniBroj.Text, dtpDatum.Value, int.Parse(tbKupacSifra.Text), tbKupac.Text, tbAdresa.Text, tbKupacaTelefon.Text, tbKupacBrojLk.Text, tbKupacMaticniBroj.Text
                   , decimal.Parse(tbIznosSaPDV.Text), decimal.Parse(tbInicijalnoUplaceno.Text), decimal.Parse(tbSumaUplata.Text), decimal.Parse(tbPreostaloZaUplatu.Text), tbNapomena.Text, tbRadnik.Text, tbStatus.Text, int.Parse(tbBrojRata.Text), tbBrojRacuna.Text);
            tabControl1.SelectedIndex = 0;
            Clear();
            ReadUgovor("", "");
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //broj, datum, kupac_sifra, kupac_maticni_broj, kupac_broj_lk, kupac_naziv, kupac_adresa, kupac_telefon, broj_racuna, radnik, inicijalno_placeno, iznos_bez_pdv, pdv, iznos_sa_pdv, broj_rata, suma_uplata, preostalo_za_uplatu, status, napomena


            if (dgvPrijave.SelectedRows.Count == 0)
                return;
            object o = dgvPrijave.SelectedRows[0].DataBoundItem;
            tabControl1.SelectedIndex = 1;
            tbRedniBroj.Text = ((DataRowView)o).Row.ItemArray[0].ToString();
         
            dtpDatum.Value = (DateTime)((DataRowView)o).Row.ItemArray[1];
            tbKupacSifra.Text = ((DataRowView)o).Row.ItemArray[2].ToString();
            tbKupacMaticniBroj.Text = ((DataRowView)o).Row.ItemArray[3].ToString();
            tbKupacBrojLk.Text = ((DataRowView)o).Row.ItemArray[4].ToString();
            tbKupac.Text = ((DataRowView)o).Row.ItemArray[5].ToString();
            tbAdresa.Text = ((DataRowView)o).Row.ItemArray[6].ToString();
            tbKupacaTelefon.Text = ((DataRowView)o).Row.ItemArray[7].ToString();
            tbBrojRacuna.Text = ((DataRowView)o).Row.ItemArray[8].ToString();
            tbRadnik.Text = ((DataRowView)o).Row.ItemArray[9].ToString();

            //inicijalno_placeno, iznos_bez_pdv, pdv, iznos_sa_pdv, broj_rata, suma_uplata, preostalo_za_uplatu
            tbInicijalnoUplaceno.Text = ((DataRowView)o).Row.ItemArray[10].ToString();
            tbIznosSaPDV.Text = ((DataRowView)o).Row.ItemArray[13].ToString();
            tbBrojRata .Text = ((DataRowView)o).Row.ItemArray[14].ToString();
            tbSumaUplata.Text = ((DataRowView)o).Row.ItemArray[15].ToString();
            tbPreostaloZaUplatu.Text = ((DataRowView)o).Row.ItemArray[16].ToString();
            tbStatus.Text = ((DataRowView)o).Row.ItemArray[17].ToString();
         
            tbNapomena.Text = ((DataRowView)o).Row.ItemArray[18].ToString();          
        
            SetVisibility();
        }

        private void dtpDatumUplate_ValueChanged(object sender, EventArgs e)
        {
            dtpDatumUplate.Format = DateTimePickerFormat.Short;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
            tbRedniBroj.Text = "AUTO";
            Clear();

        }

        private void Clear()
        {
            dtpDatum.Value = DateTime.Now;
            tbKupacMaticniBroj.Text = "";
            tbKupacBrojLk.Text = "";
            tbKupac.Text = "";
            tbKupacaTelefon.Text = "";
            tbKupacSifra.Text = "";
            tbAdresa.Text = "";
            tbRadnik.Text = "";
            tbBrojRacuna.Text = "";
            tbInicijalnoUplaceno.Text = "";
            tbSumaUplata.Text = "";
            tbPreostaloZaUplatu.Text = "";
            tbIznosSaPDV.Text = "";
            tbBrojRata.Text = "";
            tbNapomena.Text = "";
            tbStatus.Text = "N";
          
            tbKupac.ReadOnly = false;
            tbKupac.Focus();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
                tbKupac.Focus();
            else
            {
                textBox1.Focus();
                textBox1.Select();
            }
        }

        private void tabControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (!textBox1.Focused)
                {
                    if (tabControl1.SelectedIndex == 1)
                    {
                        e.SuppressKeyPress = true;
                        SelectNextControl(ActiveControl, true, true, true, true);
                    }
                    else
                    {
                        dataGridView1_CellDoubleClick(this, null);
                    }
                }
            }
            else if (e.KeyData == Keys.F3)
            {
                if (textBox1.Focused == true)
                    textBox2.Focus();
                else if (textBox2.Focused == true)
                    textBox1.Focus();
                else
                    textBox2.Focus();
                textBox2.Clear();
                textBox1.Clear();
            }
            else if (e.KeyData == Keys.F2)
            {
                tabControl1.SelectedIndex = 1;
            }
            else if (e.KeyData == Keys.Escape)
            {
                button2_Click(this, null);
            }
            else if (e.KeyData == Keys.F4)
            {
                btnStampa_Click(this, null);
            }
            else if (e.KeyData == Keys.F5)
            {
                btnBrisanje_Click(this, null);
            }
            else if (e.KeyData == Keys.F1)
            {
                if (tabControl1.SelectedIndex == 1)
                    button1_Click(this, null);
            }
            else if (e.KeyData == Keys.Down)
            {
                if (tabControl1.SelectedIndex == 0)
                {
                    dgvPrijave.Focus();
                    dgvPrijave.Select();
                }
            }

        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            //string i = dgvPrijave.Rows[e.RowIndex].Cells[9].Value.ToString();
            //if (i != "")
            //{
            //    //dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.PaleGreen;
            //    //dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            //    dgvPrijave.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Green;
            //    dgvPrijave.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("Tahoma", 10, FontStyle.Italic);
            //}
            //else
            //{

            //    dgvPrijave.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
            //    dgvPrijave.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("Tahoma", 10, FontStyle.Regular);
            //}
        }

        private void btnStampa_Click(object sender, EventArgs e)
        {
            //string dir = Environment.SpecialFolder.MyDocuments + "\\ServisDB\\";

            string dir = System.IO.Path.Combine(Environment.GetFolderPath(
          Environment.SpecialFolder.MyDoc‌​uments), "ServisDB");

            if (Directory.Exists(dir) == false)
            {
                Directory.CreateDirectory(dir);
            }



            XLWorkbook doc = new XLWorkbook("PRIJEMNICA NA SERVIS.xlsx");
            //doc.Worksheets.Add("Ugovor");

            var sheet = doc.Worksheet(1);

            object o = dgvPrijave.SelectedRows[0].DataBoundItem;

            string rednibroj = ((DataRowView)o).Row.ItemArray[0].ToString();
            string datum = ((DateTime)((DataRowView)o).Row.ItemArray[2]).Date.ToString();
            string garantnilist = ((DataRowView)o).Row.ItemArray[21].ToString();
            string kupac = ((DataRowView)o).Row.ItemArray[4].ToString();
            string kupac_telefon = ((DataRowView)o).Row.ItemArray[6].ToString();
            string model = ((DataRowView)o).Row.ItemArray[8].ToString();
            string serijski_broj = ((DataRowView)o).Row.ItemArray[9].ToString();
            string dodatna_oprema = ((DataRowView)o).Row.ItemArray[10].ToString();
            string opis_kvara = ((DataRowView)o).Row.ItemArray[11].ToString();
            string napomena_servisera = ((DataRowView)o).Row.ItemArray[12].ToString();
            string serviser = ((DataRowView)o).Row.ItemArray[13].ToString();
            string zavrseno = "";
            if (((DataRowView)o).Row.ItemArray[15] == DBNull.Value)
            {
                zavrseno = "";
            }
            else
            {
                zavrseno = ((DateTime)((DataRowView)o).Row.ItemArray[15]).ToString();
            }

            string[] parts = rednibroj.Split('/');
            string rb = parts[0];
            string year = parts[1];
            int rrb = int.Parse(rb);
            rednibroj = rrb.ToString("D4") + "/" + year;
            sheet.Cells("C17").Value = rednibroj;
            sheet.Cells("C17").DataType = XLCellValues.Text;
            sheet.Cells("C15").Value = rednibroj;
            sheet.Cells("C15").Style.Font.FontName = "Free 3 of 9 Extended";
            sheet.Cells("C15").Style.Font.FontSize = 28;
            sheet.Cells("C18").Value = garantnilist;
            sheet.Cells("C21").Value = datum;
            sheet.Cells("C24").Value = kupac;
            sheet.Cells("C25").Value = kupac_telefon;
            sheet.Cells("C28").Value = model;
            sheet.Cells("C29").Value = serijski_broj;
            sheet.Cells("C31").Value = dodatna_oprema;
            sheet.Cells("C32").Value = opis_kvara;


            string fileName = dir + "\\" + rednibroj.Replace("/", "-") + ".xlsx";
            if (File.Exists(fileName) == true)
            {
                DialogResult dr = MessageBox.Show("Štampana verzija već postoji. Napraviti novu ?", "Upozorenje", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        File.Delete(fileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Zatvorite dokument pa pokušajte opet!");
                        return;
                    }
                    doc.SaveAs(fileName);
                    Process.Start(fileName);
                }
            }
            else
            {
                doc.SaveAs(fileName);
                Process.Start(fileName);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

            ReadUgovor(textBox1.Text, textBox2.Text);
        }

        private void btnBrisanje_Click(object sender, EventArgs e)
        {
            object o = dgvPrijave.SelectedRows[0].DataBoundItem;
            string rb = ((DataRowView)o).Row.ItemArray[0].ToString();
            if (MessageBox.Show(string.Format("Obrisati ugovor {0} ?", rb), "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                PersistanceManager.DeleteUgovor(rb);
                MessageBox.Show(string.Format("Ugovor {0} je uspješno obrisan!", rb), "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                ReadUgovor(textBox1.Text, textBox2.Text);
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            ReadUgovor(textBox1.Text, textBox2.Text);
            dtpDatumUplate.Format = DateTimePickerFormat.Custom;
            dtpDatumUplate.CustomFormat = " ";
            
            dgvPrijave.Focus();
            dgvPrijave.Select();
            dgvPrijave.DefaultCellStyle = new DataGridViewCellStyle() { SelectionBackColor = Color.LightBlue, SelectionForeColor = Color.Red };

            textBox1.Focus();
            textBox1.Select();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string strCurrentString = textBox1.Text.Trim().ToString();
                if (strCurrentString != "")
                {
                    //Do something with the barcode entered 
                    //MessageBox.Show(textBox1.Text);

                    ReadUgovor(textBox1.Text, "");
                    textBox1.Text = "";
                    dataGridView1_CellDoubleClick(this, null);
                    tbNapomena.Focus();
                    tbNapomena.Select();
                    //textBox1.Text = "";
                }
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            ReadUgovor("", "");
        }

        private void btnPartneri_Click(object sender, EventArgs e)
        {
            FormPartner frm = new FormPartner();
            frm.DynamicFilters = new List<string>() { "kupac=true" };
            frm.AccessMode = Klase.Enums.AccessMode.LOOKUP;
            frm.ShowDialog();
            if (frm.Selected != null)
            {
                tbKupacSifra.Text = frm.Selected.Sifra.ToString();
                tbKupac.Text = frm.Selected.Naziv;
                tbKupacaTelefon.Text = frm.Selected.Telefon;
                tbAdresa.Text = frm.Selected.Adresa;
                tbKupac.ReadOnly = true;
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }



        private void btnKupacClear_Click(object sender, EventArgs e)
        {
            tbKupacSifra.Text = "";
            tbKupacaTelefon.Text = "";
            tbKupac.Text = "";
            tbAdresa.Text = "";
            tbKupacMaticniBroj.Text = "";
            tbKupacBrojLk.Text = "";
            tbKupac.ReadOnly = false;
        }

     


        private void SetVisibility()
        {
            //lblPoslatMejlDobavljacu.Visible = tbDobavljacSifra.Text != "";
            //dtpPoslatMejlDobavljacu.Visible = tbDobavljacSifra.Text != "";
            //lblDatumVracanja.Visible = tbDobavljacSifra.Text != "";
            //dtpDatumVracanja.Visible = tbDobavljacSifra.Text != "";
            //btnDpDatumVracanja.Visible = tbDobavljacSifra.Text != "";
            //btnDpPoslatMejlDobavljacu.Visible = tbDobavljacSifra.Text != "";

            //tbNapomena.Visible = tbDobavljacSifra.Text == "";
            //lblnapomena.Visible = tbDobavljacSifra.Text == "";
            //tbRadnik.Visible = tbDobavljacSifra.Text == "";
            //lblRadnik.Visible = tbDobavljacSifra.Text == "";
            //lblBrojNaloga.Visible = tbDobavljacSifra.Text == "";
            //tbBrojNaloga.Visible = tbDobavljacSifra.Text == "";
            //lblGarantniRok.Visible = tbDobavljacSifra.Text == "";
            //tbGarantniRok.Visible = tbDobavljacSifra.Text == "";
            //lblBrojGarantnogLista.Visible = tbDobavljacSifra.Text == "";
            //tbBrojGarantnogLista.Visible = tbDobavljacSifra.Text == "";
            tbKupac.ReadOnly = tbKupacSifra.Text != "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dtpDatumUplate.Format = DateTimePickerFormat.Custom;
            dtpDatumUplate.CustomFormat = " ";
        }

 

    
    }
}
