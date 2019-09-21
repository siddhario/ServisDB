using Delos.Forme;
using ServisDB.Klase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServisDB.Forme
{
    public partial class FormGlavna : Form
    {
        public FormGlavna()
        {
            InitializeComponent();



        }


        private void btnServisnePrijave_Click(object sender, EventArgs e)
        {
            frmServisnaPrijava frm = new frmServisnaPrijava();
            frm.ShowDialog();
        }

        private void btnServisniNalozi_Click(object sender, EventArgs e)
        {
            //frmServisnaPrijava frm = new frmServisnaPrijava();
            //frm.DynamicFilters = new List<string>() { "dobavljac_sifra is null" };
            //frm.ShowDialog();

            dlgReports dlg = new dlgReports();
            dlg.ShowDialog();
        }

        private void btnUgovori_Click(object sender, EventArgs e)
        {
            FormUgovor frm = new FormUgovor();
            frm.ShowDialog();
        }

        private void btnPartneri_Click(object sender, EventArgs e)
        {
            FormPartner frm = new FormPartner();
            frm.ShowDialog();
        }

        private void pregledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmServisnaPrijava frm = new frmServisnaPrijava();
            frm.ShowDialog();
        }

        private void ugovoriOOdloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUgovor frm = new FormUgovor();
            frm.ShowDialog();
        }

        private void pregledDugovanjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dlgReports.PrepareReport("Pregled dugovanja u periodu");
        }

        private void pregledUplataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dlgReports.PrepareReport("Pregled uplata u periodu");
        }

        private void btnPonude_Click(object sender, EventArgs e)
        {
            FormPonuda frm = new FormPonuda();
            frm.ShowDialog();
        }

        private void FormGlavna_Load(object sender, EventArgs e)
        {
            lblKorisnik.Text = "Prijavljeni korisnik: " + PersistanceManager.GetKorisnik().Ime +" " +PersistanceManager.GetKorisnik().Prezime+(PersistanceManager.GetKorisnik().Admin==true?" (Sve privilegije)":"");
        }
    }
}
