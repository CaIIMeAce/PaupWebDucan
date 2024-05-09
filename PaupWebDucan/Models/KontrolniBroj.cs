using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaupWebDucan.Models
{
    public class KontrolniBroj
    {
        public static bool ProvjeriKontrolniBroj(string PKB) //PKB - Provjeri Kontrolni Broj
        {
            if (PKB.Length != 11) return false;

            long b;
            if (!long.TryParse(PKB, out b)) return false;

            int a = 10;
            for (int i = 0; i < 10; i++)
            {
                a = a + Convert.ToInt32(PKB.Substring(i, 1));
                a = a % 10;
                if (a == 0) a = 10;
                a *= 2;
                a = a % 11;
            }
            int konrolni = 11 - a;
            if (konrolni == 10) konrolni = 0;

            return konrolni == Convert.ToInt32(PKB.Substring(10, 1));
        }
    }
}