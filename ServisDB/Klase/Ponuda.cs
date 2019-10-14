using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisDB.Klase
{
    //broj, datum, status, napomena, predmet, radnik, 
    //partner_sifra, partner_jib, partner_adresa, partner_naziv, partner_telefon, partner_email, 
    //valuta_placanja, rok_vazenja, paritet_kod, paritet, rok_isporuke, 
    //iznos_bez_rabata, rabat, iznos_sa_rabatom, pdv, iznos_sa_pdv, nabavna_vrijednost, ruc
    public class Ponuda
    {
        public string Broj { get; set; }
        public string Status { get; set; }
        public string Napomena { get; set; }
        public string Predmet { get; set; }
        public string Radnik { get; set; }
        public DateTime Datum { get; set; }
        public int PartnerSifra { get; set; }
        public string PartnerJib { get; set; }
        public string PartnerAdresa { get; set; }
        public string PartnerNaziv { get; set; }
        public string PartnerTelefon { get; set; }
        public string PartnerEmail { get; set; }
        public string ValutaPlacanja { get; set; }
        public string RokVazenja { get; set; }
        public string ParitetKod { get; set; }
        public string Paritet { get; set; }
        public string RokIsporuke { get; set; }
        public decimal IznosBezRabata { get; set; }
        public decimal Rabat { get; set; }
        public decimal IznosSaRabatom { get; set; }
        public decimal Pdv { get; set; }
        public decimal IznosSaPdv { get; set; }
        public decimal? NabavnaVrijednost { get; set; }
        public decimal? Ruc { get; set; }

        public Korisnik RadnikIzradio { get; set; }
    }
}
