using APIExample2705.Data;
using APIExample2705.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIExample2705.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArabaController : ControllerBase
    {
        private readonly ApiExampleDbContext _context;

        public ArabaController(ApiExampleDbContext context)
        {
            _context = context;
        }

        [HttpGet("ArabaListesi")]
        public IActionResult ArabaListesi()
        {
            
            return Ok(_context.Arabalar.ToList());
        }

        [HttpPost("ArabaEkle")]
        public IActionResult ArabaEkle(Araba araba)
        {
            _context.Arabalar.Add(araba);
            _context.SaveChanges();
            return Created();
        }

        [HttpDelete("ArabaSil")]
        public IActionResult ArabaSil(int id)
        {
           var silinecekAraba= _context.Arabalar.Remove(_context.Arabalar.Find(id));
            if (silinecekAraba==null)
            {
                return BadRequest("silmek istediğiniz id ye sahip biri bulunamadı");
            }
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut("ArabaGuncelle")]
        public IActionResult ArabaGuncelle(int id,Araba araba)
        {

            var guncellenecekAraba = _context.Arabalar.Find(id);

            guncellenecekAraba.Renk=araba.Renk;
            guncellenecekAraba.Marka=araba.Marka;
            _context.Arabalar.Update(guncellenecekAraba);

            _context.SaveChanges();
            return Ok();
        }

        [HttpGet("IdYeGoreGetir")]
        public IActionResult IdYeGoreGetir(int id)
        {
            var arananAraba = _context.Arabalar.Find(id);
            if (arananAraba==null)
                return BadRequest("aradığınız araba bulunamadı");

            return Ok(arananAraba);
        }

    }
}
