using ClosedXML.Excel;
using Delos.Klase;
using Npgsql;
//using RawPrint;
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
using System.Net.Mail;
using System.Text;
using System.Threading;
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
            StaticFilters.Add("(broj in (select Ponuda_broj from ponuda_stavka where lower(artikal_naziv) like concat(lower(@kupac_ime),'%')) or (lower(partner_naziv) like concat(lower(@kupac_ime),'%') or @kupac_ime is null))");

            List<string> filters = new List<string>();
            filters = filters.Concat(StaticFilters).ToList();
            if (DynamicFilters != null)
                filters = filters.Concat(DynamicFilters).ToList();

            List<Ponuda> ponude = PersistanceManager.ReadPonuda(broj, kupac,filters);
            dgvPrijave.DataSource = null;
            dgvPrijave.AutoGenerateColumns = false;

            dgvPrijave.Columns.Clear();
            dgvPrijave.Columns.Add(new DataGridViewTextBoxColumn() { Name = "R.broj", DataPropertyName = "Broj", Width = 80 });
            dgvPrijave.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Datum", DataPropertyName = "Datum", Width = 100, DefaultCellStyle = new DataGridViewCellStyle() { Format = "dd.MM.yyyy." } });
            dgvPrijave.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Šifra partnera", DataPropertyName = "PartnerSifra", Width = 50, Visible = false });
            dgvPrijave.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Partner", DataPropertyName = "PartnerNaziv", Width = 180 });

            dgvPrijave.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Iznos sa PDV", DataPropertyName = "IznosSaPdv", DefaultCellStyle = new DataGridViewCellStyle() { Format = "N2" }, Width = 120 });
            dgvPrijave.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Status", DataPropertyName = "Status", Width = 80 });
            dgvPrijave.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Predmet", DataPropertyName = "Predmet", Width = 500 });

            dgvPrijave.DataSource = new BindingList<Ponuda>(ponude);
        }

        private void ReadPonuda2(string broj, string kupac)
        {
            StaticFilters = new List<string>();
            StaticFilters.Add("(broj like concat(@broj,'%') or @broj is null)");
            StaticFilters.Add("(broj in (select Ponuda_broj from ponuda_stavka where lower(artikal_naziv) like concat(lower(@kupac_ime),'%')) or (lower(partner_naziv) like concat(lower(@kupac_ime),'%') or @kupac_ime is null))");

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
            //            foreach (string printerName in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            //            {
            //                MessageBox.Show(printerName);
            //            }

            //            /** Outputs something like:

            //Send To OneNote 2016
            //Microsoft XPS Document Writer
            //Microsoft Print to PDF
            //Fax
            //Brother HL-3172CDW series Printer

            //*/
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
            tbRadnik.Text = PersistanceManager.GetKorisnik().KorisnickoIme;
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
            FillDetailView();
        }

        private void FillDetailView()
        {
            if (dgvPrijave.SelectedRows.Count == 0)
                return;
            //object o = dgvPrijave.SelectedRows[0].DataBoundItem;
            Ponuda o = (Ponuda)dgvPrijave.SelectedRows[0].DataBoundItem;

            tbRedniBroj.Text = o.Broj;

            dtpDatum.Value = o.Datum;
            tbPredmet.Text = o.Predmet;
            tbNapomena.Text = o.Napomena;
            tbStatus.Text = o.Status;
            tbRadnik.Text = o.Radnik;

            tbValutaPlacanja.Text = o.ValutaPlacanja;
            tbRokIsporuke.Text = o.RokIsporuke;
            tbParitet.Text = o.Paritet;
            tbRokVazenja.Text = o.RokVazenja;
            cbParitetKod.SelectedItem = o.ParitetKod;
            tabControl1.SelectedIndex = 1;


            tbPartnerSifra.Text = o.PartnerSifra.ToString();
            tbPartner.Text = o.PartnerNaziv;
            tbEmail.Text = o.PartnerEmail;
            tbJIB.Text = o.PartnerJib;
            tbAdresa.Text = o.PartnerAdresa;
            tbTelefon.Text = o.PartnerTelefon;

            tbIznosBezRabata.Text =o.IznosBezRabata.ToString();
            tbRabat.Text = o.Rabat.ToString();
            tbIznosSaRabatom.Text = o.IznosSaRabatom.ToString();
            tbPdv.Text = o.Pdv.ToString();
            tbRUC.Text =o.Ruc!=null? o.Ruc.ToString():"";
            tbNabavnaVrijednost.Text = o.NabavnaVrijednost!=null? o.NabavnaVrijednost.ToString():"";
            tbIznosSaPdv.Text = o.IznosSaPdv.ToString();



            SetVisibility();
        }

        private void BindPonudaStavka(List<PonudaStavka> stavke, bool unos = false)
        {
            dgvStavkePonude.DataSource = null;
            dgvStavkePonude.AutoGenerateColumns = false;
            dgvStavkePonude.Columns.Clear();
            dgvStavkePonude.Columns.Add(new DataGridViewTextBoxColumn() { ReadOnly = true, Name = "RB", DataPropertyName = "StavkaBroj", Width = 50 });
            dgvStavkePonude.Columns.Add(new DataGridViewTextBoxColumn() { ReadOnly = false, Name = "Opis", DataPropertyName = "ArtikalNaziv", Width = 300 });
            dgvStavkePonude.Columns.Add(new DataGridViewTextBoxColumn() { ReadOnly = false, Name = "JM", DataPropertyName = "JedinicaMjere", Width = 45 });

            dgvStavkePonude.Columns.Add(new DataGridViewTextBoxColumn() { ReadOnly = false, Name = "Količina", DataPropertyName = "kolicina", Width = 55, DefaultCellStyle = new DataGridViewCellStyle() { Format = "N2" } });

            dgvStavkePonude.Columns.Add(new DataGridViewTextBoxColumn() { ReadOnly = false, Name = "Nabavna cijena", DataPropertyName = "CijenaNabavna", Width = 90, DefaultCellStyle = new DataGridViewCellStyle() { Format = "N2" } });
            dgvStavkePonude.Columns.Add(new DataGridViewTextBoxColumn() { ReadOnly = true, Name = "Nabavna vrijednost", DataPropertyName = "VrijednostNabavna", Width = 90, DefaultCellStyle = new DataGridViewCellStyle() { Format = "N2" } });

            dgvStavkePonude.Columns.Add(new DataGridViewTextBoxColumn() { ReadOnly = false, Name = "Margina %", DataPropertyName = "MarzaProcenat", Width = 60, DefaultCellStyle = new DataGridViewCellStyle() { Format = "N2" } });
            dgvStavkePonude.Columns.Add(new DataGridViewTextBoxColumn() { ReadOnly = true, Name = "RUC", DataPropertyName = "Ruc", Width = 90, DefaultCellStyle = new DataGridViewCellStyle() { Format = "N2" } });

            dgvStavkePonude.Columns.Add(new DataGridViewTextBoxColumn() { ReadOnly = false, Name = "Cijena bez PDV-a", DataPropertyName = "CijenaBezPdv", Width = 90, DefaultCellStyle = new DataGridViewCellStyle() { Format = "N2" } });
            dgvStavkePonude.Columns.Add(new DataGridViewTextBoxColumn() { ReadOnly = true, Name = "Iznos bez PDV-a", DataPropertyName = "IznosBezPdv", Width = 90, DefaultCellStyle = new DataGridViewCellStyle() { Format = "N2" } });

            dgvStavkePonude.Columns.Add(new DataGridViewTextBoxColumn() { ReadOnly = false, Name = "Rabat %", DataPropertyName = "RabatProcenat", Width = 50, DefaultCellStyle = new DataGridViewCellStyle() { Format = "N2" } });
            dgvStavkePonude.Columns.Add(new DataGridViewTextBoxColumn() { ReadOnly = true, Name = "Rabat iznos", DataPropertyName = "RabatIznos", Width = 90, DefaultCellStyle = new DataGridViewCellStyle() { Format = "N2" } });

            dgvStavkePonude.Columns.Add(new DataGridViewTextBoxColumn() { ReadOnly = true, Name = "Cijena bez PDV-a sa rabatom", DataPropertyName = "CijenaBezPdvSaRabatom", Width = 90, DefaultCellStyle = new DataGridViewCellStyle() { Format = "N2" } });
            dgvStavkePonude.Columns.Add(new DataGridViewTextBoxColumn() { ReadOnly = true, Name = "Iznos bez PDV-a sa rabatom", DataPropertyName = "IznosBezPdvSaRabatom", Width = 90, DefaultCellStyle = new DataGridViewCellStyle() { Format = "N2" } });


            dgvStavkePonude.Columns.Add(new DataGridViewTextBoxColumn() { ReadOnly = true, Name = "PDV %", DataPropertyName = "PdvStopa", Width = 50, DefaultCellStyle = new DataGridViewCellStyle() { Format = "N2" } });
            dgvStavkePonude.Columns.Add(new DataGridViewTextBoxColumn() { ReadOnly = true, Name = "PDV iznos", DataPropertyName = "Pdv", Width = 90, DefaultCellStyle = new DataGridViewCellStyle() { Format = "N2" } });
            dgvStavkePonude.Columns.Add(new DataGridViewTextBoxColumn() { ReadOnly = true, Name = "Iznos sa PDV", DataPropertyName = "IznosSaPdv", Width = 90, DefaultCellStyle = new DataGridViewCellStyle() { Format = "N2" } });


            dgvStavkePonude.DataSource = new BindingList<PonudaStavka>(stavke);


        }

        private void BindPonudaDokument(List<PonudaDokument> dokumenti, bool unos = false)
        {
            dgvDokumenti.DataSource = null;
            dgvDokumenti.AutoGenerateColumns = false;
            dgvDokumenti.Columns.Clear();
            dgvDokumenti.Columns.Add(new DataGridViewTextBoxColumn() { ReadOnly = true, Name = "RB", DataPropertyName = "DokumentBroj", Width = 50 });
            dgvDokumenti.Columns.Add(new DataGridViewTextBoxColumn() { ReadOnly = false, Name = "Naziv", DataPropertyName = "Naziv", Width = 500 });
            //dgvDokumenti.Columns.Add(new DataGridViewTextBoxColumn() { ReadOnly = false, Name = "Opis", DataPropertyName = "Opis", Width = 90 });

            dgvDokumenti.DataSource = new BindingList<PonudaDokument>(dokumenti);
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
            //tbRadnik.ReadOnly = tbStatus.Text != "E";
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
            string fileName = Stampa();
            if (fileName != null)
                Process.Start(fileName);
        }
        private string Stampa()
        {
            //string dir = Environment.SpecialFolder.MyDocuments + "\\ServisDB\\";

            string dir = System.IO.Path.Combine(Environment.GetFolderPath(
          Environment.SpecialFolder.MyDoc‌​uments), "ServisDB\\temp");

            if (Directory.Exists(dir) == false)
            {
                Directory.CreateDirectory(dir);
            }



            XLWorkbook doc = new XLWorkbook("PONUDA.xlsx");
            //doc.Worksheets.Add("PRIJAVA");

            var sheet = doc.Worksheet(1);

            object o = dgvPrijave.SelectedRows[0].DataBoundItem;
            string rednibroj = ((Ponuda)o).Broj;


            StaticFilters = new List<string>();
            StaticFilters.Add("(broj like concat(@broj,'%') or @broj is null)");
            StaticFilters.Add("(broj in (select Ponuda_broj from ponuda_stavka where lower(artikal_naziv) like concat(lower(@kupac_ime),'%')) or (lower(partner_naziv) like concat(lower(@kupac_ime),'%') or @kupac_ime is null))");

            List<string> filters = new List<string>();
            filters = filters.Concat(StaticFilters).ToList();
            if (DynamicFilters != null)
                filters = filters.Concat(DynamicFilters).ToList();

            Ponuda p = PersistanceManager.ReadPonuda(rednibroj, "", filters).FirstOrDefault();
        

            //string rednibroj = p.Broj;
            string datum = p.Datum.Date.ToString("dd.MM.yyyy");
            string partner_naziv = p.PartnerNaziv;
            string partner_jib = p.PartnerJib;
            string partner_adresa = p.PartnerAdresa;

            string valuta = p.ValutaPlacanja;
            string opcija_ponude = p.RokVazenja;
            string rok_isporuke = p.RokIsporuke;
            string paritet = p.Paritet;
            string paritet_kod = p.ParitetKod;
            string radnik = p.Radnik;

            string iznos_bez_pdv = p.IznosBezRabata.ToString();
            string rabat = p.Rabat.ToString();
            string iznos_sa_rabatom = p.IznosSaRabatom.ToString();
            string pdv = p.Pdv.ToString();
            string iznos_sa_pdv = p.IznosSaPdv.ToString();

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
                sheet.Row(14 + index).Height = 20;
                sheet.Row(14 + index).Style.Font.FontName = "Arial";
                sheet.Row(14 + index).Style.Font.FontSize = 10;
                sheet.Row(14 + index).Style.Font.FontColor = XLColor.Black;
                sheet.Row(14 + index).Style.Font.Bold = false;
                sheet.Row(14 + index).Style.Alignment.Vertical = XLAlignmentVerticalValues.Bottom;

                sheet.Cells("A" + rowIndex).Value = stavka.StavkaBroj.ToString();
                sheet.Cells("A" + rowIndex).DataType = XLDataType.Text;
                sheet.Cells("A" + rowIndex).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                sheet.Cells("A" + rowIndex).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                sheet.Cells("A" + rowIndex).Style.Border.OutsideBorderColor = XLColor.FromArgb(216, 228, 188);


                sheet.Cells("B" + rowIndex).Value = stavka.ArtikalNaziv.ToString();
                sheet.Cells("B" + rowIndex).DataType = XLDataType.Text;
                sheet.Cells("B" + rowIndex).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                sheet.Cells("B" + rowIndex).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                sheet.Cells("B" + rowIndex).Style.Border.OutsideBorderColor = XLColor.FromArgb(216, 228, 188);

                sheet.Cells("C" + rowIndex).Value = stavka.JedinicaMjere.ToString();
                sheet.Cells("C" + rowIndex).DataType = XLDataType.Text;
                sheet.Cells("C" + rowIndex).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                sheet.Cells("C" + rowIndex).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                sheet.Cells("C" + rowIndex).Style.Border.OutsideBorderColor = XLColor.FromArgb(216, 228, 188);

                sheet.Cells("D" + rowIndex).Value = stavka.Kolicina.ToString();
                sheet.Cells("D" + rowIndex).DataType = XLDataType.Number;
                sheet.Cells("D" + rowIndex).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                sheet.Cells("D" + rowIndex).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                sheet.Cells("D" + rowIndex).Style.Border.OutsideBorderColor = XLColor.FromArgb(216, 228, 188);

                sheet.Cells("E" + rowIndex).Value = stavka.CijenaBezPdv.ToString();
                sheet.Cells("E" + rowIndex).DataType = XLDataType.Number;
                sheet.Cells("E" + rowIndex).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                sheet.Cells("E" + rowIndex).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                sheet.Cells("E" + rowIndex).Style.Border.OutsideBorderColor = XLColor.FromArgb(216, 228, 188);
                sheet.Cells("E" + rowIndex).Style.NumberFormat.Format = "#,##0.00 \"KM\"";

                sheet.Cells("F" + rowIndex).Value = stavka.RabatProcenat.ToString();
                sheet.Cells("F" + rowIndex).DataType = XLDataType.Number;
                sheet.Cells("F" + rowIndex).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                sheet.Cells("F" + rowIndex).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                sheet.Cells("F" + rowIndex).Style.Border.OutsideBorderColor = XLColor.FromArgb(216, 228, 188);
                sheet.Cells("F" + rowIndex).Style.NumberFormat.Format = "0.00%";

                sheet.Cells("G" + rowIndex).Value = stavka.IznosBezPdvSaRabatom.ToString();
                sheet.Cells("G" + rowIndex).DataType = XLDataType.Number;
                sheet.Cells("G" + rowIndex).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                sheet.Cells("G" + rowIndex).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                sheet.Cells("G" + rowIndex).Style.Border.OutsideBorderColor = XLColor.FromArgb(216, 228, 188);
                sheet.Cells("G" + rowIndex).Style.NumberFormat.Format = "#,##0.00 \"KM\"";
                sheet.Cells("G" + rowIndex).Style.Font.Bold = false;

                index++;
            }

            sheet.Row(14 + stavke.Count + 2).Height = 20;
            sheet.Row(14 + stavke.Count + 3).Height = 20;
            sheet.Row(14 + stavke.Count + 4).Height = 20;
            sheet.Row(14 + stavke.Count + 5).Height = 20;
            sheet.Row(14 + stavke.Count + 6).Height = 20;

            sheet.Cells("A" + (14 + stavke.Count + 2).ToString()).Value = "UKUPAN IZNOS BEZ RABATA";
            sheet.Cells("A" + (14 + stavke.Count + 2).ToString()).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
            sheet.Cells("A" + (14 + stavke.Count + 2).ToString()).Style.Font.Bold = false;
            sheet.Cells("A" + (14 + stavke.Count + 2).ToString()).Style.Font.FontName = "Arial";
            sheet.Cells("A" + (14 + stavke.Count + 2).ToString()).Style.Font.FontSize = 10;
            sheet.Cells("A" + (14 + stavke.Count + 2).ToString()).Style.Font.FontColor = XLColor.Black;

            sheet.Cells("A" + (14 + stavke.Count + 3).ToString()).Value = "IZNOS RABATA";
            sheet.Cells("A" + (14 + stavke.Count + 3).ToString()).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
            sheet.Cells("A" + (14 + stavke.Count + 3).ToString()).Style.Font.Bold = false;
            sheet.Cells("A" + (14 + stavke.Count + 3).ToString()).Style.Font.FontName = "Arial";
            sheet.Cells("A" + (14 + stavke.Count + 3).ToString()).Style.Font.FontSize = 10;
            sheet.Cells("A" + (14 + stavke.Count + 3).ToString()).Style.Font.FontColor = XLColor.Black;

            sheet.Cells("A" + (14 + stavke.Count + 4).ToString()).Value = "UKUPAN IZNOS BEZ PDV";
            sheet.Cells("A" + (14 + stavke.Count + 4).ToString()).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
            sheet.Cells("A" + (14 + stavke.Count + 4).ToString()).Style.Font.Bold = false;
            sheet.Cells("A" + (14 + stavke.Count + 4).ToString()).Style.Font.FontName = "Arial";
            sheet.Cells("A" + (14 + stavke.Count + 4).ToString()).Style.Font.FontSize = 10;
            sheet.Cells("A" + (14 + stavke.Count + 4).ToString()).Style.Font.FontColor = XLColor.Black;

            sheet.Cells("A" + (14 + stavke.Count + 5).ToString()).Value = "PDV";
            sheet.Cells("A" + (14 + stavke.Count + 5).ToString()).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
            sheet.Cells("A" + (14 + stavke.Count + 5).ToString()).Style.Font.Bold = false;
            sheet.Cells("A" + (14 + stavke.Count + 5).ToString()).Style.Font.FontName = "Arial";
            sheet.Cells("A" + (14 + stavke.Count + 5).ToString()).Style.Font.FontSize = 10;
            sheet.Cells("A" + (14 + stavke.Count + 5).ToString()).Style.Font.FontColor = XLColor.Black;

            sheet.Cells("A" + (14 + stavke.Count + 6).ToString()).Value = "UKUPAN IZNOS SA PDV";
            sheet.Cells("A" + (14 + stavke.Count + 6).ToString()).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
            sheet.Cells("A" + (14 + stavke.Count + 6).ToString()).Style.Font.Bold = false;
            sheet.Cells("A" + (14 + stavke.Count + 6).ToString()).Style.Font.FontName = "Arial";
            sheet.Cells("A" + (14 + stavke.Count + 6).ToString()).Style.Font.FontSize = 10;
            sheet.Cells("A" + (14 + stavke.Count + 6).ToString()).Style.Font.FontColor = XLColor.Black;

            sheet.Range("A" + (14 + stavke.Count + 2).ToString() + ":" + "F" + (14 + stavke.Count + 2).ToString()).Row(1).Merge();
            sheet.Range("A" + (14 + stavke.Count + 3).ToString() + ":" + "F" + (14 + stavke.Count + 3).ToString()).Row(1).Merge();
            sheet.Range("A" + (14 + stavke.Count + 4).ToString() + ":" + "F" + (14 + stavke.Count + 4).ToString()).Row(1).Merge();
            sheet.Range("A" + (14 + stavke.Count + 5).ToString() + ":" + "F" + (14 + stavke.Count + 5).ToString()).Row(1).Merge();
            sheet.Range("A" + (14 + stavke.Count + 6).ToString() + ":" + "F" + (14 + stavke.Count + 6).ToString()).Row(1).Merge();

            sheet.Range("A" + (14 + stavke.Count + 2).ToString() + ":" + "F" + (14 + stavke.Count + 2).ToString()).Style.Border.OutsideBorder = XLBorderStyleValues.None;
            sheet.Range("A" + (14 + stavke.Count + 3).ToString() + ":" + "F" + (14 + stavke.Count + 3).ToString()).Style.Border.OutsideBorder = XLBorderStyleValues.None;
            sheet.Range("A" + (14 + stavke.Count + 4).ToString() + ":" + "F" + (14 + stavke.Count + 4).ToString()).Style.Border.OutsideBorder = XLBorderStyleValues.None;
            sheet.Range("A" + (14 + stavke.Count + 5).ToString() + ":" + "F" + (14 + stavke.Count + 5).ToString()).Style.Border.OutsideBorder = XLBorderStyleValues.None;
            sheet.Range("A" + (14 + stavke.Count + 6).ToString() + ":" + "F" + (14 + stavke.Count + 6).ToString()).Style.Border.OutsideBorder = XLBorderStyleValues.None;


            sheet.Cells("G" + (14 + stavke.Count + 2).ToString()).Value = iznos_bez_pdv;
            sheet.Cells("G" + (14 + stavke.Count + 2).ToString()).DataType = XLDataType.Number;
            sheet.Cells("G" + (14 + stavke.Count + 2).ToString()).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
            sheet.Cells("G" + (14 + stavke.Count + 2).ToString()).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            sheet.Cells("G" + (14 + stavke.Count + 2).ToString()).Style.Border.OutsideBorderColor = XLColor.FromArgb(216, 228, 188);
            sheet.Cells("G" + (14 + stavke.Count + 2).ToString()).Style.NumberFormat.Format = "#,##0.00 \"KM\"";
            sheet.Cells("G" + (14 + stavke.Count + 2).ToString()).Style.Font.Bold = true;
            sheet.Cells("G" + (14 + stavke.Count + 2).ToString()).Style.Font.FontName = "Arial";
            sheet.Cells("G" + (14 + stavke.Count + 2).ToString()).Style.Font.FontSize = 10;
            sheet.Cells("G" + (14 + stavke.Count + 2).ToString()).Style.Font.FontColor = XLColor.Black;

            sheet.Cells("G" + (14 + stavke.Count + 3).ToString()).Value = rabat;
            sheet.Cells("G" + (14 + stavke.Count + 3).ToString()).DataType = XLDataType.Number;
            sheet.Cells("G" + (14 + stavke.Count + 3).ToString()).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
            sheet.Cells("G" + (14 + stavke.Count + 3).ToString()).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            sheet.Cells("G" + (14 + stavke.Count + 3).ToString()).Style.Border.OutsideBorderColor = XLColor.FromArgb(216, 228, 188);
            sheet.Cells("G" + (14 + stavke.Count + 3).ToString()).Style.NumberFormat.Format = "#,##0.00 \"KM\"";
            sheet.Cells("G" + (14 + stavke.Count + 3).ToString()).Style.Font.Bold = true;
            sheet.Cells("G" + (14 + stavke.Count + 3).ToString()).Style.Font.FontName = "Arial";
            sheet.Cells("G" + (14 + stavke.Count + 3).ToString()).Style.Font.FontSize = 10;
            sheet.Cells("G" + (14 + stavke.Count + 3).ToString()).Style.Font.FontColor = XLColor.Black;

            sheet.Cells("G" + (14 + stavke.Count + 4).ToString()).Value = iznos_sa_rabatom;
            sheet.Cells("G" + (14 + stavke.Count + 4).ToString()).DataType = XLDataType.Number;
            sheet.Cells("G" + (14 + stavke.Count + 4).ToString()).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
            sheet.Cells("G" + (14 + stavke.Count + 4).ToString()).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            sheet.Cells("G" + (14 + stavke.Count + 4).ToString()).Style.Border.OutsideBorderColor = XLColor.FromArgb(216, 228, 188);
            sheet.Cells("G" + (14 + stavke.Count + 4).ToString()).Style.NumberFormat.Format = "#,##0.00 \"KM\"";
            sheet.Cells("G" + (14 + stavke.Count + 4).ToString()).Style.Font.Bold = true;
            sheet.Cells("G" + (14 + stavke.Count + 4).ToString()).Style.Font.FontName = "Arial";
            sheet.Cells("G" + (14 + stavke.Count + 4).ToString()).Style.Font.FontSize = 10;
            sheet.Cells("G" + (14 + stavke.Count + 4).ToString()).Style.Font.FontColor = XLColor.Black;

            sheet.Cells("G" + (14 + stavke.Count + 5).ToString()).Value = pdv;
            sheet.Cells("G" + (14 + stavke.Count + 5).ToString()).DataType = XLDataType.Number;
            sheet.Cells("G" + (14 + stavke.Count + 5).ToString()).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
            sheet.Cells("G" + (14 + stavke.Count + 5).ToString()).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            sheet.Cells("G" + (14 + stavke.Count + 5).ToString()).Style.Border.OutsideBorderColor = XLColor.FromArgb(216, 228, 188);
            sheet.Cells("G" + (14 + stavke.Count + 5).ToString()).Style.NumberFormat.Format = "#,##0.00 \"KM\"";
            sheet.Cells("G" + (14 + stavke.Count + 5).ToString()).Style.Font.Bold = true;
            sheet.Cells("G" + (14 + stavke.Count + 5).ToString()).Style.Font.FontName = "Arial";
            sheet.Cells("G" + (14 + stavke.Count + 5).ToString()).Style.Font.FontSize = 10;
            sheet.Cells("G" + (14 + stavke.Count + 5).ToString()).Style.Font.FontColor = XLColor.Black;

            sheet.Cells("G" + (14 + stavke.Count + 6).ToString()).Value = iznos_sa_pdv;
            sheet.Cells("G" + (14 + stavke.Count + 6).ToString()).DataType = XLDataType.Number;
            sheet.Cells("G" + (14 + stavke.Count + 6).ToString()).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
            sheet.Cells("G" + (14 + stavke.Count + 6).ToString()).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            sheet.Cells("G" + (14 + stavke.Count + 6).ToString()).Style.Border.OutsideBorderColor = XLColor.FromArgb(216, 228, 188);
            sheet.Cells("G" + (14 + stavke.Count + 6).ToString()).Style.NumberFormat.Format = "#,##0.00 \"KM\"";
            sheet.Cells("G" + (14 + stavke.Count + 6).ToString()).Style.Font.Bold = true;
            sheet.Cells("G" + (14 + stavke.Count + 6).ToString()).Style.Font.FontName = "Arial";
            sheet.Cells("G" + (14 + stavke.Count + 6).ToString()).Style.Font.FontSize = 10;
            sheet.Cells("G" + (14 + stavke.Count + 6).ToString()).Style.Font.FontColor = XLColor.Black;

            sheet.Cells("E" + (14 + stavke.Count + 8).ToString()).Value = "Dokument sastavio:";
            sheet.Cells("F" + (14 + stavke.Count + 8).ToString()).Value = radnik;

            sheet.Cells("F" + (14 + stavke.Count + 12).ToString()).Value = "M.P.";
            sheet.Cells("A" + (14 + stavke.Count + 16).ToString()).Value = "Hvala na povjerenju!";
            sheet.Range("A" + (14 + stavke.Count + 16).ToString() + ":" + "G" + (14 + stavke.Count + 16).ToString()).Row(1).Merge();
            sheet.Cells("A" + (14 + stavke.Count + 16).ToString()).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            var imagePath = "footer.jpg";

            var image = sheet.AddPicture(imagePath)
                .MoveTo(sheet.Cell("A" + (14 + stavke.Count + 16).ToString())).Scale(0.1);

            string fileName = dir + "\\Ponuda_" + rednibroj.Replace("/", "-") + ".xlsx";
            if (File.Exists(fileName) == true)
            {
                //DialogResult dr = MessageBox.Show("Štampana verzija već postoji. Napraviti novu ?", "Upozorenje", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                //if (dr == DialogResult.Yes)
                //{
                    try
                    {
                        File.Delete(fileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Zatvorite dokument pa pokušajte opet!");
                        return null;
                    }
                    doc.SaveAs(fileName);
                    //Process.Start(fileName);
                //}
            }
            else
            {
                doc.SaveAs(fileName);
                //Process.Start(fileName);
            }

            return fileName;
            //IPrinter printer = new Printer();
            //StreamReader sr = new StreamReader(fileName);

            //printer.PrintRawFile("Foxit Reader PDF Printer", "C:\\Users\\Dario\\Downloads\\PONUDA.xlsx", "Ponuda.pdf");
            //printer.PrintRawStream("Microsoft Print to PDF", sr.BaseStream, "Ponuda.pdf");

         

        }

        private void btnBrisanje_Click(object sender, EventArgs e)
        {

            object o = dgvPrijave.SelectedRows[0].DataBoundItem;
            string rb = ((Ponuda)o).Broj;
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
            string rb = ((Ponuda)o).Broj;
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
            string rb = ((Ponuda)o).Broj;
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
            string rb = ((Ponuda)o).Broj;
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
            string rb = ((Ponuda)o).Broj;
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
            //object o = dgvPrijave.Rows[e.RowIndex].DataBoundItem;
            Ponuda o = (Ponuda)dgvPrijave.Rows[e.RowIndex].DataBoundItem;
            string i = o.Status;
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
            {
                tbPartner.Focus();
                if (tbRedniBroj.Text == "AUTO")
                {
                    dgvStavkePonude.DataSource = null;
                    dgvDokumenti.DataSource = null;

                    tbRadnik.Text = PersistanceManager.GetKorisnik().KorisnickoIme;
                }
            }
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
            Ponuda o = (Ponuda)dgvPrijave.SelectedRows[0].DataBoundItem;
            string status = o.Status;

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
            string redni_broj = o.Broj;
            List<PonudaStavka> stavke = PersistanceManager.ReadPonudaStavka(redni_broj);
            BindPonudaStavka(stavke);

            List<PonudaDokument> dokumenti = PersistanceManager.ReadPonudaDokument(redni_broj);
            BindPonudaDokument(dokumenti);
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
                        if (s1 == true)
                        {
                            stavka.VrijednostNabavna = Math.Round(stavka.Kolicina * stavka.CijenaNabavna == 0 ? stavka.CijenaBezPdvSaRabatom : stavka.CijenaNabavna, 2, MidpointRounding.AwayFromZero);
                            stavka.Ruc = Math.Round(stavka.VrijednostNabavna * stavka.MarzaProcenat / 100, 2, MidpointRounding.AwayFromZero);
                            stavka.IznosBezPdv = stavka.VrijednostNabavna + stavka.Ruc;
                            stavka.CijenaBezPdv = Math.Round(stavka.IznosBezPdv / stavka.Kolicina, 2, MidpointRounding.AwayFromZero);
                            stavka.RabatIznos = Math.Round(stavka.IznosBezPdv * stavka.RabatProcenat / 100, 2, MidpointRounding.AwayFromZero);
                            stavka.IznosBezPdvSaRabatom = stavka.IznosBezPdv - stavka.RabatIznos;
                            stavka.CijenaBezPdvSaRabatom = Math.Round(stavka.IznosBezPdvSaRabatom / stavka.Kolicina, 2, MidpointRounding.AwayFromZero);
                            stavka.Pdv = Math.Round(stavka.IznosBezPdvSaRabatom * stavka.PdvStopa / 100, 2, MidpointRounding.AwayFromZero);
                            stavka.IznosSaPdv = stavka.IznosBezPdvSaRabatom + stavka.Pdv;
                        }
                        break;
                    }

                case "cijenabezpdv":
                    {
                        decimal cijena_bez_pdv;
                        bool s1 = decimal.TryParse(newValueString, out cijena_bez_pdv);
                        if (s1 == true)
                        {
                            stavka.IznosBezPdv = Math.Round(stavka.Kolicina * stavka.CijenaBezPdv, 2, MidpointRounding.AwayFromZero);
                            stavka.Ruc = stavka.IznosBezPdv - stavka.VrijednostNabavna;
                            stavka.MarzaProcenat = stavka.VrijednostNabavna == 0 ? 0 : Math.Round(stavka.Ruc / stavka.VrijednostNabavna * 100, 2, MidpointRounding.AwayFromZero);

                            stavka.RabatIznos = Math.Round(stavka.IznosBezPdv * stavka.RabatProcenat / 100, 2, MidpointRounding.AwayFromZero);
                            stavka.IznosBezPdvSaRabatom = stavka.IznosBezPdv - stavka.RabatIznos;
                            stavka.CijenaBezPdvSaRabatom = Math.Round(stavka.IznosBezPdvSaRabatom / stavka.Kolicina, 2, MidpointRounding.AwayFromZero);
                            stavka.Pdv = Math.Round(stavka.IznosBezPdvSaRabatom * stavka.PdvStopa / 100, 2, MidpointRounding.AwayFromZero);
                            stavka.IznosSaPdv = stavka.IznosBezPdvSaRabatom + stavka.Pdv;
                        }
                        break;
                    }
                case "rabatprocenat":
                    {
                        decimal rabatprocenat;
                        bool s1 = decimal.TryParse(newValueString, out rabatprocenat);
                        if (s1 == true)
                        {
                            stavka.RabatIznos = Math.Round(stavka.IznosBezPdv * stavka.RabatProcenat / 100, 2, MidpointRounding.AwayFromZero);
                            stavka.IznosBezPdvSaRabatom = stavka.IznosBezPdv - stavka.RabatIznos;
                            stavka.CijenaBezPdvSaRabatom = Math.Round(stavka.IznosBezPdvSaRabatom / stavka.Kolicina, 2, MidpointRounding.AwayFromZero);
                            stavka.Pdv = Math.Round(stavka.IznosBezPdvSaRabatom * stavka.PdvStopa / 100, 2, MidpointRounding.AwayFromZero);
                            stavka.IznosSaPdv = stavka.IznosBezPdvSaRabatom + stavka.Pdv;
                        }
                        break;
                    }
                case "cijenanabavna":
                    {
                        decimal cijenanabavna;
                        bool s1 = decimal.TryParse(newValueString, out cijenanabavna);
                        if (s1 == true)
                        {
                            stavka.VrijednostNabavna = Math.Round(stavka.Kolicina * stavka.CijenaNabavna, 2, MidpointRounding.AwayFromZero);
                            stavka.Ruc = Math.Round(stavka.VrijednostNabavna * stavka.MarzaProcenat / 100, 2, MidpointRounding.AwayFromZero);
                            stavka.IznosBezPdv = stavka.VrijednostNabavna + stavka.Ruc;
                            stavka.CijenaBezPdv = Math.Round(stavka.IznosBezPdv / stavka.Kolicina, 2, MidpointRounding.AwayFromZero);
                            stavka.RabatIznos = Math.Round(stavka.IznosBezPdv * stavka.RabatProcenat / 100, 2, MidpointRounding.AwayFromZero);
                            stavka.IznosBezPdvSaRabatom = stavka.IznosBezPdv - stavka.RabatIznos;
                            stavka.CijenaBezPdvSaRabatom = Math.Round(stavka.IznosBezPdvSaRabatom / stavka.Kolicina, 2, MidpointRounding.AwayFromZero);
                            stavka.Pdv = Math.Round(stavka.IznosBezPdvSaRabatom * stavka.PdvStopa / 100, 2, MidpointRounding.AwayFromZero);
                            stavka.IznosSaPdv = stavka.IznosBezPdvSaRabatom + stavka.Pdv;
                        }
                        break;
                    }

                case "marzaprocenat":
                    {
                        decimal marzaprocenat;
                        bool s1 = decimal.TryParse(newValueString, out marzaprocenat);
                        if (s1 == true)
                        {
                            stavka.Ruc = Math.Round(stavka.VrijednostNabavna * stavka.MarzaProcenat / 100, 2, MidpointRounding.AwayFromZero);
                            stavka.IznosBezPdv = stavka.VrijednostNabavna + stavka.Ruc;
                            stavka.CijenaBezPdv = Math.Round(stavka.IznosBezPdv / stavka.Kolicina, 2, MidpointRounding.AwayFromZero);
                            stavka.RabatIznos = Math.Round(stavka.IznosBezPdv * stavka.RabatProcenat / 100, 2, MidpointRounding.AwayFromZero);
                            stavka.IznosBezPdvSaRabatom = stavka.IznosBezPdv - stavka.RabatIznos;
                            stavka.CijenaBezPdvSaRabatom = Math.Round(stavka.IznosBezPdvSaRabatom / stavka.Kolicina, 2, MidpointRounding.AwayFromZero);
                            stavka.Pdv = Math.Round(stavka.IznosBezPdvSaRabatom * stavka.PdvStopa / 100, 2, MidpointRounding.AwayFromZero);
                            stavka.IznosSaPdv = stavka.IznosBezPdvSaRabatom + stavka.Pdv;
                        }
                        break;
                    }
            }
            if (stavka.PonudaBroj != null)
            {
                PersistanceManager.UpdatePonudaStavka(stavka);
                CalculateTotals();
                Ponuda p = PersistanceManager.ReadPonuda(stavka.PonudaBroj, "",DynamicFilters).FirstOrDefault();
                Ponuda ponuda = (Ponuda)dgvPrijave.SelectedRows[0].DataBoundItem;
                ponuda.IznosSaPdv = p.IznosSaPdv;
                //BindingList<Ponuda> lista = (BindingList<Ponuda>)dgvPrijave.DataSource;
                //lista.Where(l => l.Broj == p.Broj).FirstOrDefault() = p;
                dgvPrijave.Refresh();


                //ReadPonuda("", "");
                //dgvPrijave_CellDoubleClick(this, null);
            }
            dgvStavkePonude.Refresh();

            DataGridViewCell cell = dgvStavkePonude.Rows[e.RowIndex].Cells[e.ColumnIndex + 1];
            ////int i = 0;
            ////while (cell.OwningColumn.ReadOnly == true)
            ////{
            ////    cell = dgvStavkePonude.Rows[e.RowIndex].Cells[e.ColumnIndex + 1+i];
            ////    i++;
            ////}
            ////if(dgvStavkePonude.CurrentCell!=cell)
            //dgvStavkePonude.CurrentCell = cell;

            //dgvStavkePonude.BeginEdit(true);
        }

        private void dgvStavkePonude_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show("f");
        }

        private void dgvStavkePonude_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {

        }

        private void dgvStavkePonude_RowValidated_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvStavkePonude_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            PonudaStavka stavka = null;
            try
            {
                Ponuda o = (Ponuda)dgvPrijave.SelectedRows[0].DataBoundItem;
                string broj = o.Broj;

                stavka = (PonudaStavka)dgvStavkePonude.Rows[e.RowIndex]?.DataBoundItem;
                if (stavka == null)
                    return;
                if (stavka.PonudaBroj == null)
                {

                    
                    string statusPonude = o.Status;
                    if (statusPonude != "E")
                    {
                        e.Cancel = true;
                        return;
                    }

                    if (stavka.ArtikalNaziv == null)
                    {
                        e.Cancel = true;
                        return;
                    }
                    stavka.PonudaBroj = broj;
                    stavka.StavkaBroj = ((BindingList<PonudaStavka>)dgvStavkePonude.DataSource).Where(ps => ps.PonudaBroj != null).Max(ps => ps.StavkaBroj) + 1;
                    PersistanceManager.InsertPonudaStavka(stavka);

                    CalculateTotals();

                    Ponuda p = PersistanceManager.ReadPonuda(stavka.PonudaBroj, "",DynamicFilters).FirstOrDefault();
                    Ponuda ponuda = (Ponuda)dgvPrijave.SelectedRows[0].DataBoundItem;
                    ponuda.IznosSaPdv = p.IznosSaPdv;
                    //BindingList<Ponuda> lista = (BindingList<Ponuda>)dgvPrijave.DataSource;
                    //lista.Where(l => l.Broj == p.Broj).FirstOrDefault() = p;
                    dgvPrijave.Refresh();

                    //ReadPonuda("", "");
                    //FillDetailView();
                }
            }
            catch (Exception ex)
            {
                e.Cancel = true;
                stavka.PonudaBroj = null;
                MessageBox.Show(ex.Message + ":" + ex.StackTrace);
            }
        }

        private void CalculateTotals()
        {
            IList<PonudaStavka> stavke = (BindingList<PonudaStavka>)dgvStavkePonude.DataSource;
            tbIznosBezRabata.Text = stavke.Sum(s => s.IznosBezPdv).ToString();
            tbIznosSaRabatom.Text = stavke.Sum(s => s.IznosBezPdvSaRabatom).ToString();
            tbRabat.Text = stavke.Sum(s => s.RabatIznos).ToString();
            tbNabavnaVrijednost.Text = stavke.Sum(s => s.VrijednostNabavna).ToString();
            tbRUC.Text = stavke.Sum(s => s.Ruc).ToString();
            tbPdv.Text = stavke.Sum(s => s.Pdv).ToString();
            tbIznosSaPdv.Text = stavke.Sum(s => s.IznosSaPdv).ToString();
        }

        private void dgvStavkePonude_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            object o = dgvPrijave.SelectedRows[0].DataBoundItem;
            string statusPonude = ((Ponuda)o).Status;
            if (statusPonude != "E")
                e.Cancel = true;
            else
            {
                PonudaStavka stavka = (PonudaStavka)e.Row.DataBoundItem;
                PersistanceManager.DeletePonudaStavka(stavka);
                CalculateTotals();
                Ponuda p = PersistanceManager.ReadPonuda(stavka.PonudaBroj, "",DynamicFilters).FirstOrDefault();
                Ponuda ponuda = (Ponuda)dgvPrijave.SelectedRows[0].DataBoundItem;
                ponuda.IznosSaPdv = p.IznosSaPdv;
                //BindingList<Ponuda> lista = (BindingList<Ponuda>)dgvPrijave.DataSource;
                //lista.Where(l => l.Broj == p.Broj).FirstOrDefault() = p;
                dgvPrijave.Refresh();

            }
        }


        private void dgvStavkePonude_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.DefaultCellStyle.BackColor = e.Column.ReadOnly == true ? Color.Gainsboro : Color.White;
        }

        private void dgvStavkePonude_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            object o = dgvPrijave.SelectedRows[0].DataBoundItem;
            string statusPonude = ((Ponuda)o).Status;
            if (statusPonude != "E")
                e.Cancel = true;
        }

        private void dgvStavkePonude_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {

        }

        private void dataGridView1_DragDrop(object sender, DragEventArgs e)
        {
            UploadFiles(e);
        }

        private void dgvDokumenti_DragEnter(object sender, DragEventArgs e)
        {

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void dgvDokumenti_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            PonudaDokument dokument = (PonudaDokument)dgvDokumenti.Rows[e.RowIndex].DataBoundItem;
            byte[] sadrzaj = PersistanceManager.ReadPonudaDokumentSadrzaj(dokument.PonudaBroj, dokument.DokumentBroj);
            string dir = System.IO.Path.Combine(Environment.GetFolderPath(
        Environment.SpecialFolder.MyDoc‌​uments), "ServisDB\\temp");

            if (Directory.Exists(dir) == false)
            {
                Directory.CreateDirectory(dir);
            }
            string path = dir + "\\" + Guid.NewGuid().ToString() + "_" + dokument.Naziv;
            File.WriteAllBytes(path, sadrzaj);
            Process.Start(path);
        }

        private void FormPonuda_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void tabControl2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void tabControl2_DragDrop(object sender, DragEventArgs e)
        {
            UploadFiles(e);
        }

        private void UploadFiles(DragEventArgs e)
        {
            string statusPonude = ((Ponuda)dgvPrijave.SelectedRows[0].DataBoundItem).Status;
            if (statusPonude != "E")
            {
                return;
            }
            string brojPonude = ((Ponuda)dgvPrijave.SelectedRows[0].DataBoundItem).Broj;

            List<PonudaDokument> dokumenti = ((BindingList<PonudaDokument>)dgvDokumenti.DataSource).Where(ps => ps.PonudaBroj != null).ToList();
            int maxBD = 0;
            if (dokumenti.Count != 0)
                maxBD = dokumenti.Max(ps => ps.DokumentBroj);


            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            for (int i = 0; i < files.Length; i++)
            {
                PonudaDokument dokument = new PonudaDokument();
                dokument.PonudaBroj = brojPonude;
                dokument.DokumentBroj = maxBD + i + 1;
                dokument.Naziv = files[i].Substring(files[i].LastIndexOf("\\") + 1);
                dokument.Dokument = File.ReadAllBytes(files[i]);
                PersistanceManager.InsertPonudaDokument(dokument);

            }
            MessageBox.Show("Dokumenti su uspješno dodani!");

            BindPonudaDokument(PersistanceManager.ReadPonudaDokument(brojPonude));
        }

        private void dgvDokumenti_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            PonudaDokument dokument = (PonudaDokument)e.Row.DataBoundItem;
            if (MessageBox.Show(string.Format("Obrisati dokument {0} ?", dokument.Naziv), "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                PersistanceManager.DeletePonudaDokument(dokument);
            }
            else
                e.Cancel = true;
        }

        private void dgvDokumenti_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {

        }

        private void dgvStavkePonude_DragDrop(object sender, DragEventArgs e)
        {
            UploadFiles(e);
        }

        private void dgvPrijave_DragDrop(object sender, DragEventArgs e)
        {
            UploadFiles(e);
        }

        private void btnDeleteCache_Click(object sender, EventArgs e)
        {
            try
            {
                string path = System.IO.Path.Combine(Environment.GetFolderPath(
   Environment.SpecialFolder.MyDoc‌​uments), "ServisDB\\temp");


                System.IO.DirectoryInfo di = new DirectoryInfo(path);

                if (di.Exists == true)

                    foreach (FileInfo file in di.GetFiles())
                    {
                        file.Delete();
                    }
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    dir.Delete(true);
                }

                MessageBox.Show("Uspješno!");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Dokumenti ne mogu obrisani! Pokušajte zatvori");
            }
        }

        private void dgvStavkePonude_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                e.SuppressKeyPress = true;
                int iColumn = dgvStavkePonude.CurrentCell.ColumnIndex;
                int iRow = dgvStavkePonude.CurrentCell.RowIndex;
                if (iColumn == dgvStavkePonude.Columns.Count - 1)
                    dgvStavkePonude.CurrentCell = dgvStavkePonude[0, iRow + 1];
                else
                    dgvStavkePonude.CurrentCell = dgvStavkePonude[iColumn + 1, iRow];

                dgvStavkePonude.BeginEdit(true);

            }
        }

        private void btnCopyPonuda_Click(object sender, EventArgs e)
        {
            string broj = ((Ponuda)dgvPrijave.SelectedRows[0].DataBoundItem).Broj;
           
            if (MessageBox.Show(string.Format("Kopirati ponudu {0} ?", broj), "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                PersistanceManager.CopyPonuda(broj, PersistanceManager.GetKorisnik().KorisnickoIme);

                MessageBox.Show(string.Format("Ponuda {0} je kopirana!", broj), "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        
                ReadPonuda(textBox1.Text, textBox2.Text);
                tabControl1.SelectedIndex = 0;
                Clear();
                ReadPonuda("", "");
            }
        }

        private void btnSendMail_Click(object sender, EventArgs e)
        {
            string fileName = Stampa();
            Ponuda p = (Ponuda)dgvPrijave.SelectedRows[0].DataBoundItem;
            var mailMessage = new MailMessage();

            mailMessage.From = new MailAddress("dariodjekic@gmail.com");
            mailMessage.To.Add(p.PartnerEmail);
            mailMessage.Subject = "Ponuda za " + p.Predmet;
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = "<span style='font-size: 12pt; color: black;'>Poštovani ,<br/> u prilogu se nalazi ponuda. <br/><br/> Pozdrav</span>";

            mailMessage.Attachments.Add(new Attachment(fileName));

            var eml = fileName + ".eml";

            //save the MailMessage to the filesystem
            mailMessage.Save(eml);

            //Open the file with the default associated application registered on the local machine
            Process.Start(eml);
        }
    }
}
