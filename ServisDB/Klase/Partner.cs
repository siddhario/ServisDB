using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisDB.Klase
{
    public class Partner
    {
        public int Sifra { get; set; }
        public string Naziv { get; set; }
        public string Tip { get; set; }
        public string MaticniBroj { get; set; }
        public string Adresa { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public bool Kupac { get; set; }
        public bool Dobavljac { get; set; }


    }
}
