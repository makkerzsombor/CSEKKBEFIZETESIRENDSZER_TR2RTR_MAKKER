using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsekkAPI.helpers;
using CsekkAPI.models;
using Microsoft.AspNetCore.Mvc;

namespace CsekkAPI.controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
                    return BadRequest("Hibás tranzakció");

                befizetesek.Add(input);
                return Ok(befizetesek);
            }
            catch
            {
                return BadRequest("Hibás tranzakció");
            }
        }

        // GET kérés, ami visszaadja az összes befizetést
        [HttpGet]
        public IActionResult GetAllPayments()
        {
            // Visszaküldjük az összes befizetést
            return Ok(befizetesek);
        }
    }
}