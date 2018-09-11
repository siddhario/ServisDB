using ClosedXML.Excel;
using Npgsql;
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
    public partial class FormPartner : Form
    {

        public string conn_string = "Host=localhost;Username=postgres;Password=postgres;Database=servisdb";
        public FormPartner()
        {
            InitializeComponent();
            ReadAll(textBox1.Text, textBox2.Text);
            dgvMain.Focus();
            dgvMain.Select();
            dgvMain.DefaultCellStyle = new DataGridViewCellStyle() { SelectionBackColor = Color.LightBlue, SelectionForeColor = Color.Red };

        }

        private void ReadAll(string sifra, string naziv)
        {
            using (var conn = new NpgsqlConnection(conn_string))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    dgvMain.DataSource = null;
                    dgvMain.AutoGenerateColumns = false;

                    dgvMain.Columns.Clear();
                    dgvMain.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Šifra", DataPropertyName = "sifra", Width = 80 });
                    dgvMain.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Naziv", DataPropertyName = "naziv", Width = 100, DefaultCellStyle = new DataGridViewCellStyle() { Format = "dd.MM.yyyy." } });
                    dgvMain.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Tip", DataPropertyName = "tip", Width = 80 });
                    dgvMain.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Matični broj", DataPropertyName = "maticni_broj", Width = 180 });
                    dgvMain.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Adresa", DataPropertyName = "adresa", Width = 150 });
                    dgvMain.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Telefon", DataPropertyName = "telefon", Width = 320 });
                    dgvMain.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Email", DataPropertyName = "email", Width = 100, DefaultCellStyle = new DataGridViewCellStyle() { Format = "dd.MM.yyyy." } });
                    dgvMain.Columns.Add(new DataGridViewCheckBoxColumn() { Name = "Kupac", DataPropertyName = "kupac", Width = 80 });
                    dgvMain.Columns.Add(new DataGridViewCheckBoxColumn() { Name = "Dobavljač", DataPropertyName = "dobavljac", Width = 80 });
                    // Retrieve all rows
                    cmd.Parameters.Clear();
                    Npgsql.NpgsqlParameter p1 = new NpgsqlParameter("@naziv", DbType.String);
                    cmd.Parameters.Add(p1);

                    Npgsql.NpgsqlParameter p2 = new NpgsqlParameter("@sifra", DbType.Int32);
                    cmd.Parameters.Add(p2);

                    if (naziv == "")
                        p1.Value = DBNull.Value;
                    else
                        p1.Value = naziv;

                    if (sifra == "")
                        p2.Value = DBNull.Value;
                    else
                        p2.Value = sifra;
                    cmd.CommandText = @"SELECT sifra, naziv, tip, maticni_broj, adresa, 
       telefon, email,kupac,dobavljac FROM partner where (sifra=@sifra or @sifra is null) and (lower(naziv) like concat(lower(@naziv),'%') or @naziv is null) order by sifra asc";
                    using (var reader = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        dgvMain.DataSource = dt;
                        dgvMain.Refresh();
                    }


                }
            }

        }



        private void Update(int sifra,string naziv, string tip, string maticni_broj, string adresa, string telefon, string email,bool kupac,bool dobavljac)
        {
            using (var conn = new NpgsqlConnection(conn_string))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@sifra", sifra);
                    cmd.Parameters.AddWithValue("@naziv", naziv);
                    cmd.Parameters.AddWithValue("@tip", tip);
                    cmd.Parameters.AddWithValue("@maticni_broj", maticni_broj);
                    cmd.Parameters.AddWithValue("@adresa", adresa);
                    cmd.Parameters.AddWithValue("@telefon", telefon);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@kupac", kupac);
                    cmd.Parameters.AddWithValue("@dobavljac", dobavljac);

                    // Insert some data
                    cmd.CommandText = @"update partner set naziv=@naziv ,  tip=@tip,  maticni_broj=@maticni_broj, adresa= @adresa , 
telefon=@telefon, email= @email,kupac=@kupac,dobavljac=@dobavljac
where sifra=@sifra";
                    cmd.ExecuteNonQuery();


                }
            }
        }

        private void Insert(string naziv, string tip, string maticni_broj, string adresa, string telefon, string email, bool kupac, bool dobavljac)
        {
            using (var conn = new NpgsqlConnection(conn_string))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;

                    cmd.Parameters.AddWithValue("@naziv", naziv);
                    cmd.Parameters.AddWithValue("@tip", tip);
                    cmd.Parameters.AddWithValue("@maticni_broj", maticni_broj);
                    cmd.Parameters.AddWithValue("@adresa", adresa);
                    cmd.Parameters.AddWithValue("@telefon", telefon);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@kupac", kupac);
                    cmd.Parameters.AddWithValue("@dobavljac", dobavljac);

                    // Insert some data
                    cmd.CommandText = @"INSERT INTO partner (naziv ,  tip,  maticni_broj ,  adresa,  telefon,  email,kupac,dobavljac) 
                    VALUES (@naziv ,  @tip,  @maticni_broj ,  @adresa,  @telefon,  @email, @kupac, @dobavljac)";
                    cmd.ExecuteNonQuery();


                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbSifra.Text == "AUTO")
                Insert(tbNaziv.Text, rbFizickoLice.Checked?"F":"P", tbMaticniBroj.Text, tbAdresa.Text, tbTelefon.Text, tbEmail.Text,cbKupac.Checked,cbDobavljac.Checked);
            else
                Update(int.Parse(tbSifra.Text), tbNaziv.Text, rbFizickoLice.Checked ? "F" : "P", tbMaticniBroj.Text, tbAdresa.Text, tbTelefon.Text, tbEmail.Text, cbKupac.Checked, cbDobavljac.Checked);
            ReadAll(textBox1.Text, textBox2.Text);
            tabControl1.SelectedIndex = 0;
            Clear();
        }


        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMain.SelectedRows.Count == 0)
                return;
            object o = dgvMain.SelectedRows[0].DataBoundItem;
            tabControl1.SelectedIndex = 1;
            tbSifra.Text = ((DataRowView)o).Row.ItemArray[0].ToString();

            tbNaziv.Text = ((DataRowView)o).Row.ItemArray[1].ToString();
            tbTelefon.Text = ((DataRowView)o).Row.ItemArray[5].ToString();
            tbMaticniBroj.Text = ((DataRowView)o).Row.ItemArray[3].ToString();
            rbFizickoLice.Checked = ((DataRowView)o).Row.ItemArray[2].ToString() == "F";
            rbPravnoLice.Checked = ((DataRowView)o).Row.ItemArray[2].ToString() == "P";
            tbAdresa.Text = ((DataRowView)o).Row.ItemArray[4].ToString();
            tbEmail.Text = ((DataRowView)o).Row.ItemArray[6].ToString();
            cbKupac.Checked = (bool)((DataRowView)o).Row.ItemArray[7];
            cbDobavljac.Checked = (bool)((DataRowView)o).Row.ItemArray[8];

        }



        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
            tbSifra.Text = "AUTO";
            Clear();

        }

        private void Clear()
        {

            tbNaziv.Text = "";
            tbTelefon.Text = "";
            tbMaticniBroj.Text = "";
            tbAdresa.Text = "";
            tbEmail.Text = "";
            cbDobavljac.Checked = false;
            cbKupac.Checked = false;

            tbNaziv.Focus();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
                tbNaziv.Focus();
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
                    dgvMain.Focus();
                    dgvMain.Select();
                }
            }

        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            //string i = dgvMain.Rows[e.RowIndex].Cells[6].Value.ToString();
            //if (i != "")
            //{
            //  //dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.PaleGreen;
            //  //dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            //  dgvMain.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Green;
            //  dgvMain.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("Tahoma", 10, FontStyle.Italic);
            //}
            //else
            //{

            //  dgvMain.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
            //  dgvMain.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("Tahoma", 10, FontStyle.Regular);
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
            //doc.Worksheets.Add("PRIJAVA");

            var sheet = doc.Worksheet(1);

            object o = dgvMain.SelectedRows[0].DataBoundItem;

            string rednibroj = ((DataRowView)o).Row.ItemArray[12].ToString();
            string datum = ((DateTime)((DataRowView)o).Row.ItemArray[1]).Date.ToString();
            string garantnilist = ((DataRowView)o).Row.ItemArray[2].ToString();
            string kupac = ((DataRowView)o).Row.ItemArray[3].ToString();
            string kupac_telefon = ((DataRowView)o).Row.ItemArray[4].ToString();
            string model = ((DataRowView)o).Row.ItemArray[5].ToString();
            string serijski_broj = ((DataRowView)o).Row.ItemArray[6].ToString();
            string dodatna_oprema = ((DataRowView)o).Row.ItemArray[7].ToString();
            string opis_kvara = ((DataRowView)o).Row.ItemArray[8].ToString();
            string napomena_servisera = ((DataRowView)o).Row.ItemArray[9].ToString();
            string serviser = ((DataRowView)o).Row.ItemArray[10].ToString();
            string zavrseno = "";
            if (((DataRowView)o).Row.ItemArray[11] == DBNull.Value)
            {
                zavrseno = "";
            }
            else
            {
                zavrseno = ((DateTime)((DataRowView)o).Row.ItemArray[1]).ToString();
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

            ReadAll(textBox1.Text, textBox2.Text);
        }

        //private void textBox1_TextChanged(object sender, EventArgs e)
        //{
        //  //ReadPrijava();
        //}

        private void btnBrisanje_Click(object sender, EventArgs e)
        {
            object o = dgvMain.SelectedRows[0].DataBoundItem;
            string rb = ((DataRowView)o).Row.ItemArray[0].ToString();
            if (MessageBox.Show(string.Format("Obrisati partnera {0} ?", rb), "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Brisi(int.Parse(rb));
                MessageBox.Show(string.Format("Partner {0} je uspješno obrisan!", rb), "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                ReadAll(textBox1.Text, textBox2.Text);
            }
        }

        private void Brisi(int sifra)
        {
            using (var conn = new NpgsqlConnection(conn_string))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;

                    cmd.Parameters.AddWithValue("@sifra", sifra);
                    // Insert some data
                    cmd.CommandText = @"delete from partner where sifra=@sifra";
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //dataGridView1.Focus();
            textBox1.Focus();
            textBox1.Select();

        }


        private void txtBarcode_KeyUp(object sender, KeyEventArgs e)
        {

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

                    ReadAll(textBox1.Text, "");
                    textBox1.Text = "";
                    dataGridView1_CellDoubleClick(this, null);
                    tbNaziv.Focus();
                    tbNaziv.Select();
                    //textBox1.Text = "";
                }

            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            ReadAll("", "");
        }


    }
}
