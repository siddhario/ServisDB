using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisDB.Klase
{
    public class PersistanceManager
    {
        public static string GetConnectionString()
        {
            return _connectionString;
        }

        public static string GetConnectionStringByName(string name)
        {
            // Assume failure.
            string returnValue = null;

            // Look for the name in the connectionStrings section.
            ConnectionStringSettings settings =
                ConfigurationManager.ConnectionStrings[name];

            // If found, return the connection string.
            if (settings != null)
                returnValue = settings.ConnectionString;

            return returnValue;
        }


        public static void SetConnection(string connectionString)
        {
            _connectionString = connectionString;
            _connection = new NpgsqlConnection(connectionString);
            _connection.Open();
        }
        private static string _connectionString;
        private static NpgsqlConnection _connection;

        public static void InsertPartner(string naziv, string tip, string maticni_broj, string adresa, string telefon, string email, bool kupac, bool dobavljac, string broj_lk, out int? kupacSifra)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;

                    cmd.Parameters.AddWithValue("@naziv", naziv);
                    cmd.Parameters.AddWithValue("@tip", tip);
                    cmd.Parameters.AddWithValue("@maticni_broj", maticni_broj);
                    cmd.Parameters.AddWithValue("@adresa", adresa);
                    cmd.Parameters.AddWithValue("@telefon", telefon);
                    cmd.Parameters.AddWithValue("@email", email != null ? email : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@kupac", kupac);
                    cmd.Parameters.AddWithValue("@dobavljac", dobavljac);
                    cmd.Parameters.AddWithValue("@broj_lk", broj_lk);

                    cmd.CommandText = "select coalesce(max(sifra),0)+1 from partner";
                    kupacSifra = (int)cmd.ExecuteScalar();

                    // Insert some data
                    cmd.CommandText = @"INSERT INTO partner (sifra,naziv ,  tip,  maticni_broj ,  adresa,  telefon,  email,kupac,dobavljac,broj_lk) 
                    VALUES ((select coalesce(max(sifra),0)+1 from partner), @naziv ,  @tip,  @maticni_broj ,  @adresa,  @telefon,  @email, @kupac, @dobavljac,@broj_lk)";
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void UpdatePartner(int sifra, string naziv, string tip, string maticni_broj, string adresa, string telefon, string email, bool kupac, bool dobavljac, string broj_lk)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@sifra", sifra);
                    cmd.Parameters.AddWithValue("@naziv", naziv);
                    cmd.Parameters.AddWithValue("@tip", tip);
                    cmd.Parameters.AddWithValue("@maticni_broj", maticni_broj);
                    cmd.Parameters.AddWithValue("@adresa", adresa);
                    cmd.Parameters.AddWithValue("@telefon", telefon);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@kupac", kupac);
                    cmd.Parameters.AddWithValue("@dobavljac", dobavljac);
                    cmd.Parameters.AddWithValue("@broj_lk", broj_lk);
                    // Insert some data
                    cmd.CommandText = @"update partner set naziv=@naziv ,  tip=@tip,  maticni_broj=@maticni_broj, adresa= @adresa , 
telefon=@telefon, email= @email,kupac=@kupac,dobavljac=@dobavljac,broj_lk=@broj_lk
where sifra=@sifra";
                    cmd.ExecuteNonQuery();


                }
            }
        }
        public static void UpdatePartner(int sifra, string adresa, string telefon, string email)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@sifra", sifra);
                    cmd.Parameters.AddWithValue("@adresa", adresa);
                    cmd.Parameters.AddWithValue("@telefon", telefon);
                    cmd.Parameters.AddWithValue("@email", email);
                    // Insert some data
                    cmd.CommandText = @"update partner set adresa= @adresa , telefon=@telefon, email= @email where sifra=@sifra";
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void UpdatePartner(int sifra, string adresa, string telefon, string maticni_broj, string broj_lk)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@sifra", sifra);
                    cmd.Parameters.AddWithValue("@adresa", adresa);
                    cmd.Parameters.AddWithValue("@telefon", telefon);
                    cmd.Parameters.AddWithValue("@maticni_broj", maticni_broj);
                    cmd.Parameters.AddWithValue("@broj_lk", broj_lk);
                    // Insert some data
                    cmd.CommandText = @"update partner set adresa= @adresa , telefon=@telefon,maticni_broj=@maticni_broj,broj_lk=@broj_lk where sifra=@sifra";
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void DeletePartner(int sifra)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;

                    cmd.Parameters.AddWithValue("@sifra", sifra);
                    // Insert some data
                    cmd.CommandText = @"delete from partner where sifra=@sifra";
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void DeleteUgovor(string broj)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;

                    cmd.Parameters.AddWithValue("@broj", broj);
                    // Insert some data
                    cmd.CommandText = @"delete from ponuda where broj=@broj";
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdatePrijava(string broj, DateTime datum, string broj_garantnog_lista, int? kupac_sifra, string kupac_ime, string kupac_adresa, string kupac_telefon, string kupac_email, string model, string serijski_broj,
      string dodatna_oprema, string predmet, string napomena_servisera, string serviser, string serviser_primio, DateTime? zavrseno, int? dobavljac_sifra, string dobavljac, DateTime? datumVracanja, DateTime? poslatMejlDobavljacu, int? garantni_rok, string broj_racuna, bool instalacija_os, bool instalacija_office, bool instalacija_ostalo, string instalacija, bool dobavljacPromjenjen)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;

                    cmd.Parameters.AddWithValue("@broj", broj);
                    cmd.Parameters.AddWithValue("@datum", datum);
                    cmd.Parameters.AddWithValue("@kupac_sifra", kupac_sifra);
                    cmd.Parameters.AddWithValue("@kupac_ime", kupac_ime);
                    cmd.Parameters.AddWithValue("@kupac_adresa", kupac_adresa);
                    cmd.Parameters.AddWithValue("@kupac_telefon", kupac_telefon);
                    cmd.Parameters.AddWithValue("@kupac_email", kupac_email);
                    cmd.Parameters.AddWithValue("@model", model);
                    cmd.Parameters.AddWithValue("@serijski_broj", serijski_broj);
                    cmd.Parameters.AddWithValue("@dodatna_oprema", dodatna_oprema);
                    cmd.Parameters.AddWithValue("@predmet", predmet);
                    cmd.Parameters.AddWithValue("@napomena_servisera", napomena_servisera);
                    cmd.Parameters.AddWithValue("@serviser", serviser);
                    cmd.Parameters.AddWithValue("@serviser_primio", serviser_primio);
                    cmd.Parameters.AddWithValue("@zavrseno", zavrseno.HasValue ? (object)zavrseno.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@dobavljac_sifra", dobavljac_sifra.HasValue ? (object)dobavljac_sifra : DBNull.Value);
                    cmd.Parameters.AddWithValue("@dobavljac", dobavljac);
                    cmd.Parameters.AddWithValue("@datum_vracanja", datumVracanja.HasValue ? (object)datumVracanja.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@poslat_mejl_dobavljacu", poslatMejlDobavljacu.HasValue ? (object)poslatMejlDobavljacu.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@garantni_rok", garantni_rok.HasValue ? (object)garantni_rok : DBNull.Value);
                    cmd.Parameters.AddWithValue("@broj_garantnog_lista", broj_garantnog_lista);
                    cmd.Parameters.AddWithValue("@broj_racuna", broj_racuna);
                    cmd.Parameters.AddWithValue("@instalacija_os", instalacija_os);
                    cmd.Parameters.AddWithValue("@instalacija_office", instalacija_office);
                    cmd.Parameters.AddWithValue("@instalacija_ostalo", instalacija_ostalo);
                    cmd.Parameters.AddWithValue("@instalacija", instalacija);
                    // Insert some data
                    cmd.CommandText = @"update prijava set datum=@datum, kupac_sifra=@kupac_sifra, kupac_ime=@kupac_ime, kupac_adresa=@kupac_adresa, kupac_telefon=@kupac_telefon, kupac_email=@kupac_email,
                                                            model=@model, serijski_broj=@serijski_broj, dodatna_oprema=@dodatna_oprema, predmet=@predmet, napomena_servisera=@napomena_servisera,
                                                            serviser=@serviser, serviser_primio=@serviser_primio, zavrseno=@zavrseno, dobavljac_sifra=@dobavljac_sifra, dobavljac=@dobavljac,
                                                            datum_vracanja=@datum_vracanja, poslat_mejl_dobavljacu=@poslat_mejl_dobavljacu, garantni_rok=@garantni_rok, broj_garantnog_lista=@broj_garantnog_lista,broj_racuna= @broj_racuna,instalacija_os=@instalacija_os,instalacija_office=@instalacija_office,instalacija_ostalo=@instalacija_ostalo,instalacija=@instalacija
                                                            where broj=@broj";

                    cmd.ExecuteNonQuery();

                    if (dobavljacPromjenjen)
                    {
                        cmd.CommandText = "update prijava set broj_naloga = " + (dobavljac_sifra.HasValue ? ("null") : "(select concat((coalesce(max(substring(broj_naloga, 1, position('/' in broj_naloga) - 1)::int), 0) + 1)::text, '/', '" + datum.Year.ToString() + "') from prijava where date_part('year', datum) = " + datum.Year.ToString() + ")") + " where broj=@broj";
                        cmd.ExecuteNonQuery();
                    }


                }
            }
        }

        public static void InsertPonuda(DateTime datum, string radnik,
            int? partner_sifra, string partner_naziv, string partner_jib, string partner_adresa, string partner_telefon, string partner_email,
            string valuta_placanja, string rok_vazenja, string rok_isporuke, string paritet_kod, string paritet,
            string predmet, string napomena)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;

                    cmd.Parameters.AddWithValue("@datum", datum);
                    cmd.Parameters.AddWithValue("@radnik", radnik);
                    cmd.Parameters.AddWithValue("@partner_sifra", partner_sifra);
                    cmd.Parameters.AddWithValue("@partner_naziv", partner_naziv);
                    cmd.Parameters.AddWithValue("@partner_jib", partner_jib);
                    cmd.Parameters.AddWithValue("@partner_adresa", partner_adresa);
                    cmd.Parameters.AddWithValue("@partner_telefon", partner_telefon);
                    cmd.Parameters.AddWithValue("@partner_email", partner_email);
                    cmd.Parameters.AddWithValue("@valuta_placanja", valuta_placanja);
                    cmd.Parameters.AddWithValue("@rok_vazenja", rok_vazenja);
                    cmd.Parameters.AddWithValue("@rok_isporuke", rok_isporuke);
                    cmd.Parameters.AddWithValue("@paritet_kod", paritet_kod);
                    cmd.Parameters.AddWithValue("@paritet", paritet);
                    cmd.Parameters.AddWithValue("@predmet", predmet);
                    cmd.Parameters.AddWithValue("@napomena", napomena);
                    // Insert some data
                    cmd.CommandText = @"INSERT INTO ponuda (datum, radnik,
                  partner_sifra,partner_naziv, partner_jib, partner_adresa, partner_telefon, partner_email,
                  valuta_placanja, rok_vazenja, rok_isporuke, paritet_kod, paritet,
                   predmet,napomena,
                    broj) 
                VALUES (    
                @datum, @radnik,
                  @partner_sifra,@partner_naziv, @partner_jib, @partner_adresa, @partner_telefon, @partner_email,
                  @valuta_placanja, @rok_vazenja, @rok_isporuke, @paritet_kod, @paritet,
                   @predmet,@napomena
                ,(select concat((coalesce(max(substring(broj,1,position('/' in broj)-1)::int),0)+1)::text,'/','" + datum.Year.ToString() + @"') from ponuda where date_part('year', datum)=" + datum.Year.ToString() + @"))";

                    cmd.ExecuteNonQuery();


                }
            }
        }
        public static void DeletePonuda(string broj)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;

                    cmd.Parameters.AddWithValue("@broj", broj);
                    // Insert some data
                    cmd.CommandText = @"delete from ponuda where broj=@broj";
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public static List<PonudaStavka> ReadPonudaStavka(string  broj)
        {
            List<PonudaStavka> stavke = new List<PonudaStavka>();
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@broj", broj);
                    // Insert some data
                    cmd.CommandText = @"SELECT ponuda_broj,stavka_broj,artikal_naziv,kolicina,jedinica_mjere,cijena_bez_pdv,rabat_procenat,iznos_bez_pdv,iznos_bez_pdv_sa_rabatom
,cijena_nabavna,vrijednost_nabavna,marza_procenat,ruc,pdv_stopa,pdv,iznos_sa_pdv,rabat_iznos,cijena_bez_pdv_sa_rabatom
	FROM public.ponuda_stavka where ponuda_broj=@broj order by stavka_broj asc";
                    var dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        PonudaStavka r = new PonudaStavka();
                        r.PonudaBroj = dr.GetString(0);
                        r.StavkaBroj = dr.GetInt32(1);
                        r.ArtikalNaziv = dr.GetString(2);
                        r.Kolicina = dr.GetDecimal(3);
                        r.JedinicaMjere = dr.GetString(4);
                        r.CijenaBezPdv = dr.GetDecimal(5);
                        r.RabatProcenat = dr.GetDecimal(6);
                        r.IznosBezPdv = dr.GetDecimal(7);
                        r.IznosBezPdvSaRabatom = dr.GetDecimal(8);
                        r.CijenaNabavna = dr.GetDecimal(9);
                        r.VrijednostNabavna = dr.GetDecimal(10);
                        r.MarzaProcenat = dr.GetDecimal(11);
                        r.Ruc = dr.GetDecimal(12);
                        r.PdvStopa = dr.GetDecimal(13);
                        r.Pdv = dr.GetDecimal(14);
                        r.IznosSaPdv = dr.GetDecimal(15);
                        r.RabatIznos = dr.GetDecimal(16);
                        r.CijenaBezPdvSaRabatom = dr.GetDecimal(17);

                        stavke.Add(r);
                    }
                    dr.Close();
                }
            }
            return stavke;
        }

        public static void UpdatePonuda(string broj, string status)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@broj", broj);
                    cmd.Parameters.AddWithValue("@status", status);
                    // Insert some data
                    cmd.CommandText = @"update ponuda set status=@status
                    where broj=@broj";

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdatePonuda(string broj, DateTime datum, string radnik,
           int? partner_sifra, string partner_naziv, string partner_jib, string partner_adresa, string partner_telefon, string partner_email,
           string valuta_placanja, string rok_vazenja, string rok_isporuke, string paritet_kod, string paritet,
           string predmet, string napomena)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@broj", broj);
                    cmd.Parameters.AddWithValue("@datum", datum);
                    cmd.Parameters.AddWithValue("@radnik", radnik);
                    cmd.Parameters.AddWithValue("@partner_sifra", partner_sifra);
                    cmd.Parameters.AddWithValue("@partner_naziv", partner_naziv);
                    cmd.Parameters.AddWithValue("@partner_jib", partner_jib);
                    cmd.Parameters.AddWithValue("@partner_adresa", partner_adresa);
                    cmd.Parameters.AddWithValue("@partner_telefon", partner_telefon);
                    cmd.Parameters.AddWithValue("@partner_email", partner_email);
                    cmd.Parameters.AddWithValue("@valuta_placanja", valuta_placanja);
                    cmd.Parameters.AddWithValue("@rok_vazenja", rok_vazenja);
                    cmd.Parameters.AddWithValue("@rok_isporuke", rok_isporuke);
                    cmd.Parameters.AddWithValue("@paritet_kod", paritet_kod);
                    cmd.Parameters.AddWithValue("@paritet", paritet);
                    cmd.Parameters.AddWithValue("@predmet", predmet);
                    cmd.Parameters.AddWithValue("@napomena", napomena);
                    // Insert some data
                    cmd.CommandText = @"update ponuda set datum=@datum,radnik=@radnik,
                  partner_sifra=@partner_sifra,partner_naziv=@partner_naziv, partner_jib=@partner_jib, partner_adresa=@partner_adresa, partner_telefon=@partner_telefon, partner_email=@partner_email,
                  valuta_placanja=@valuta_placanja, rok_vazenja=@rok_vazenja, rok_isporuke=@rok_isporuke, paritet_kod=@paritet_kod, paritet=@paritet,
                   predmet=@predmet,napomena=@napomena
                    where broj=@broj";

                    cmd.ExecuteNonQuery();


                }
            }
        }

        public static void UpdatePonudaStavka(PonudaStavka stavka)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@ponuda_broj", stavka.PonudaBroj);
                    cmd.Parameters.AddWithValue("@stavka_broj", stavka.StavkaBroj);
                    cmd.Parameters.AddWithValue("@cijena_bez_pdv", stavka.CijenaBezPdv);
                    cmd.Parameters.AddWithValue("@cijena_bez_pdv_sa_rabatom", stavka.CijenaBezPdvSaRabatom);
                    cmd.Parameters.AddWithValue("@kolicina", stavka.Kolicina);
                    cmd.Parameters.AddWithValue("@rabat_procenat", stavka.RabatProcenat);
                    cmd.Parameters.AddWithValue("@rabat_iznos", stavka.RabatIznos);
                    cmd.Parameters.AddWithValue("@iznos_bez_pdv", stavka.IznosBezPdv);
                    cmd.Parameters.AddWithValue("@iznos_bez_pdv_sa_rabatom", stavka.IznosBezPdvSaRabatom);
                    cmd.Parameters.AddWithValue("@cijena_nabavna", stavka.CijenaNabavna);
                    cmd.Parameters.AddWithValue("@vrijednost_nabavna", stavka.VrijednostNabavna);
                    cmd.Parameters.AddWithValue("@marza_procenat", stavka.MarzaProcenat);
                    cmd.Parameters.AddWithValue("@ruc", stavka.Ruc);
                    cmd.Parameters.AddWithValue("@pdv_stopa", stavka.PdvStopa);
                    cmd.Parameters.AddWithValue("@pdv", stavka.Pdv);
                    cmd.Parameters.AddWithValue("@iznos_sa_pdv", stavka.IznosSaPdv);
                    // Insert some data
                    cmd.CommandText = @"update ponuda_stavka set cijena_bez_pdv=@cijena_bez_pdv, cijena_bez_pdv_sa_rabatom=@cijena_bez_pdv_sa_rabatom, kolicina=@kolicina, 
