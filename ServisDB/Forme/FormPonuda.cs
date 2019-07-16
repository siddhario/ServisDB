using ClosedXML.Excel;
using Npgsql;
using ServisDB.Forme;
using ServisDB.Klase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMS.Core.Helpers;

namespace Delos.Forme
{
    public partial class FormPonuda : Form
    {
        public List<string> DynamicFilters { get; set; }
        public List<string> StaticFilters { get; set; }

        public FormPonuda()
        {
            InitializeComponent();
            DynamicFilters = new List<string>();

        }

        private void ReadPonuda(string broj, string kupac)
        {
            StaticFilters = new List<string>();
            StaticFilters.Add("(broj like concat(@broj,'%') or @broj is null)");
            StaticFilters.Add("(lower(partner_naziv) like concat(lower(@kupac_ime),'%') or @kupac_ime is null)");

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
                    dgvPrijave.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Datum", DataPropertyName = "datum", Width = 100, DefaultCellStyle = new DataGridViewCellStyle() { Format = "dd.MM.yyyy." } });
                    dgvPrijave.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Šifra partnera", DataPropertyName = "partner_sifra", Width = 50, Visible = false });
                    dgvPrijave.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Partner", DataPropertyName = "partner_naziv", Width = 180 });

                    dgvPrijave.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Iznos sa PDV", DataPropertyName = "iznos_sa_pdv", DefaultCellStyle = new DataGridViewCellStyle() { Format = "N2" }, Width = 120 });
                    dgvPrijave.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Status", DataPropertyName = "status", Width = 80 });
                    dgvPrijave.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Predmet", DataPropertyName = "predmet", Width = 500 });
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

                    if (broj == "")
                        p2.Value = DBNull.Value;
                    else
                        p2.Value = broj;
                    cmd.CommandText = @"SELECT broj, datum, status, napomena, predmet, radnik, 
                    partner_sifra, partner_jib, partner_adresa, partner_naziv, partner_telefon, partner_email, 
                    valuta_placanja, rok_vazenja, paritet_kod, paritet, rok_isporuke, 
                    iznos_bez_rabata, rabat, iznos_sa_rabatom, pdv, iznos_sa_pdv, nabavna_vrijednost, ruc 
	FROM public.ponuda";
                    if (filters.Count > 0)
                    {
                        cmd.CommandText += " WHERE ";
                        foreach (string f in filters)
                            cmd.CommandText += f + " AND ";
                        cmd.CommandText = cmd.CommandText.Substring(0, cmd.CommandText.Length - 4);
                    }
                    cmd.CommandText += " order by datum desc,broj desc";

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

        private void FormPonuda_Load(object sender, EventArgs e)
        {
            ReadPonuda(textBox1.Text, textBox2.Text);
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            ReadPonuda("", "");
        }

        private void lblValuta_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void Clear()
        {
            dtpDatum.Value = DateTime.Now;
            tbPartner.Text = "";
            tbTelefon.Text = "";
            tbPartnerSifra.Text = "";
            tbAdresa.Text = "";
            tbEmail.Text = "";
            tbJIB.Text = "";
            tbRokIsporuke.Text = "";
            tbRokVazenja.Text = "";
            tbValutaPlacanja.Text = "";
            tbParitet.Text = "";
            cbParitetKod.SelectedIndex = -1;
            tbIznosBezRabata.Text = "";
            tbRabat.Text = "";
            tbNabavnaVrijednost.Text = "";
            tbPdv.Text = "";
            tbIznosSaRabatom.Text = "";
            tbRUC.Text = "";
            tbIznosSaPdv.Text = "";
            tbRadnik.Text = "";
            tbPredmet.Text = "";
            tbNapomena.Text = "";
            tbStatus.Text = "E";
            tbPartner.ReadOnly = false;
            tbPartner.Focus();
            SetVisibility();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int? partnerSifra;
                if (tbPartnerSifra.Text == "")
                {
                    PersistanceManager.InsertPartner(tbPartner.Text, "P", tbJIB.Text, tbAdresa.Text, tbTelefon.Text, tbEmail.Text, true, false, "", out partnerSifra);
                    tbPartnerSifra.Text = partnerSifra.ToString();
                }
                else
                    PersistanceManager.UpdatePartner(int.Parse(tbPartnerSifra.Text), tbAdresa.Text, tbTelefon.Text, tbEmail.Text);

                if (tbRedniBroj.Text == "AUTO")
                    PersistanceManager.InsertPonuda(dtpDatum.Value, tbRadnik.Text, (tbPartnerSifra.Text != "" ? int.Parse(tbPartnerSifra.Text) : (int?)null), tbPartner.Text, tbJIB.Text, tbAdresa.Text, tbTelefon.Text, tbEmail.Text,
                      tbValutaPlacanja.Text, tbRokVazenja.Text, tbRokIsporuke.Text, cbParitetKod.SelectedItem.ToString(), tbParitet.Text,
                      tbPredmet.Text, tbNapomena.Text);
                else
                {
                    PersistanceManager.UpdatePonuda(tbRedniBroj.Text, dtpDatum.Value, tbRadnik.Text, (tbPartnerSifra.Text != "" ? int.Parse(tbPartnerSifra.Text) : (int?)null), tbPartner.Text, tbJIB.Text, tbAdresa.Text, tbTelefon.Text, tbEmail.Text,
                         tbValutaPlacanja.Text, tbRokVazenja.Text, tbRokIsporuke.Text, cbParitetKod.SelectedItem.ToString(), tbParitet.Text,
                         tbPredmet.Text, tbNapomena.Text);
                }
                tabControl1.SelectedIndex = 0;
                Clear();
                ReadPonuda("", "");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace);
                Logger.Exception(ex);
            }
        }

