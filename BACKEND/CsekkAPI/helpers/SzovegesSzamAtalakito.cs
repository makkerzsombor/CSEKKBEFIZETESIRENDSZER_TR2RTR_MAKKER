using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CsekkAPI.helpers
{
    public static class SzovegesSzamAtalakito
    {
        public static bool Egyezik(int szam, string szoveg)
        {
            string alakitott = AlakitsdAtSzoveggé(szam);
            Console.WriteLine($"Szám: {szam}, Alakított szöveg: {alakitott}, Bemeneti szöveg: {szoveg}"); // Teszteléshez
            return alakitott == szoveg;
        }

        public static string AlakitsdAtSzoveggé(int szam)
        {
            return "";
        }
    }
}