rabat_procenat=@rabat_procenat,iznos_bez_pdv=@iznos_bez_pdv,iznos_bez_pdv_sa_rabatom=@iznos_bez_pdv_sa_rabatom,
cijena_nabavna=@cijena_nabavna,vrijednost_nabavna=@vrijednost_nabavna,marza_procenat=@marza_procenat,ruc=@ruc
,pdv_stopa=@pdv_stopa,pdv=@pdv,iznos_sa_pdv=@iznos_sa_pdv,rabat_iznos=@rabat_iznos
                    where ponuda_broj=@ponuda_broj and stavka_broj=@stavka_broj";

                    cmd.ExecuteNonQuery();
                }
            }
        }


        public static void InsertPrijava(DateTime datum, string broj_garantnog_lista, int? kupac_sifra, string kupac_ime, string kupac_adresa, string kupac_telefon, string kupac_email, string model, string serijski_broj,
      string dodatna_oprema, string predmet, string napomena_servisera, string serviser, string serviser_primio, DateTime? zavrseno, int? dobavljac_sifra, string dobavljac, DateTime? datumVracanja, DateTime? poslatMejlDobavljacu, int? garantni_rok, string broj_racuna, bool instalacija_os, bool instalacija_office, bool instalacija_ostalo, string instalacija)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;

                    cmd.Parameters.AddWithValue("@datum", datum);
                    cmd.Parameters.AddWithValue("@kupac_sifra", kupac_sifra);
                    cmd.Parameters.AddWithValue("@kupac_ime", kupac_ime);
                    cmd.Parameters.AddWithValue("@kupac_adresa", kupac_adresa);
                    cmd.Parameters.AddWithValue("@kupac_telefon", kupac_telefon);
                    cmd.Parameters.AddWithValue("@kupac_email", kupac_email);
                    cmd.Parameters.AddWithValue("@model", model);
                    cmd.Parameters.AddWithValue("@serijski_broj", serijski_broj);
                    cmd.Parameters.AddWithValue("@dodatna_oprema", dodatna_oprema);
                    cmd.Parameters.AddWithValue("@predmet", predmet);
                    cmd.Parameters.AddWithValue("@napomena_servisera", napomena_servisera);
                    cmd.Parameters.AddWithValue("@serviser", serviser);
                    cmd.Parameters.AddWithValue("@serviser_primio", serviser_primio);
                    cmd.Parameters.AddWithValue("@zavrseno", zavrseno.HasValue ? (object)zavrseno.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@dobavljac_sifra", dobavljac_sifra.HasValue ? (object)dobavljac_sifra : DBNull.Value);
                    cmd.Parameters.AddWithValue("@dobavljac", dobavljac);
                    cmd.Parameters.AddWithValue("@datum_vracanja", datumVracanja.HasValue ? (object)datumVracanja.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@poslat_mejl_dobavljacu", poslatMejlDobavljacu.HasValue ? (object)poslatMejlDobavljacu.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@garantni_rok", garantni_rok.HasValue ? (object)garantni_rok : DBNull.Value);
                    cmd.Parameters.AddWithValue("@broj_garantnog_lista", broj_garantnog_lista);
                    cmd.Parameters.AddWithValue("@broj_racuna", broj_racuna);
                    cmd.Parameters.AddWithValue("@instalacija_os", instalacija_os);
                    cmd.Parameters.AddWithValue("@instalacija_office", instalacija_office);
                    cmd.Parameters.AddWithValue("@instalacija_ostalo", instalacija_ostalo);
                    cmd.Parameters.AddWithValue("@instalacija", instalacija);
                    // Insert some data
                    cmd.CommandText = @"INSERT INTO prijava (datum, kupac_sifra, kupac_ime, kupac_adresa, kupac_telefon, kupac_email,
                                                            model, serijski_broj, dodatna_oprema, predmet, napomena_servisera,
                                                            serviser, serviser_primio, zavrseno, dobavljac_sifra, dobavljac,
                                                            datum_vracanja, poslat_mejl_dobavljacu, garantni_rok, broj_garantnog_lista, broj_racuna,
                                                            instalacija_os,instalacija_office,instalacija_ostalo,instalacija,
                                                            broj,                                                           
                                                            broj_naloga
                                                            ) VALUES 
                                                            (@datum, @kupac_sifra, @kupac_ime, @kupac_adresa, @kupac_telefon, @kupac_email,
                                                            @model, @serijski_broj, @dodatna_oprema, @predmet, @napomena_servisera,
                                                            @serviser, @serviser_primio, @zavrseno, @dobavljac_sifra, @dobavljac,
                                                            @datum_vracanja, @poslat_mejl_dobavljacu, @garantni_rok, @broj_garantnog_lista, @broj_racuna
                                                            ,@instalacija_os,@instalacija_office,@instalacija_ostalo,@instalacija                                           
                                                            ,(select concat((coalesce(max(substring(broj,1,position('/' in broj)-1)::int),0)+1)::text,'/','" + datum.Year.ToString() + @"') from prijava where date_part('year', datum)=" + datum.Year.ToString() + @")
                                                            ," + (dobavljac_sifra.HasValue ? "null" : "(select concat((coalesce(max(substring(broj_naloga, 1, position('/' in broj_naloga) - 1)::int), 0) + 1)::text, '/', '" + datum.Year.ToString() + "') from prijava where date_part('year', datum) = " + datum.Year.ToString() + ")") +
                                                            ")";
                    cmd.ExecuteNonQuery();


                }
            }
        }

        public static void InsertUgovor(DateTime datum, int? kupac_sifra, string kupac_naziv, string kupac_adresa, string kupac_telefon, string kupac_broj_lk, string kupac_maticni_broj,
            decimal iznos_sa_pdv, decimal inicijalno_uplaceno, decimal suma_uplata, decimal preostalo_za_uplatu,
            string napomena, string radnik, string status, int broj_rata, string broj_racuna, bool mk, decimal uplaceno_po_ratama, out string broj_ugovora)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;

                    cmd.Parameters.AddWithValue("@datum", datum);
                    cmd.Parameters.AddWithValue("@kupac_sifra", kupac_sifra);
                    cmd.Parameters.AddWithValue("@kupac_naziv", kupac_naziv);
                    cmd.Parameters.AddWithValue("@kupac_adresa", kupac_adresa);
                    cmd.Parameters.AddWithValue("@kupac_telefon", kupac_telefon);
                    cmd.Parameters.AddWithValue("@kupac_broj_lk", kupac_broj_lk);
                    cmd.Parameters.AddWithValue("@kupac_broj_lk", kupac_broj_lk);
                    cmd.Parameters.AddWithValue("@kupac_maticni_broj", kupac_maticni_broj);
                    cmd.Parameters.AddWithValue("@iznos_sa_pdv", iznos_sa_pdv);
                    cmd.Parameters.AddWithValue("@iznos_bez_pdv", 0);
                    cmd.Parameters.AddWithValue("@pdv", 0);
                    cmd.Parameters.AddWithValue("@iznos_sa_pdv", iznos_sa_pdv);
                    cmd.Parameters.AddWithValue("@inicijalno_placeno", inicijalno_uplaceno);
                    cmd.Parameters.AddWithValue("@suma_uplata", suma_uplata);
                    cmd.Parameters.AddWithValue("@preostalo_za_uplatu", preostalo_za_uplatu);
                    cmd.Parameters.AddWithValue("@napomena", napomena);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@radnik", radnik);
                    cmd.Parameters.AddWithValue("@broj_rata", broj_rata);
                    cmd.Parameters.AddWithValue("@broj_racuna", broj_racuna);
                    cmd.Parameters.AddWithValue("@mk", mk);
                    cmd.Parameters.AddWithValue("@uplaceno_po_ratama", uplaceno_po_ratama);
                    cmd.CommandText = "select concat((coalesce(max(substring(broj, 1, position('/' in broj) - 1)::int), 0) + 1)::text, '/', '" + datum.Year.ToString() + @"') from ugovor where date_part('year', datum) = " + datum.Year.ToString();
                    broj_ugovora = (string)cmd.ExecuteScalar();
                    // Insert some data
                    cmd.CommandText = @"INSERT INTO ugovor (datum, kupac_sifra, kupac_maticni_broj, kupac_broj_lk, kupac_naziv, kupac_adresa, kupac_telefon, broj_racuna, radnik, inicijalno_placeno, iznos_bez_pdv, pdv, iznos_sa_pdv, broj_rata, suma_uplata, preostalo_za_uplatu, status, napomena,mk,uplaceno_po_ratama, broj)
                                                            VALUES 
                                                            (@datum, @kupac_sifra, @kupac_maticni_broj, @kupac_broj_lk, @kupac_naziv, @kupac_adresa, @kupac_telefon, @broj_racuna, @radnik, @inicijalno_placeno, @iznos_bez_pdv, @pdv, @iznos_sa_pdv, @broj_rata, @suma_uplata, @preostalo_za_uplatu, @status, @napomena,@mk,@uplaceno_po_ratama
                                                            ,(select concat((coalesce(max(substring(broj,1,position('/' in broj)-1)::int),0)+1)::text,'/','" + datum.Year.ToString() + @"') from ugovor where date_part('year', datum)=" + datum.Year.ToString() + @")"

                                                            + ")";
                    cmd.ExecuteNonQuery();


                }
            }
        }

        public static void UpdateUgovor(string broj, DateTime datum, int? kupac_sifra, string kupac_naziv, string kupac_adresa, string kupac_telefon, string kupac_broj_lk, string kupac_maticni_broj,
       decimal iznos_sa_pdv, decimal inicijalno_uplaceno, decimal suma_uplata, decimal preostalo_za_uplatu,
       string napomena, string radnik, string status, int broj_rata, string broj_racuna, bool mk)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;

                    cmd.Parameters.AddWithValue("@broj", broj);
                    cmd.Parameters.AddWithValue("@datum", datum);
                    cmd.Parameters.AddWithValue("@kupac_sifra", kupac_sifra);
                    cmd.Parameters.AddWithValue("@kupac_naziv", kupac_naziv);
                    cmd.Parameters.AddWithValue("@kupac_adresa", kupac_adresa);
                    cmd.Parameters.AddWithValue("@kupac_telefon", kupac_telefon);
                    cmd.Parameters.AddWithValue("@kupac_broj_lk", kupac_broj_lk);
                    cmd.Parameters.AddWithValue("@kupac_maticni_broj", kupac_maticni_broj);
                    cmd.Parameters.AddWithValue("@iznos_bez_pdv", 0);
                    cmd.Parameters.AddWithValue("@pdv", 0);
                    cmd.Parameters.AddWithValue("@iznos_sa_pdv", iznos_sa_pdv);
                    cmd.Parameters.AddWithValue("@inicijalno_placeno", (decimal)inicijalno_uplaceno);
                    cmd.Parameters.AddWithValue("@suma_uplata", suma_uplata);
                    cmd.Parameters.AddWithValue("@preostalo_za_uplatu", preostalo_za_uplatu);
                    cmd.Parameters.AddWithValue("@napomena", napomena);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@radnik", radnik);
                    cmd.Parameters.AddWithValue("@broj_rata", broj_rata);
                    cmd.Parameters.AddWithValue("@broj_racuna", broj_racuna);
                    cmd.Parameters.AddWithValue("@mk", mk);
                    // Insert some data
                    cmd.CommandText = @"update ugovor set datum=@datum, 
