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
            string alakitott = "";
            bool under2000 = false;

            if (szam <= 0 || szam > 10000000)
            {
                throw new ArgumentException("A szám 1 és 10.000.000 között lehet csak!");
            }

            if (szam < 2000)
            {
                under2000 = true;
            }

            if (szam == 10000000)
            {
                alakitott += "tízmillió";
                szam = 0;
            }

            if (szam >= 1000000 && szam < 10000000) // nagyobb mint 1 milka, de kisebb mint 10 milka
            {
                int osztott = szam / 1000000;
                int maradek = szam % 1000000;
                if (maradek == 0) // Csak milliós
                {
                    if (osztott == 1)
                    {
                        alakitott += "egymillió";
                    }
                    else if (osztott == 2)
                    {
                        alakitott += "kétmillió";
                    }
                    else
                    {
                        alakitott += OsztottEgyesek(osztott);
                        alakitott += "millió";
                    }
                }
                else // Van maradék
                {
                    if (osztott == 1)
                    {
                        alakitott += "egymillió-";
                    }
                    else if (osztott == 2)
                    {
                        alakitott += "kétmillió-";
                    }
                    else
                    {
                        alakitott += OsztottEgyesek(osztott) + "millió-";
                    }
                }
                szam -= osztott * 1000000;
            }

            if (szam == 100000) // 100k
            {
                if ((szam - 100000) == 0)
                {
                    alakitott += "szazezer";
                    szam -= 100000;
                }
            }

            if (szam > 100000 && szam < 1000000) // Nagyobb, mint 100k, de kisebb mint 1 milka
            {
                int osztott = szam / 100000;
                int maradek = szam % 100000;
                if (maradek == 0) // Nincs utána semmi
                {
                    if (osztott == 2)
                    {
                        alakitott += "kétszáz";
                    }
                    else if (osztott == 1)
                    {
                        alakitott += "száz";
                    }
                    else
                    {
                        alakitott += OsztottEgyesek(osztott) + "száz";
                    }
                    alakitott += "ezer";
                }
                else // Van valami utána
                {
                    if (maradek > 999) // Nagyobb, mint ezer
                    {
                        if (osztott == 2)
                        {
                            alakitott += "kétszáz";
                        }
                        else if (osztott == 1)
                        {
                            alakitott += "száz";
                        }
                        else
                        {
                            alakitott += OsztottEgyesek(osztott) + "száz";
                        }
                    }
                    else // Kisebb mint ezer
                    {
                        if (osztott == 2)
                        {
                            alakitott += "kétszáz";
                        }
                        else if (osztott == 1)
                        {
                            alakitott += "száz";
                        }
                        else
                        {
                            alakitott += OsztottEgyesek(osztott) + "száz";
                        }
                        alakitott += "ezer-";
                    }
                }
                szam -= osztott * 100000;
            }

            if (szam >= 30000 && szam < 100000) // 30k - 100k
            {
                int osztott = szam / 10000;
                int maradek = szam % 10000;
                if (maradek == 0) // Ha nincs mögötte semmi
                {
                    alakitott += OsztottTizesek(osztott);
                    alakitott += "ezer";
                }
                else
                {
                    if (maradek > 999)
                    {
                        alakitott += OsztottTizesek(osztott);
                    }
                    else // Kisebb mint ezer
                    {
                        alakitott += OsztottTizesek(osztott);
                        alakitott += "ezer-";
                    }
                }
                szam -= osztott * 10000;
            }

            if (szam < 30000 && szam > 9999) // 10k - 30k
            {
                int osztott = szam / 10000;
                int maradek = szam % 10000;
                if (maradek == 0) // 10k, 20k
                {
                    if (osztott == 1)
                    {
                        alakitott += "tízezer";
                    }
                    else
                    {
                        alakitott += "húszezer";
                    }
                }
                else
                {
                    if (maradek > 999) // nagyob mint ezer
                    {
                        if (osztott == 1)
                        {
                            alakitott += "tizen";
                        }
                        else
                        {
                            alakitott += "huszon";
                        }
                    }
                    else
                    {
                        if (osztott == 1)
                        {
                            alakitott += "tízezer-";
                        }
                        else
                        {
                            alakitott += "húszezer-";
                        }
                    }

                }
                szam -= osztott * 10000;
            }

            if (szam > 999 && szam < 10000) // 1k - 10k
            {
                int osztott = szam / 1000;
                int maradek = szam % 1000;
                if (maradek == 0)
                {
                    if (osztott == 1 && alakitott == "")
                    {
                        alakitott += "ezer";
                    }
                    else if (osztott == 1)
                    {
                        alakitott += "egyezer";
                    }
                    else if (osztott == 2)
                    {
                        alakitott += "kétezer";
                    }
                    else
                    {
                        alakitott += OsztottEgyesek(osztott);
                        alakitott += "ezer";
                    }
                }
                else // Ha még van mögötte szám
                {
                    if (under2000 && osztott == 1 && alakitott == "") 
                    {
                        alakitott += "ezer";
                    }
                    else if (osztott == 1 && alakitott == "")
                    {
                        alakitott += "ezer-";
                    }
                    else if (osztott == 1)
                    {
                        alakitott += "egyezer-";
                    }
                    else if (osztott == 2)
                    {
                        alakitott += "kétezer-";
                    }
                    else
                    {
                        alakitott += OsztottEgyesek(osztott);
                        alakitott += "ezer-";
                    }
                }
                szam -= osztott * 1000;
            }

            if (szam > 99 && szam < 1000)
            {
                int osztott = szam / 100;
                if (osztott == 1)
                {
                    alakitott += "száz";
                }
                else if (osztott == 2)
                {
                    alakitott += "kétszáz";
                }
                else
                {
                    alakitott += OsztottEgyesek(osztott);
                    alakitott += "száz";
                }
                szam -= osztott * 100;
            }

            // Ez jönn

            if (szam > 29 && szam < 100) // 30-100
            {
                int osztott = szam / 10;
                alakitott += OsztottTizesek(osztott);
                szam -= osztott * 10;
            }

            if (szam == 20) // 20
            {
                alakitott += "húsz";
                szam -= 20;
            }

            if (szam > 20 && szam < 30) // 20-30
            {
                int osztott = szam / 10;
                alakitott += "huszon";
                szam -= osztott * 10;
            }

            if (szam == 10) // 10
            {
                alakitott += "tíz";
                szam -= 10;
            }

            if (szam > 10 && szam < 20) // 10-20 
            {
                int osztott = szam / 10;
                alakitott += "tizen";
                szam -= osztott * 10;
            }

            if (szam > 0)
            {
                int osztott = szam / 1;
                alakitott += OsztottEgyesek(osztott);
                szam -= osztott;
            }

            return alakitott;
        }
        private static string OsztottEgyesek(int szam)
        {
            switch (szam)
            {
                case 1: return "egy";
                case 2: return "kettő";
                case 3: return "három";
                case 4: return "négy";
                case 5: return "öt";
                case 6: return "hat";
                case 7: return "hét";
                case 8: return "nyolc";
                case 9: return "kilenc";
                default: return "";
            }
        }

        private static string OsztottTizesek(int szam)
        {
            switch (szam)
            {
                case 3: return "harminc";
                case 4: return "negyven";
                case 5: return "ötven";
                case 6: return "hatvan";
                case 7: return "hetven";
                case 8: return "nyolcvan";
                case 9: return "kilencven";
                default: return "";
            }
        }
        
    }
}