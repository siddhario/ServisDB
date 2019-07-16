using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisDB.Klase
{
    public class PonudaStavka
    {
        public string PonudaBroj { get; set; }
        public int StavkaBroj { get; set; }
        public string ArtikalNaziv { get; set; }
        public string JedinicaMjere { get; set; }
        public decimal Kolicina { get; set; }
        public decimal CijenaBezPdv { get; set; }
        public decimal CijenaBezPdvSaRabatom { get; set; }
        public decimal RabatProcenat { get; set; }
        public decimal IznosBezPdv { get; set; }
        public decimal CijenaNabavna { get; set; }
        public decimal MarzaProcenat { get; set; }
        public decimal Ruc { get; set; }
    }
}
