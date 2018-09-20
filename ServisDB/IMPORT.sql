delete from ugovor_rata;
delete from ugovor;
delete from prijava;
delete from partner;
INSERT INTO public.partner(
           sifra, naziv, tip, maticni_broj, adresa, telefon, email, kupac, 
           dobavljac, broj_lk)
SELECT ROW_NUMBER () OVER (ORDER BY  kupac_ime, kupac_telefon),kupac_ime,'F',null,null,kupac_telefon,null,true,false,null
from (
   
      select distinct upper(trim(kupac_ime)) as kupac_ime, 
     lower(replace(replace(replace(kupac_telefon,' ',''),'-',''),'/','')) as kupac_telefon
      FROM public.prijava2 order by upper(trim(kupac_ime))
    

  ) as T;


  INSERT INTO public.prijava(
            broj, broj_naloga, datum, kupac_sifra, kupac_ime, kupac_adresa, 
            kupac_telefon, kupac_email, model, serijski_broj, dodatna_oprema, 
            predmet, napomena_servisera, serviser, serviser_primio, zavrseno, 
            dobavljac_sifra, dobavljac, datum_vracanja, poslat_mejl_dobavljacu, 
            garantni_rok, broj_garantnog_lista, broj_racuna,mk)
select 	    redni_broj, redni_broj, datum, null, kupac_ime, null, 
            kupac_telefon, null, model, serijski_broj, dodatna_oprema, 
            opis_kvara, napomena_servisera, serviser, null, zavrseno, 
            null, null, null, null, 
            null, broj_garantnog_lista, null,false
            from prijava2;


select broj,kupac_sifra,kupac_ime,kupac_telefon,par.naziv, par.telefon,par.sifra from prijava pri left join partner par
on upper(trim(pri.kupac_ime))=par.naziv and lower(replace(replace(replace(pri.kupac_telefon,' ',''),'-',''),'/',''))=par.telefon
order by sifra;
            

update prijava pri set kupac_sifra=par.sifra from partner par
where  upper(trim(pri.kupac_ime))=par.naziv and lower(replace(replace(replace(pri.kupac_telefon,' ',''),'-',''),'/',''))=par.telefon
;