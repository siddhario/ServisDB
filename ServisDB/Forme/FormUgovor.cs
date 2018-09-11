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
  public partial class FormUgovor : Form
  {

    public string conn_string = "Host=localhost;Username=postgres;Password=postgres;Database=servisdb";
    public FormUgovor()
    {
      InitializeComponent();
      ReadPrijava(textBox1.Text,textBox2.Text);
      dtpZavrseno.Format = DateTimePickerFormat.Custom;
      dtpZavrseno.CustomFormat = " ";
      dgvPrijave.Focus();
      dgvPrijave.Select();
      dgvPrijave.DefaultCellStyle = new DataGridViewCellStyle() { SelectionBackColor = Color.LightBlue, SelectionForeColor = Color.Red };

    }

    private void ReadPrijava(string brojPrijave,string kupac)
    {
      using (var conn = new NpgsqlConnection(conn_string))
      {
        conn.Open();
        using (var cmd = new NpgsqlCommand())
        {
          cmd.Connection = conn;
          dgvPrijave.DataSource = null;
          dgvPrijave.AutoGenerateColumns = false;

          dgvPrijave.Columns.Clear();
          dgvPrijave.Columns.Add(new DataGridViewTextBoxColumn() { Name = "R.broj", DataPropertyName = "redni_broj", Width = 80 });
          dgvPrijave.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Datum prijave", DataPropertyName = "datum", Width = 100, DefaultCellStyle = new DataGridViewCellStyle() { Format = "dd.MM.yyyy." } });
          dgvPrijave.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Kupac", DataPropertyName = "kupac_ime", Width = 180 });
          dgvPrijave.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Telefon", DataPropertyName = "kupac_telefon", Width = 130 });
          dgvPrijave.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Model", DataPropertyName = "model", Width = 150 });
          dgvPrijave.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Kvar", DataPropertyName = "opis_kvara", Width = 320 });
          dgvPrijave.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Završeno", DataPropertyName = "zavrseno", Width = 100, DefaultCellStyle = new DataGridViewCellStyle() { Format = "dd.MM.yyyy." } });
          // Retrieve all rows
          cmd.Parameters.Clear();
          Npgsql.NpgsqlParameter p1 = new NpgsqlParameter("@kupac_ime", DbType.String);
          cmd.Parameters.Add(p1);

          Npgsql.NpgsqlParameter p2 = new NpgsqlParameter("@redni_broj", DbType.String);
          cmd.Parameters.Add(p2);

          if (kupac == "")
            p1.Value = DBNull.Value;
          else
            p1.Value = kupac;

          if (brojPrijave == "")
            p2.Value = DBNull.Value;
          else
            p2.Value = brojPrijave;
          cmd.CommandText = @"SELECT broj, datum, broj_garantnog_lista, kupac_ime, kupac_telefon, 
       model, serijski_broj, dodatna_oprema, opis_kvara, napomena_servisera, 
       serviser, zavrseno, redni_broj FROM prijava where (redni_broj like concat(@redni_broj,'%') or @redni_broj is null) and (lower(kupac_ime) like concat(lower(@kupac_ime),'%') or @kupac_ime is null) order by broj desc";
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



    private void UpdatePrijava(string redni_broj, DateTime datum, string broj_garantnog_lista, string kupac_ime, string kupac_telefon, string model, string serijski_broj,
string dodatna_oprema, string opis_kvara, string napomena_servisera, string serviser, DateTime? zavrseno)
    {
      using (var conn = new NpgsqlConnection(conn_string))
      {
        conn.Open();
        using (var cmd = new NpgsqlCommand())
        {
          cmd.Connection = conn;

          cmd.Parameters.AddWithValue("@redni_broj", redni_broj);
          cmd.Parameters.AddWithValue("@datum", datum);
          cmd.Parameters.AddWithValue("@broj_garantnog_lista", broj_garantnog_lista);
          cmd.Parameters.AddWithValue("@kupac_ime", kupac_ime);
          cmd.Parameters.AddWithValue("@kupac_telefon", kupac_telefon);
          cmd.Parameters.AddWithValue("@model", model);
          cmd.Parameters.AddWithValue("@serijski_broj", serijski_broj);
          cmd.Parameters.AddWithValue("@dodatna_oprema", dodatna_oprema);
          cmd.Parameters.AddWithValue("@opis_kvara", opis_kvara);
          cmd.Parameters.AddWithValue("@napomena_servisera", napomena_servisera);
          cmd.Parameters.AddWithValue("@serviser", serviser);
          cmd.Parameters.AddWithValue("@zavrseno", zavrseno.HasValue ? (object)zavrseno.Value : DBNull.Value);

          // Insert some data
          cmd.CommandText = @"update prijava set datum=@datum ,  broj_garantnog_lista=@broj_garantnog_lista,  kupac_ime=@kupac_ime, kupac_telefon= @kupac_telefon , 
model=@model, serijski_broj= @serijski_broj, dodatna_oprema=@dodatna_oprema, opis_kvara= @opis_kvara,napomena_servisera=  @napomena_servisera,  serviser=@serviser,zavrseno= @zavrseno
where redni_broj=@redni_broj";
          cmd.ExecuteNonQuery();


        }
      }
    }

    private void InsertPrijava(DateTime datum, string broj_garantnog_lista, string kupac_ime, string kupac_telefon, string model, string serijski_broj,
  string dodatna_oprema, string opis_kvara, string napomena_servisera, string serviser, DateTime? zavrseno)
    {
      using (var conn = new NpgsqlConnection(conn_string))
      {
        conn.Open();
        using (var cmd = new NpgsqlCommand())
        {
          cmd.Connection = conn;

          cmd.Parameters.AddWithValue("@datum", datum);
          cmd.Parameters.AddWithValue("@broj_garantnog_lista", broj_garantnog_lista);
          cmd.Parameters.AddWithValue("@kupac_ime", kupac_ime);
          cmd.Parameters.AddWithValue("@kupac_telefon", kupac_telefon);
          cmd.Parameters.AddWithValue("@model", model);
          cmd.Parameters.AddWithValue("@serijski_broj", serijski_broj);
          cmd.Parameters.AddWithValue("@dodatna_oprema", dodatna_oprema);
          cmd.Parameters.AddWithValue("@opis_kvara", opis_kvara);
          cmd.Parameters.AddWithValue("@napomena_servisera", napomena_servisera);
          cmd.Parameters.AddWithValue("@serviser", serviser);
          cmd.Parameters.AddWithValue("@zavrseno", zavrseno.HasValue ? (object)zavrseno.Value : DBNull.Value);

          // Insert some data
          cmd.CommandText = @"INSERT INTO prijava (datum ,  broj_garantnog_lista,  kupac_ime,  kupac_telefon ,  model,  serijski_broj,
  dodatna_oprema,  opis_kvara,  napomena_servisera,  serviser,  zavrseno,redni_broj) VALUES (@datum ,  @broj_garantnog_lista,  @kupac_ime,  @kupac_telefon ,  @model,  
@serijski_broj, @dodatna_oprema,  @opis_kvara,  @napomena_servisera,  @serviser,  @zavrseno,(select concat((coalesce(max(broj),0)+1)::text,'/'," + DateTime.Now.Year.ToString() + ") from prijava where date_part('year',current_timestamp)=" + DateTime.Now.Year.ToString() + "))";
          cmd.ExecuteNonQuery();


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
      else
      {
        zavrseno = dtpZavrseno.Value;
      }
      if (tbRedniBroj.Text == "AUTO")
        InsertPrijava(dtpDatum.Value, tbBrojGarantnogLista.Text, tbKupac.Text, tbKupacaTelefon.Text, tbModel.Text, tbSerijskiBroj.Text, tbDodatnaOprema.Text, tbOpisKvara.Text, tbNapomenaServisera.Text, tbServiser.Text, zavrseno);
      else
        UpdatePrijava(tbRedniBroj.Text, dtpDatum.Value, tbBrojGarantnogLista.Text, tbKupac.Text, tbKupacaTelefon.Text, tbModel.Text, tbSerijskiBroj.Text, tbDodatnaOprema.Text, tbOpisKvara.Text, tbNapomenaServisera.Text, tbServiser.Text, zavrseno);
      ReadPrijava(textBox1.Text, textBox2.Text);
      tabControl1.SelectedIndex = 0;
      Clear();
    }

    private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
    {

    }

    private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
      if (dgvPrijave.SelectedRows.Count == 0)
        return;
      object o = dgvPrijave.SelectedRows[0].DataBoundItem;
      tabControl1.SelectedIndex = 1;
      tbRedniBroj.Text = ((DataRowView)o).Row.ItemArray[12].ToString();
      dtpDatum.Value = (DateTime)((DataRowView)o).Row.ItemArray[1];
      tbBrojGarantnogLista.Text = ((DataRowView)o).Row.ItemArray[2].ToString();
      tbKupac.Text = ((DataRowView)o).Row.ItemArray[3].ToString();
      tbKupacaTelefon.Text = ((DataRowView)o).Row.ItemArray[4].ToString();
      tbModel.Text = ((DataRowView)o).Row.ItemArray[5].ToString();
      tbSerijskiBroj.Text = ((DataRowView)o).Row.ItemArray[6].ToString();
      tbDodatnaOprema.Text = ((DataRowView)o).Row.ItemArray[7].ToString();
      tbOpisKvara.Text = ((DataRowView)o).Row.ItemArray[8].ToString();
      tbNapomenaServisera.Text = ((DataRowView)o).Row.ItemArray[9].ToString();
      tbServiser.Text = ((DataRowView)o).Row.ItemArray[10].ToString();
      if (((DataRowView)o).Row.ItemArray[11] == DBNull.Value)
      {
        dtpZavrseno.Format = DateTimePickerFormat.Custom;
        dtpZavrseno.CustomFormat = " ";

      }
      else
      {
        dtpZavrseno.Format = DateTimePickerFormat.Short;
        dtpZavrseno.Value = (DateTime)((DataRowView)o).Row.ItemArray[1];
      }

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
      tbModel.Text = "";
      tbSerijskiBroj.Text = "";
      tbDodatnaOprema.Text = "";
      tbOpisKvara.Text = "";
      tbNapomenaServisera.Text = "";
      tbServiser.Text = "";
      dtpZavrseno.Format = DateTimePickerFormat.Custom;
      dtpZavrseno.CustomFormat = " ";
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

    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {

    }

    private void tabPage2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
    {

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
      string i = dgvPrijave.Rows[e.RowIndex].Cells[6].Value.ToString();
      if (i != "")
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

      ReadPrijava(textBox1.Text, textBox2.Text);
    }

    //private void textBox1_TextChanged(object sender, EventArgs e)
    //{
    //  //ReadPrijava();
    //}

    private void btnBrisanje_Click(object sender, EventArgs e)
    {
      object o = dgvPrijave.SelectedRows[0].DataBoundItem;
      string rb = ((DataRowView)o).Row.ItemArray[12].ToString();
      if (MessageBox.Show(string.Format("Obrisati prijavu {0} ?", rb), "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
      {
        BrisiPrijavu(rb);
        MessageBox.Show(string.Format("Prijava {0} je uspješno obrisana!", rb), "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        ReadPrijava(textBox1.Text, textBox2.Text);
      }
    }

    private void BrisiPrijavu(string rb)
    {
      using (var conn = new NpgsqlConnection(conn_string))
      {
        conn.Open();
        using (var cmd = new NpgsqlCommand())
        {
          cmd.Connection = conn;

          cmd.Parameters.AddWithValue("@redni_broj", rb);
          // Insert some data
          cmd.CommandText = @"delete from prijava where redni_broj=@redni_broj";
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
  }
}
