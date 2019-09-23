using Delos;
using ServisDB.Forme;
using ServisDB.Klase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServisDB
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

#if (DEBUG)
            var connectionString = PersistanceManager.GetConnectionStringByName("ServisDBLocal");
#else
        var connectionString = PersistanceManager.GetConnectionStringByName("ServisDB");      
#endif
            PersistanceManager.SetConnection(connectionString);


#if (DEBUG)
            Application.Run(new FormGlavna());
#else
            dlgLogin dlg = new dlgLogin();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new FormGlavna());
            }
#endif

        }
    }
}
