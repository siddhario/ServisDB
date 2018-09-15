using Npgsql;
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

        public static void InsertPartner(string naziv, string tip, string maticni_broj, string adresa, string telefon, string email, bool kupac, bool dobavljac, out int? kupacSifra)
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
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@kupac", kupac);
                    cmd.Parameters.AddWithValue("@dobavljac", dobavljac);

                    cmd.CommandText = "select coalesce(max(sifra),0)+1 from partner";
                    kupacSifra = (int)cmd.ExecuteScalar();

                    // Insert some data
                    cmd.CommandText = @"INSERT INTO partner (sifra,naziv ,  tip,  maticni_broj ,  adresa,  telefon,  email,kupac,dobavljac) 
                    VALUES ((select coalesce(max(sifra),0)+1 from partner), @naziv ,  @tip,  @maticni_broj ,  @adresa,  @telefon,  @email, @kupac, @dobavljac)";
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void UpdatePartner(int sifra, string naziv, string tip, string maticni_broj, string adresa, string telefon, string email, bool kupac, bool dobavljac)
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

                    // Insert some data
                    cmd.CommandText = @"update partner set naziv=@naziv ,  tip=@tip,  maticni_broj=@maticni_broj, adresa= @adresa , 
telefon=@telefon, email= @email,kupac=@kupac,dobavljac=@dobavljac
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


        public static void UpdatePrijava(string broj, DateTime datum, string broj_garantnog_lista, int? kupac_sifra, string kupac_ime, string kupac_adresa, string kupac_telefon, string kupac_email, string model, string serijski_broj,
      string dodatna_oprema, string predmet, string napomena_servisera, string serviser, string serviser_primio, DateTime? zavrseno, int? dobavljac_sifra, string dobavljac, DateTime? datumVracanja, DateTime? poslatMejlDobavljacu, int? garantni_rok, string broj_racuna, bool dobavljacPromjenjen)
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

                    // Insert some data
                    cmd.CommandText = @"update prijava set datum=@datum, kupac_sifra=@kupac_sifra, kupac_ime=@kupac_ime, kupac_adresa=@kupac_adresa, kupac_telefon=@kupac_telefon, kupac_email=@kupac_email,
                                                            model=@model, serijski_broj=@serijski_broj, dodatna_oprema=@dodatna_oprema, predmet=@predmet, napomena_servisera=@napomena_servisera,
                                                            serviser=@serviser, serviser_primio=@serviser_primio, zavrseno=@zavrseno, dobavljac_sifra=@dobavljac_sifra, dobavljac=@dobavljac,
                                                            datum_vracanja=@datum_vracanja, poslat_mejl_dobavljacu=@poslat_mejl_dobavljacu, garantni_rok=@garantni_rok, broj_garantnog_lista=@broj_garantnog_lista,broj_racuna= @broj_racuna
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

        public static void InsertPrijava(DateTime datum, string broj_garantnog_lista, int? kupac_sifra, string kupac_ime, string kupac_adresa, string kupac_telefon, string kupac_email, string model, string serijski_broj,
      string dodatna_oprema, string predmet, string napomena_servisera, string serviser, string serviser_primio, DateTime? zavrseno, int? dobavljac_sifra, string dobavljac, DateTime? datumVracanja, DateTime? poslatMejlDobavljacu, int? garantni_rok, string broj_racuna)
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
                    // Insert some data
                    cmd.CommandText = @"INSERT INTO prijava (datum, kupac_sifra, kupac_ime, kupac_adresa, kupac_telefon, kupac_email,
                                                            model, serijski_broj, dodatna_oprema, predmet, napomena_servisera,
                                                            serviser, serviser_primio, zavrseno, dobavljac_sifra, dobavljac,
                                                            datum_vracanja, poslat_mejl_dobavljacu, garantni_rok, broj_garantnog_lista, broj_racuna,
                                                            broj,                                                           
                                                            broj_naloga
                                                            ) VALUES 
                                                            (@datum, @kupac_sifra, @kupac_ime, @kupac_adresa, @kupac_telefon, @kupac_email,
                                                            @model, @serijski_broj, @dodatna_oprema, @predmet, @napomena_servisera,
                                                            @serviser, @serviser_primio, @zavrseno, @dobavljac_sifra, @dobavljac,
                                                            @datum_vracanja, @poslat_mejl_dobavljacu, @garantni_rok, @broj_garantnog_lista, @broj_racuna
                                                            ,(select concat((coalesce(max(substring(broj,1,position('/' in broj)-1)::int),0)+1)::text,'/','" + datum.Year.ToString() + @"') from prijava where date_part('year', datum)=" + datum.Year.ToString() + @")
                                                            ," + (dobavljac_sifra.HasValue ? "null" : "(select concat((coalesce(max(substring(broj_naloga, 1, position('/' in broj_naloga) - 1)::int), 0) + 1)::text, '/', '" + datum.Year.ToString() + "') from prijava where date_part('year', datum) = " + datum.Year.ToString() + ")") +
                                                            ")";
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
    }
}
