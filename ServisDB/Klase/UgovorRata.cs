using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisDB.Klase
{
    public class UgovorRata
    {
        public string BrojUgovora { get; set; }
        public int BrojRate { get; set; }
        public DateTime RokPlacanja { get; set; }
        public DateTime? DatumPlacanja { get; set; }
        public decimal Iznos { get; set; }
        public decimal? Uplaceno { get; set; }
        public string Napomena { get; set; }
    }
}
