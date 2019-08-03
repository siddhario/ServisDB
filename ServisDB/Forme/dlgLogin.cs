using ServisDB.Klase;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using TMS.Core.Helpers;

namespace Delos
{
    public partial class dlgLogin : Form
	{
		private string username;
		private string password;

		public dlgLogin()
		{
			this.InitializeComponent();
			//try
			//{
			//	//string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\tms\\config.ini";
   //             string path = Application.StartupPath + "\\config.ini";
			//	StreamReader streamReader = new StreamReader(path);
			//	string text = streamReader.ReadLine();
			//	this.username = text.Substring(0, text.IndexOf("|"));
			//	this.password = text.Substring(text.IndexOf("|") + 1);
			//}
			//catch (Exception)
			//{
			//	MessageBox.Show("Ne postoji konfiguracioni fajl!");
			//}
		}
		private void button1_Click(object sender, EventArgs e)
		{

            //if (this.username == null || this.password == null)
            //{
            //	MessageBox.Show("Ne postoji konfiguracioni fajl!");
            //	return;
            //}
            Korisnik k = PersistanceManager.ReadKorisnik(tbUserName.Text);
            if (k == null)
            {
                MessageBox.Show("Neispravno korisničko ime!");
                return;
            }
            string b = CryptoProvider.CalculateMD5Hash(this.tbPassword.Text);
			if (k.Lozinka.ToUpper() == b.ToUpper() && this.tbUserName.Text == k.KorisnickoIme)
			{
                PersistanceManager.SetKorisnik(k);

				base.DialogResult = DialogResult.OK;
				base.Close();
				return;
			}
			MessageBox.Show("Neispravno korisničko ime i lozinka!");
		}
		private void button2_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			base.Close();
		}
		
	}
}
