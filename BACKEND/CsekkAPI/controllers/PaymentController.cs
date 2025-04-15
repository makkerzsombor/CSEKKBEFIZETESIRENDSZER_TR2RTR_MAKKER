using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsekkAPI.helpers;
using CsekkAPI.models;
using Microsoft.AspNetCore.Mvc;

namespace CsekkAPI.controllers
{
    public class PaymentController: ControllerBase
    {
        private static List<PaymentModel> befizetesek = new();

        [HttpPost]
        public IActionResult Befizet(PaymentModel input)
        {
            try
            {
                // A szöveges összegek összehasonlítása
                bool szovegekEgyeznek = SzovegesSzamAtalakito.Egyezik(input.OsszegSzam, input.OsszegSzoveg);

                if (!szovegekEgyeznek)
                    return BadRequest("Hibás szöveges összeg.");

                befizetesek.Add(input);
                return Ok(befizetesek);
            }
            catch
            {
                return BadRequest("Hibás szöveges összeg.");
            }
        }
    }
}