using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TMS.Forms
{
  public partial class dlgPregledDugovanja : Form
  {
    public dlgPregledDugovanja()
    {
      InitializeComponent();
    }

    public DateTime DateFrom { get; set; }

    public DateTime DateTo { get; set; }

    private void btnOK_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.OK;
      DateFrom = dtpDateFrom.Value.Date;
      DateTo = dtpDateTo.Value.Date;
      Close();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
      Close();
    }

    private void dlgPrognoza_Load(object sender, EventArgs e)
    {
      dtpDateFrom.Value = DateFrom;
      dtpDateTo.Value = DateTo;
    }
  }
}
