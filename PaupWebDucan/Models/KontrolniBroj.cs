using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaupWebDucan.Models
{
    public class KontrolniBroj
    {
        public static bool ProvjeriKontrolniBroj(string PKB) // PKB - Provjeri Kontrolni Broj
        {
            if (string.IsNullOrEmpty(PKB)) return false; // Provjeri je li ulaz null ili prazan

            if (PKB.Length != 11) return false; // Provjera duljine

            if (!long.TryParse(PKB, out _)) return false; // Provjeri je li ulaz brojčani

            // Algoritam za provjeru validnosti kontrolnog broja
            int a = 10;
            for (int i = 0; i < 10; i++)
            {
                a = a + Convert.ToInt32(PKB.Substring(i, 1)); // Dohvatiti pojedinačni znak i konvertirati u int
                a = a % 10;
                if (a == 0) a = 10;
                a *= 2;
                a = a % 11;
            }

            int kontrolni = 11 - a;
            if (kontrolni == 10) kontrolni = 0; // Ako je kontrolni 10, postavi ga na 0

            int zadnjiBroj = Convert.ToInt32(PKB.Substring(10, 1)); // Dohvati zadnji broj

            return kontrolni == zadnjiBroj; // Usporedi kontrolni broj sa zadnjim znakom
        }
    }
}
