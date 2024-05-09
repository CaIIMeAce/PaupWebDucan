using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaupWebDucan.Models
{
    public class KontrolniBroj
    {
        public static bool JeValidanKontrolniBroj(string ulaz)
        {
            // Provjeriti je li unos prazan ili null
            if (string.IsNullOrEmpty(ulaz))
            {
                return false;
            }

            // Provjeriti je li duljina točno 11 znakova
            if (ulaz.Length != 11)
            {
                return false;
            }

            // Provjeriti je li svaki znak brojčani
            if (!long.TryParse(ulaz, out _))
            {
                return false;
            }

            // Ako su svi uvjeti ispunjeni, broj je valjan
            return true;
        }
    }
}
