using APIExample2705.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace APIExample2705.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmanGiderController : ControllerBase
    {
        private static readonly string[] BlokAdi = new[]
        {
            "A", "B", "C", "D", "E"
        };


        [HttpGet("AylikGider")]
        public List<string> AylikGider()
        {
            Site site = new Site();
            List<string> list = new List<string>();
            for (int i = 0; i <= 4; i++)
            {
                    site.DaireAdi = BlokAdi[i];
                for (int j = 1; j <= 200; j++)
                {
                    site.DaireAdi = BlokAdi[i] + "-" + j+" = " + Random.Shared.Next(950, 2500);
                    list.Add(site.DaireAdi);

                }

            }
            return list.ToList();

        }
    }
}
