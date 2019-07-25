using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisDB.Klase
{
    public class PonudaDokument
    {
        public string PonudaBroj { get; set; }
        public int DokumentBroj { get; set; }
        public byte[] Dokument { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
    }
}
