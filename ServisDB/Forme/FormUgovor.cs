﻿using ClosedXML.Excel;
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
using TMS.Core.Helpers;

namespace ServisDB.Forme
{
    public partial class FormUgovor : Form
    {
        public List<string> DynamicFilters { get; set; }
        public List<string> StaticFilters { get; set; }
        //NpgsqlConnection con = new NpgsqlConnection("Host=localhost;Username=postgres;Password=postgres;Database=servisdb");

        //public string conn_string = "Host=localhost;Username=postgres;Password=postgres;Database=servisdb";
        //private int? dobavljacStari;

        public FormUgovor()
        {
            InitializeComponent();
            DynamicFilters = new List<string>();


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
                    dgvPrijave.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Šifra kupca", DataPropertyName = "kupac_sifra", Width = 50, Visible = false });
                    dgvPrijave.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Kupac", DataPropertyName = "kupac_naziv", Width = 180 });
                    dgvPrijave.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Adresa", DataPropertyName = "kupac_adresa", Width = 180 });
                    dgvPrijave.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Telefon", DataPropertyName = "kupac_telefon", Width = 130 });
                    dgvPrijave.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Br.računa", DataPropertyName = "broj_racuna", Width = 130 });
                    dgvPrijave.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Iznos ugovora (sa PDV)", DataPropertyName = "iznos_sa_pdv", DefaultCellStyle = new DataGridViewCellStyle() { Format = "N2" }, Width = 120 });
                    dgvPrijave.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Inicijalno uplaćeno", DataPropertyName = "inicijalno_placeno", DefaultCellStyle = new DataGridViewCellStyle() { Format = "N2" }, Width = 120 });
                    dgvPrijave.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Uplaćeno po ratama", DataPropertyName = "uplaceno_po_ratama", DefaultCellStyle = new DataGridViewCellStyle() { Format = "N2" }, Width = 120 });
                    dgvPrijave.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Suma uplata", DataPropertyName = "suma_uplata", Width = 120, DefaultCellStyle = new DataGridViewCellStyle() { Format = "N2" } });
                    dgvPrijave.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Preostalo za uplatu", DataPropertyName = "preostalo_za_uplatu", DefaultCellStyle = new DataGridViewCellStyle() { Format = "N2" }, Width = 120 });
                    dgvPrijave.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Status", DataPropertyName = "status", Width = 80 });
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
                    cmd.CommandText = @"SELECT broj, datum, kupac_sifra, kupac_maticni_broj, kupac_broj_lk, kupac_naziv, kupac_adresa, kupac_telefon, broj_racuna, radnik, inicijalno_placeno, iznos_bez_pdv, pdv, iznos_sa_pdv, broj_rata, suma_uplata, preostalo_za_uplatu, status, napomena, mk,uplaceno_po_ratama
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
            try
            {
                decimal IznosSaPDV, InicijalnoUplaceno;
                int brojRata;
                bool s1 = decimal.TryParse(tbIznosSaPDV.Text, out IznosSaPDV);
                bool s2 = decimal.TryParse(tbInicijalnoUplaceno.Text, out InicijalnoUplaceno);
                bool s3 = int.TryParse(tbBrojRata.Text, out brojRata);

                if (s1 == false || s2 == false || s3 == false)
                {
                    MessageBox.Show("Validacija iznosa neuspješna!", "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }

                if (s3 == true && (brojRata < 0 || brojRata > 24))
                {
                    MessageBox.Show("Broj rata može biti između 1 i 24!", "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }

                bool s4 = tbKupac.Text != "";
                bool s5 = tbKupacBrojLk.Text != "";
                bool s6 = tbKupacMaticniBroj.Text != "";

                if (s4 == false || s5 == false || s6 == false)
                {
                    MessageBox.Show("Validacija podataka o kupcu neuspješna! Obavezni podaci su ime kupca, Broj LK i JMBG.", "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                if (s6 == true && (tbKupacMaticniBroj.Text.Trim().Length > 13 || tbKupacMaticniBroj.Text.Trim().Length < 1))
                {
                    MessageBox.Show("Broj cifara matičnog broja ne može biti veći od 13!", "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }

                if (s5 == true && (tbKupacBrojLk.Text.Trim().Length != 9))
                {
                    MessageBox.Show("Broj karaktera broja LK mora biti 9!", "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
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
                    PersistanceManager.InsertPartner(tbKupac.Text, "F", tbKupacMaticniBroj.Text, tbAdresa.Text, tbKupacaTelefon.Text, null, true, false, tbKupacBrojLk.Text, out kupacSifra);
                    tbKupacSifra.Text = kupacSifra.ToString();
                }
                else
                    PersistanceManager.UpdatePartner(int.Parse(tbKupacSifra.Text), tbAdresa.Text, tbKupacaTelefon.Text, tbKupacMaticniBroj.Text, tbKupacBrojLk.Text);

                if (tbRedniBroj.Text == "AUTO")
                {
                    string broj_ugovora;
                    PersistanceManager.InsertUgovor(dtpDatum.Value, int.Parse(tbKupacSifra.Text), tbKupac.Text, tbAdresa.Text, tbKupacaTelefon.Text, tbKupacBrojLk.Text, tbKupacMaticniBroj.Text
                       , decimal.Parse(tbIznosSaPDV.Text), decimal.Parse(tbInicijalnoUplaceno.Text), decimal.Parse(tbSumaUplata.Text), decimal.Parse(tbPreostaloZaUplatu.Text), tbNapomena.Text, tbRadnik.Text, tbStatus.Text, int.Parse(tbBrojRata.Text), tbBrojRacuna.Text, cbMK.Checked, decimal.Parse(tbUplacenoPoRatama.Text), out broj_ugovora);
                    if (cbMK.Checked == false)
                    {
                        List<UgovorRata> rate = KreirajRateUgovora(broj_ugovora);
                        dgvRate.DataSource = rate;
                        //dgvugov
                        foreach (UgovorRata r in rate)
                            PersistanceManager.InsertUgovorRata(r.BrojUgovora, r.BrojRate, r.RokPlacanja, r.DatumPlacanja, r.Iznos, r.Uplaceno, r.Napomena);
                    }
                }
                else
                {
                    PersistanceManager.UpdateUgovor(tbRedniBroj.Text, dtpDatum.Value, int.Parse(tbKupacSifra.Text), tbKupac.Text, tbAdresa.Text, tbKupacaTelefon.Text, tbKupacBrojLk.Text, tbKupacMaticniBroj.Text
                       , decimal.Parse(tbIznosSaPDV.Text), decimal.Parse(tbInicijalnoUplaceno.Text), decimal.Parse(tbSumaUplata.Text), decimal.Parse(tbPreostaloZaUplatu.Text), tbNapomena.Text, tbRadnik.Text, tbStatus.Text, int.Parse(tbBrojRata.Text), tbBrojRacuna.Text, cbMK.Checked);
                    if (cbMK.Checked == false)
                    {
                        if (tbStatus.Text == "E")
                        {

                            List<UgovorRata> rate = KreirajRateUgovora(tbRedniBroj.Text);
                            dgvRate.DataSource = rate;

                            PersistanceManager.DeleteUgovorRata(tbRedniBroj.Text);
                            //dgvugov
                            foreach (UgovorRata r in rate)
                                PersistanceManager.InsertUgovorRata(r.BrojUgovora, r.BrojRate, r.RokPlacanja, r.DatumPlacanja, r.Iznos, r.Uplaceno, r.Napomena);

                        }
                        else
                        {
                            PersistanceManager.UpdateUgovorRata(tbRedniBroj.Text, int.Parse(tbBrojRate.Text), dtpRokPlacanja.Value, dtpDatumUplate.Value, decimal.Parse(tbIznosRate.Text), decimal.Parse(tbUplaceno.Text), tbNapomena.Text);

                            if (dtpDatumUplate.Value != null)
                            {
                                StampaPotvrdaPlacanja();
                            }
                        }
                    }

                }
                tabControl1.SelectedIndex = 0;
                Clear();
                ReadUgovor("", "");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace);
                Logger.Exception(ex);
            }
        }

        private List<UgovorRata> KreirajRateUgovora(string broj_ugovora)
        {

            List<UgovorRata> rate = new List<UgovorRata>();
            try
            {
                int brojRata;
                decimal iznos, inicijalnoUplaceno;
                bool s1 = int.TryParse(tbBrojRata.Text, out brojRata);
                bool s2 = decimal.TryParse(tbIznosSaPDV.Text, out iznos);
                bool s3 = decimal.TryParse(tbInicijalnoUplaceno.Text, out inicijalnoUplaceno);
                if (s1 == true && s2 == true && s3 == true && brojRata > 0)
                {
                    decimal iznosRate = decimal.Round((iznos - inicijalnoUplaceno) / brojRata, 2, MidpointRounding.AwayFromZero);
                    decimal sumaIznosaRata = 0;
                    UgovorRata r;
                    for (int i = 0; i < brojRata - 1; i++)
                    {
                        r = new UgovorRata();
                        r.BrojUgovora = broj_ugovora;
                        r.BrojRate = i + 1;
                        r.DatumPlacanja = null;
                        r.Uplaceno = 0;
                        r.Iznos = iznosRate;
                        r.RokPlacanja = DateTime.Now.AddMonths(i + 1);
                        rate.Add(r);
                        sumaIznosaRata = sumaIznosaRata + iznosRate;
                    }
                    r = new UgovorRata();
                    r.BrojUgovora = broj_ugovora;
                    r.BrojRate = brojRata;
                    r.DatumPlacanja = null;
                    r.Uplaceno = 0;
                    r.Iznos = (iznos - inicijalnoUplaceno) - sumaIznosaRata;
                    r.RokPlacanja = DateTime.Now.AddMonths(brojRata);
                    rate.Add(r);
                }
            }
            catch (Exception ex)
            { }
            return rate;
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
            tbInicijalnoUplaceno.Text = ((decimal)((DataRowView)o).Row.ItemArray[10]).ToString("N2");
            tbIznosSaPDV.Text = ((decimal)((DataRowView)o).Row.ItemArray[13]).ToString("N2");
            tbBrojRata.Text = ((DataRowView)o).Row.ItemArray[14].ToString();
            tbSumaUplata.Text = ((decimal)((DataRowView)o).Row.ItemArray[15]).ToString("N2");
            tbPreostaloZaUplatu.Text = ((decimal)((DataRowView)o).Row.ItemArray[16]).ToString("N2");
            tbStatus.Text = ((DataRowView)o).Row.ItemArray[17].ToString();

            tbNapomena.Text = ((DataRowView)o).Row.ItemArray[18].ToString();

            cbMK.Checked = (bool)(((DataRowView)o).Row.ItemArray[19]);
            tbUplacenoPoRatama.Text = ((decimal)((DataRowView)o).Row.ItemArray[20]).ToString("N2");
            List<UgovorRata> rate = PersistanceManager.ReadUgovorRata(tbRedniBroj.Text);
            BindUgovorRata(rate);

            SetVisibility();
        }

        private void BindUgovorRata(List<UgovorRata> rate, bool unos = false)
        {
            dgvRate.DataSource = null;
            dgvRate.AutoGenerateColumns = false;
            dgvRate.Columns.Clear();
            dgvRate.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Br.rate", DataPropertyName = "BrojRate", Width = 50 });
            dgvRate.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Iznos", DataPropertyName = "Iznos", Width = 100, DefaultCellStyle = new DataGridViewCellStyle() { Format = "N2" } });
            dgvRate.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Rok plaćanja", DataPropertyName = "RokPlacanja", Width = 97, DefaultCellStyle = new DataGridViewCellStyle() { Format = "dd.MM.yyyy." } });
            dgvRate.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Uplaćeno", DataPropertyName = "Uplaceno", Width = 100, DefaultCellStyle = new DataGridViewCellStyle() { Format = "N2" }, Visible = !unos });
            dgvRate.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Datum uplate", DataPropertyName = "DatumPlacanja", Width = 97, Visible = !unos, DefaultCellStyle = new DataGridViewCellStyle() { Format = "dd.MM.yyyy." } });


            dgvRate.DataSource = rate;
            var r = rate.Where(rr => rr.Iznos != rr.Uplaceno).FirstOrDefault();
            int? prvaNeplacenaRata = r != null ? r.BrojRate : (int?)null;
            if (prvaNeplacenaRata.HasValue)
            {
                dgvRate.Rows[prvaNeplacenaRata.Value - 1].Selected = true;
            }
        }

        private void dtpDatumUplate_ValueChanged(object sender, EventArgs e)
        {
            dtpDatumUplate.Format = DateTimePickerFormat.Short;
        }

        private void dtpRokPlacanja_ValueChanged(object sender, EventArgs e)
        {
            dtpRokPlacanja.Format = DateTimePickerFormat.Short;
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
            tbInicijalnoUplaceno.Text = "0";
            tbSumaUplata.Text = "0";
            tbPreostaloZaUplatu.Text = "0";
            tbUplacenoPoRatama.Text = "0";
            tbIznosSaPDV.Text = "";
            tbBrojRata.Text = "";
            tbNapomena.Text = "";
            tbStatus.Text = "E";

            tbIznosRate.Text = "";
            tbUplaceno.Text = "";
            tbUplacenoPoRatama.Text = "";
            dtpDatumUplate.Format = DateTimePickerFormat.Custom;
            dtpDatumUplate.CustomFormat = " ";

            dtpRokPlacanja.Format = DateTimePickerFormat.Custom;
            dtpRokPlacanja.CustomFormat = " ";
            tbKupac.ReadOnly = false;
            tbKupac.Focus();
            dgvRate.DataSource = null;
            SetVisibility();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                tbKupac.Focus();
                if (tbRedniBroj.Text == "AUTO")
                {
                    tbRadnik.Text = PersistanceManager.GetKorisnik().KorisnickoIme;
                }
            }
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

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            //= dgvPrijave.Rows[e.RowIndex].Cells[10].Value.ToString();
            object o = dgvPrijave.Rows[e.RowIndex].DataBoundItem;
            string i = ((DataRowView)o).Row.ItemArray[17].ToString();
            if (i == "R")
            {
                //dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.PaleGreen;
                //dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                dgvPrijave.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Green;
                dgvPrijave.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("Tahoma", 10, FontStyle.Italic);
            }
            else if (i == "Z")
            {

                dgvPrijave.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                dgvPrijave.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("Tahoma", 10, FontStyle.Regular);
            }
        }

        private void btnStampa_Click(object sender, EventArgs e)
        {
            Stampa();
        }

        private void Stampa()
        {
            //  //string dir = Environment.SpecialFolder.MyDocuments + "\\ServisDB\\";

            string dir = System.IO.Path.Combine(Environment.GetFolderPath(
          Environment.SpecialFolder.MyDoc‌​uments), "ServisDB");

            if (Directory.Exists(dir) == false)
            {
                Directory.CreateDirectory(dir);
            }
            object o = dgvPrijave.SelectedRows[0].DataBoundItem;
            string rednibroj = ((DataRowView)o).Row.ItemArray[0].ToString();
            string kupac = ((DataRowView)o).Row.ItemArray[5].ToString();
            string adresa = ((DataRowView)o).Row.ItemArray[6].ToString();
            string lk = ((DataRowView)o).Row.ItemArray[4].ToString();
            string jmbg = ((DataRowView)o).Row.ItemArray[3].ToString();
            decimal uplaceno = (decimal)((DataRowView)o).Row.ItemArray[10];
            string brojrata = ((DataRowView)o).Row.ItemArray[14].ToString();
            DateTime datum = (DateTime)((DataRowView)o).Row.ItemArray[1];
            decimal iznos = (decimal)((DataRowView)o).Row.ItemArray[13];
            string napomena = ((DataRowView)o).Row.ItemArray[18].ToString();

            List<UgovorRata> rate = PersistanceManager.ReadUgovorRata(rednibroj);
            string plan = "";
            for (int i = 0; i < rate.Count; i++)
                plan = plan + Environment.NewLine + (i + 1).ToString() + ". do " + rate[i].RokPlacanja.ToString("dd.MM.yyyy") + " - iznos: " + rate[i].Iznos.ToString("N2") + " KM";


            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("OTPLATNIPLAN", plan);
            dict.Add("KUPAC", kupac);
            dict.Add("ADRESA", adresa);
            dict.Add("LK", lk);
            dict.Add("JMBG", jmbg);
            dict.Add("UPLACENO", uplaceno.ToString("N2"));
            dict.Add("BROJRATA", brojrata.ToString());
            dict.Add("DATUM", datum.ToString("dd.MM.yyyy"));
            dict.Add("IZNOSRATE", (Math.Round((iznos - uplaceno) / int.Parse(brojrata), 2, MidpointRounding.AwayFromZero)).ToString("N2"));
            dict.Add("UKUPANIZNOS", (iznos).ToString("N2"));
            dict.Add("PREDMET", napomena);
            string fileName = dir + "\\" + rednibroj.Replace("/", "-") + ".docx";

            WordDocumentBuilder.FillBookmarksUsingOpenXml("Ugovor.docx", fileName, dict);
            Process.Start(fileName);
        }

        private void StampaPotvrdaPlacanja()
        {
            //  //string dir = Environment.SpecialFolder.MyDocuments + "\\ServisDB\\";

            string dir = System.IO.Path.Combine(Environment.GetFolderPath(
          Environment.SpecialFolder.MyDoc‌​uments), "ServisDB");

            if (Directory.Exists(dir) == false)
            {
                Directory.CreateDirectory(dir);
            }
            object o = dgvPrijave.SelectedRows[0].DataBoundItem;
            string rednibroj = ((DataRowView)o).Row.ItemArray[0].ToString();
            string kupac = ((DataRowView)o).Row.ItemArray[5].ToString();
            string adresa = ((DataRowView)o).Row.ItemArray[6].ToString();
            string lk = ((DataRowView)o).Row.ItemArray[4].ToString();
            string jmbg = ((DataRowView)o).Row.ItemArray[3].ToString();
            decimal inicijalnoplaceno = (decimal)((DataRowView)o).Row.ItemArray[10];
            string brojrata = ((DataRowView)o).Row.ItemArray[14].ToString();
            DateTime datum = (DateTime)((DataRowView)o).Row.ItemArray[1];
            decimal iznos = (decimal)((DataRowView)o).Row.ItemArray[13];
            string napomena = ((DataRowView)o).Row.ItemArray[18].ToString();
            string brojracuna = tbBrojRacuna.Text;
            int brojrate = int.Parse(tbBrojRate.Text);
            //decimal inicijalnoplaceno = decimal.Parse(tbInicijalnoUplaceno.Text);
            List<UgovorRata> rate = PersistanceManager.ReadUgovorRata(tbRedniBroj.Text);

            decimal? sumauplata = rate.Sum(r => r.Uplaceno);

            decimal uplacenoPoRati = decimal.Parse(tbUplaceno.Text);
            DateTime datumPlacanja = dtpDatumUplate.Value;

            string uplacenerate = "";
            List<UgovorRata> uplate = rate.Where(ss => ss.Iznos <= ss.Uplaceno).ToList();
            for (int i = 0; i < uplate.Count; i++)
            {
                uplacenerate = uplacenerate + Environment.NewLine + uplate[i].BrojRate.ToString() + ". " + "rata - uplaćeno: " + uplate[i].Uplaceno.Value.ToString("N2") + "" + " KM ";
            }
            string neplacenerate = "";
            List<UgovorRata> neplaceneRate = rate.Where(ss => ss.Iznos > ss.Uplaceno).ToList();
            for (int i = 0; i < neplaceneRate.Count; i++)
            {
                neplacenerate = neplacenerate + Environment.NewLine + neplaceneRate[i].BrojRate.ToString() + ". rata" + " do " + neplaceneRate[i].RokPlacanja.ToString("dd.MM.yyyy") + " - iznos od " + neplaceneRate[i].Iznos.ToString("N2") + " KM";
            }

            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("DATUMPLACANJA", datumPlacanja.ToString("dd.MM.yyyy"));
            dict.Add("IZNOS", uplacenoPoRati.ToString());
            dict.Add("UPLACENERATE", uplacenerate);
            dict.Add("NEPLACENERATE", neplacenerate);
            dict.Add("KUPAC", kupac);
            dict.Add("ADRESA", adresa);
            dict.Add("LK", lk);
            dict.Add("JMBG", jmbg);
            dict.Add("UPLACENO", inicijalnoplaceno.ToString("N2"));
            dict.Add("BROJRATA", brojrata.ToString());
            dict.Add("DATUM", datum.ToString("dd.MM.yyyy"));
            dict.Add("IZNOSRATE", (Math.Round((iznos - inicijalnoplaceno) / int.Parse(brojrata), 2, MidpointRounding.AwayFromZero)).ToString("N2"));
            dict.Add("UKUPANIZNOS", (iznos).ToString("N2"));
            dict.Add("PREDMET", napomena);
            dict.Add("BROJRATE", brojrate.ToString());
            dict.Add("BROJRACUNA", brojracuna);
            dict.Add("BROJUGOVORA", rednibroj);
            dict.Add("INICIJALNOPLACENO", inicijalnoplaceno.ToString("N2"));
            dict.Add("UKUPNOPLACENO", (inicijalnoplaceno + sumauplata.Value).ToString("N2"));
            dict.Add("PREOSTALO", (iznos - inicijalnoplaceno - sumauplata.Value).ToString("N2"));
            string fileName = dir + "\\" + rednibroj.Replace("/", "-") + ".docx";

            WordDocumentBuilder.FillBookmarksUsingOpenXml("PotvrdaPlacanjaRate.docx", fileName, dict);
            Process.Start(fileName);
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

                tabControl1.SelectedIndex = 0;
                Clear();
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
                tbKupacMaticniBroj.Text = frm.Selected.MaticniBroj;
                tbKupacBrojLk.Text = frm.Selected.BrojLK;
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
            tbIznosSaPDV.ReadOnly = tbStatus.Text != "E";
            tbBrojRata.ReadOnly = tbStatus.Text != "E";
            tbInicijalnoUplaceno.ReadOnly = tbStatus.Text != "E";
            tbKupacaTelefon.ReadOnly = tbStatus.Text != "E";
            tbAdresa.ReadOnly = tbStatus.Text != "E";
            tbKupacMaticniBroj.ReadOnly = tbStatus.Text != "E";
            tbKupacBrojLk.ReadOnly = tbStatus.Text != "E";
            dtpDatum.Enabled = tbStatus.Text == "E";
            //tbBrojRacuna.ReadOnly = tbStatus.Text != "E";
            cbMK.Enabled = tbStatus.Text == "E";
            tbUplaceno.ReadOnly = tbStatus.Text == "E";
            tbUgovorRataNapomena.ReadOnly = tbStatus.Text == "E";
            dtpDatumUplate.Enabled = tbStatus.Text != "E";
            btnPreuzmiIznos.Visible = tbStatus.Text != "E";
            btnKupacClear.Visible = tbStatus.Text == "E";
            btnPartneri.Visible = tbStatus.Text == "E";
            //gbRate.Visible = tbRedniBroj.Text != "AUTO";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dtpDatumUplate.Format = DateTimePickerFormat.Custom;
            dtpDatumUplate.CustomFormat = " ";
        }

        private void tbIznosSaPDV_TextChanged(object sender, EventArgs e)
        {
            if (cbMK.Checked == false && (tbRedniBroj.Text == "AUTO" || tbStatus.Text == "E"))
            {
                List<UgovorRata> rate = KreirajRateUgovora(null);
                BindUgovorRata(rate, true);
                decimal iznos, inicijalnoUplaceno;
                bool s1 = decimal.TryParse(tbIznosSaPDV.Text, out iznos);
                bool s2 = decimal.TryParse(tbInicijalnoUplaceno.Text, out inicijalnoUplaceno);
                if (s1 == true && s2 == true)
                    tbPreostaloZaUplatu.Text = (iznos - inicijalnoUplaceno).ToString("N2");
            }
        }

        private void tbBrojRata_TextChanged(object sender, EventArgs e)
        {
            if (cbMK.Checked == false && (tbRedniBroj.Text == "AUTO" || tbStatus.Text == "E"))
            {
                List<UgovorRata> rate = KreirajRateUgovora(null);
                BindUgovorRata(rate, true);
            }
        }

        private void dgvRate_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRate.SelectedRows.Count == 0)
                return;

            UgovorRata r = (UgovorRata)dgvRate.SelectedRows[0].DataBoundItem;
            tbIznosRate.Text = r.Iznos.ToString("N2");
            tbUplaceno.Text = r.Uplaceno.Value.ToString("N2");
            dtpRokPlacanja.Value = r.RokPlacanja;
            tbBrojRate.Text = r.BrojRate.ToString();

            if (r.DatumPlacanja == null)
            {
                dtpDatumUplate.Format = DateTimePickerFormat.Custom;
                dtpDatumUplate.CustomFormat = " ";

            }
            else
            {
                dtpDatumUplate.Format = DateTimePickerFormat.Short;
                dtpDatumUplate.Value = r.DatumPlacanja.Value;

            }

            if (r.RokPlacanja == null)
            {
                dtpRokPlacanja.Format = DateTimePickerFormat.Custom;
                dtpRokPlacanja.CustomFormat = " ";

            }
            else
            {
                dtpRokPlacanja.Format = DateTimePickerFormat.Short;
                dtpRokPlacanja.Value = r.RokPlacanja;

            }
        }

        private void btnZakljuciUgovor_Click(object sender, EventArgs e)
        {
            object o = dgvPrijave.SelectedRows[0].DataBoundItem;
            string rb = ((DataRowView)o).Row.ItemArray[0].ToString();
            if (MessageBox.Show(string.Format("Zaključiti ugovor {0} ?", rb), "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                PersistanceManager.UpdateUgovor(rb, "Z");
                MessageBox.Show(string.Format("Ugovor {0} je uspješno zaključen!", rb), "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                Stampa();
                ReadUgovor(textBox1.Text, textBox2.Text);
                tabControl1.SelectedIndex = 0;
                Clear();
                ReadUgovor("", "");
            }

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            tbUplaceno.Text = tbIznosRate.Text;
            dtpDatumUplate.Checked = true;
            dtpDatumUplate.Value = DateTime.Now;
        }

        private void dgvRate_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            string iznos = dgvRate.Rows[e.RowIndex].Cells[1].Value.ToString();
            string uplaceno = dgvRate.Rows[e.RowIndex].Cells[3].Value.ToString();
            if (iznos == uplaceno)
            {
                //dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.PaleGreen;
                //dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                dgvRate.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Green;
                dgvRate.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("Tahoma", 10, FontStyle.Italic);
            }
            else
            {

                dgvRate.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                dgvRate.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("Tahoma", 10, FontStyle.Regular);
            }
        }

        private void rbRealizovani_Click(object sender, EventArgs e)
        {
            DynamicFilters.Clear();
            DynamicFilters.Add("status='R'");
            ReadUgovor("", "");
        }

        private void rbNerealizovani_Click(object sender, EventArgs e)
        {
            DynamicFilters.Clear();
            DynamicFilters.Add("status='Z'");
            ReadUgovor("", "");
        }

        private void rbSviUgovori_Click(object sender, EventArgs e)
        {
            DynamicFilters.Clear();
            ReadUgovor("", "");
        }

        private void dgvPrijave_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPrijave.SelectedRows.Count == 0)
                return;
            object o = dgvPrijave.SelectedRows[0].DataBoundItem;
            string status = (string)(((DataRowView)o).Row.ItemArray[17]);
            decimal sumaUplata = (decimal)(((DataRowView)o).Row.ItemArray[15]);
            bool mk = (bool)(((DataRowView)o).Row.ItemArray[19]);

            if (status == "E")
            {
                btnZakljuciUgovor.Enabled = true;
                btnBrisanje.Enabled = true;
                btnRealizovan.Enabled = false;
                btnOtkljucaj.Enabled = false;
            }
            else if (status == "Z")
            {
                btnZakljuciUgovor.Enabled = false;
                btnBrisanje.Enabled = false;
                btnRealizovan.Enabled = true && mk == true;
                btnOtkljucaj.Enabled = true && sumaUplata == 0;
            }
            else
            {
                btnZakljuciUgovor.Enabled = false;
                btnBrisanje.Enabled = false;
                btnRealizovan.Enabled = false;
                btnOtkljucaj.Enabled = false;
            }
        }

        private void cbMK_CheckedChanged(object sender, EventArgs e)
        {
            gbRate.Visible = cbMK.Checked == false;
            dgvRate.Visible = cbMK.Checked == false;
            tbBrojRata.ReadOnly = cbMK.Checked == true;
            lblRate.Visible = cbMK.Checked == false;
            if (cbMK.Checked == true)
                tbBrojRata.Text = "1";

        }

        private void btnRealizovan_Click(object sender, EventArgs e)
        {
            object o = dgvPrijave.SelectedRows[0].DataBoundItem;
            string rb = ((DataRowView)o).Row.ItemArray[0].ToString();
            if (MessageBox.Show(string.Format("Proglasiti ugovor {0} realizovanim ?", rb), "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                // PersistanceManager.UpdateUgovor(rb, "Z");
                PersistanceManager.UpdateUgovor(rb, "R");
                MessageBox.Show(string.Format("Ugovor {0} je realizovan.", rb), "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                //Stampa();
                ReadUgovor(textBox1.Text, textBox2.Text);
                tabControl1.SelectedIndex = 0;
                Clear();
                ReadUgovor("", "");
            }
        }

        private void btnOtkljucaj_Click(object sender, EventArgs e)
        {
            object o = dgvPrijave.SelectedRows[0].DataBoundItem;
            string rb = ((DataRowView)o).Row.ItemArray[0].ToString();
            if (MessageBox.Show(string.Format("Otključati ugovor {0} ?", rb), "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                PersistanceManager.UpdateUgovor(rb, "E");
                MessageBox.Show(string.Format("Ugovor {0} je uspješno otključan!", rb), "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                //Stampa();
                ReadUgovor(textBox1.Text, textBox2.Text);
                tabControl1.SelectedIndex = 0;
                Clear();
                ReadUgovor("", "");
            }
        }

        private void tbInicijalnoUplaceno_TextChanged(object sender, EventArgs e)
        {
            if (cbMK.Checked == false && (tbRedniBroj.Text == "AUTO" || tbStatus.Text == "E"))
            {
                List<UgovorRata> rate = KreirajRateUgovora(null);
                BindUgovorRata(rate, true);
                tbSumaUplata.Text = tbInicijalnoUplaceno.Text;
                decimal iznos, inicijalnoUplaceno;
                bool s1 = decimal.TryParse(tbIznosSaPDV.Text, out iznos);
                bool s2 = decimal.TryParse(tbInicijalnoUplaceno.Text, out inicijalnoUplaceno);
                if (s1 == true && s2 == true)
                    tbPreostaloZaUplatu.Text = (iznos - inicijalnoUplaceno).ToString("N2");
            }
        }
    }
}
