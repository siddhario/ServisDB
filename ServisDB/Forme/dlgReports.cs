using Npgsql;
using ServisDB.Klase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using TMS.Core.Helpers;
using TMS.Forms;

namespace ServisDB.Forme
{
    public partial class dlgReports : Form
    {
        private List<string> _scripts;

        public int Year { get; set; }

        public string CompetitionId { get; set; }


        public dlgReports()
        {
            InitializeComponent();
        }

        private void dlgReports_Load(object sender, EventArgs e)
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(Helper.GetReportRoot());
                if (di.Exists == false)
                    return;
                FileInfo[] scripts = di.GetFiles();
                int i = 0;
                _scripts = new List<string>();
                foreach (var script in scripts)
                {
                    i++;
                    if (!script.Name.StartsWith("rpt"))
                        lbReports.Items.Add(i + ". " + script.Name.Replace(script.Extension, ""));
                    _scripts.Add(script.Name.Replace(script.Extension, ""));
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var selectedIndex = lbReports.SelectedIndex;
            string report = _scripts[selectedIndex];
            PrepareReport(report);
        }



        private void lbReports_DoubleClick(object sender, EventArgs e)
        {
            var selectedIndex = lbReports.SelectedIndex;
            string report = _scripts[selectedIndex];
            PrepareReport(report);
        }

        public static async void PrepareReport(string report)
        {
            //var selectedIndex = lbReports.SelectedIndex;
            //string report = _scripts[selectedIndex];
            string rpt = "";
            string title = "";
            //List<SQLiteParameter> parameters = new List<SQLiteParameter>();
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            List<string> sume = new List<string>();
            switch (report)
            {
                case "Pregled uplata u periodu":
                    {
                        rpt = "rptPregledUplata";

                        dlpPregledUplata dlg = new dlpPregledUplata();
                        dlg.DateFrom = DateTime.Now.Date.AddDays(-7);
                        dlg.DateTo = DateTime.Now.Date;
                        if (dlg.ShowDialog() == DialogResult.OK)
                        {
                            parameters.Add(new NpgsqlParameter() { ParameterName = "datefrom",NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Date, Value = dlg.DateFrom.Date });
                            parameters.Add(new NpgsqlParameter() { ParameterName = "dateto", NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Date, Value = dlg.DateTo.Date });
                        }
                        title = report + " " + dlg.DateFrom.ToString("dd.MM.yyyy") +"-"+ dlg.DateTo.ToString("dd.MM.yyyy");
                        sume.Add("uplaćeno");
                    }
                    break;

                case "Pregled dugovanja u periodu":
                    {
                        rpt = "rptPregledDugovanja";

                        dlgPregledDugovanja dlg = new dlgPregledDugovanja();
                        dlg.DateFrom = DateTime.Now;
                        dlg.DateTo = DateTime.Now.Date.AddMonths(1);
                        if (dlg.ShowDialog() == DialogResult.OK)
                        {
                            parameters.Add(new NpgsqlParameter() { ParameterName = "datefrom", NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Date, Value = dlg.DateFrom.Date });
                            parameters.Add(new NpgsqlParameter() { ParameterName = "dateto", NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Date, Value = dlg.DateTo.Date });
                        }
                        title = report + " " + dlg.DateFrom.ToString("dd.MM.yyyy") + "-" + dlg.DateTo.ToString("dd.MM.yyyy");
                        sume.Add("dug");
                    }
                    break;
            }

            var ds = await ReportManager.ExecuteProcedureReport(rpt, parameters);

            var reportFile = ReportBuilder.BuildReport(report,title, ds, sume);
            if (reportFile != null)
                Process.Start(reportFile);        
        }
    }
}
