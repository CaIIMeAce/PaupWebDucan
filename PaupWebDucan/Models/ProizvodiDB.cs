using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace PaupWebDucan.Models
{
    public class ProizvodiDB
    {
        //Lista proizvoda
        private static List<Proizvod> lista = new List<Proizvod>();
        private static bool listaInicijalizirana = false;

        //Konstruktor se izvrsava kod instanciranja klase (Kad korisitm -- ProizvodiDB proizvodi=new ProizvodiDB(); --
        public ProizvodiDB()
        {
            if (listaInicijalizirana == false)
            {
                lista.Add(new Proizvod()
                {
                    SkladisniBroj = 10,
                    ImeProizvoda = "Stalak za jakne",
                    BojaProizvoda = "Crna",
                    Ostecen = 'N',
                    KontrolniBroj = "12345678911",
                    DatumProizvodnje = new DateTime(2022, 12, 03),
                    GodinaModela = GodinaModela.DvijeTisuceDevetnaesta,
                    Dostupnost = true,
                    DanaZaNabavu = 3
                });

                lista.Add(new Proizvod()
                {
                    SkladisniBroj = 2,
                    ImeProizvoda = "Šalica",
                    BojaProizvoda = "Plava",
                    Ostecen = 'N',
                    KontrolniBroj = "12345654321",
                    DatumProizvodnje = new DateTime(2021, 11, 04),
                    GodinaModela = GodinaModela.DvijeTisuceSedamnaesta,
                    Dostupnost = true,
                    DanaZaNabavu = 5
                });

                lista.Add(new Proizvod()
                {
                    SkladisniBroj = 3,
                    ImeProizvoda = "Svijecnjak",
                    BojaProizvoda = "Bijela",
                    Ostecen = 'D',
                    KontrolniBroj = "12345678765",
                    DatumProizvodnje = new DateTime(2020, 07, 21),
                    GodinaModela = GodinaModela.DvijeTisucePetnaesta,
                    Dostupnost = true,
                    DanaZaNabavu = 7
                });

                lista.Add(new Proizvod()
                {
                    SkladisniBroj = 4,
                    ImeProizvoda = "Termo boca",
                    BojaProizvoda = "Crvena",
                    Ostecen = 'D',
                    KontrolniBroj = "78956734521",
                    DatumProizvodnje = new DateTime(2023, 01, 01),
                    GodinaModela = GodinaModela.DvijeTisuceDvadesetDruga,
                    Dostupnost = false,
                    DanaZaNabavu = 1
                });
            }
        }
        //Metoda koja vraca listu proizvoda popunjenu u konstruktoru
        public List<Proizvod> VratiListu()
        {
            return lista;
        }

        public void AzurirajProizvod(Proizvod proizvod)
        {
            int proizvodIndex = lista.FindIndex(x => x.SkladisniBroj == proizvod.SkladisniBroj);
            lista[proizvodIndex] = proizvod;
        }
    }
}