kupac_sifra=@kupac_sifra, 
kupac_maticni_broj=@kupac_maticni_broj, 
kupac_broj_lk=@kupac_broj_lk, 
kupac_naziv=@kupac_naziv, 
kupac_adresa=@kupac_adresa, 
kupac_telefon=@kupac_telefon,
broj_racuna=@broj_racuna, 
radnik=@radnik, 
inicijalno_placeno=@inicijalno_placeno, 
iznos_bez_pdv=@iznos_bez_pdv, 
pdv=@pdv, 
iznos_sa_pdv=@iznos_sa_pdv, 
broj_rata= @broj_rata, 
suma_uplata=@suma_uplata, 
preostalo_za_uplatu=@preostalo_za_uplatu, 
status= @status, 
napomena=@napomena,
mk= @mk
                                                            where broj=@broj";
                    cmd.ExecuteNonQuery();


                }
            }
        }

        public static void DeletePrijava(string rb)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;

                    cmd.Parameters.AddWithValue("@broj", rb);
                    // Insert some data
                    cmd.CommandText = @"delete from prijava where broj=@broj";
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void InsertUgovorRata(string broj_ugovora, int broj_rate, DateTime rok_placanja, DateTime? datum_placanja, decimal iznos, decimal? uplaceno, string napomena)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;

                    cmd.Parameters.AddWithValue("@broj_ugovora", broj_ugovora);
                    cmd.Parameters.AddWithValue("@broj_rate", broj_rate);
                    cmd.Parameters.AddWithValue("@rok_placanja", rok_placanja);
                    cmd.Parameters.AddWithValue("@datum_placanja", datum_placanja.HasValue ? datum_placanja : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@iznos", iznos);
                    cmd.Parameters.AddWithValue("@uplaceno", uplaceno);
                    cmd.Parameters.AddWithValue("@napomena", napomena != null ? napomena : (object)DBNull.Value);
                    // Insert some data
                    cmd.CommandText = @"INSERT INTO public.ugovor_rata(
	broj_ugovora, broj_rate, iznos, uplaceno, rok_placanja, datum_placanja, napomena)
