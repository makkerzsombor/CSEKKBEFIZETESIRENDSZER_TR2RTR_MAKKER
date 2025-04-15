using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CsekkAPI.models
{
    public class PaymentModel
    {
        public string Nev { get; set; } = string.Empty;
        public int OsszegSzam { get; set; }
        public string OsszegSzoveg { get; set; } = string.Empty;
        public DateTime Datum { get; set; }
    }
}