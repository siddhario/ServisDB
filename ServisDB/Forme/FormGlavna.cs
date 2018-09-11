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
            FormServisnaPrijava frm = new FormServisnaPrijava();
            frm.ShowDialog();
        }

        private void btnServisniNalozi_Click(object sender, EventArgs e)
        {
            FormServisniNalog frm = new FormServisniNalog();
            frm.ShowDialog();
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
    }
}