values
(@broj_ugovora, @broj_rate, @iznos, @uplaceno, @rok_placanja, @datum_placanja, @napomena)";

                    cmd.ExecuteNonQuery();


                }
            }
        }

        public static void UpdateUgovorRata(string broj_ugovora, int broj_rate, DateTime rok_placanja, DateTime? datum_placanja, decimal iznos, decimal? uplaceno, string napomena)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;

                    cmd.Parameters.AddWithValue("@broj_ugovora", broj_ugovora);
                    cmd.Parameters.AddWithValue("@broj_rate", broj_rate);
                    cmd.Parameters.AddWithValue("@rok_placanja", rok_placanja);
                    cmd.Parameters.AddWithValue("@datum_placanja", datum_placanja);
                    cmd.Parameters.AddWithValue("@iznos", iznos);
                    cmd.Parameters.AddWithValue("@uplaceno", uplaceno);
                    cmd.Parameters.AddWithValue("@napomena", napomena);
                    // Insert some data
                    cmd.CommandText = @"update ugovor_rata set
	iznos=@iznos, uplaceno=@uplaceno, rok_placanja=@rok_placanja, datum_placanja=@datum_placanja, napomena=@napomena
where broj_ugovora=@broj_ugovora and broj_rate=@broj_rate";

                    cmd.ExecuteNonQuery();


                }
            }
        }
        public static void DeleteUgovorRata(string broj_ugovora, int? broj_rate = null)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;

                    cmd.Parameters.AddWithValue("@broj_ugovora", broj_ugovora);
                    cmd.Parameters.AddWithValue("@broj_rate", broj_rate.HasValue ? broj_rate : (object)DBNull.Value);
                    // Insert some data
                    cmd.CommandText = @"delete from ugovor_rata where broj_ugovora=@broj_ugovora and (broj_rate=@broj_rate or @broj_rate is null)";
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<UgovorRata> ReadUgovorRata(string broj_ugovora)
        {
            List<UgovorRata> rate = new List<UgovorRata>();
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@broj_ugovora", broj_ugovora);
                    // Insert some data
                    cmd.CommandText = @"SELECT broj_ugovora, broj_rate, iznos, uplaceno, rok_placanja, datum_placanja, napomena
	FROM public.ugovor_rata where broj_ugovora=@broj_ugovora order by broj_rate asc";
                    var dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        UgovorRata r = new UgovorRata();
                        r.BrojUgovora = dr.GetString(0);
                        r.BrojRate = dr.GetInt32(1);
                        r.Iznos = dr.GetDecimal(2);
                        r.Uplaceno = dr.GetDecimal(3);
                        r.RokPlacanja = dr.GetDateTime(4);
                        r.DatumPlacanja = dr[5] != DBNull.Value ? dr.GetDateTime(5) : (DateTime?)null;
                        r.Napomena = dr[6] != DBNull.Value ? dr.GetString(6) : (string)null;
                        rate.Add(r);
                    }
                    dr.Close();
                }
            }
            return rate;
        }

        public static void UpdateUgovor(string broj, string status)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;

                    cmd.Parameters.AddWithValue("@broj", broj);
                    cmd.Parameters.AddWithValue("@status", status);
                    // Insert some data
                    cmd.CommandText = @"update ugovor set status= @status,suma_uplata = case when  @status='R' then iznos_sa_pdv else suma_uplata end,preostalo_za_uplatu = case when  @status='R' then 0 else preostalo_za_uplatu end  where broj=@broj";
                    cmd.ExecuteNonQuery();
                }
            }
        }

        internal static void InsertPonudaStavka(PonudaStavka stavka)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;

                    cmd.Parameters.AddWithValue("@ponuda_broj", stavka.PonudaBroj);
                    cmd.Parameters.AddWithValue("@stavka_broj", stavka.StavkaBroj);
                    cmd.Parameters.AddWithValue("@artikal_naziv", stavka.ArtikalNaziv);
                    cmd.Parameters.AddWithValue("@jedinica_mjere", stavka.JedinicaMjere);
                    cmd.Parameters.AddWithValue("@cijena_bez_pdv", stavka.CijenaBezPdv);
                    cmd.Parameters.AddWithValue("@cijena_bez_pdv_sa_rabatom", stavka.CijenaBezPdvSaRabatom);
                    cmd.Parameters.AddWithValue("@kolicina", stavka.Kolicina);
                    cmd.Parameters.AddWithValue("@rabat_procenat", stavka.RabatProcenat);
                    cmd.Parameters.AddWithValue("@rabat_iznos", stavka.RabatIznos);
                    cmd.Parameters.AddWithValue("@iznos_bez_pdv", stavka.IznosBezPdv);
                    cmd.Parameters.AddWithValue("@iznos_bez_pdv_sa_rabatom", stavka.IznosBezPdvSaRabatom);
                    cmd.Parameters.AddWithValue("@cijena_nabavna", stavka.CijenaNabavna);
                    cmd.Parameters.AddWithValue("@vrijednost_nabavna", stavka.VrijednostNabavna);
                    cmd.Parameters.AddWithValue("@marza_procenat", stavka.MarzaProcenat);
                    cmd.Parameters.AddWithValue("@ruc", stavka.Ruc);
                    cmd.Parameters.AddWithValue("@pdv_stopa", stavka.PdvStopa);
                    cmd.Parameters.AddWithValue("@pdv", stavka.Pdv);
                    cmd.Parameters.AddWithValue("@iznos_sa_pdv", stavka.IznosSaPdv);
                    //cmd.Parameters.AddWithValue("@partner_telefon", partner_telefon);
                    //cmd.Parameters.AddWithValue("@partner_email", partner_email);
                    //cmd.Parameters.AddWithValue("@valuta_placanja", valuta_placanja);
                    //cmd.Parameters.AddWithValue("@rok_vazenja", rok_vazenja);
                    //cmd.Parameters.AddWithValue("@rok_isporuke", rok_isporuke);
                    //cmd.Parameters.AddWithValue("@paritet_kod", paritet_kod);
                    //cmd.Parameters.AddWithValue("@paritet", paritet);
                    //cmd.Parameters.AddWithValue("@predmet", predmet);
                    //cmd.Parameters.AddWithValue("@napomena", napomena);
                    // Insert some data
                    cmd.CommandText = @"INSERT INTO ponuda_stavka (ponuda_broj, stavka_broj,
                  artikal_naziv,jedinica_mjere, cijena_bez_pdv,cijena_bez_pdv_sa_rabatom, kolicina, rabat_procenat, iznos_bez_pdv,iznos_bez_pdv_sa_rabatom
,cijena_nabavna,vrijednost_nabavna,marza_procenat,ruc 
,pdv_stopa,pdv,iznos_sa_pdv,rabat_iznos)
                VALUES (    
             @ponuda_broj, @stavka_broj,
                  @artikal_naziv,@jedinica_mjere, @cijena_bez_pdv,@cijena_bez_pdv_sa_rabatom, @kolicina, @rabat_procenat, @iznos_bez_pdv,@iznos_bez_pdv_sa_rabatom,@cijena_nabavna,
@vrijednost_nabavna,@marza_procenat,@ruc 
,@pdv_stopa,@pdv,@iznos_sa_pdv,@rabat_iznos)";

                    cmd.ExecuteNonQuery();


                }
            }
        }

        internal static void DeletePonudaStavka(PonudaStavka stavka)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;

                    cmd.Parameters.AddWithValue("@ponuda_broj", stavka.PonudaBroj);
                    cmd.Parameters.AddWithValue("@stavka_broj", stavka.StavkaBroj);
                    // Insert some data
                    cmd.CommandText = @"delete from ponuda_stavka where ponuda_broj=@ponuda_broj and stavka_broj=@stavka_broj";
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
