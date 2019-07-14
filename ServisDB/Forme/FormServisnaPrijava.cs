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
    public partial class frmServisnaPrijava : Form
    {
        public List<string> DynamicFilters { get; set; }
        public List<string> StaticFilters { get; set; }
        //NpgsqlConnection con = new NpgsqlConnection("Host=localhost;Username=postgres;Password=postgres;Database=servisdb");

        //public string conn_string = "Host=localhost;Username=postgres;Password=postgres;Database=servisdb";
        private int? dobavljacStari;

        public frmServisnaPrijava()
        {
            InitializeComponent();
          

        }


        private void ReadPrijava(string brojPrijave, string kupac)
        {
            StaticFilters = new List<string>();
            StaticFilters.Add("(broj like concat(@broj,'%') or @broj is null)");
            StaticFilters.Add("(lower(kupac_ime) like concat(lower(@kupac_ime),'%') or @kupac_ime is null)");

            List<string> filters = new List<string>();
            filters = filters.Concat(StaticFilters).ToList();
            if (DynamicFilters != null)
                filters = filters.Concat(DynamicFilters).ToList();

            using (var conn = new NpgsqlConnection(PersistanceManager.GetConnectionString()))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    dgvPrijave.DataSource = null;
                    dgvPrijave.AutoGenerateColumns = false;

                    dgvPrijave.Columns.Clear();
                    dgvPrijave.Columns.Add(new DataGridViewTextBoxColumn() { Name = "R.broj", DataPropertyName = "broj", Width = 80 });
                    dgvPrijave.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Datum prijema", DataPropertyName = "datum", Width = 100, DefaultCellStyle = new DataGridViewCellStyle() { Format = "dd.MM.yyyy." } });
                    dgvPrijave.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Šifra kupca", DataPropertyName = "kupac_sifra", Width = 50, Visible = false });
                    dgvPrijave.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Kupac", DataPropertyName = "kupac_ime", Width = 180 });
                    dgvPrijave.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Adresa", DataPropertyName = "kupac_adresa", Width = 180 });
                    dgvPrijave.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Telefon", DataPropertyName = "kupac_telefon", Width = 130 });
                    dgvPrijave.Columns.Add(new DataGridViewTextBoxColumn() { Name = "E-mail", DataPropertyName = "kupac_email", Visible = false });
                    dgvPrijave.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Predmet", DataPropertyName = "predmet", Width = 250 });
                    dgvPrijave.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Model", DataPropertyName = "model", Visible = true });
                    dgvPrijave.Columns.Add(new DataGridViewTextBoxColumn() { Name = "SB", DataPropertyName = "serijski_broj", Visible = false });
                    dgvPrijave.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Dodatna oprema", DataPropertyName = "dodatna_oprema", Visible = false });
                    dgvPrijave.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Dobavljač", DataPropertyName = "dobavljac_sifra", Width = 80 });
                    dgvPrijave.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Email dobavljaču", DataPropertyName = "poslat_mejl_dobavljacu", Width = 100, DefaultCellStyle = new DataGridViewCellStyle() { Format = "dd.MM.yyyy." } });
                    dgvPrijave.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Datum vraćanja", DataPropertyName = "datum_vracanja", Width = 100, DefaultCellStyle = new DataGridViewCellStyle() { Format = "dd.MM.yyyy." } });
                    dgvPrijave.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Završeno", DataPropertyName = "zavrseno", Width = 100, DefaultCellStyle = new DataGridViewCellStyle() { Format = "dd.MM.yyyy." } });
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
                    cmd.CommandText = @"SELECT broj, broj_naloga, datum, kupac_sifra, kupac_ime, kupac_adresa, kupac_telefon, kupac_email, model, serijski_broj, dodatna_oprema, predmet, napomena_servisera, serviser, serviser_primio, zavrseno, dobavljac_sifra, dobavljac, datum_vracanja, poslat_mejl_dobavljacu, garantni_rok, broj_garantnog_lista, broj_racuna,instalacija_os,instalacija_office, instalacija_ostalo,instalacija
	 FROM prijava";
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
            DateTime? zavrseno = null;
            if (dtpZavrseno.Format == DateTimePickerFormat.Custom)
            {
                zavrseno = null;
            }
            else if(dtpZavrseno.Checked==true)
            {
                zavrseno = dtpZavrseno.Value;
            }

            DateTime? poslatMejlDobavljacu = null;
            if (dtpPoslatMejlDobavljacu.Format == DateTimePickerFormat.Custom)
            {
                poslatMejlDobavljacu = null;
            }
            else if (dtpPoslatMejlDobavljacu.Checked == true)
            {
                poslatMejlDobavljacu = dtpPoslatMejlDobavljacu.Value;
            }

            DateTime? datumVracanja = null;
            if (dtpDatumVracanja.Format == DateTimePickerFormat.Custom)
            {
                datumVracanja = null;
            }
            else if (dtpDatumVracanja.Checked == true)
            {
                datumVracanja = dtpDatumVracanja.Value;
            }
            bool dobavljacPromjenjen = false;
            int? noviDobavljac = null;
            if (tbDobavljacSifra.Text != "")
                noviDobavljac = int.Parse(tbDobavljacSifra.Text);
            if (dobavljacStari != noviDobavljac)
                dobavljacPromjenjen = true;
            int? kupacSifra;
            if (tbKupacSifra.Text == "")
            {
                PersistanceManager.InsertPartner(tbKupac.Text, "F", "", tbAdresa.Text, tbKupacaTelefon.Text, tbEmail.Text, true, false,"", out kupacSifra);
                tbKupacSifra.Text = kupacSifra.ToString();
            }
            else
                PersistanceManager.UpdatePartner(int.Parse(tbKupacSifra.Text), tbAdresa.Text, tbKupacaTelefon.Text, tbEmail.Text);

            if (tbRedniBroj.Text == "AUTO")
                PersistanceManager.InsertPrijava(dtpDatum.Value, tbBrojGarantnogLista.Text, (tbKupacSifra.Text != "" ? int.Parse(tbKupacSifra.Text) : (int?)null), tbKupac.Text, tbAdresa.Text, tbKupacaTelefon.Text, tbEmail.Text,
                    tbModel.Text, tbSerijskiBroj.Text, tbDodatnaOprema.Text, tbPredmet.Text, tbNapomenaServisera.Text, tbServiser.Text, tbServiserPrimio.Text, zavrseno, (tbDobavljacSifra.Text != "" ? int.Parse(tbDobavljacSifra.Text) : (int?)null)
                    , tbDobavljac.Text, datumVracanja, poslatMejlDobavljacu, (tbGarantniRok.Text != "" ? int.Parse(tbGarantniRok.Text) : (int?)null), tbBrojRacuna.Text,cbOS.Checked,cbOffice.Checked,cbOstalo.Checked,tbInstalacija.Text);
            else
                PersistanceManager.UpdatePrijava(tbRedniBroj.Text, dtpDatum.Value, tbBrojGarantnogLista.Text, (tbKupacSifra.Text != "" ? int.Parse(tbKupacSifra.Text) : (int?)null), tbKupac.Text, tbAdresa.Text, tbKupacaTelefon.Text, tbEmail.Text,
                    tbModel.Text, tbSerijskiBroj.Text, tbDodatnaOprema.Text, tbPredmet.Text, tbNapomenaServisera.Text, tbServiser.Text, tbServiserPrimio.Text, zavrseno, (tbDobavljacSifra.Text != "" ? int.Parse(tbDobavljacSifra.Text) : (int?)null)
                    , tbDobavljac.Text, datumVracanja, poslatMejlDobavljacu, (tbGarantniRok.Text != "" ? int.Parse(tbGarantniRok.Text) : (int?)null), tbBrojRacuna.Text, cbOS.Checked, cbOffice.Checked, cbOstalo.Checked, tbInstalacija.Text, dobavljacPromjenjen);
            tabControl1.SelectedIndex = 0;
            Clear();
            ReadPrijava("", "");
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvPrijave.SelectedRows.Count == 0)
                return;
            object o = dgvPrijave.SelectedRows[0].DataBoundItem;
            tabControl1.SelectedIndex = 1;
            tbRedniBroj.Text = ((DataRowView)o).Row.ItemArray[0].ToString();
            tbBrojNaloga.Text = ((DataRowView)o).Row.ItemArray[1].ToString();
            dtpDatum.Value = (DateTime)((DataRowView)o).Row.ItemArray[2];
            tbKupacSifra.Text = ((DataRowView)o).Row.ItemArray[3].ToString();
            tbKupac.Text = ((DataRowView)o).Row.ItemArray[4].ToString();
            tbAdresa.Text = ((DataRowView)o).Row.ItemArray[5].ToString();
            tbKupacaTelefon.Text = ((DataRowView)o).Row.ItemArray[6].ToString();
            tbEmail.Text = ((DataRowView)o).Row.ItemArray[7].ToString();
            tbModel.Text = ((DataRowView)o).Row.ItemArray[8].ToString();
            tbSerijskiBroj.Text = ((DataRowView)o).Row.ItemArray[9].ToString();
            tbDodatnaOprema.Text = ((DataRowView)o).Row.ItemArray[10].ToString();
            tbPredmet.Text = ((DataRowView)o).Row.ItemArray[11].ToString();
            tbNapomenaServisera.Text = ((DataRowView)o).Row.ItemArray[12].ToString();
            tbServiser.Text = ((DataRowView)o).Row.ItemArray[13].ToString();
            tbServiserPrimio.Text = ((DataRowView)o).Row.ItemArray[14].ToString();

            if (((DataRowView)o).Row.ItemArray[15] == DBNull.Value)
            {
                dtpZavrseno.Format = DateTimePickerFormat.Custom;
                dtpZavrseno.CustomFormat = " ";

            }
            else
            {
                dtpZavrseno.Format = DateTimePickerFormat.Short;
                dtpZavrseno.Value = (DateTime)((DataRowView)o).Row.ItemArray[15];

            }
            if (((DataRowView)o).Row.ItemArray[16].ToString() != "")
                dobavljacStari = int.Parse(((DataRowView)o).Row.ItemArray[16].ToString());
            else
                dobavljacStari = null;
            tbDobavljacSifra.Text = ((DataRowView)o).Row.ItemArray[16].ToString();
            tbDobavljac.Text = ((DataRowView)o).Row.ItemArray[17].ToString();

            if (((DataRowView)o).Row.ItemArray[18] == DBNull.Value)
            {
                dtpDatumVracanja.Format = DateTimePickerFormat.Custom;
                dtpDatumVracanja.CustomFormat = " ";
            

            }
            else
            {
                dtpDatumVracanja.Format = DateTimePickerFormat.Short;
                dtpDatumVracanja.Value = (DateTime)((DataRowView)o).Row.ItemArray[18];
            }

            if (((DataRowView)o).Row.ItemArray[19] == DBNull.Value)
            {
                dtpPoslatMejlDobavljacu.Format = DateTimePickerFormat.Custom;
                dtpPoslatMejlDobavljacu.CustomFormat = " ";
            }
            else
            {
                dtpPoslatMejlDobavljacu.Format = DateTimePickerFormat.Short;
                dtpPoslatMejlDobavljacu.Value = (DateTime)((DataRowView)o).Row.ItemArray[19];
            }

            tbGarantniRok.Text = ((DataRowView)o).Row.ItemArray[20].ToString();
            tbBrojGarantnogLista.Text = ((DataRowView)o).Row.ItemArray[21].ToString();
            tbBrojRacuna.Text = ((DataRowView)o).Row.ItemArray[22].ToString();

            cbOS.Checked = (bool)((DataRowView)o).Row.ItemArray[23];
            cbOffice.Checked = (bool)((DataRowView)o).Row.ItemArray[24];
            cbOstalo.Checked = (bool)((DataRowView)o).Row.ItemArray[25];
            tbInstalacija.Text = ((DataRowView)o).Row.ItemArray[26].ToString();

            SetVisibility();
        }

        private void dtpZavrseno_ValueChanged(object sender, EventArgs e)
        {
            dtpZavrseno.Format = DateTimePickerFormat.Short;
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
            tbBrojGarantnogLista.Text = "";
            tbKupac.Text = "";
            tbKupacaTelefon.Text = "";
            tbKupacSifra.Text = "";
            tbAdresa.Text = "";
            tbEmail.Text = "";
            tbServiserPrimio.Text = "";
            tbBrojRacuna.Text = "";
            tbGarantniRok.Text = "";
            tbPredmet.Text = "";
            tbModel.Text = "";
            tbSerijskiBroj.Text = "";
            tbDodatnaOprema.Text = "";
            //tbOpisKvara.Text = "";
            tbNapomenaServisera.Text = "";
            tbServiser.Text = "";
            dtpZavrseno.Format = DateTimePickerFormat.Custom;
            dtpZavrseno.CustomFormat = " ";

            cbOS.Checked = false;
            cbOffice.Checked = false;
            cbOstalo.Checked = false;
            tbInstalacija.Text = "";

            dtpPoslatMejlDobavljacu.Format = DateTimePickerFormat.Custom;
            dtpPoslatMejlDobavljacu.CustomFormat = " ";

            dtpDatumVracanja.Format = DateTimePickerFormat.Custom;
            dtpDatumVracanja.CustomFormat = " ";

            tbDobavljac.Text = "";
            tbDobavljacSifra.Text = "";
            tbBrojNaloga.Text = "";
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
            else if (e.KeyData == Keys.F7)
            {
                btnStampaRadnogNaloga_Click(this, null);
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
            object o = dgvPrijave.Rows[e.RowIndex].DataBoundItem;
            string i = ((DataRowView)o).Row.ItemArray[15].ToString();
            //string i = dgvPrijave.Rows[e.RowIndex].Cells[9].Value.ToString();
            if (i!="")
            {
                //dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.PaleGreen;
                //dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                dgvPrijave.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Green;
                dgvPrijave.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("Tahoma", 10, FontStyle.Italic);
            }
            else
            {

                dgvPrijave.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                dgvPrijave.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("Tahoma", 10, FontStyle.Regular);
            }
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
            //doc.Worksheets.Add("PRIJAVA");

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
            sheet.Cells("C17").DataType = XLDataType.Text;
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

            ReadPrijava(textBox1.Text, textBox2.Text);
        }

        private void btnBrisanje_Click(object sender, EventArgs e)
        {
            object o = dgvPrijave.SelectedRows[0].DataBoundItem;
            string rb = ((DataRowView)o).Row.ItemArray[0].ToString();
            if (MessageBox.Show(string.Format("Obrisati prijavu {0} ?", rb), "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                PersistanceManager.DeletePrijava(rb);
                MessageBox.Show(string.Format("Prijava {0} je uspješno obrisana!", rb), "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                ReadPrijava(textBox1.Text, textBox2.Text);
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            ReadPrijava(textBox1.Text, textBox2.Text);
            dtpZavrseno.Format = DateTimePickerFormat.Custom;
            dtpZavrseno.CustomFormat = " ";

            dtpDatumVracanja.Format = DateTimePickerFormat.Custom;
            dtpDatumVracanja.CustomFormat = " ";

            dtpPoslatMejlDobavljacu.Format = DateTimePickerFormat.Custom;
            dtpPoslatMejlDobavljacu.CustomFormat = " ";

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

                    ReadPrijava(textBox1.Text, "");
                    textBox1.Text = "";
                    dataGridView1_CellDoubleClick(this, null);
                    dtpZavrseno.Value = DateTime.Now;
                    tbNapomenaServisera.Focus();
                    tbNapomenaServisera.Select();
                    //textBox1.Text = "";
                }
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            ReadPrijava("", "");
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
                tbEmail.Text = frm.Selected.Email;
                tbAdresa.Text = frm.Selected.Adresa;
                tbKupac.ReadOnly = true;
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void btnDobavljaci_Click(object sender, EventArgs e)
        {
            FormPartner frm = new FormPartner();
            frm.DynamicFilters = new List<string>() { "dobavljac=true" };
            frm.AccessMode = Klase.Enums.AccessMode.LOOKUP;
            frm.ShowDialog();
            if (frm.Selected != null)
            {
                tbDobavljac.Text = frm.Selected.Naziv;
                tbDobavljacSifra.Text = frm.Selected.Sifra.ToString();
            }
        }


        private void btnKupacClear_Click(object sender, EventArgs e)
        {
            tbKupacSifra.Text = "";
            tbKupacaTelefon.Text = "";
            tbKupac.Text = "";
            tbAdresa.Text = "";
            tbEmail.Text = "";
            tbKupac.ReadOnly = false;
        }

        private void btnDobavljacClear_Click(object sender, EventArgs e)
        {
            tbDobavljac.Text = "";
            tbDobavljacSifra.Text = "";
        }

        private void dtpPoslatMejlDobavljacu_ValueChanged(object sender, EventArgs e)
        {
            dtpPoslatMejlDobavljacu.Format = DateTimePickerFormat.Short;
        }

        private void dtpDatumVracanja_ValueChanged(object sender, EventArgs e)
        {
            dtpDatumVracanja.Format = DateTimePickerFormat.Short;
        }

        private void tbDobavljacSifra_TextChanged(object sender, EventArgs e)
        {
            SetVisibility();
        }

        private void SetVisibility()
        {
            lblPoslatMejlDobavljacu.Visible = tbDobavljacSifra.Text != "";
            dtpPoslatMejlDobavljacu.Visible = tbDobavljacSifra.Text != "";
            lblDatumVracanja.Visible = tbDobavljacSifra.Text != "";
            dtpDatumVracanja.Visible = tbDobavljacSifra.Text != "";
            btnDpDatumVracanja.Visible = tbDobavljacSifra.Text != "";
            btnDpPoslatMejlDobavljacu.Visible = tbDobavljacSifra.Text != "";

            tbNapomenaServisera.Visible = tbDobavljacSifra.Text == "";
            lblnapomenaServisera.Visible = tbDobavljacSifra.Text == "";
            tbServiser.Visible = tbDobavljacSifra.Text == "";
            lblServiser.Visible = tbDobavljacSifra.Text == "";
            lblBrojNaloga.Visible = tbDobavljacSifra.Text == "";
            tbBrojNaloga.Visible = tbDobavljacSifra.Text == "";
            lblGarantniRok.Visible = tbDobavljacSifra.Text == "";
            tbGarantniRok.Visible = tbDobavljacSifra.Text == "";
            lblBrojGarantnogLista.Visible = tbDobavljacSifra.Text == "";
            tbBrojGarantnogLista.Visible = tbDobavljacSifra.Text == "";
            tbKupac.ReadOnly = tbKupacSifra.Text != "";

            cbOstalo.Visible = tbDobavljacSifra.Text == "";
            cbOffice.Visible = tbDobavljacSifra.Text == "";
            cbOS.Visible = tbDobavljacSifra.Text == "";
            tbInstalacija.Visible = tbDobavljacSifra.Text == "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dtpDatumVracanja.Format = DateTimePickerFormat.Custom;
            dtpDatumVracanja.CustomFormat = " ";
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            dtpPoslatMejlDobavljacu.Format = DateTimePickerFormat.Custom;
            dtpPoslatMejlDobavljacu.CustomFormat = " ";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dtpZavrseno.Format = DateTimePickerFormat.Custom;
            dtpZavrseno.CustomFormat = " ";
        }

        private void dtpDatum_ValueChanged(object sender, EventArgs e)
        {

        }
        private void StampaRadnogNaloga()
        {
            //  //string dir = Environment.SpecialFolder.MyDocuments + "\\ServisDB\\";

            string dir = System.IO.Path.Combine(Environment.GetFolderPath(
          Environment.SpecialFolder.MyDoc‌​uments), "ServisDB");

            if (Directory.Exists(dir) == false)
            {
                Directory.CreateDirectory(dir);
            }
            object o = dgvPrijave.SelectedRows[0].DataBoundItem;
            string brojnaloga = ((DataRowView)o).Row.ItemArray[1].ToString();
            string kupac = ((DataRowView)o).Row.ItemArray[4].ToString();
            string adresa = ((DataRowView)o).Row.ItemArray[5].ToString();
            string telefon = ((DataRowView)o).Row.ItemArray[6].ToString();
            string predmet = ((DataRowView)o).Row.ItemArray[11].ToString();
            DateTime datum = (DateTime)((DataRowView)o).Row.ItemArray[2];

            string serviser = ((DataRowView)o).Row.ItemArray[13].ToString();

            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("BROJNALOGA", brojnaloga);
            dict.Add("PREDMET", predmet);
            dict.Add("KUPAC", kupac+", "+telefon+", "+adresa);
            dict.Add("SERVISER", serviser);
            dict.Add("DATUM", datum.ToString("dd.MM.yyyy"));
            dict.Add("DATUMNALOGA", datum.ToString("dd.MM.yyyy"));

            string fileName = dir + "\\" + brojnaloga.Replace("/", "-") + ".docx";

            WordDocumentBuilder.FillBookmarksUsingOpenXml("RadniNalog.docx", fileName, dict);
            Process.Start(fileName);
        }

        private void btnStampaRadnogNaloga_Click(object sender, EventArgs e)
        {
            StampaRadnogNaloga();
        }
    }
}