        private void btnKupacClear_Click(object sender, EventArgs e)
        {
            tbPartnerSifra.Text = "";
            tbTelefon.Text = "";
            tbPartner.Text = "";
            tbAdresa.Text = "";
            tbJIB.Text = "";

            tbPartner.ReadOnly = false;
        }

        private void btnPartneri_Click(object sender, EventArgs e)
        {
            FormPartner frm = new FormPartner();
            frm.DynamicFilters = new List<string>() { "kupac=true" };
            frm.AccessMode = ServisDB.Klase.Enums.AccessMode.LOOKUP;
            frm.ShowDialog();
            if (frm.Selected != null)
            {
                tbPartnerSifra.Text = frm.Selected.Sifra.ToString();
                tbPartner.Text = frm.Selected.Naziv;
                tbTelefon.Text = frm.Selected.Telefon;
                tbAdresa.Text = frm.Selected.Adresa;
                tbJIB.Text = frm.Selected.MaticniBroj;
                tbEmail.Text = frm.Selected.Email;
                tbPartner.ReadOnly = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
            tbRedniBroj.Text = "AUTO";
            Clear();
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
                        dgvPrijave_CellDoubleClick(this, null);
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
            else if (e.KeyData == Keys.F6)
            {
                btnZakljuciUgovor_Click(this, null);
            }
            else if (e.KeyData == Keys.F7)
            {
                btnRealizovan_Click(this, null);
            }
            else if (e.KeyData == Keys.F8)
            {
                btnPonudaNerealizovana_Click(this, null);
            }
            else if (e.KeyData == Keys.F9)
            {
                btnOtkljucaj_Click(this, null);
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

        private void dgvPrijave_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //broj, datum, kupac_sifra, kupac_maticni_broj, kupac_broj_lk, kupac_naziv, kupac_adresa, kupac_telefon, broj_racuna, radnik, inicijalno_placeno, iznos_bez_pdv, pdv, iznos_sa_pdv, broj_rata, suma_uplata, preostalo_za_uplatu, status, napomena


            if (dgvPrijave.SelectedRows.Count == 0)
                return;
            object o = dgvPrijave.SelectedRows[0].DataBoundItem;
            tabControl1.SelectedIndex = 1;
            tbRedniBroj.Text = ((DataRowView)o).Row.ItemArray[0].ToString();

            dtpDatum.Value = (DateTime)((DataRowView)o).Row["datum"];
            tbPredmet.Text = ((DataRowView)o).Row["predmet"].ToString();
            tbNapomena.Text = ((DataRowView)o).Row["napomena"].ToString();
            tbStatus.Text = ((DataRowView)o).Row["status"].ToString();
            tbRadnik.Text = ((DataRowView)o).Row["radnik"].ToString();

            tbValutaPlacanja.Text = ((DataRowView)o).Row["valuta_placanja"].ToString();
            tbRokIsporuke.Text = ((DataRowView)o).Row["rok_isporuke"].ToString();
            tbParitet.Text = ((DataRowView)o).Row["paritet"].ToString();
            tbRokVazenja.Text = ((DataRowView)o).Row["rok_vazenja"].ToString();
            cbParitetKod.SelectedItem = ((DataRowView)o).Row["paritet_kod"].ToString();



            tbPartnerSifra.Text = ((DataRowView)o).Row["partner_sifra"].ToString();
            tbPartner.Text = ((DataRowView)o).Row["partner_naziv"].ToString();
            tbEmail.Text = ((DataRowView)o).Row["partner_email"].ToString();
            tbJIB.Text = ((DataRowView)o).Row["partner_jib"].ToString();
            tbAdresa.Text = ((DataRowView)o).Row["partner_adresa"].ToString();
            tbTelefon.Text = ((DataRowView)o).Row["partner_telefon"].ToString();

            tbIznosBezRabata.Text = ((DataRowView)o).Row["iznos_bez_rabata"].ToString();
            tbRabat.Text = ((DataRowView)o).Row["rabat"].ToString();
            tbIznosSaRabatom.Text = ((DataRowView)o).Row["iznos_sa_rabatom"].ToString();
            tbNabavnaVrijednost.Text = ((DataRowView)o).Row["nabavna_vrijednost"].ToString();
            tbRUC.Text = ((DataRowView)o).Row["ruc"].ToString();
            tbPdv.Text = ((DataRowView)o).Row["pdv"].ToString();
            tbIznosSaPdv.Text = ((DataRowView)o).Row["iznos_sa_pdv"].ToString();

        

            SetVisibility();
        }

        private void BindPonudaStavka(List<PonudaStavka> stavke, bool unos = false)
        {
            dgvStavkePonude.DataSource = null;
            dgvStavkePonude.AutoGenerateColumns = false;
            dgvStavkePonude.Columns.Clear();
            dgvStavkePonude.Columns.Add(new DataGridViewTextBoxColumn() { Name = "RB", DataPropertyName = "StavkaBroj", Width = 50 ,ReadOnly=true});
            dgvStavkePonude.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Opis", DataPropertyName = "ArtikalNaziv", Width = 100 });
            dgvStavkePonude.Columns.Add(new DataGridViewTextBoxColumn() { Name = "JM", DataPropertyName = "JedinicaMjere", Width = 97});
            dgvStavkePonude.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Količina", DataPropertyName = "kolicina", Width = 100, DefaultCellStyle = new DataGridViewCellStyle() { Format = "N2" } });
            dgvStavkePonude.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Cijena bez PDV-a", DataPropertyName = "CijenaBezPdv", Width = 97, DefaultCellStyle = new DataGridViewCellStyle() { Format = "N2" } });
            dgvStavkePonude.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Rabat %", DataPropertyName = "RabatProcenat", Width = 97, DefaultCellStyle = new DataGridViewCellStyle() { Format = "N2" } });
            dgvStavkePonude.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Cijena bez PDV-a sa rabatom", DataPropertyName = "CijenaBezPdvSaRabatom", Width = 97, DefaultCellStyle = new DataGridViewCellStyle() { Format = "N2" } });

            dgvStavkePonude.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Iznos bez PDV-a", DataPropertyName = "IznosBezPdv", Width = 97, DefaultCellStyle = new DataGridViewCellStyle() { Format = "N2" } });

            dgvStavkePonude.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Nabavna cijena", DataPropertyName = "CijenaNabavna", Width = 97, DefaultCellStyle = new DataGridViewCellStyle() { Format = "N2" } });
            dgvStavkePonude.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Margina", DataPropertyName = "MarzaProcenat", Width = 97, DefaultCellStyle = new DataGridViewCellStyle() { Format = "N2" } });
            dgvStavkePonude.Columns.Add(new DataGridViewTextBoxColumn() { Name = "RUC", DataPropertyName = "Ruc", Width = 97, DefaultCellStyle = new DataGridViewCellStyle() { Format = "N2" } });


            dgvStavkePonude.DataSource = new BindingList<PonudaStavka>(stavke);
          
          
        }

        private void SetVisibility()
        {
            tbPartner.ReadOnly = tbPartnerSifra.Text != "";

            tbRokIsporuke.ReadOnly = tbStatus.Text != "E";
            tbRokVazenja.ReadOnly = tbStatus.Text != "E";
            tbValutaPlacanja.ReadOnly = tbStatus.Text != "E";
            tbParitet.ReadOnly = tbStatus.Text != "E";
            cbParitetKod.Enabled = tbStatus.Text == "E";

            tbPredmet.ReadOnly = tbStatus.Text != "E";
            tbRadnik.ReadOnly = tbStatus.Text != "E";
            dtpDatum.Enabled = tbStatus.Text == "E";

            tbPartner.ReadOnly = tbStatus.Text != "E";
            tbPartnerSifra.ReadOnly = tbStatus.Text != "E";
            tbAdresa.ReadOnly = tbStatus.Text != "E";
            tbEmail.ReadOnly = tbStatus.Text != "E";
            tbTelefon.ReadOnly = tbStatus.Text != "E";
            tbJIB.ReadOnly = tbStatus.Text != "E";

            btnKupacClear.Visible = tbStatus.Text == "E";
            btnPartneri.Visible = tbStatus.Text == "E";


        }

        private void btnStampa_Click(object sender, EventArgs e)
        {
            Stampa();
        }
        private void Stampa()
        {
            //string dir = Environment.SpecialFolder.MyDocuments + "\\ServisDB\\";

            string dir = System.IO.Path.Combine(Environment.GetFolderPath(
          Environment.SpecialFolder.MyDoc‌​uments), "ServisDB");

            if (Directory.Exists(dir) == false)
            {
                Directory.CreateDirectory(dir);
            }



            XLWorkbook doc = new XLWorkbook("PONUDA.xlsx");
            //doc.Worksheets.Add("PRIJAVA");

            var sheet = doc.Worksheet(1);

            object o = dgvPrijave.SelectedRows[0].DataBoundItem;

            string rednibroj = ((DataRowView)o).Row["broj"].ToString();
            string datum = ((DateTime)((DataRowView)o).Row["datum"]).Date.ToString("dd.MM.yyyy");
            string partner_naziv = ((DataRowView)o).Row["partner_naziv"].ToString();
            string partner_jib = ((DataRowView)o).Row["partner_jib"].ToString();
            string partner_adresa = ((DataRowView)o).Row["partner_adresa"].ToString();

            string valuta = ((DataRowView)o).Row["valuta_placanja"].ToString();
            string opcija_ponude = ((DataRowView)o).Row["rok_vazenja"].ToString();
            string rok_isporuke = ((DataRowView)o).Row["rok_isporuke"].ToString();
            string paritet = ((DataRowView)o).Row["paritet"].ToString();
            string paritet_kod = ((DataRowView)o).Row["paritet_kod"].ToString();
            string radnik = ((DataRowView)o).Row["radnik"].ToString();

            string iznos_bez_pdv = ((DataRowView)o).Row["iznos_bez_rabata"].ToString();
            string rabat = ((DataRowView)o).Row["rabat"].ToString();
            string iznos_sa_rabatom = ((DataRowView)o).Row["iznos_sa_rabatom"].ToString();
            string pdv = ((DataRowView)o).Row["pdv"].ToString();
            string iznos_sa_pdv = ((DataRowView)o).Row["iznos_sa_pdv"].ToString();
            //string garantnilist = ((DataRowView)o).Row.ItemArray[21].ToString();
            //string kupac = ((DataRowView)o).Row.ItemArray[4].ToString();
            //string kupac_telefon = ((DataRowView)o).Row.ItemArray[6].ToString();
            //string model = ((DataRowView)o).Row.ItemArray[8].ToString();
            //string serijski_broj = ((DataRowView)o).Row.ItemArray[9].ToString();
            //string dodatna_oprema = ((DataRowView)o).Row.ItemArray[10].ToString();
            //string opis_kvara = ((DataRowView)o).Row.ItemArray[11].ToString();
            //string napomena_servisera = ((DataRowView)o).Row.ItemArray[12].ToString();
            //string serviser = ((DataRowView)o).Row.ItemArray[13].ToString();
            //string zavrseno = "";
            //if (((DataRowView)o).Row.ItemArray[15] == DBNull.Value)
            //{
            //    zavrseno = "";
            //}
            //else
            //{
            //    zavrseno = ((DateTime)((DataRowView)o).Row.ItemArray[15]).ToString();
            //}
            string broj = rednibroj;
            string[] parts = rednibroj.Split('/');
            string rb = parts[0];
            string year = parts[1];
            int rrb = int.Parse(rb);
            rednibroj = rrb.ToString("D4") + "/" + year;
            sheet.Cells("A3").Value = "PONUDA BROJ: " + rednibroj;
            sheet.Cells("A3").DataType = XLDataType.Text;

            sheet.Cells("G2").Value = datum;
            sheet.Cells("G2").DataType = XLDataType.Text;

            sheet.Cells("B7").Value = partner_naziv;
            sheet.Cells("B7").DataType = XLDataType.Text;

            sheet.Cells("B8").Value = partner_jib;
            sheet.Cells("B8").DataType = XLDataType.Text;

            sheet.Cells("B9").Value = partner_adresa;
            sheet.Cells("B9").DataType = XLDataType.Text;

            sheet.Cells("F7").Value = valuta;
            sheet.Cells("F7").DataType = XLDataType.Text;

            sheet.Cells("F8").Value = opcija_ponude;
            sheet.Cells("F8").DataType = XLDataType.Text;

            sheet.Cells("F9").Value = rok_isporuke;
            sheet.Cells("F9").DataType = XLDataType.Text;

            sheet.Cells("F10").Value = paritet_kod + " " + paritet;
            sheet.Cells("F10").DataType = XLDataType.Text;

            List<PonudaStavka> stavke = PersistanceManager.ReadPonudaStavka(broj);
            int index = 0;
            string rowIndex = (14 + index).ToString();
            foreach (var stavka in stavke)
            {                
                rowIndex = (14 + index).ToString();
                sheet.Cells("A"+ rowIndex).Value = stavka.StavkaBroj.ToString();
                sheet.Cells("A"+ rowIndex).DataType = XLDataType.Text;

                sheet.Cells("B" + rowIndex).Value = stavka.ArtikalNaziv.ToString();
                sheet.Cells("B" + rowIndex).DataType = XLDataType.Text;

                sheet.Cells("C" + rowIndex).Value = stavka.JedinicaMjere.ToString();
                sheet.Cells("C" + rowIndex).DataType = XLDataType.Text;

                sheet.Cells("D" + rowIndex).Value = stavka.Kolicina.ToString();
                sheet.Cells("D" + rowIndex).DataType = XLDataType.Text;

                sheet.Cells("E" + rowIndex).Value = stavka.CijenaBezPdv.ToString();
                sheet.Cells("E" + rowIndex).DataType = XLDataType.Text;

                sheet.Cells("F" + rowIndex).Value = stavka.RabatProcenat.ToString();
                sheet.Cells("F" + rowIndex).DataType = XLDataType.Text;

                sheet.Cells("G" + rowIndex).Value = stavka.IznosBezPdv.ToString();
                sheet.Cells("G" + rowIndex).DataType = XLDataType.Text;

                index++;
            }


            sheet.Cells("A" + (14 + stavke.Count + 2).ToString()).Value = "UKUPAN IZNOS BEZ RABATA";
            sheet.Cells("A" + (14 + stavke.Count + 2).ToString()).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

            sheet.Cells("A" + (14 + stavke.Count + 3).ToString()).Value = "IZNOS RABATA";
            sheet.Cells("A" + (14 + stavke.Count + 3).ToString()).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

            sheet.Cells("A" + (14 + stavke.Count + 4).ToString()).Value = "UKUPAN IZNOS BEZ PDV";
            sheet.Cells("A" + (14 + stavke.Count + 4).ToString()).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

            sheet.Cells("A" + (14 + stavke.Count + 5).ToString()).Value = "PDV";
            sheet.Cells("A" + (14 + stavke.Count + 5).ToString()).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

            sheet.Cells("A" + (14 + stavke.Count + 6).ToString()).Value = "UKUPAN IZNOS SA PDV";
            sheet.Cells("A" + (14 + stavke.Count + 6).ToString()).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

            sheet.Range("A" + (14 + stavke.Count + 2).ToString()+":"+ "F" + (14 + stavke.Count + 2).ToString()).Row(1).Merge();
            sheet.Range("A" + (14 + stavke.Count + 3).ToString() + ":" + "F" + (14 + stavke.Count + 3).ToString()).Row(1).Merge();
            sheet.Range("A" + (14 + stavke.Count + 4).ToString() + ":" + "F" + (14 + stavke.Count + 4).ToString()).Row(1).Merge();
            sheet.Range("A" + (14 + stavke.Count + 5).ToString() + ":" + "F" + (14 + stavke.Count + 5).ToString()).Row(1).Merge();
            sheet.Range("A" + (14 + stavke.Count + 6).ToString() + ":" + "F" + (14 + stavke.Count + 6).ToString()).Row(1).Merge();


            sheet.Cells("G" + (14+stavke.Count+2).ToString()).Value = iznos_bez_pdv;
            sheet.Cells("G" + rowIndex).DataType = XLDataType.Text;

            sheet.Cells("G" + (14 + stavke.Count + 3).ToString()).Value = rabat;
            sheet.Cells("G" + rowIndex).DataType = XLDataType.Text;

            sheet.Cells("G" + (14 + stavke.Count + 4).ToString()).Value = iznos_sa_rabatom;
            sheet.Cells("G" + rowIndex).DataType = XLDataType.Text;

            sheet.Cells("G" + (14 + stavke.Count + 5).ToString()).Value = pdv;
            sheet.Cells("G" + rowIndex).DataType = XLDataType.Text;

            sheet.Cells("G" + (14 + stavke.Count + 6).ToString()).Value = iznos_sa_pdv;
            sheet.Cells("G" + rowIndex).DataType = XLDataType.Text;

            sheet.Cells("E" + (14 + stavke.Count + 8).ToString()).Value = "Dokument sastavio:";
            sheet.Cells("F" + (14 + stavke.Count + 8).ToString()).Value = radnik;

            sheet.Cells("F" + (14 + stavke.Count + 12).ToString()).Value = "M.P.";
            sheet.Cells("A" + (14 + stavke.Count + 16).ToString()).Value = "Hvala na povjerenju!";
            sheet.Range("A" + (14 + stavke.Count + 16).ToString() + ":" + "G" + (14 + stavke.Count + 16).ToString()).Row(1).Merge();
            sheet.Cells("A" + (14 + stavke.Count + 16).ToString()).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            var imagePath = "footer.jpg";

            var image = sheet.AddPicture(imagePath)
                .MoveTo(sheet.Cell("A"+( 14 + stavke.Count + 16).ToString())).Scale(0.1);

            string fileName = dir + "\\Ponuda_" + rednibroj.Replace("/", "-") + ".xlsx";
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

        private void btnBrisanje_Click(object sender, EventArgs e)
        {

            object o = dgvPrijave.SelectedRows[0].DataBoundItem;
            string rb = ((DataRowView)o).Row.ItemArray[0].ToString();
            if (MessageBox.Show(string.Format("Obrisati podnudu {0} ?", rb), "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                PersistanceManager.DeleteUgovor(rb);
                MessageBox.Show(string.Format("Ponuda {0} je uspješno obrisana!", rb), "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                tabControl1.SelectedIndex = 0;
                Clear();
                ReadPonuda(textBox1.Text, textBox2.Text);
            }

        }

        private void btnZakljuciUgovor_Click(object sender, EventArgs e)
        {
            object o = dgvPrijave.SelectedRows[0].DataBoundItem;
            string rb = ((DataRowView)o).Row.ItemArray[0].ToString();
            if (MessageBox.Show(string.Format("Zaključiti ponudu {0} ?", rb), "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                PersistanceManager.UpdatePonuda(rb, "Z");
                MessageBox.Show(string.Format("Ponuda {0} je uspješno zaključena!", rb), "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                Stampa();
                ReadPonuda(textBox1.Text, textBox2.Text);
                tabControl1.SelectedIndex = 0;
                Clear();
                ReadPonuda("", "");
            }
        }
        private void rbRealizovani_Click(object sender, EventArgs e)
        {
            DynamicFilters.Clear();
            DynamicFilters.Add("status='R'");
            ReadPonuda("", "");
        }

        private void rbUtoku_Click(object sender, EventArgs e)
        {
            DynamicFilters.Clear();
            DynamicFilters.Add("status='Z'");
            ReadPonuda("", "");
        }

        private void rbNerealizovani_Click(object sender, EventArgs e)
        {
            DynamicFilters.Clear();
            DynamicFilters.Add("status='N'");
            ReadPonuda("", "");
        }

        private void rbSviUgovori_Click(object sender, EventArgs e)
        {
            DynamicFilters.Clear();
            ReadPonuda("", "");
        }
        private void btnRealizovan_Click(object sender, EventArgs e)
        {
            object o = dgvPrijave.SelectedRows[0].DataBoundItem;
            string rb = ((DataRowView)o).Row.ItemArray[0].ToString();
            if (MessageBox.Show(string.Format("Proglasiti ponudu {0} realizovanom ?", rb), "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                // PersistanceManager.UpdateUgovor(rb, "Z");
                PersistanceManager.UpdatePonuda(rb, "R");
                MessageBox.Show(string.Format("Ponuda {0} je realizovana.", rb), "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                //Stampa();
                ReadPonuda(textBox1.Text, textBox2.Text);
                tabControl1.SelectedIndex = 0;
                Clear();
                ReadPonuda("", "");
            }
        }

        private void btnOtkljucaj_Click(object sender, EventArgs e)
        {
            object o = dgvPrijave.SelectedRows[0].DataBoundItem;
            string rb = ((DataRowView)o).Row.ItemArray[0].ToString();
            if (MessageBox.Show(string.Format("Otključati ponudu {0} ?", rb), "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                PersistanceManager.UpdatePonuda(rb, "E");
                MessageBox.Show(string.Format("Ponuda {0} je uspješno otključana!", rb), "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                //Stampa();
                ReadPonuda(textBox1.Text, textBox2.Text);
                tabControl1.SelectedIndex = 0;
                Clear();
                ReadPonuda("", "");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

            ReadPonuda(textBox1.Text, textBox2.Text);
        }

        private void btnPonudaNerealizovana_Click(object sender, EventArgs e)
        {
            object o = dgvPrijave.SelectedRows[0].DataBoundItem;
            string rb = ((DataRowView)o).Row.ItemArray[0].ToString();
            if (MessageBox.Show(string.Format("Proglasiti ponudu {0} nerealizovanom ?", rb), "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                // PersistanceManager.UpdateUgovor(rb, "Z");
                PersistanceManager.UpdatePonuda(rb, "N");
                MessageBox.Show(string.Format("Ponuda {0} je nerealizovana.", rb), "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                //Stampa();
                ReadPonuda(textBox1.Text, textBox2.Text);
                tabControl1.SelectedIndex = 0;
                Clear();
                ReadPonuda("", "");
            }
        }

        private void dgvPrijave_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            //= dgvPrijave.Rows[e.RowIndex].Cells[10].Value.ToString();
            object o = dgvPrijave.Rows[e.RowIndex].DataBoundItem;
            string i = ((DataRowView)o).Row["status"].ToString();
            if (i == "R")
            {
                //dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.PaleGreen;
                //dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                dgvPrijave.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Green;
                dgvPrijave.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("Tahoma", 10, FontStyle.Regular);
            }
            if (i == "N")
            {
                //dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.PaleGreen;
                //dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                dgvPrijave.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                dgvPrijave.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("Tahoma", 10, FontStyle.Regular);
            }
            else if (i == "Z")
            {

                dgvPrijave.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                dgvPrijave.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("Tahoma", 10, FontStyle.Regular);
            }
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

                    ReadPonuda(textBox1.Text, "");
                    textBox1.Text = "";
                    dgvPrijave_CellDoubleClick(this, null);
                    tbNapomena.Focus();
                    tbNapomena.Select();
                    //textBox1.Text = "";
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
                tbPartner.Focus();
            else
            {
                textBox1.Focus();
                textBox1.Select();
            }
        }

        private void dgvPrijave_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPrijave.SelectedRows.Count == 0)
                return;
            object o = dgvPrijave.SelectedRows[0].DataBoundItem;
            string status = (string)(((DataRowView)o).Row["status"].ToString());

            if (status == "E")
            {
                btnZakljuciUgovor.Enabled = true;
                btnBrisanje.Enabled = true;
                btnRealizovan.Enabled = false;
                btnPonudaNerealizovana.Enabled = false;
                btnOtkljucaj.Enabled = false;
            }
            else if (status == "Z")
            {
                btnZakljuciUgovor.Enabled = false;
                btnBrisanje.Enabled = false;
                btnRealizovan.Enabled = true;
                btnPonudaNerealizovana.Enabled = true;
                btnOtkljucaj.Enabled = true;
            }
            else if (status == "N")
            {
                btnZakljuciUgovor.Enabled = false;
                btnBrisanje.Enabled = false;
                btnRealizovan.Enabled = true;
                btnPonudaNerealizovana.Enabled = false;
                btnOtkljucaj.Enabled = true;
            }
            else if (status == "R")
            {
                btnZakljuciUgovor.Enabled = false;
                btnBrisanje.Enabled = true;
                btnRealizovan.Enabled = false;
                btnPonudaNerealizovana.Enabled = true;
                btnOtkljucaj.Enabled = true;
            }
            string redni_broj = ((DataRowView)dgvPrijave.SelectedRows[0].DataBoundItem).Row["broj"].ToString();
            List<PonudaStavka> stavke = PersistanceManager.ReadPonudaStavka(redni_broj);
            BindPonudaStavka(stavke);
        }

        private void dgvStavkePonude_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            PonudaStavka stavka = (PonudaStavka)dgvStavkePonude.Rows[e.RowIndex].DataBoundItem;
            object newValue = dgvStavkePonude.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            if (newValue == null)
                return;
            string newValueString = newValue.ToString();
            switch (dgvStavkePonude.Columns[e.ColumnIndex].DataPropertyName.ToLower())
            {
                case "kolicina":
                    {
                        decimal kolicina;
                        bool s1 = decimal.TryParse(newValueString, out kolicina);
                        if(s1==true)
                        {                         
                            decimal rabat = Math.Round(kolicina * stavka.CijenaBezPdv * stavka.RabatProcenat / 100,2,MidpointRounding.AwayFromZero);
                            decimal iznosBezPdvSaRabatom = Math.Round(kolicina * stavka.CijenaBezPdv - rabat, 2, MidpointRounding.AwayFromZero);
                            stavka.IznosBezPdv = iznosBezPdvSaRabatom;
                        }
                        break;
                    }

                case "cijenabezpdv":
                    {
                        decimal cijena_bez_pdv;
                        bool s1 = decimal.TryParse(newValueString, out cijena_bez_pdv);
                        if (s1 == true)
                        {
                            decimal rabat = Math.Round(stavka.Kolicina * cijena_bez_pdv * stavka.RabatProcenat / 100, 2, MidpointRounding.AwayFromZero);
                            decimal iznosBezPdvSaRabatom = Math.Round(stavka.Kolicina * cijena_bez_pdv - rabat, 2, MidpointRounding.AwayFromZero);
                            stavka.IznosBezPdv = iznosBezPdvSaRabatom;
                        }
                        break;
                    }
                case "rabatprocenat":
                    {
                        decimal rabatprocenat;
                        bool s1 = decimal.TryParse(newValueString, out rabatprocenat);
                        if (s1 == true)
                        {
                            decimal rabat = Math.Round(stavka.Kolicina * stavka.CijenaBezPdv * rabatprocenat / 100, 2, MidpointRounding.AwayFromZero);
                            decimal iznosBezPdvSaRabatom = Math.Round(stavka.Kolicina * stavka.CijenaBezPdv - rabat, 2, MidpointRounding.AwayFromZero);
                            stavka.IznosBezPdv = iznosBezPdvSaRabatom;
                        }
                        break;
                    }
                case "cijenanabavna":
                    {
                        decimal cijenanabavna;
                        bool s1 = decimal.TryParse(newValueString, out cijenanabavna);
                        if (s1 == true)
                        {
                            decimal ruc = Math.Round(stavka.Kolicina * stavka.CijenaNabavna * stavka.MarzaProcenat / 100, 2, MidpointRounding.AwayFromZero) ;
                            stavka.Ruc = ruc;
                            decimal iznosBezPdv = Math.Round(stavka.Kolicina * stavka.CijenaNabavna, 2, MidpointRounding.AwayFromZero)+stavka.Ruc;
                            stavka.IznosBezPdv = iznosBezPdv;

                        }
                        break;
                    }

                case "marzaprocenat":
                    {
                        decimal marzaprocenat;
                        bool s1 = decimal.TryParse(newValueString, out marzaprocenat);
                        if (s1 == true)
                        {
                            decimal ruc = Math.Round(stavka.Kolicina * stavka.CijenaNabavna * stavka.MarzaProcenat / 100, 2, MidpointRounding.AwayFromZero);
                            stavka.Ruc = ruc;
                            decimal iznosBezPdv = Math.Round(stavka.Kolicina * stavka.CijenaNabavna, 2, MidpointRounding.AwayFromZero) + stavka.Ruc;
                            stavka.IznosBezPdv = iznosBezPdv;
                        }
                        break;
                    }
            }
            PersistanceManager.UpdatePonudaStavka(stavka);

        }

        private void dgvStavkePonude_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("f");
        }

        private void dgvStavkePonude_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
           
        }

        private void dgvStavkePonude_RowValidated_1(object sender, DataGridViewCellEventArgs e)
        {            
         
        }

        private void dgvStavkePonude_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {

            try
            {
                object o = dgvPrijave.SelectedRows[0].DataBoundItem;
                string broj = ((DataRowView)o).Row["broj"].ToString();

                PonudaStavka stavka = (PonudaStavka)dgvStavkePonude.Rows[e.RowIndex]?.DataBoundItem;
                if (stavka == null)
                    return;
                if (stavka.PonudaBroj == null)
                {
                    if (stavka.ArtikalNaziv == null)
                    {
                        e.Cancel = true;
                        return;
                    }
                    stavka.PonudaBroj = broj;
                    stavka.StavkaBroj = ((BindingList<PonudaStavka>)dgvStavkePonude.DataSource).Where(ps => ps.PonudaBroj != null).Max(ps => ps.StavkaBroj) + 1;
                    PersistanceManager.InsertPonudaStavka(stavka);
                }
            }
            catch (Exception ex) { }
        }

        private void dgvStavkePonude_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            PonudaStavka stavka = (PonudaStavka)e.Row.DataBoundItem;
            PersistanceManager.DeletePonudaStavka(stavka);
        }
    }
}
